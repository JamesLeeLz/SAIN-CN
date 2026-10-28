using SAIN.Preset.Shared.BotSettings;
using SAIN.Preset.Shared.BotSettings.SAINSettings;
using SAIN.Preset.Shared.Enums;
using SAIN.Preset.Shared.GlobalSettings;
using SAIN.Preset.Shared.Models.WS;
using SAIN.Preset.Shared.Preset;
using SAIN.ServerInterop;
using SAINServerMod.Extensions;
using SAINServerMod.Models.Preset;
using SAINServerMod.Services;
using SAINServerMod.Utils;
using SAINServerMod.Ws;
using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Tables;
using SPTarkov.Server.Core.Utils.Cloners;

namespace SAINServerMod.Generators;

[Injectable(InjectionType.Singleton, TypePriority = OnLoadOrder.PostLoad + 5)]
public sealed class PresetGenerationService(
    BotTable botTable,
    PresetService presetService,
    SAINPresetWebSocketHandler webSocket,
    ICloner cloner,
    ISptLogger<PresetGenerationService> logger
) : IOnLoad, ISainBotTypeRegistry
{
    // Modded bot types registered through the interop
    private readonly List<BotTypeInfo> _registered = [];
    private static readonly ESainBotDifficulty[] _difficulties =
    [
        ESainBotDifficulty.easy,
        ESainBotDifficulty.normal,
        ESainBotDifficulty.hard,
        ESainBotDifficulty.impossible,
    ];

    private static readonly DefaultPreset[] _defaults =
    [
        new(SAINDifficulty.easy, "Baby Bots", "机器人反应迟缓，并且极不精准。"),
        new(SAINDifficulty.lesshard, "Less Difficult", "机器人反应较慢，精准度也低于平时。"),
        new(SAINDifficulty.hard, "Default", "机器人有难度但公平，这是 SAIN 设计时的游玩方式。"),
        new(SAINDifficulty.harderpmcs, "Default with Harder PMCs", "默认设置，但 PMC 比平常更难。"),
        new(SAINDifficulty.veryhard, "I Like Pain", "机器人反应更快、更精准，视野也更远。"),
        new(
            SAINDifficulty.deathwish,
            "Death Wish",
            "准备受死吧。机器人几乎没有散布，开火时武器后坐力更小，更精准，反应也极快。"
        ),
    ];

    public List<GeneratedPreset> Presets { get; set; } = [];

    public async Task OnLoadAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            GenerateDefaults();
            logger.Success($"[SAIN] Generated {Presets.Count} default presets");
        }
        catch (Exception ex)
        {
            logger.Error($"[SAIN] Failed to generate default presets on boot: {ex}");
            throw;
        }

        try
        {
            var imported = await presetService.ImportCustomDirectoriesAsync();
            if (imported.Count > 0)
            {
                logger.Info($"[SAIN] Imported {imported.Count} directory preset(s) as custom: {string.Join(", ", imported)}");
            }
        }
        catch (Exception ex)
        {
            logger.Error($"[SAIN] Failed to import directory presets: {ex.Message}");
        }

        try
        {
            await presetService.UpgradeCustomToCurrentSchemaAsync();
        }
        catch (Exception ex)
        {
            logger.Error($"[SAIN] Failed to bring custom presets up to date: {ex.Message}");
        }
    }

    public GeneratedPreset Generate(SAINDifficulty difficulty, string name, string description)
    {
        var global = new GlobalSettingsClass();
        var botSettings = GenerateBotSettings(AllBotTypes(), _difficulties);

        difficulty.ApplyTuning(global, botSettings);

        var personalities = PersonalityGenerator.BuildDefaults();
        var gearStealth = GearStealthGenerator.BuildDefaults();
        var info = SAINPresetDefinition.CreateDefaultDefinition(name, difficulty, description);
        return new GeneratedPreset(info, global, botSettings, personalities, gearStealth);
    }

    private Dictionary<ESainWildSpawnType, SAINSettingsGroupClass> GenerateBotSettings(
        IEnumerable<BotTypeInfo> botTypes,
        ESainBotDifficulty[] difficulties
    )
    {
        var result = new Dictionary<ESainWildSpawnType, SAINSettingsGroupClass>();

        foreach (BotTypeInfo botType in botTypes)
        {
            var group = new SAINSettingsGroupClass(difficulties)
            {
                Name = botType.Name,
                WildSpawnType = botType.WildSpawnType,
                DifficultyModifier = botType.DefaultDifficultyModifier,
            };

            foreach (KeyValuePair<ESainBotDifficulty, SAINSettingsClass> pair in group.Settings)
            {
                var defaults = GetDefaults(botType, pair.Key);

                if (defaults != null)
                {
                    SettingsCopier.CopyValues(defaults, pair.Value, SettingsCopier.ShouldCopyDefault);
                }
            }

            result[botType.WildSpawnType] = group;
        }

        return result;
    }

    private DifficultyCategories? GetDefaults(BotTypeInfo botType, ESainBotDifficulty difficulty)
    {
        string key = botType.BotDbKey ?? botType.WildSpawnType.ToString().ToLowerInvariant();

        if (!botTable.Types.TryGetValue(key, out var dbType) || dbType?.BotDifficulty is null)
        {
            return null;
        }

        return dbType.BotDifficulty.TryGetValue(difficulty.ToString().ToLowerInvariant(), out var categories)
            ? cloner.Clone(categories)
            : null;
    }

    public List<GeneratedPreset> GenerateDefaults()
    {
        var result = new List<GeneratedPreset>();

        foreach (var (difficulty, name, description) in _defaults)
        {
            result.Add(Generate(difficulty, name, description));
        }

        Presets = result;

        return result;
    }

    // SAIN's defaults plus anything registered through the interop.
    public List<BotTypeInfo> AllBotTypes()
    {
        var all = DefaultBotTypes.All();
        all.AddRange(_registered);
        return all;
    }

    public async Task RegisterAsync(SainBotTypeRegistration registration, CancellationToken cancellationToken = default)
    {
        var wildSpawnType = (ESainWildSpawnType)registration.WildSpawnType;

        if (AllBotTypes().Any(t => t.WildSpawnType == wildSpawnType))
        {
            logger.Error(
                $"[SAIN] Ignoring modded bot type '{registration.Name}': WildSpawnType {registration.WildSpawnType} is already known."
            );
            return;
        }

        _registered.Add(
            new BotTypeInfo(
                registration.Name,
                wildSpawnType,
                registration.DifficultyModifier,
                registration.Section,
                registration.Description
            )
            {
                BotDbKey = registration.BotDbKey ?? wildSpawnType.ToString().ToLowerInvariant(),
                BrainsToApply = registration.BrainsToApply,
                LayersToRemove = registration.LayersToRemove,
                BaseBrain = registration.BaseBrain,
            }
        );

        logger.Info($"[SAIN] Registered modded bot type '{registration.Name}' ({wildSpawnType}).");

        // Rebuild the in-memory defaults so the new type is present everywhere, then tell connected clients to re-pull.
        GenerateDefaults();
        await webSocket.BroadcastPresetChanged(string.Empty, EPresetSyncChange.ConfigChanged);
    }

    public SAINPresetBundle ComposeCustom(SAINPresetBundle stored)
    {
        var defaults = DefaultBotSettingsFor(stored.Info?.BaseSAINDifficulty ?? SAINDifficulty.hard);
        var merged = new Dictionary<ESainWildSpawnType, SAINSettingsGroupClass>();

        foreach (BotTypeInfo botType in AllBotTypes())
        {
            var type = botType.WildSpawnType;
            if (stored.BotSettings.TryGetValue(type, out var group))
            {
                merged[type] = group;
            }
            else if (defaults != null && defaults.TryGetValue(type, out var fallback))
            {
                merged[type] = fallback;
            }
        }

        stored.BotSettings = merged;
        return stored;
    }

    private Dictionary<ESainWildSpawnType, SAINSettingsGroupClass>? DefaultBotSettingsFor(SAINDifficulty difficulty)
    {
        foreach (var preset in Presets)
        {
            if (preset.Info.BaseSAINDifficulty == difficulty)
            {
                return preset.BotSettings;
            }
        }
        return Presets.FirstOrDefault()?.BotSettings;
    }
}
