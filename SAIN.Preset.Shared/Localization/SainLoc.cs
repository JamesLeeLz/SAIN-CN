using System;
using System.Collections.Generic;

namespace SAIN.Preset.Shared.Localization;

/// <summary>
/// English to Simplified Chinese lookup table for SAIN text.
/// The table is shared by the in game F6 editor and by the SAIN server mod web UI,
/// so both show the same translated names, descriptions and categories.
/// Text without an entry (for example a preset name typed in by a user) is returned unchanged.
/// </summary>
public static class SainLoc
{
    /// <summary>
    /// Returns the Chinese text for <paramref name="text"/>, or the original text when no translation exists.
    /// </summary>
    public static string T(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return Zh.TryGetValue(text, out string translated) ? translated : text;
    }

    /// <summary>
    /// Same as <see cref="T(string)"/> but runs the translated text through string.Format.
    /// </summary>
    public static string F(string text, params object[] args)
    {
        string translated = T(text);
        if (args == null || args.Length == 0)
        {
            return translated;
        }

        try
        {
            return string.Format(translated, args);
        }
        catch (FormatException)
        {
            return translated;
        }
    }

    public static bool IsChinese(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return false;
        }

        foreach (char c in text)
        {
            if (c >= '\u4e00' && c <= '\u9fff')
            {
                return true;
            }
        }

        return false;
    }

    private static readonly Dictionary<string, string> Zh = new(StringComparer.Ordinal)
    {

        {
            "General",
            "通用"
        },
        {
            "Show Advanced Bot Configs",
            "显示高级机器人配置"
        },
        {
            "Show Advanced Settings. Most of these should remain unchanged, unless you want to change something specific.",
            "显示高级设置。除非你想调整某些特定选项，否则大部分都应保持默认。"
        },
        {
            "Show Developer Options",
            "显示开发者选项"
        },
        {
            "You shouldn't change any of these unless you know exactly what it does based on exploring SAIN's codebase.",
            "除非你已通过阅读 SAIN 源码完全清楚其作用，否则不要改动这些选项。"
        },
        {
            "GUI Size Scaling",
            "GUI 尺寸缩放"
        },
        {
            "GUI Dimensions",
            "GUI 尺寸"
        },
        {
            "Config Entry Sliders",
            "配置项滑块"
        },
        {
            "Vision Distance Multiplier",
            "视觉距离倍率"
        },
        {
            "Higher is more difficult.",
            "数值越高，难度越大。"
        },
        {
            "Vision Speed Multiplier",
            "视觉速度倍率"
        },
        {
            "Higher Is More Difficult. A value of 2 means bots will spot enemies twice as fast.",
            "数值越高，难度越大。设为 2 时，机器人发现敌人的速度是原来的两倍。"
        },
        {
            "Scatter Multiplier",
            "散布倍率"
        },
        {
            "Lower is more difficult.",
            "数值越低，难度越大。"
        },
        {
            "Hearing Distance Multiplier",
            "听觉距离倍率"
        },
        {
            "Aggression Multiplier",
            "攻击性倍率"
        },
        {
            "Higher is more difficult. Affects how long bots wait before entering search and how long they stand their ground to return fire when spotting an enemy.",
            "数值越高，难度越大。影响机器人进入搜索状态前的等待时间，以及发现敌人时原地还击的坚持时间。"
        },
        {
            "Precision Speed Multiplier",
            "精度速度倍率"
        },
        {
            "Accuracy Speed Multiplier",
            "精准度速度倍率"
        },
        {
            "Lower is more difficult. Affects how long it takes for a bot to line up a shot when aiming.",
            "数值越低，难度越大。影响机器人瞄准时对准目标所需的时间。"
        },
        {
            "Difficulty Modifier",
            "难度修正"
        },
        {
            "How much to improve this bot type's recoil handling, fire-rate, and full auto burst length, reaction time, general stats that are used in SAIN.",
            "调节该类型机器人在后坐力控制、射速、全自动连射时长、反应时间以及 SAIN 所用通用属性上的提升幅度。"
        },
        {
            "Aim Target",
            "瞄准部位"
        },
        {
            "Override Global Part Weights",
            "覆盖全局部位权重"
        },
        {
            "Use this bot type's own aim target weights instead of the global ones.",
            "使用该机器人类型自己的瞄准部位权重，而非全局权重。"
        },
        {
            "Part Weights",
            "部位权重"
        },
        {
            "Only used when Override Global Part Weights is enabled.",
            "仅在启用“覆盖全局部位权重”时生效。"
        },
        {
            "Can Aim for Headshots",
            "可瞄准头部"
        },
        {
            "Can Aim for Headshots - Percentage Chance",
            "瞄准头部概率"
        },
        {
            "Time to Aim",
            "瞄准时间"
        },
        {
            "Distance Aim Time Multiplier",
            "距离瞄准时间倍率"
        },
        {
            "Multiplies the time a bot takes to aim based on distance. So higher values will cause bots to take longer to aim depending on distance.",
            "按距离乘算机器人的瞄准时间。数值越高，机器人瞄准所需时间随距离增加得越多。"
        },
        {
            "Angle Aim Time Multiplier",
            "角度瞄准时间倍率"
        },
        {
            "Multiplies the time a bot takes to aim based on the angle they have to turn to line up a shot. So higher values will cause bots to take longer to aim depending on the angle to turn.",
            "按需要转动的角度乘算机器人的瞄准时间。数值越高，机器人瞄准所需时间随转动角度增加得越多。"
        },
        {
            "Faster CQB Reactions",
            "近身战反应加速"
        },
        {
            "Sets whether this bot reacts and aims faster before being able to shoot at close ranges",
            "设置该机器人在近距离是否更快反应并瞄准后开枪"
        },
        {
            "Faster CQB Reactions Max Distance",
            "近身战反应加速最大距离"
        },
        {
            "Max distance a bot can react faster for Faster CQB Reactions. Scales with distance.",
            "近身战反应加速生效的最大距离，效果随距离变化。"
        },
        {
            "Example: If Max distance is set to 20 meters, and an enemy is 10 meters away. they will react 2x as fast as usual, ",
            "例如：最大距离设为 20 米，敌人位于 10 米处，机器人的反应速度将是平时的 2 倍，"
        },
        {
            "or if an enemy is 15 meters away, they will react 1.5x as fast as usual. ",
            "如果敌人位于 15 米处，反应速度则为平时的 1.5 倍。"
        },
        {
            "If the enemy is at 20 meters or further, nothing will happen.",
            "如果敌人在 20 米或更远，则不会有任何加速。"
        },
        {
            "Faster CQB Reactions Minimum Speed",
            "近身战反应加速最小速度"
        },
        {
            "Accuracy Spread Multiplier",
            "精准度散布倍率"
        },
        {
            "Higher = less accurate. Modifies a bot's base accuracy and spread. 1.5 = 1.5x higher accuracy spread",
            "数值越高，精准度越低。修正机器人的基础精准度与散布。1.5 表示精准度散布为原来的 1.5 倍"
        },
        {
            "Max Aiming Upgrade By Time",
            "随时间最大瞄准提升"
        },
        {
            "VANILLA EFT CONFIG VALUE : Lower = Better. How much to cap this bots aim improvement based on time. 0.25 means they will be able to multiply their aim offset by 0.25x when aiming. Making their shots more accurate",
            "原版 EFT 配置项：数值越低越好。限制该机器人随时间获得的瞄准提升幅度。0.25 表示瞄准偏移量可乘以 0.25，使其射击更精准"
        },
        {
            "Scatter Modifiers",
            "散布修正"
        },
        {
            "Distance To Not Scatter Aim",
            "不产生瞄准散布的距离"
        },
        {
            "VANILLA EFT CONFIG VALUE : If an enemy is closer than this distance, ignore scatter.",
            "原版 EFT 配置项：敌人近于此距离时，忽略散布。"
        },
        {
            "VANILLA EFT CONFIG VALUE : Scatter Multiplier - Moving",
            "原版 EFT 配置项：散布倍率 - 移动中"
        },
        {
            "VANILLA EFT CONFIG VALUE : Aim Time Multiplier - Moving",
            "原版 EFT 配置项：瞄准时间倍率 - 移动中"
        },
        {
            "Max Aim Time",
            "最大瞄准时间"
        },
        {
            "VANILLA EFT CONFIG VALUE :  A cap on how long it will take this bot to finish aiming at a target, and begin shooting.",
            "原版 EFT 配置项：该机器人完成瞄准并开始射击所需时间的上限。"
        },
        {
            "Friendly Fire Spherecast Size",
            "友军火力球体检测范围"
        },
        {
            "VANILLA EFT CONFIG VALUE : Hit Reaction Recovery Time",
            "原版 EFT 配置项：受击反应恢复时间"
        },
        {
            "How much time it takes to recover a bot's aim when they get hit by a bullet",
            "机器人被子弹击中后恢复瞄准所需的时间"
        },
        {
            "VANILLA EFT CONFIG VALUE : Hit Aim Time Penalty Seconds - Min",
            "原版 EFT 配置项：受击瞄准时间惩罚（秒）- 最小"
        },
        {
            "VANILLA EFT CONFIG VALUE : Hit Aim Time Penalty Seconds - Max",
            "原版 EFT 配置项：受击瞄准时间惩罚（秒）- 最大"
        },
        {
            "VANILLA EFT CONFIG VALUE : Enemy First Contact Reaction Delay",
            "原版 EFT 配置项：敌人首次接触反应延迟"
        },
        {
            "Vision",
            "视觉"
        },
        {
            "Field of View",
            "视野范围"
        },
        {
            "Base Vision Distance",
            "基础视觉距离"
        },
        {
            "Gain Sight Coeficient",
            "视觉感知系数"
        },
        {
            "Default EFT Config. Affects how quickly this bot will notice their enemies. Small changes to this have dramatic affects on bot vision speed.",
            "EFT 默认配置。影响该机器人发现敌人的速度。小幅改动就会对机器人的视觉速度产生显著影响。"
        },
        {
            "Aim and Shoot",
            "瞄准与射击"
        },
        {
            "Accuracy Speed",
            "精准度速度"
        },
        {
            "Default EFT Config. Affects how quickly this bot will aim at targets.",
            "EFT 默认配置。影响该机器人瞄准目标的速度。"
        },
        {
            "Default EFT Config. I do not know what this does exactly.",
            "EFT 默认配置。我也不确定它的具体作用。"
        },
        {
            "Hearing",
            "听觉"
        },
        {
            "Modifies the distance that this bot can hear sounds",
            "修正该机器人能听到声音的距离"
        },
        {
            "Can Use Grenades",
            "可使用手雷"
        },
        {
            "Can Throw at Visible Enemies",
            "可向可见敌人投掷"
        },
        {
            "Toggles bots throwing grenades directly at enemies they can see.",
            "开关机器人是否直接向看得见的敌人投掷手雷。"
        },
        {
            "Since Since Enemy Seen before Throw",
            "投掷前发现敌人多久"
        },
        {
            "How long it has been since a bot's enemy has been visible before a bot can consider throwing a grenade.",
            "敌人被看到持续多久后，机器人才会考虑投掷手雷。"
        },
        {
            "Time Before Next Throw - Min",
            "下次投掷间隔 - 最小"
        },
        {
            "How much time to wait before a bot is allowed to throw another grenade.",
            "机器人被允许再次投掷手雷前需等待的时间。"
        },
        {
            "Time Before Next Throw - Max",
            "下次投掷间隔 - 最大"
        },
        {
            "Minimum Friendly Distance to Throw Target",
            "投掷目标处友军最小距离"
        },
        {
            "How close a friendly bot can be in Meters to a bot's grenade target before it stops them from throwing it.",
            "友军机器人距投掷目标多少米以内时，该机器人会停止投掷（单位：米）。"
        },
        {
            "Minimum Enemy Distance to Bot",
            "敌人距机器人最小距离"
        },
        {
            "How close a enemy can be in Meters before a bot doesn't try throwing grenades.",
            "敌人距机器人多少米以内时，机器人不再尝试投掷手雷（单位：米）。"
        },
        {
            "Grenade Spread",
            "手雷散布"
        },
        {
            "How much distance, in meters, to randomize a bot's throw target position.",
            "机器人投掷目标位置的随机偏移距离（单位：米）。"
        },
        {
            "Flashbang Duration Multiplier",
            "闪光持续时间倍率"
        },
        {
            "Scales how long this bot type stays blinded, on top of the global multiplier. Lowering makes them recover more quickly.",
            "在全局倍率基础上，额外乘算该类型机器人被闪光的持续时间。降低可让它们更快恢复。"
        },
        {
            "Flashbang Disorientation",
            "闪光迷失程度"
        },
        {
            "How far off a blinded bot of this type aims and sprays. Lower it for leaving bots to get their bearings back faster.",
            "该类型机器人被闪光后瞄准与扫射的偏移程度。降低可让机器人更快恢复状态。"
        },
        {
            "Can Use Flashlights",
            "可使用手电筒"
        },
        {
            "Full 360 Vision Cheat Vision",
            "360 度全向视觉（作弊）"
        },
        {
            "Vision Speed Distance Clamp",
            "视觉速度距离上限"
        },
        {
            "Lower Bot Vision Speed by distance up to a maximum of this value",
            "随距离降低机器人的视觉速度，最大降幅不超过此值"
        },
        {
            "NightVision Visible Angle",
            "夜视可见角度"
        },
        {
            "The Maximum Angle of a bot's cone of vision with NightVision Enabled",
            "开启夜视时机器人视野锥的最大角度"
        },
        {
            "FlashLight Visible Angle",
            "手电可见角度"
        },
        {
            "The Maximum Angle of a bot's cone of vision with Flashlight Enabled",
            "开启手电时机器人视野锥的最大角度"
        },
        {
            "White Light Visible Distance",
            "白光可见距离"
        },
        {
            "How far a bot can see enemies with a White Light Enabled",
            "开启白光时机器人能发现敌人的距离"
        },
        {
            "IR Light Visible Distance",
            "红外光可见距离"
        },
        {
            "How far a bot can see enemies with an IR Light Enabled, if they are using NVGs",
            "机器人使用 NVG 时，开启红外光能发现敌人的距离"
        },
        {
            "Lose Vision Ability Time",
            "失去视觉后感知时长"
        },
        {
            "How Long after losing vision a bot will still be able to sense an enemy",
            "失去视野后，机器人仍能感知敌人的时长"
        },
        {
            "Lose Vision Ability Foliage Time",
            "失去视觉后植被感知时长"
        },
        {
            "Lose Shoot Ability Time",
            "失去视觉后射击时长"
        },
        {
            "How Long after losing vision a bot will still be able to shoot an enemy",
            "失去视野后，机器人仍能向敌人开火的时长"
        },
        {
            "Max Grass Vision",
            "草丛最大可视距离"
        },
        {
            "How far into grass a bot will be able to see, how far the depth must be to lose visibilty",
            "机器人能看进草丛的深度，超过此深度即失去视野"
        },
        {
            "Vision Distance No Foliage",
            "无视植被的视觉距离"
        },
        {
            "Bots will not see foliage at this distance or less, so if a target is below this number in distance, they will ignore foliage",
            "在此距离及以内机器人不会考虑植被遮挡，目标距离低于该数值时将忽略植被。"
        },
        {
            "Vision Distance No Grass",
            "无视草丛的视觉距离"
        },
        {
            "Bots will not see grass at this distance or less, so if a target is below this number in distance, they will ignore grass",
            "在此距离及以内机器人不会考虑草丛遮挡，目标距离低于该数值时将忽略草丛。"
        },
        {
            "Personality",
            "性格"
        },
        {
            "Global Aggression Multiplier",
            "全局攻击性倍率"
        },
        {
            "How quickly bots will move to search for enemies after losing sight, and how carefully they will search. Higher number equals higher aggression.",
            "机器人失去目标后前往搜索敌人的速度，以及搜索的仔细程度。数值越高攻击性越强。"
        },
        {
            "Weapon Control",
            "武器控制"
        },
        {
            "Weapon Proficiency",
            "武器熟练度"
        },
        {
            "How Well this bot can fire any weapon type, affects recoil, fire-rate, and burst length. Higher number equals harder bots.",
            "该机器人使用各类武器的水平，影响后坐力、射速和点射时长。数值越高机器人越强。"
        },
        {
            "Suppression Resistance",
            "压制抗性"
        },
        {
            "Higher = Less affected by suppression. A Value of 0 means No Resistance. ",
            "越高受压制影响越小。0 表示无抗性。"
        },
        {
            "A Value of 1 means Full Resistance. ",
            "1 表示完全抗性。"
        },
        {
            "The final resistance number is the mid-point between their personality and bot type resistance. ",
            "最终抗性取性格抗性与机器人类型抗性的中间值。"
        },
        {
            "So a value of 0.25 for personality and a value of 0.75 for bot type would result in 0.5",
            "例如性格为 0.25、机器人类型为 0.75，最终结果为 0.5"
        },
        {
            "Talk",
            "语音"
        },
        {
            "Talk Frequency",
            "语音频率"
        },
        {
            "How often to check if a bot wants to talk. Higher = More Delay between Talking.",
            "检查机器人是否有话要说的频率。越高两次语音间隔越长。"
        },
        {
            "Squad Talk Frequency. Higher = More Delay between Talking.",
            "小队语音频率。越高两次语音间隔越长。"
        },
        {
            "Squad Leader Talk Frequency. Higher = More Delay between Talking.",
            "小队长语音频率。越高两次语音间隔越长。"
        },
        {
            "Extract",
            "撤离"
        },
        {
            "Enable Extracts",
            "启用撤离"
        },
        {
            "Max Raid Percentage before Extract",
            "撤离前最大剩余局时百分比"
        },
        {
            "The longest possible time before this bot can decide to move to extract. Based on total raid timer and time remaining. 60 min total raid time with 6 minutes remaining would be 10 percent",
            "此机器人最早可能决定前往撤离的时间。基于总局时与剩余时间计算。总局时 60 分钟、剩余 6 分钟即为 10%。"
        },
        {
            "Min Raid Percentage before Extract",
            "撤离前最小剩余局时百分比"
        },
        {
            "Strafe Speed",
            "侧移速度"
        },
        {
            "How fast a bot will strafe when fighting an enemy at close range",
            "近距离与敌人交火时机器人的侧移速度"
        },
        {
            "Can Lean",
            "可侧身"
        },
        {
            "Can this bot lean while peeking and while outside of cover?",
            "该机器人在探头时和离开掩体时能否侧身？"
        },
        {
            "Movement Option Toggles",
            "移动选项开关"
        },
        {
            "Can Lean in Cover",
            "可在掩体内侧身"
        },
        {
            "Can this bot lean while in cover?",
            "该机器人在掩体内能否侧身？"
        },
        {
            "Can Jump",
            "可跳跃"
        },
        {
            "Can this bot Jump?",
            "该机器人能否跳跃？"
        },
        {
            "Can Auto Pose",
            "可自动调整姿态"
        },
        {
            "Does this bot automatically adjust their crouch height depending on objects between them and their enemy?",
            "该机器人是否会根据自身与敌人之间的物体自动调整下蹲高度？"
        },
        {
            "Can Go Prone",
            "可趴下"
        },
        {
            "Can this bot go Prone at all?",
            "该机器人能否趴下？"
        },
        {
            "Can Go Prone from Suppression",
            "受压后可趴下"
        },
        {
            "Can this bot go Prone as a panic response to being suppressed?",
            "该机器人被压制时是否会因惊慌而趴下？"
        },
        {
            "Can Vault",
            "可翻越"
        },
        {
            "Can this bot Vault?",
            "该机器人能否翻越？"
        },
        {
            "Can Vault to get Unstuck",
            "可翻越脱困"
        },
        {
            "Can this bot Vault if they are stuck on map geometry?",
            "该机器人卡在地图几何体上时能否翻越脱困？"
        },
        {
            "Arm Injury Scatter Multiplier",
            "手臂受伤散布倍率"
        },
        {
            "Increase scatter when a bots arms are injured.",
            "机器人手臂受伤时增加散布。"
        },
        {
            "Arm Injury Aim Speed Multiplier",
            "手臂受伤瞄准速度倍率"
        },
        {
            "Recoil",
            "后坐力"
        },
        {
            "Recoil Scatter Multiplier",
            "后坐力散布倍率"
        },
        {
            "Modifies how much recoil a bot gets from firing their weapon. ",
            "调整机器人开火时受到的后坐力大小。"
        },
        {
            "Higher = more recoil, more kick. 1.5 = 1.5x more recoil",
            "越高后坐力越大、枪口跳动越明显。1.5 表示后坐力为 1.5 倍"
        },
        {
            "Firerate",
            "射速"
        },
        {
            "Burst Length Multiplier",
            "点射时长倍率"
        },
        {
            "Modifies how long bots shoot a burst during full auto fire. ",
            "调整机器人在全自动射击时单次点射的持续时间。"
        },
        {
            "Higher = longer full auto time. 1.5 = 1.5x longer bursts",
            "越高全自动射击时间越长。1.5 表示点射时长为 1.5 倍"
        },
        {
            "Semiauto Firerate Multiplier",
            "半自动射速倍率"
        },
        {
            "Modifies the time a bot waits between semiauto fire. ",
            "调整机器人半自动射击之间的间隔时间。"
        },
        {
            "Higher = faster firerate. 1.5 = 1.5x more shots per second",
            "越高射速越快。1.5 表示每秒射击次数为 1.5 倍"
        },
        {
            "Aim",
            "瞄准"
        },
        {
            "Full Auto Scatter Multiplier",
            "全自动散布倍率"
        },
        {
            "Squad Talk",
            "小队语音"
        },
        {
            "Power Level Calculation",
            "实力等级计算"
        },
        {
            "Aim Target Selection",
            "瞄准目标选择"
        },
        {
            "Enemy Move Scatter Max Buff",
            "敌人移动散布最大增益"
        },
        {
            "The max buff to bot scatter, so if their enemy is standing still. Scales with velocity. A value of 1 is disabled",
            "机器人散布的最大增益，即敌人静止不动时的情况。随移动速度变化。1 表示禁用"
        },
        {
            "Enemy Move Scatter Max Debuff",
            "敌人移动散布最大减益"
        },
        {
            "The minimum debuff to bot scatter, so if their enemy is moving at full speed, but not sprinting. Scales with velocity. A value of 1 is disabled",
            "机器人散布的最大减益，即敌人全速移动但未冲刺时的情况。随移动速度变化。1 表示禁用"
        },
        {
            "Enemy Move Scatter Sprint Debuff",
            "敌人冲刺散布减益"
        },
        {
            "How much to divide bot scatter by if their enemy is sprinting. So the lower the number, the worse their aim will be. A value of 1 is disabled",
            "敌人冲刺时机器人散布的除数。数值越低，瞄准越差。1 表示禁用"
        },
        {
            "Pose Scatter Multiplier",
            "姿态散布倍率"
        },
        {
            "Lower is more scatter. If a bot is crouching, reduce their scatter up to X. 1.2 would result in 20% less scatter.",
            "数值越低散布越大。机器人下蹲时，其散布最多按 X 缩减。1.2 表示散布减少 20%。"
        },
        {
            "Prone Scatter Multiplier",
            "趴下散布倍率"
        },
        {
            "Lower is more scatter. If a bot is prone, reduce their scatter up to X. 1.3 would result in 30% less scatter.",
            "数值越低散布越大。机器人趴下时，其散布最多按 X 缩减。1.3 表示散布减少 30%。"
        },
        {
            "Body Part Visibility Scatter Multiplier",
            "身体部位可见散布倍率"
        },
        {
            "Lower is more scatter. If all body parts on an enemy are visible, reduce their scatter up to X. 1.25 would result in 25% less scatter.",
            "数值越低散布越大。敌人所有身体部位均可见时，其散布最多按 X 缩减。1.25 表示散布减少 25%。"
        },
        {
            "Magnified Optic - Ideal Range - Max Buff",
            "倍镜 - 理想距离 - 最大增益"
        },
        {
            "Lower is more scatter. If a target is further than or equal to Optic Ideal Distance, reduce their scatter by X. 1.2 = 20% less scatter",
            "数值越低散布越大。目标距离大于等于倍镜理想距离时，将其散布降低 X。1.2 表示散布减少 20%"
        },
        {
            "Magnified Optic - Ideal Range - Distance",
            "倍镜 - 理想距离 - 距离"
        },
        {
            "The distance, in meters, that is considered ideal for a magnified optic, if shooting at a target further than or equal to this, reduce scatter.",
            "倍镜的理想射击距离（米）。目标距离大于等于该值时降低散布。"
        },
        {
            "Magnified Optic - Too Close - Max Debuff",
            "倍镜 - 过近 - 最大减益"
        },
        {
            "Lower is more scatter. If a target is closer than or equal to Optic Too Close Distance, increase their scatter by X. 0.8 = 20% more scatter",
            "数值越低散布越大。目标距离小于或等于倍镜过近距离时，其散布增加 X。0.8 = 散布增加 20%"
        },
        {
            "Magnified Optic - Too Close - Distance",
            "倍镜 - 过近 - 距离"
        },
        {
            "The distance, in meters, that is considered too close for a magnified optic. ",
            "对倍镜而言被视为过近的距离（米）。"
        },
        {
            "If shooting at a target closer than or equal to this, increase scatter.",
            "射击距离小于或等于此值的目标时，增加散布。"
        },
        {
            "Red-dot / Holo - Out of Range - Max Debuff",
            "红点/全息 - 超出射程 - 最大减益"
        },
        {
            "Lower is more scatter. If a target is further than or equal to Red-dot / Holo - **Out of Range** - Distance, increase their scatter by X. 0.85 = 15% more scatter",
            "数值越低散布越大。目标距离大于或等于红点/全息 - **超出射程** - 距离时，其散布增加 X。0.85 = 散布增加 15%"
        },
        {
            "Red-dot / Holo - Out of Range - Distance",
            "红点/全息 - 超出射程 - 距离"
        },
        {
            "The distance, in meters, that is considered **Out of Range** for a Red-dot / Holo. ",
            "对红点/全息而言被视为**超出射程**的距离（米）。"
        },
        {
            "If shooting at a target further than or equal to this, increase scatter by **Red-dot / Holo - Out of Range - Max Debuff.**",
            "射击距离大于或等于此值的目标时，按**红点/全息 - 超出射程 - 最大减益**增加散布。"
        },
        {
            "Red-dot / Holo - Ideal Range - Max Buff",
            "红点/全息 - 理想射程 - 最大增益"
        },
        {
            "Lower is more scatter. If a target is further than or equal to Optic Ideal Distance, reduce their scatter by X. 1.15 = 15% less scatter",
            "数值越低散布越大。目标距离大于或等于光学瞄具理想距离时，其散布减少 X。1.15 = 散布减少 15%"
        },
        {
            "Red-dot / Holo - Ideal Range - Distance",
            "红点/全息 - 理想射程 - 距离"
        },
        {
            "The distance, in meters, that is considered **Ideal Range** for a Red-dot / Holo. ",
            "对红点/全息而言被视为**理想射程**的距离（米）。"
        },
        {
            "If shooting at a target closer than or equal to this, reduce scatter by **Red-dot / Holo - Ideal Range - Max Buff.**",
            "射击距离小于或等于此值的目标时，按**红点/全息 - 理想射程 - 最大增益**减少散布。"
        },
        {
            "Ironsights - Out of Range - Max Debuff",
            "机械瞄具 - 超出射程 - 最大减益"
        },
        {
            "Lower is more scatter. If a target is further than or equal to Optic Ideal Distance, reduce their scatter by X. 0.7 = 30% more scatter",
            "数值越低散布越大。目标距离大于或等于光学瞄具理想距离时，其散布减少 X。0.7 = 散布增加 30%"
        },
        {
            "Ironsights - Out of Range - Distance - Scale Start",
            "机械瞄具 - 超出射程 - 距离 - 缩放起点"
        },
        {
            "The distance, in meters, that is considered **Out of Range** for a ironsights. ",
            "对机械瞄具而言被视为**超出射程**的距离（米）。"
        },
        {
            "If shooting at a target further than or equal to this, start increasing scatter linearly up to **Ironsights - Out of Range - Distance - Scale End** by **Ironsights - Out of Range - Max Debuff.**",
            "射击距离大于或等于此值的目标时，散布开始线性增加，直至**机械瞄具 - 超出射程 - 距离 - 缩放终点**，增幅上限为**机械瞄具 - 超出射程 - 最大减益**。"
        },
        {
            "Ironsights - Out of Range - Distance - Scale End",
            "机械瞄具 - 超出射程 - 距离 - 缩放终点"
        },
        {
            "If shooting at a target further than or equal to this, increase scatter by **Ironsights - Out of Range - Max Debuff.**",
            "射击距离大于或等于此值的目标时，按**机械瞄具 - 超出射程 - 最大减益**增加散布。"
        },
        {
            "Global Minimum Aiming Time",
            "全局最短瞄准时间"
        },
        {
            "Time To Aim",
            "瞄准时间"
        },
        {
            "Global Faster CQB Reactions",
            "全局更快近身战反应"
        },
        {
            "if this toggle is disabled, all bots will have Faster CQB Reactions turned OFF, so their individual settings will be ignored.",
            "关闭此开关后，所有机器人的“更快近身战反应”都会被关闭，各自的单独设置将被忽略。"
        },
        {
            "Aim Down Sight Aim Time Multiplier",
            "开镜瞄准时间倍率"
        },
        {
            "If a bot is aiming down sights, their time to aim will be multiplied by this number",
            "机器人开镜瞄准时，其瞄准时间将乘以该数值"
        },
        {
            "Dynamic Aim Target Selection",
            "动态瞄准部位选择"
        },
        {
            "Bots pick which body part to shoot by weight from the parts they can actually hit. ",
            "机器人根据权重，从实际可命中的部位中选择要射击的身体部位。"
        },
        {
            "For the old always-center-mass behaviour, set the head, arm and leg weights to 0. ",
            "若想沿用旧的“始终瞄准中心”行为，请将头部、手臂和腿部权重设为 0。"
        },
        {
            "Disable to fall back to vanilla behaviour",
            "禁用后回退到原版行为"
        },
        {
            "Aim Point Spread",
            "瞄准点散布"
        },
        {
            "How much of the chosen body part a bot will spread its aim across, where 1 uses the whole part and 0 always aims at the same point on it.",
            "机器人在所选部位上的瞄准散布范围：1 表示覆盖整个部位，0 表示始终瞄准部位上的同一点。"
        },
        {
            "Re-pick Time - Min",
            "重选间隔 - 最短"
        },
        {
            "Minimum seconds a bot sticks with a chosen body part before rolling again.",
            "机器人保持同一瞄准部位、直到重新随机的最短秒数。"
        },
        {
            "Re-pick Time - Max",
            "重选间隔 - 最长"
        },
        {
            "Limb Falloff - Start Distance",
            "肢体衰减 - 起始距离"
        },
        {
            "Distance at which bots start favouring the torso over the head and limbs.",
            "超过该距离后，机器人开始偏好躯干而非头部和肢体。"
        },
        {
            "Limb Falloff - End Distance",
            "肢体衰减 - 结束距离"
        },
        {
            "Past this distance limb weights reach zero and bots only shoot at the torso.",
            "超过该距离后肢体权重降为零，机器人只射击躯干。"
        },
        {
            "Close Range Torso Distance",
            "近距离躯干距离"
        },
        {
            "Below this distance bots always aim at the torso.",
            "低于该距离时，机器人始终瞄准躯干。"
        },
        {
            "Head",
            "头部"
        },
        {
            "Only used if Can Aim for Headshots is enabled for the bot.",
            "仅当该机器人启用“可瞄准头部射击”时生效。"
        },
        {
            "Chest",
            "胸部"
        },
        {
            "Stomach",
            "腹部"
        },
        {
            "Arms",
            "手臂"
        },
        {
            "Legs",
            "腿部"
        },
        {
            "Door Open Sound Range",
            "开门声音范围"
        },
        {
            "The Maximum range a bot can hear a door opening",
            "机器人能听到开门声的最大范围"
        },
        {
            "Hearing Distance",
            "听觉距离"
        },
        {
            "Door Kick Sound Range",
            "踹门声音范围"
        },
        {
            "The Maximum range a bot can hear a door being kicked",
            "机器人能听到踹门声的最大范围"
        },
        {
            "Jump Sound Range",
            "跳跃声音范围"
        },
        {
            "The Maximum range a bot can hear someone jumping",
            "机器人能听到跳跃声的最大范围"
        },
        {
            "Rain Sound Multiplier - Outdoors",
            "雨声倍率 - 室外"
        },
        {
            "If it is raining, reduce heard distances by up to X amount. Depending on intensity of rain. Scales linearly with rain value.",
            "下雨时最多将听觉距离减少 X，具体幅度取决于雨势强度，并随雨量数值线性缩放。"
        },
        {
            "Rain Sound Multiplier - Inside Building",
            "雨声倍率 - 建筑内"
        },
        {
            "Max Footstep Audio Distance",
            "最大脚步声距离"
        },
        {
            "The Maximum Range that a bot can hear footsteps, sprinting, and jumping, turning, gear sounds, and any movement related sounds, in meters. ",
            "机器人能听到脚步声、冲刺、跳跃、转身、装备声响及任何移动相关声音的最大范围（米）。"
        },
        {
            "This is a theoretical max range, actual range heavily changes depending on conditions.",
            "这是理论最大范围，实际范围会随条件大幅变化。"
        },
        {
            "Max Footstep Audio Distance without Headphones",
            "未戴耳机时的最大脚步声距离"
        },
        {
            "Hearing Randomization and Estimation",
            "听觉随机化与估算"
        },
        {
            "Position Randomization",
            "位置随机化"
        },
        {
            "Unheard Shot Bullet Fly-by Modifier",
            "子弹掠过时枪声来源随机化倍率"
        },
        {
            "When a bot has a bullet fly by them, the dispersion on the source of the gunshot will be X times more random, ",
            "当有子弹从机器人身边掠过时，其对枪声来源位置的散布会变为原来的 X 倍，"
        },
        {
            "so a value of 2 will mean that it will multiply the randomized position to be 2x as far as originally calculated.",
            "因此数值为 2 表示随机化后的位置偏移会达到原本计算值的 2 倍。"
        },
        {
            "Minimum Hearing Randomization",
            "最小听觉随机化"
        },
        {
            "Higher = More Randomization, less accuracy in position prediction. Minimum Dispersion of a bot's estimated position from a sound they heard. In Meters. ",
            "数值越高随机化越强、位置预测越不准。机器人根据所听声音估算位置时的最小散布范围（米）。"
        },
        {
            "No Randomization Distance",
            "无随机化距离"
        },
        {
            "If the distance to a sound is less and or equal to this number, a bot will perfectly predict the source position, so no randomization or dispersion at all. ",
            "与声音的距离小于或等于该数值时，机器人会完美判断声源位置，完全没有随机化或散布。"
        },
        {
            "A value of 0 will disable this.",
            "设为 0 将禁用该功能。"
        },
        {
            "Max Randomization Distance",
            "最大随机化距离"
        },
        {
            "The max cap, in meters, that an estimated position can be from the real position that a sound is played from. ",
            "估算位置与声音实际播放位置之间允许的最大偏差（米）。"
        },
        {
            "Hearing Randomization Angle - Maximum",
            "听觉随机化角度 - 最大"
        },
        {
            "Hearing Randomization Angle - Minimum",
            "听觉随机化角度 - 最小"
        },
        {
            "Bunker Audio Range",
            "地堡音频范围"
        },
        {
            "Reduces audio range if a bot and an enemy are not in the same bunker",
            "当机器人与敌人不在同一地堡时，降低音频范围"
        },
        {
            "Hearing Environment Modifiers",
            "听觉环境修正"
        },
        {
            "Bunker Elevation Range",
            "地堡楼层范围"
        },
        {
            "Reduces audio range if a bot and an enemy are both in a bunker, but at different levels",
            "当机器人与敌人都在地堡内但处于不同楼层时，降低音频范围"
        },
        {
            "Gunshot Occlusion",
            "枪声遮挡"
        },
        {
            "If an obstacle is inbetween a bot's head and the position of a sound, reduce its range by this amount",
            "若机器人头部与声音位置之间存在障碍物，则按该数值降低音频范围"
        },
        {
            "Suppressed Gunshot Occlusion",
            "消音枪声遮挡"
        },
        {
            "Footstep Occlusion",
            "脚步声遮挡"
        },
        {
            "Sprint Occlusion",
            "冲刺声遮挡"
        },
        {
            "Other Occlusion",
            "其他声音遮挡"
        },
        {
            "Indoor / Outdoor Difference - Gunfire",
            "室内/室外差异 - 枪声"
        },
        {
            "If bots are not in the same area as the source of a sound, reduce audio range by this amount",
            "当机器人与声源不在同一区域时，按该数值降低音频范围"
        },
        {
            "Indoor / Outdoor Difference - Footsteps/Other",
            "室内/室外差异 - 脚步声/其他"
        },
        {
            "Environment Modifier Minimum",
            "环境修正下限"
        },
        {
            "No Headphones",
            "未戴耳机"
        },
        {
            "If a bot does not have headphones, reduce audible range of all sounds by this amount.",
            "若机器人未佩戴耳机，则按该数值降低所有声音的可听范围。"
        },
        {
            "Hearing Modifiers",
            "听觉修正"
        },
        {
            "Heavy Helmet",
            "重型头盔"
        },
        {
            "If a bot is wearing a heavy helmet, reduce audible range of all sounds by this amount.",
            "若机器人佩戴重型头盔，所有声音的可听范围按此数值降低。"
        },
        {
            "Dying",
            "濒死"
        },
        {
            "If a bot is dying or seriously injured, reduce audible range of all sounds by this amount.",
            "若机器人濒死或重伤，所有声音的可听范围按此数值降低。"
        },
        {
            "Sprinting",
            "冲刺"
        },
        {
            "If a bot is sprinting, reduce audible range of all sounds by this amount.",
            "若机器人正在冲刺，所有声音的可听范围按此数值降低。"
        },
        {
            "Heavy Breathing",
            "呼吸急促"
        },
        {
            "If a bot is breathing heavily, reduce audible range of all sounds by this amount.",
            "若机器人呼吸急促，所有声音的可听范围按此数值降低。"
        },
        {
            "Minimum Hear Modifier",
            "最小听觉修正"
        },
        {
            "Final Multiplier will not go below this value.",
            "最终倍率不会低于此值。"
        },
        {
            "Maximum Hear Modifier",
            "最大听觉修正"
        },
        {
            "Final Multiplier will not go above this value.",
            "最终倍率不会高于此值。"
        },
        {
            "Minimum Hearing Modifier Distance",
            "最小听觉修正距离"
        },
        {
            "Sounds that originate closer than this have a 100% chance of being heard.",
            "声源距离近于此值时，被听见的几率为 100%。"
        },
        {
            "Scale Start Distance - No Headphones",
            "缩放起始距离 - 无耳机"
        },
        {
            "Hearing Chance",
            "听觉几率"
        },
        {
            "Scale Start Distance - Headphones",
            "缩放起始距离 - 耳机"
        },
        {
            "Midrange Coefficient",
            "中距离系数"
        },
        {
            "If the distance between a sound and the bot is X distance of its max range, increase its chance to hear slightly. So if a sound has a range of 50 meters, and the distance to a bot hears is 25 meters away, that would result in 25 / 50, so 0.5, which is below this mid range value.",
            "若声音与机器人的距离占其最大范围的比例为 X，则略微提高听见的几率。例如声音范围为 50 米，而机器人在 25 米处听见，比值为 25 / 50，即 0.5，低于此中距离数值。"
        },
        {
            "Mid range Minimum Chance - Headphones",
            "中距离最小几率 - 耳机"
        },
        {
            "If a sound is within mid-range. Increase the minimum chance by this amount",
            "若声音位于中距离范围内，最小几率按此数值提高。"
        },
        {
            "Long range Minimum Chance - Headphones",
            "远距离最小几率 - 耳机"
        },
        {
            "If a sound is further than mid-range. Increase the minimum chance by this amount",
            "若声音超出中距离范围，最小几率按此数值提高。"
        },
        {
            "Standing Still Velocity",
            "静止速度阈值"
        },
        {
            "Boost Hearing chance slightly if a bot's velocity is under this value.",
            "若机器人速度低于此值，略微提高听觉几率。"
        },
        {
            "Standing Still Min Chance - No Headphones",
            "静止最小几率 - 无耳机"
        },
        {
            "If a bot is standing still, add X percent to a bot minimum hear chance for sounds that aren't gunshots.",
            "若机器人处于静止状态，非枪声的最小听觉几率提高 X%。"
        },
        {
            "Standing Still Min Chance - Headphones",
            "静止最小几率 - 耳机"
        },
        {
            "Other Sounds Min Chance - Headphones",
            "其他声音最小几率 - 耳机"
        },
        {
            "If the type of sound is not footsteps or gunfire, add X percent to a bot minimum hear chance.",
            "若声音类型不是脚步声或枪声，最小听觉几率提高 X%。"
        },
        {
            "Active Enemy Min Chance - No Headphones",
            "当前敌人最小几率 - 无耳机"
        },
        {
            "If the source of a sound is from a bot's active primary enemy, add X percent to a bot minimum hear chance for sounds that aren't gunshots.",
            "若声源来自机器人当前的主要敌人，非枪声的最小听觉几率提高 X%。"
        },
        {
            "Active Enemy Min Chance - Headphones",
            "当前敌人最小几率 - 耳机"
        },
        {
            "Looting Sound",
            "搜刮声"
        },
        {
            "Footstep Skid and Turn",
            "脚步急停与转身"
        },
        {
            "Grenade Pullout and Pin Pull",
            "拔出手雷与拉环"
        },
        {
            "Footstep Sound",
            "脚步声"
        },
        {
            "Sprint Sound",
            "冲刺声"
        },
        {
            "Jump Sound",
            "跳跃声"
        },
        {
            "Prone Sound",
            "卧倒声"
        },
        {
            "Healing Sound",
            "治疗声"
        },
        {
            "Reload Sound",
            "换弹声"
        },
        {
            "Surgery Sound",
            "手术声"
        },
        {
            "Dryfire Sound",
            "空击声"
        },
        {
            "Fall Landing Sound",
            "落地声"
        },
        {
            "Aim Down Sights Sound",
            "开镜声"
        },
        {
            "Eat and Drink Sound",
            "饮食声"
        },
        {
            "Max Squad Communication Range - No Headphones",
            "小队最大通讯距离 - 无耳机"
        },
        {
            "Base Hearing Delay Settings",
            "基础听觉延迟设置"
        },
        {
            "Hearing Delay / Reaction Delay",
            "听觉延迟 / 反应延迟"
        },
        {
            "Sound Type based Hearing Delay / Reaction Time",
            "按声音类型的听觉延迟 / 反应时间"
        },
        {
            "Optional: If a soundtype is defined here, it will override the Base Hearing Delays defined above.",
            "可选：若在此定义了声音类型，将覆盖上方的基础听觉延迟。"
        },
        {
            "Global Gunshot Audible Range Multiplier",
            "全局枪声可听范围倍率"
        },
        {
            "Global Footstep Audible Range Multiplier",
            "全局脚步声可听范围倍率"
        },
        {
            "Suppressed Sound Modifier",
            "消音声音修正"
        },
        {
            "Audible Gun Range is multiplied by this number when using a suppressor",
            "使用消音器时，枪声可听范围乘以该数值。"
        },
        {
            "Subsonic Sound Modifier",
            "亚音速声音修正"
        },
        {
            "Audible Gun Range is multiplied by this number when using a suppressor and subsonic ammo",
            "使用消音器与亚音速弹药时，枪声可听范围乘以该数值。"
        },
        {
            "Hearing Distances by Ammo Type",
            "按弹药类型的听觉距离"
        },
        {
            "How far a bot can hear a gunshot when fired from each specific caliber listed here.",
            "此处列出的各口径枪声，机器人能听见的最远距离。"
        },
        {
            "New Hit Reactions",
            "新受击反应"
        },
        {
            "Disable to get vanilla bot hit reactions. If this is disabled, all below settings will do nothing.",
            "关闭后使用原版机器人受击反应。若关闭，下方所有设置均无效。"
        },
        {
            "Hit Effect Multiplier",
            "受击效果倍率"
        },
        {
            "Higher = getting shot has more affect on bot aim.",
            "数值越高，中弹对机器人瞄准的影响越大。"
        },
        {
            "Use Hit Point Direction",
            "使用受击方向"
        },
        {
            "Instead of randomly calculating an angle to affect bot aim. ",
            "不再随机计算影响机器人瞄准的角度。"
        },
        {
            "Use the direction they were hit from, so if they are shot in the right arm, their aim gets kicked to the right. ",
            "改用中弹方向：若右臂中弹，瞄准会向右偏。"
        },
        {
            "If they are shot in the leg, kick their aim down towards their leg.",
            "若腿部中弹，瞄准会向下偏向腿部。"
        },
        {
            "Min Base Hit Effect Angle",
            "最小基础受击角度"
        },
        {
            "If Use Hit Point Direction is On, this does nothing.",
            "若开启“使用受击方向”，此项无效。"
        },
        {
            "Max Base Hit Effect Angle",
            "最大基础受击角度"
        },
        {
            "Damage Baseline",
            "伤害基准值"
        },
        {
            "The amount of damage a bot received is divided by this number to produce a multiplier for how much to kick their aim. ",
            "机器人所受伤害除以该数值，得出瞄准偏移的倍率。"
        },
        {
            "So if the value here is 50, and a bot is shot by a bullet that does 100 damage, it will result in their hit reaction being 2x, or twice as impactful.",
            "例如该值为 50，机器人被造成 100 点伤害的子弹击中，则受击反应为 2 倍，即影响翻倍。"
        },
        {
            "Min Hit Damage Multiplier",
            "最小受击伤害倍率"
        },
        {
            "Max Hit Damage Multiplier",
            "最大受击伤害倍率"
        },
        {
            "Enemy Suppression Toggle",
            "敌人压制开关"
        },
        {
            "Enemy Suppression",
            "敌人压制"
        },
        {
            "Force Single Personality For All Bots",
            "强制所有机器人使用单一性格"
        },
        {
            "All Spawned SAIN bots will be assigned the selected Personality, if any are set to true, no matter what.",
            "只要有任一性格设为开启，所有生成的 SAIN 机器人都会被强制分配所选性格。"
        },
        {
            "Boss Personalities",
            "Boss 性格"
        },
        {
            "Sets the pesonality that a boss will always use.",
            "设置 Boss 始终使用的性格。"
        },
        {
            "Global Aggression",
            "全局攻击性"
        },
        {
            "Higher = More aggressive bots, less time before seeking enemies. 2x = half the wait time.",
            "数值越高，机器人越具攻击性，开始搜寻敌人的等待时间越短。2 倍 = 等待时间减半。"
        },
        {
            "Bots can use Stealth Search",
            "机器人可使用隐蔽搜索"
        },
        {
            "If a bot thinks he was not heard, and isn't currently fighting an enemy, they can decide to be stealthy while they seek out an enemy, if they are inside a building.",
            "若机器人认为自己未被听见、当前未与敌人交火，且身处建筑内，搜寻敌人时可以保持隐蔽。"
        },
        {
            "Only Sneaky Personalities can be Stealthy",
            "仅 Sneaky 性格可保持隐蔽"
        },
        {
            "The distance from a bot's search destination that they will begin to be stealthy, if enabled.",
            "启用后，机器人在距搜索目标此距离时开始保持隐蔽。"
        },
        {
            "Bot Suppression",
            "机器人压制"
        },
        {
            "Toggles whether bots get suppressed or not. If disabled, all options below will do nothing.",
            "开关机器人是否会被压制。若关闭，下方所有选项均无效。"
        },
        {
            "Suppression",
            "压制"
        },
        {
            "Suppression Distance Scale Start",
            "压制距离缩放起点"
        },
        {
            "The distance between the bullet, and a bot's head to receive full suppression effect. In Meters.",
            "子弹与机器人头部之间获得完整压制效果的距离，单位：米。"
        },
        {
            "Suppression Distance Scale End",
            "压制距离缩放终点"
        },
        {
            "The maximum distance between the bullet, and a bot's head to be considered Suppressing fire. In Meters. Scales linearly between Scale End and Scale Start.",
            "子弹与机器人头部之间的最大距离，在此范围内才视为压制射击。单位为米。在缩放终点与缩放起点之间线性变化。"
        },
        {
            "Suppression Distance Amplify Distance",
            "压制增幅距离"
        },
        {
            "If a bullet is closer than this distance, in meters, to the bot's head. Amplify the amount of suppression.",
            "若子弹与机器人头部的距离小于此值（米），则增幅压制量。"
        },
        {
            "Suppression Distance Amplify Amount",
            "压制增幅倍率"
        },
        {
            "If a bullet is closer than Amplify Distance to the bot's head. Amplify the amount of suppression by this multiplier.",
            "若子弹与机器人头部的距离小于增幅距离，则按此倍数增幅压制量。"
        },
        {
            "The maximum distance between the bullet, and a bot's head to be considered under active enemy fire.",
            "子弹与机器人头部之间的最大距离，在此范围内才视为处于敌方火力压制下。"
        },
        {
            "Suppression States",
            "压制状态"
        },
        {
            "Configure each tier of suppression.",
            "配置每一档压制状态。"
        },
        {
            "Amount Multiplier",
            "数量倍率"
        },
        {
            "Linearly increase or decrease the amount of suppression points bots receive from 1 bullet. Higher = Bots get suppressed more easily.",
            "线性增减机器人每颗子弹获得的压制点数。数值越高，机器人越容易被压制。"
        },
        {
            "Strength Multiplier",
            "强度倍率"
        },
        {
            "Linearly increase or decrease the strength of suppression effects on bots. Higher = Suppression has more effect on bot stats.",
            "线性增减压制效果对机器人的强度。数值越高，压制对机器人属性的影响越大。"
        },
        {
            "Decay Tick Amount",
            "衰减单次数值"
        },
        {
            "How much suppression to remove per update tick.",
            "每次更新移除的压制量。"
        },
        {
            "Decay Tick Frequency",
            "衰减触发频率"
        },
        {
            "How often to tick decay per second. 0.25 = 4 per second",
            "每秒触发衰减的次数。0.25 = 每秒 4 次"
        },
        {
            "State Update Tick Frequency",
            "状态更新频率"
        },
        {
            "How often to check suppression state per second. 0.5 = 2 per second",
            "每秒检查压制状态的次数。0.5 = 每秒 2 次"
        },
        {
            "Suppression Amounts Per Caliber",
            "各口径压制量"
        },
        {
            "For each bullet that flies by a bot, add this number to their suppression counter, which decays constantly and linearly.",
            "每有一颗子弹从机器人附近飞过，就在其压制计数上加上此数值；该计数会持续线性衰减。"
        },
        {
            "Max Suppression Number",
            "最大压制值"
        },
        {
            "Suppression caps at this number.",
            "压制值以此为上限。"
        },
        {
            "Can Lean - Global",
            "可探身（全局）"
        },
        {
            "Can any bot lean while peeking and while outside of cover?",
            "机器人能否在探头观察时以及在掩体之外探身？"
        },
        {
            "Can Lean in Cover - Global",
            "掩体内可探身（全局）"
        },
        {
            "Can any bot lean while in cover?",
            "机器人能否在掩体内探身？"
        },
        {
            "Can Jump - Global",
            "可跳跃（全局）"
        },
        {
            "Can any bot Jump?",
            "机器人能否跳跃？"
        },
        {
            "Can Auto Pose - Global",
            "自动调整姿态（全局）"
        },
        {
            "Does any bot automatically adjust their crouch height depending on objects between them and their enemy?",
            "机器人是否会根据自身与敌人之间的物体自动调整蹲伏高度？"
        },
        {
            "Can Go Prone - Global",
            "可卧倒（全局）"
        },
        {
            "Can any bot go Prone at all?",
            "机器人能否卧倒？"
        },
        {
            "Can Go Prone from Suppression - Global",
            "受压制可卧倒（全局）"
        },
        {
            "Can any bot go Prone as a panic response to being suppressed?",
            "机器人能否在被压制时作为惊慌反应而卧倒？"
        },
        {
            "Can Vault - Global",
            "可翻越（全局）"
        },
        {
            "Can any bot Vault?",
            "机器人能否翻越？"
        },
        {
            "Can Vault to get Unstuck - Global",
            "脱困翻越（全局）"
        },
        {
            "Can any bot Vault if they are stuck on map geometry?",
            "机器人卡在地图几何体上时能否翻越脱困？"
        },
        {
            "Force Constant Sprint Speed",
            "强制恒定冲刺速度"
        },
        {
            "In vanilla, bot movement speed while sprinting is set to a constant speed, if this is disabled, bots will use the same movement speed calculations as a normal player.",
            "在原版中，机器人冲刺时的移动速度被设为恒定值；若禁用此项，机器人将使用与普通玩家相同的移动速度计算方式。"
        },
        {
            "Not Moving Distance Threshold",
            "判定静止的距离阈值"
        },
        {
            "How far a bot can be from their last position before they are considered Not Moving. In Meters Squared",
            "机器人距上次记录位置多远之内仍视为静止。单位为平方米"
        },
        {
            "Not Moving Check Frequency",
            "静止检测频率"
        },
        {
            "Every X seconds, check if a bot has moved from their last position.",
            "每 X 秒检查一次机器人是否离开了上次记录的位置。"
        },
        {
            "Not Moving Vault Time",
            "静止翻越时间"
        },
        {
            "If a bot is not moving for this length of time or longer, try vaulting to get themselves unstuck",
            "若机器人静止达到或超过此时长，则尝试翻越脱困"
        },
        {
            "Not Moving Jump Time",
            "静止跳跃时间"
        },
        {
            "If a bot is not moving for this length of time or longer, try jumping to get themselves unstuck",
            "若机器人静止达到或超过此时长，则尝试跳跃脱困"
        },
        {
            "Not Moving Recalculate Time",
            "静止重算路径时间"
        },
        {
            "If a bot is not moving for this length of time or longer, recalculate a path to their destination",
            "若机器人静止达到或超过此时长，则重新计算通往目的地的路径"
        },
        {
            "Path Corner Sprint Reach Distance",
            "拐点冲刺抵达距离"
        },
        {
            "How far from a corner along a path before a bot considers it self arrived, and attemps to navigate to the next corner.",
            "机器人沿路径距拐点多远时视为已抵达该拐点，并尝试前往下一个拐点。"
        },
        {
            "Path Corner Walk Reach Distance",
            "拐点行走抵达距离"
        },
        {
            "Max Corner Angle to Pause Sprint",
            "暂停冲刺的最大转角"
        },
        {
            "When a bot approaches a turn along a path, this is the maximum degrees before they pause sprinting to turn instead of keeping sprint active while they turn.",
            "机器人沿路径接近转角时，若转角不超过此角度，则暂停冲刺以便转向，而不是边冲刺边转向。"
        },
        {
            "PMC Power",
            "PMC 战力"
        },
        {
            "Add X points to a bot's power level if they are a PMC",
            "若机器人为 PMC，则为其战力等级增加 X 点"
        },
        {
            "Bot Type Power Value",
            "机器人类型战力值"
        },
        {
            "Scav Power",
            "Scav 战力"
        },
        {
            "Add X points to a bot's power level if they are a Scav",
            "若机器人为 Scav，则为其战力等级增加 X 点"
        },
        {
            "Shotgun Power",
            "霰弹枪战力"
        },
        {
            "Add X points to a bot's power level if they are using this type of weapon as their primary.",
            "若机器人主武器为此类武器，则为其战力等级增加 X 点。"
        },
        {
            "Weapon Class Power Value",
            "武器类别战力值"
        },
        {
            "Smg Power",
            "冲锋枪战力"
        },
        {
            "Assault Carbine Power",
            "突击卡宾枪战力"
        },
        {
            "Assault Rifle Power",
            "突击步枪战力"
        },
        {
            "Machinegun Power",
            "机枪战力"
        },
        {
            "Sniper Rifle Power",
            "狙击步枪战力"
        },
        {
            "Marksman Rifle Power",
            "精确射手步枪战力"
        },
        {
            "Pistol Power",
            "手枪战力"
        },
        {
            "Red Dot / 1x Holo Sight Power",
            "红点 / 1 倍全息瞄具战力"
        },
        {
            "Add X points to a bot's power level if they are using this type of attachment on their primary.",
            "若机器人主武器使用此类配件，则为其战力等级增加 X 点。"
        },
        {
            "Attachment Power Value",
            "配件战力值"
        },
        {
            "Magnified Optic Power",
            "倍镜战力"
        },
        {
            "Suppressor Power",
            "消音器战力"
        },
        {
            "Body Armor Class Power",
            "护甲等级战力"
        },
        {
            "For each AC level, add X to a bot's power level. So if they have level 4 armor, add this value 4 times.",
            "每级 AC（护甲等级）为机器人战力增加 X 点。例如机器人穿 4 级护甲，则此数值加 4 次。"
        },
        {
            "Armor Power Value",
            "护甲战力值"
        },
        {
            "Body Armor Class Power - Realism Mod",
            "护甲等级战力（Realism Mod）"
        },
        {
            "If Realism Mod is loaded, use this AC Power value. ",
            "若加载了 Realism Mod，则使用此 AC 战力值。"
        },
        {
            "Helmet Class Power",
            "头盔等级战力"
        },
        {
            "If a bot has an armored helmet above class 1, but lower than 5, add X to thier power level.",
            "若机器人佩戴 1 级以上、5 级以下的防弹头盔，则为其战力等级增加 X 点。"
        },
        {
            "Heavy Helmet Class Power",
            "重型头盔等级战力"
        },
        {
            "If a bot has an armored helmet above class 4, add X to thier power level.",
            "若机器人佩戴 4 级以上的防弹头盔，则为其战力等级增加 X 点。"
        },
        {
            "Faceshield Power",
            "面罩战力"
        },
        {
            "If a bot has an armored face shield, add X to thier Power Level.",
            "若机器人佩戴防弹面罩，则为其战力等级增加 X 点。"
        },
        {
            "Headphones Power",
            "耳机战力"
        },
        {
            "If a bot has headphones, add X to thier Power Level.",
            "若机器人佩戴耳机，则为其战力等级增加 X 点。"
        },
        {
            "Location Specific Modifiers",
            "地图专属修正"
        },
        {
            "These modifiers only apply to bots on the location they are assigned to. Applies to all bots equally.",
            "这些修正仅作用于其所分配地图上的机器人，对所有机器人一视同仁。"
        },
        {
            "Base Minimum Time Between Shots",
            "基础射击最短间隔"
        },
        {
            "Base Maximum Time Between Shots",
            "基础射击最长间隔"
        },
        {
            "Fullauto Wait Multiplier",
            "全自动间隔倍率"
        },
        {
            "If a bot is on fullauto, the time between shots will be multiplied by this value",
            "若机器人处于全自动射击状态，射击间隔将乘以该数值"
        },
        {
            "Firerate Randomization",
            "射速随机化"
        },
        {
            "Randomize the time a bot waits between shots to make it less robotic. A value of 0.25 means it will multiply it by a random value between 0.75x - 1.25x",
            "随机化机器人在两次射击之间的等待时间，使其不再那么机械。数值 0.25 表示将其乘以 0.75x - 1.25x 之间的随机值"
        },
        {
            "Bots only use Semi Auto",
            "机器人仅使用半自动"
        },
        {
            "If enabled, bots will never be able to use full auto at close/mid range.",
            "启用后，机器人在近距/中距时永远不会使用全自动。"
        },
        {
            "Global Recoil Multiplier",
            "全局后坐力倍率"
        },
        {
            "Higher = more recoil. Modifies SAIN's recoil scatter feature. 1.5 = 1.5x more recoilfrom a single gunshot",
            "数值越高，后坐力越大。修改 SAIN 的后坐力散布功能。1.5 = 单次开枪的后坐力增加 1.5 倍"
        },
        {
            "Bot Recoil",
            "机器人后坐力"
        },
        {
            "Add or Subtract Recoil",
            "增减后坐力"
        },
        {
            "Linearly add or subtract from the final recoil result",
            "对最终后坐力结果进行线性增减"
        },
        {
            "Recoil Decay Coefficient",
            "后坐力衰减系数"
        },
        {
            "Controls the speed that bots will recover from a weapon's recoil. Higher = faster decay",
            "控制机器人从武器后坐力中恢复的速度。数值越高，衰减越快"
        },
        {
            "Bot Weapon Recoil Baseline",
            "机器人武器后坐力基准值"
        },
        {
            "A Bot's weapon's recoil will get divided by this to calculate how much to rotate their view on each shot, so, for example, ",
            "机器人武器的后坐力将除以此值，以计算每次射击时其视角旋转的幅度。例如，"
        },
        {
            "with a baseline of 100 - if a bot has 250 total recoil, that number gets divided by this to produce 2.5. Higher = Less recoil for bots. ",
            "基准值为 100 时——如果机器人的总后坐力为 250，该数值会被除以此值，得到 2.5。数值越高，机器人的后坐力越小。"
        },
        {
            "This is basically an average recoil of all possible weapons.",
            "这基本上是所有可能武器的平均后坐力。"
        },
        {
            "Bot Weapon Recoil Baseline - Realism Mod",
            "机器人武器后坐力基准值 - Realism Mod"
        },
        {
            "A Bot's weapon's recoil will get divided by this to calculate how much to rotate their view on each shot. This value is used if Realism mod is on to reflect different recoil numbers.",
            "机器人武器的后坐力将除以此值，以计算每次射击时其视角旋转的幅度。启用 Realism mod 时使用此数值，以反映不同的后坐力数值。"
        },
        {
            "Ammo Shootability",
            "弹药射击性"
        },
        {
            "Lower is BETTER. ",
            "数值越低越好。"
        },
        {
            "How Shootable this ammo type is, affects semi auto firerate and full auto burst length.",
            "该弹药类型的射击性，影响半自动射速和全自动点射时长。"
        },
        {
            "Value is scaled but roughly gives a plus or minus 20% to firerate depending on the value set here.",
            "数值经过缩放，但大致会依据此处设置的数值对射速产生正负 20% 的影响。"
        },
        {
            "For Example. 9x19 will shoot about 20% faster fire-rate on semi-auto at 50 meters",
            "例如，9x19 在 50 米处半自动射击时，射速约快 20%"
        },
        {
            ", and fire 20% longer bursts when on full auto",
            "，全自动时点射时长增加 20%"
        },
        {
            "Bot Weapon Control",
            "机器人武器控制"
        },
        {
            "Max FullAuto Distances",
            "全自动最大距离"
        },
        {
            "The maximum distance a bot using this caliber can fire it full auto. Not all values are used since some calibers don't have any full auto weapons that use it.",
            "使用该口径的机器人能进行全自动射击的最大距离。并非所有数值都会被用到，因为某些口径没有任何全自动武器。"
        },
        {
            "Weapon Shootability",
            "武器射击性"
        },
        {
            "How Shootable this weapon type is, affects semi auto firerate and full auto burst length.",
            "该武器类型的射击性，影响半自动射速和全自动点射时长。"
        },
        {
            "For Example. SMGs will shoot about 20% faster fire-rate on semi-auto at 50 meters",
            "例如，冲锋枪在 50 米处半自动射击时，射速约快 20%"
        },
        {
            "Weapon Firerate Wait Time",
            "武器射速等待时间"
        },
        {
            "HIGHER is BETTER. ",
            "数值越高越好。"
        },
        {
            "This is the time to wait inbetween shots for every meter.",
            "这是每米距离在两次射击之间的等待时间。"
        },
        {
            "the number is divided by the distance to their target, to get a wait period between shots.",
            "该数值会除以与目标的距离，得出两次射击之间的等待时间。"
        },
        {
            "For Example. With a setting of 100: ",
            "例如，设置为 100 时："
        },
        {
            "if a target is 50m away, they will wait 0.5 sec between shots because 50 / 100 is 0.5.",
            "如果目标在 50m 外，两次射击之间会等待 0.5 秒，因为 50 / 100 = 0.5。"
        },
        {
            "This number is later modified by the Shootability multiplier, to get a final fire-rate that gets sent to a bot.",
            "随后该数值会被射击性倍率修正，得出最终发送给机器人的射速。"
        },
        {
            "Bot Preferred Shoot Distances",
            "机器人偏好射击距离"
        },
        {
            "The distances that a bot prefers to shoot a particular weapon class. ",
            "机器人使用特定武器类别时偏好的射击距离。"
        },
        {
            "Bots will try to close the distance if further than this.",
            "如果距离超过此值，机器人会尝试拉近距离。"
        },
        {
            "Callout Reloading Chance",
            "换弹语音概率"
        },
        {
            "If conditions are met, this is the chance a bot will actually say a voiceline.",
            "满足条件时，机器人实际说出语音的概率。"
        },
        {
            "Callout Reloading Frequency",
            "换弹语音频率"
        },
        {
            "4 = once every 4 seconds",
            "4 = 每 4 秒一次"
        },
        {
            "Callout Lost Enemy Visual Chance",
            "失去敌人视野语音概率"
        },
        {
            "Callout Rat Chance",
            "嘲讽蹲守语音概率"
        },
        {
            "Callout Rat Time Since Seen Enemy",
            "蹲守语音的敌人目击间隔时间"
        },
        {
            "Callout Enemy Conversation Chance",
            "对敌喊话语音概率"
        },
        {
            "Call Enemy Conversation Max Distance",
            "对敌喊话最大距离"
        },
        {
            "Callout Enemy Health Status Chance",
            "敌人血量状态语音概率"
        },
        {
            "Callout Enemy Health Status Frequency",
            "敌人血量状态语音频率"
        },
        {
            "8 = once every 8 seconds",
            "8 = 每 8 秒一次"
        },
        {
            "Callout Enemy Killed Chance",
            "击杀敌人语音概率"
        },
        {
            "Callout Enemy Killed Squadleader Confirm Chance",
            "队长确认击杀语音概率"
        },
        {
            "When a member calls out that they killed an enemy, this is the chance the squad leader will acknowledge and confirm the kill with a compliment.",
            "当队员喊出自己击杀了敌人时，队长会以称赞确认该击杀的概率。"
        },
        {
            "Toxic Squad Leader",
            "毒舌队长"
        },
        {
            "Old bug turned into a feature. Squad leaders will yell Nice Work when a friendly squad member is killed.",
            "旧 bug 变成了特性。友方小队成员被击杀时，队长会大喊“干得漂亮”。"
        },
        {
            "Friend Close Distance",
            "友军对话距离"
        },
        {
            "The distance to a friendly that a bot will consider speaking to them.",
            "机器人会考虑对友军说话的距离。"
        },
        {
            "Callout Friendly Killed Chance",
            "友军被击杀语音概率"
        },
        {
            "Callout Retreat Chance",
            "撤退语音概率"
        },
        {
            "Callout Retreat Frequency",
            "撤退语音频率"
        },
        {
            "10 = once every 10 seconds",
            "10 = 每 10 秒一次"
        },
        {
            "Callout Retreat Group Delay",
            "撤退语音小队延迟"
        },
        {
            "Group Delay = Squad Members will share cooldown on certain voicelines to prevent spam",
            "小队延迟 = 小队成员共享某些语音的冷却时间，以防刷屏"
        },
        {
            "Callout Under Fire Chance",
            "遭受火力语音概率"
        },
        {
            "Callout Need Help Delay",
            "呼救语音延迟"
        },
        {
            "Callout Under Fire Frequency",
            "遭受火力语音频率"
        },
        {
            "Callout Need Help Chance",
            "呼救语音概率"
        },
        {
            "Callout Noise Heard Chance",
            "听到声响语音概率"
        },
        {
            "Call Heard Noise Max Distance",
            "声响报告最大距离"
        },
        {
            "Max Distance from a non-gunshot sound to report it to squad members with a voiceline.",
            "非枪声的声响能通过语音报告给小队成员的最大距离。"
        },
        {
            "Callout Heard Noise Frequency",
            "听到声响语音频率"
        },
        {
            "Callout Enemy Location Chance",
            "敌人位置语音概率"
        },
        {
            "Callout Enemy Location Time Since Seen",
            "敌人位置语音的目击间隔时间"
        },
        {
            "Time Since Seen = How long since they have seen or heard an enemy.",
            "目击间隔时间 = 距离上次看到或听到敌人已过去多久。"
        },
        {
            "Callout Enemy Location Frequency",
            "敌人位置语音频率"
        },
        {
            "Callout Enemy Location Behind Angle Arc",
            "敌人位置语音后方角度范围"
        },
        {
            "Callout Enemy Location Side Angle Arc",
            "敌人位置语音侧方角度范围"
        },
        {
            "Callout Enemy Location Front Angle Arc",
            "敌人位置语音前方角度范围"
        },
        {
            "Max Path Length",
            "最大路径长度"
        },
        {
            "How far along a path to an enemy a bot will check vision to, in meters.",
            "机器人沿通往敌人的路径进行视觉检查的最远距离，单位为米。"
        },
        {
            "Enemy Path Visibility System",
            "敌人路径可见性系统"
        },
        {
            "Path Nodes Stack Height",
            "路径节点堆叠高度"
        },
        {
            "X number of points will be generated above each node in the path",
            "将在路径中每个节点上方生成 X 个点"
        },
        {
            "Distance Between Nodes",
            "节点间距"
        },
        {
            "Random Bot Aim Sway",
            "机器人瞄准随机晃动"
        },
        {
            "Random Sway",
            "随机晃动"
        },
        {
            "Last Seen to Last Known Position Distance Threshold",
            "最后目击点到最后已知位置的距离阈值"
        },
        {
            "Smooth Turn Settings",
            "平滑转身设置"
        },
        {
            "Peaceful Talk",
            "和平交谈"
        },
        {
            "Talkative Scavs",
            "话多的 Scav"
        },
        {
            "When at peace, scavs will talk to each other and be noisy. Revealing their location.",
            "和平时，Scav 会互相交谈并发出声响，从而暴露自己的位置。"
        },
        {
            "Talkative PMCs",
            "话多的 PMC"
        },
        {
            "When at peace, pmcs will talk to each other and be noisy. Revealing their location.",
            "和平时，PMC 会互相交谈并发出声响，从而暴露自己的位置。"
        },
        {
            "Talkative Raiders and Rogues",
            "Raider与Rogue闲聊"
        },
        {
            "When at peace, raiders and rogues will talk to each other and be noisy. Revealing their location.",
            "处于和平状态时，Raider和Rogue会互相交谈、发出声音，从而暴露自己的位置。"
        },
        {
            "Talkative Bosses",
            "Boss闲聊"
        },
        {
            "When at peace, Bosses and boss guards will talk to each other and be noisy. Revealing their location.",
            "处于和平状态时，Boss及其护卫会互相交谈、发出声音，从而暴露自己的位置。"
        },
        {
            "Talkative Goons",
            "Goons闲聊"
        },
        {
            "When at peace, The Goons will talk to each other and be noisy. Revealing their location.",
            "处于和平状态时，Goons会互相交谈、发出声音，从而暴露自己的位置。"
        },
        {
            "Human Response Chance",
            "人类回应几率"
        },
        {
            "Percentage chance to respond to a voiceline from a friendly human player.",
            "对友方人类玩家的语音做出回应的百分比几率。"
        },
        {
            "Friendly Response",
            "友方回应"
        },
        {
            "AI Response Chance",
            "AI回应几率"
        },
        {
            "Percentage chance to respond to a voiceline from a friendly AI player.",
            "对友方AI玩家的语音做出回应的百分比几率。"
        },
        {
            "Human Response Max Distance",
            "人类回应最大距离"
        },
        {
            "AI Response Max Distance",
            "AI回应最大距离"
        },
        {
            "Response Frequency",
            "回应频率"
        },
        {
            "2 = 1 check every 2 second",
            "2 = 每2秒检测1次"
        },
        {
            "Response Delay Randomization Min",
            "回应延迟随机化最小值"
        },
        {
            "Response Delay Randomization Max",
            "回应延迟随机化最大值"
        },
        {
            "Vanilla Bot Talking",
            "原版机器人语音"
        },
        {
            "Disable all SAIN based handling of bot talking. No more squad chatter, no more quiet bots, completely disables SAIN's handling of bot voices",
            "禁用SAIN对机器人语音的所有处理。不再有小队闲聊，不再有安静的机器人，完全关闭SAIN对机器人语音的管理。"
        },
        {
            "Limit SAIN Function in AI vs AI - Global Toggle",
            "限制AI对AI时的SAIN功能 - 全局开关"
        },
        {
            "Disables certains functions when ai are fighting other ai, and they aren't close to a human player. Turn off if you are spectating ai in free-cam.",
            "当AI与其他AI交战、且附近没有人类玩家时，禁用部分功能。如果你在自由视角下观战AI，请关闭此项。"
        },
        {
            "Limit AI vs AI Vision",
            "限制AI对AI视觉"
        },
        {
            "Reduces visible range for bots vs other bots if they are bot far from a human player.",
            "当机器人远离人类玩家时，降低其对抗其他机器人时的可视距离。"
        },
        {
            "Limit AI vs AI Hearing",
            "限制AI对AI听觉"
        },
        {
            "Reduces hearing distance for bots vs other bots if they are bot far from a human player.",
            "当机器人远离人类玩家时，降低其对抗其他机器人时的听觉距离。"
        },
        {
            "Draw Debug Gizmos",
            "绘制调试辅助线"
        },
        {
            "Draw Transform Gizmos",
            "绘制变换辅助线"
        },
        {
            "Draw Player Navmesh Sampling Gizmos",
            "绘制玩家导航网格采样辅助线"
        },
        {
            "Draw Line of Sight Checks",
            "绘制视线检测"
        },
        {
            "Draw Volumetric Light Gizmos",
            "绘制体积光辅助线"
        },
        {
            "Draw Door Links",
            "绘制门连接"
        },
        {
            "Draw Recoil Gizmos",
            "绘制后坐力辅助线"
        },
        {
            "Draw Aim Gizmos",
            "绘制瞄准辅助线"
        },
        {
            "Draw Blind Corner Raycasts",
            "绘制盲角射线检测"
        },
        {
            "Draw Debug Suppression Points",
            "绘制调试压制点"
        },
        {
            "Draw Search Peek Start and End Gizmos",
            "绘制搜索探头起点与终点辅助线"
        },
        {
            "Draw Debug Path Safety Tester",
            "绘制调试路径安全测试器"
        },
        {
            "Path Safety Tester",
            "路径安全测试器"
        },
        {
            "Global Debug Mode",
            "全局调试模式"
        },
        {
            "Global Performance Profiling Mode",
            "全局性能分析模式"
        },
        {
            "Enables function sampling for Unity Profiling.",
            "为Unity性能分析启用函数采样。"
        },
        {
            "Test Bot Sprint Pathfinder",
            "测试机器人冲刺寻路"
        },
        {
            "Test Bot Crawling",
            "测试机器人爬行"
        },
        {
            "Test Grenade Throw",
            "测试手雷投掷"
        },
        {
            "Draw Debug Labels",
            "绘制调试标签"
        },
        {
            "Debug External",
            "外部调试"
        },
        {
            "Debug Recoil Calculations",
            "调试后坐力计算"
        },
        {
            "Debug Aim Calculations",
            "调试瞄准计算"
        },
        {
            "Debug Hearing Calc Results",
            "调试听觉计算结果"
        },
        {
            "Debug Extracts",
            "调试撤离点"
        },
        {
            "Collect and Export Bot Layer and Brain Info",
            "收集并导出机器人层级与大脑信息"
        },
        {
            "SAIN Door Handling",
            "SAIN门处理"
        },
        {
            "WIP",
            "开发中"
        },
        {
            "No Door Animations",
            "禁用开门动画"
        },
        {
            "Bots auto open doors instead of getting stuck in an animation, if fika is loaded, this is ignored and it is always disabled.",
            "机器人会直接自动开门，而不是卡在动画里。若加载了Fika，此项会被忽略并始终禁用。"
        },
        {
            "Always Push Open Doors",
            "始终推门开启"
        },
        {
            "Only applies if No Door Animations is set to on. Bots will always push open doors to avoid getting stuck. Can cause cursed looking doors sometimes, but greatly improves their ability to navigate.",
            "仅在“禁用开门动画”开启时生效。机器人会始终推开房门以避免卡住。有时会让门看起来很奇怪，但能大幅提升其行动能力。"
        },
        {
            "Disable All Doors",
            "禁用所有门"
        },
        {
            "Doors are hard, just turn them all off. Only targets doors that can be open/closed normally.",
            "门太难搞了，干脆全部关掉。仅作用于可正常开关的门。"
        },
        {
            "SAIN Extract Behavior",
            "SAIN撤离行为"
        },
        {
            "REQUIRES GAME RESTART. Disable vanilla bot extract behavior and use SAIN decision making instead.",
            "需要重启游戏。禁用原版机器人撤离行为，改用SAIN的决策逻辑。"
        },
        {
            "Bots Use Grenades",
            "机器人使用手雷"
        },
        {
            "Bots Use Grenades Vs Other Bots",
            "机器人对其他机器人使用手雷"
        },
        {
            "Bots are not as careful with grenades as players, this will prevent accidental deaths fighting other bots.",
            "机器人在使用手雷时不像玩家那样谨慎，此项可避免它们与其他机器人交战时被误炸致死。"
        },
        {
            "Bot Inertia",
            "机器人惯性"
        },
        {
            "Bots are properly affected by the weight of their equipment and loot for inertia. Requires raid restart for existing bots, as it applies on bot creation.",
            "机器人会正确受到装备与战利品重量的惯性影响。该设置仅在机器人创建时生效，对局中已有的机器人需重开战局才能应用。"
        },
        {
            "Vanilla Bot Behavior Settings",
            "原版机器人行为设置"
        },
        {
            "If a option here is set to ON, they will use vanilla logic, ALL Features will be disabled for these types, including personality, recoil, difficulty, and behavior.",
            "若此处的某项设为开启，对应类型将使用原版逻辑，其所有功能都会被禁用，包括性格、后坐力、难度和行为。"
        },
        {
            "Looting Bots Integration",
            "Looting Bots集成"
        },
        {
            "Modify settings that relate to Looting Bots. Requires Looting Bots to be installed.",
            "修改与Looting Bots相关的设置。需要安装Looting Bots。"
        },
        {
            "Random Cheater AI",
            "随机作弊者AI"
        },
        {
            "Emulate the real Live-Like experience! 1% of bots will be a cheater. They will move faster than they should, have 0 recoil, and perfect aim, always shoot full auto at any range if their weapon supports it, and always fire as fast as possible if they have a semi-auto weapon.",
            "还原真实的线上体验！1%的机器人会成为作弊者。它们移动速度超出正常水平、后坐力为0、瞄准完美，只要武器支持就无视距离全自动射击，使用半自动武器时则总是以最快速度开火。"
        },
        {
            "Random Speed Hacker Chance",
            "随机加速挂几率"
        },
        {
            "If for some reason you enabled random cheaters, this is the chance they will be assigned as one.",
            "如果你不知为何启用了随机作弊者，此项为机器人被指定为作弊者的几率。"
        },
        {
            "Enable Khorovod layers for PMCs",
            "为PMC启用Khorovod层"
        },
        {
            "Requires restart. Allows the pmc's to get assigned a khorovod brain similar to the ones on scavs, will make PMC's rush you at the generator",
            "需要重启。允许PMC获得与Scav类似的Khorovod大脑，会让PMC在发电机处向你冲锋。"
        },
        {
            "Requires Restart. Dont touch unless you know what this is",
            "需要重启。不了解这是什么就不要动。"
        },
        {
            "Bot Extraction From Loot",
            "机器人因战利品撤离"
        },
        {
            "Min Loot Val PMC",
            "PMC最低战利品价值"
        },
        {
            "Min Loot Val SCAV",
            "Scav最低战利品价值"
        },
        {
            "Min Loot Val Other",
            "其他最低战利品价值"
        },
        {
            "Min Loot Val Exception",
            "最低战利品价值例外"
        },
        {
            "If a bot's loot value is greater than or equal to this, they will extract even with space available in their inventory.",
            "若机器人的战利品价值大于或等于此值，即使背包仍有空间，它们也会撤离。"
        },
        {
            "Performance Mode",
            "性能模式"
        },
        {
            "Limits the cover finder to maximize performance. Reduces frequency on some raycasts. ",
            "限制掩体搜索以最大化性能，并降低部分射线检测的频率。"
        },
        {
            "If your PC is CPU limited, this might let you regain some frames lost while using SAIN. Can cause bots to take too long to find cover to go to.",
            "如果你的电脑受CPU限制，此项可能帮你找回一些使用SAIN后损失的帧数。但可能导致机器人寻找掩体耗时过长。"
        },
        {
            "Vanilla Scavs",
            "原版Scav"
        },
        {
            "REQUIRES RESTART OF GAME. Non Player-Scavs will have vanilla ai behavior. Disabling sain for player scavs is not currently possible.",
            "需要重启游戏。非玩家Scav将使用原版AI行为。目前无法为玩家Scav禁用SAIN。"
        },
        {
            "Vanilla Bosses",
            "原版Boss"
        },
        {
            "Vanilla Boss Followers",
            "原版Boss护卫"
        },
        {
            "Vanilla Goons",
            "原版Goons"
        },
        {
            "REQUIRES RESTART OF GAME. Goons will have vanilla behavior. This disables custom personality edits specially made for the goons and I will be very sad.",
            "需要重启游戏。Goons将使用原版行为。这会禁用专为Goons定制的性格调整，我会非常难过。"
        },
        {
            "Vanilla Bloodhounds",
            "原版Bloodhound"
        },
        {
            "REQUIRES RESTART OF GAME",
            "需要重启游戏"
        },
        {
            "Vanilla Rogues",
            "原版 Rogue"
        },
        {
            "Vanilla Raiders",
            "原版 Raider"
        },
        {
            "Vanilla Cultists",
            "原版邪教徒"
        },
        {
            "Vanilla Labyrinth Bots",
            "原版迷宫机器人"
        },
        {
            "REQUIRES RESTART OF GAME. Shadow of Tagilla, Vengeful Killa, and their followers on Labyrinth will have vanilla behavior.",
            "需重启游戏。Shadow of Tagilla、Vengeful Killa 及其在迷宫中的追随者将使用原版行为。"
        },
        {
            "Vanilla Special Bots",
            "原版特殊机器人"
        },
        {
            "Flash Duration Multiplier",
            "闪光持续时间倍率"
        },
        {
            "Scales how long bots stay blinded",
            "调整机器人被闪光致盲的持续时间"
        },
        {
            "Night Vision Multiplier",
            "夜视仪倍率"
        },
        {
            "Extra blindness for bots wearing night vision when the flash goes off.",
            "闪光触发时，佩戴夜视仪的机器人会额外致盲。"
        },
        {
            "Max Flash Duration",
            "闪光最长持续时间"
        },
        {
            "Ceiling in seconds, applied after every other multiplier. Night vision is doubled",
            "以秒为单位的上限，在所有其他倍率之后生效。佩戴夜视仪时翻倍"
        },
        {
            "Look Around Chance",
            "环顾概率"
        },
        {
            "Chance a flashed bot spends the next moment looking around at nothing in particular.",
            "被闪光的机器人接下来四处张望、不针对特定目标的概率。"
        },
        {
            "Track Chance",
            "追踪概率"
        },
        {
            "Chance a flashed bot turns toward where it last saw its enemy without firing.",
            "被闪光的机器人转向最后看到敌人的方向但不开火的概率。"
        },
        {
            "Panic Movement Speed",
            "慌乱移动速度"
        },
        {
            "How fast a flashed bot staggers around.",
            "被闪光的机器人踉跄移动的速度。"
        },
        {
            "Panic Movement",
            "慌乱移动"
        },
        {
            "Flashed bots stagger around instead of standing still.",
            "被闪光的机器人会踉跄走动，而不是原地不动。"
        },
        {
            "Blind Fire Delay",
            "盲射延迟"
        },
        {
            "Seconds before a flashed bot will fire at where it last saw its enemy.",
            "被闪光的机器人向最后看到敌人的方向开火前的秒数。"
        },
        {
            "Partial Recovery Point",
            "部分恢复点"
        },
        {
            "The blinding effect is applied twice, and the second copy expires at this fraction of the duration. Bots shoot noticeably straighter past this point.",
            "致盲效果会施加两次，第二层在持续时间的此比例处失效。过了这个点，机器人射击会明显更准。"
        },
        {
            "Flashlight Enable Visibility Ratio",
            "开启手电筒的能见度比例"
        },
        {
            "If visibility is lower than or equal to this ratio, bots will want to turn on their flashlight to see.",
            "能见度低于或等于此比例时，机器人会想打开手电筒照明。"
        },
        {
            "Flashlight Disable Visibility Ratio",
            "关闭手电筒的能见度比例"
        },
        {
            "If a bot has a flashlight enabled to see at night, and visibility is higher than or equal to this ratio, bots will want to turn off their flashlight.",
            "夜间机器人打开手电筒照明后，若能见度高于或等于此比例，会想关闭手电筒。"
        },
        {
            "Nightvision Enable Visibility Ratio",
            "开启夜视仪的能见度比例"
        },
        {
            "If visibility is lower than or equal to this ratio, bots will want to turn on their night vision goggles to see.",
            "能见度低于或等于此比例时，机器人会想打开夜视仪照明。"
        },
        {
            "Nightvision Disable Visibility Ratio",
            "关闭夜视仪的能见度比例"
        },
        {
            "If a bot has night vision goggles enabled to see at night, and visibility is higher than or equal to this ratio, bots will want to turn off their NVGs.",
            "夜间机器人打开夜视仪后，若能见度高于或等于此比例，会想关闭 NVG。"
        },
        {
            "Core Settings",
            "核心设置"
        },
        {
            "Vision Speed Settings",
            "视觉速度设置"
        },
        {
            "Vision Distance Settings",
            "视觉距离设置"
        },
        {
            "Time Settings",
            "时间设置"
        },
        {
            "Flashlights and NVGs Settings",
            "手电筒与 NVG 设置"
        },
        {
            "Flashbang Settings",
            "闪光弹设置"
        },
        {
            "Extra",
            "额外"
        },
        {
            "Not Looking At Bot Settings",
            "未注视机器人时的设置"
        },
        {
            "Bot Reaction and Accuracy Changes Toggle - Experimental",
            "机器人反应与精准度变化开关 - 实验性"
        },
        {
            "Unseen Bot",
            "未被注视的机器人"
        },
        {
            "Experimental: Bots will have slightly reduced accuracy and vision speed if you are not looking in their direction. ",
            "实验性：如果你没有朝机器人所在方向看，机器人的精准度和视觉速度会略微降低。"
        },
        {
            "So if a bot notices and starts shooting you while your back is turned, they will be less accurate and notice you more slowly.",
            "因此，若机器人趁你背对时发现你并向你开火，其精准度更低，发现你的速度也更慢。"
        },
        {
            "Bot Reaction and Accuracy Changes Time Limit",
            "机器人反应与精准度变化时限"
        },
        {
            "The Maximum Time that a bot can be shooting at you before the reduced spread not longer has an affect. ",
            "机器人向你射击的最长时间，超过后降低散布的效果将失效。"
        },
        {
            "So if a bot is shooting at you from the back for X seconds, after that time it will no longer reduce their accuracy to give you a better chance to react.",
            "因此，若机器人从背后向你射击 X 秒，此后就不再降低其精准度——原本的降低是为了给你更好的反应机会。"
        },
        {
            "Bot Reaction and Accuracy Changes Angle",
            "机器人反应与精准度变化角度"
        },
        {
            "The Maximum Angle for the player to be considered looking at a bot.",
            "玩家被视为正在注视机器人的最大角度。"
        },
        {
            "Bot Reaction Multiplier When Out of Sight",
            "机器人视野外时的反应倍率"
        },
        {
            "How much to multiply bot vision speed by if you aren't looking at them when they notice you. Higher = More time before reacting.",
            "当你未注视机器人时，其发现你时的视觉速度所乘的倍数。数值越高，反应所需时间越长。"
        },
        {
            "Bot Accuracy and Spread Increase When Out of Sight",
            "机器人视野外时的精准度与散布增加"
        },
        {
            "How much additional random Spread to add to a bot's aim if the player isn't look at them.",
            "玩家未注视机器人时，为其瞄准额外附加的随机散布量。"
        },
        {
            " 1 means it will randomize in a 1 meter sphere around their original aim target in addition to existing random spread.",
            "为 1 时，除现有随机散布外，还会在原瞄准点周围 1 米球形范围内随机偏移。"
        },
        {
            " Higher = More spread and less accurate bots.",
            "数值越高，散布越大、机器人越不准。"
        },
        {
            "Night-time Vision Effects",
            "夜间视觉影响"
        },
        {
            "By how much to lower visible distance at nighttime. ",
            "夜间可视距离的降低幅度。"
        },
        {
            "at the default value of 0.2, bots will see 0.2 times as far, or 20% of ",
            "默认值 0.2 时，机器人只能看到 0.2 倍远，即夜间基础视距的"
        },
        {
            "their base vision distance at night-time.",
            "20%。"
        },
        {
            "Snow Vision Distance Multiplier",
            "雪天视觉距离倍率"
        },
        {
            "By how much to lower visible distance at nighttime in the snow. ",
            "夜间下雪时可视距离的降低幅度。"
        },
        {
            "Vision Speed Max Multiplier",
            "视觉速度最大倍率"
        },
        {
            "Bot Vision Speed will be reduced up to X times longer to spot enemies, depending on visibility and time of day. Higher = Worse Vision.",
            "根据能见度和时段，机器人发现敌人所需时间最多延长至 X 倍。数值越高，视觉越差。"
        },
        {
            "Minimum Multiplier",
            "最小倍率"
        },
        {
            "Weather Vision Effects",
            "天气视觉影响"
        },
        {
            "Weather will not multiply vision distance any lower than this number.",
            "天气对视距的倍率不会低于此数值。"
        },
        {
            "Minimum Weather Vision Distance",
            "天气视觉距离下限"
        },
        {
            "Base Vision distance - after weather calculation and before time effects - will not go lower than this.",
            "基础视觉距离在天气计算之后、时段影响之前，不会低于此值。"
        },
        {
            "Minimum Fog Effect",
            "雾效影响下限"
        },
        {
            "Weather Vision Effects - Fog",
            "天气视觉影响 - 雾"
        },
        {
            "Fog will scale between X and 1 depending on fog intensity. Reducing vision distance by X amount. 0.4 = up to 40% vision distance from fog alone.",
            "雾会依浓度在 X 与 1 之间缩放，从而降低视距。0.4 = 仅雾效就能让视距降至 40%。"
        },
        {
            "Very Light Rain Threshold",
            "极小雨阈值"
        },
        {
            "Weather Vision Effects - Rain",
            "天气视觉影响 - 雨"
        },
        {
            "Rain scales between 0 and 1. If the value is equal to or less than this number. It will use the multiplier below.",
            "雨量在 0 到 1 之间。若数值等于或小于此值，将使用下方的倍率。"
        },
        {
            "Very Light Rain Scaling Coef",
            "极小雨缩放系数"
        },
        {
            "Light Rain Threshold",
            "小雨阈值"
        },
        {
            "Light Rain Scaling Coef",
            "小雨缩放系数"
        },
        {
            "Normal Rain Threshold",
            "中雨阈值"
        },
        {
            "Normal Rain Scaling Coef",
            "中雨缩放系数"
        },
        {
            "Heavy Rain Threshold",
            "大雨阈值"
        },
        {
            "Heavy Rain Scaling Coef",
            "大雨缩放系数"
        },
        {
            "Very Heavy Rain Scaling Coef",
            "暴雨缩放系数"
        },
        {
            "If rain is above Heavy Rain Threshold use this scaling coef.",
            "若雨量高于大雨阈值，则使用此缩放系数。"
        },
        {
            "Clear Skies Threshold",
            "晴朗阈值"
        },
        {
            "Weather Vision Effects - Clouds",
            "天气视觉影响 - 云"
        },
        {
            "Cloudiness scales 0 to 1. If cloudiness is below X value, have no effect on vision.",
            "云量在 0 到 1 之间。若云量低于此值，则对视觉无影响。"
        },
        {
            "Cloudy Threshold",
            "多云阈值"
        },
        {
            "Cloudiness scales 0 to 1. If cloudiness is below X value, it is considered cloudy, if above, it is considered overcast or heavily clouded.",
            "云量在 0 到 1 之间。低于此值视为多云，高于此值视为阴天或浓云。"
        },
        {
            "Cloudy Scaling Coef",
            "多云缩放系数"
        },
        {
            "How much to reduce vision by if it is cloudy.",
            "多云时的视觉降低幅度。"
        },
        {
            "Very Cloudy Scaling Coef",
            "浓云缩放系数"
        },
        {
            "How much to reduce vision by if it is very cloudy.",
            "浓云时的视觉降低幅度。"
        },
        {
            "Dawn Start Hour",
            "黎明起始小时"
        },
        {
            "Dawn End Hour",
            "黎明结束小时"
        },
        {
            "Dusk Start Hour",
            "黄昏开始时刻"
        },
        {
            "Dusk End Hour",
            "黄昏结束时刻"
        },
        {
            "Movement Vision Distance Modifier",
            "移动视觉距离倍率"
        },
        {
            "Bots will see moving players this much further. ",
            "机器人发现移动玩家的距离会按此倍数增加。"
        },
        {
            "Higher is further distance, so 1.75 would result in bots seeing enemies 1.75x further at max player speed. ",
            "数值越高距离越远，例如 1.75 表示玩家以最高速度移动时，机器人发现敌人的距离变为 1.75 倍。"
        },
        {
            "Scales with player velocity.",
            "随玩家移动速度缩放。"
        },
        {
            "High Elevation Angle Range",
            "高海拔角度范围"
        },
        {
            "The difference of angle from the bot's vision to the enemy to fully apply HighElevationVisionModifier. ",
            "从机器人视线到敌人的角度差达到此值时，完全生效高海拔视觉倍率。"
        },
        {
            "The modifier is smoothed out by the angle differnce. So 1.2x at +60 degree, 1.1x at +30 degrees...and so on.",
            "该倍率会随角度差平滑过渡，例如 +60 度时为 1.2 倍，+30 度时为 1.1 倍，以此类推。"
        },
        {
            "High Elevation Vision Modifier",
            "高海拔视觉倍率"
        },
        {
            "Bots will see players this much slower when the enemy's altitude is higher than the bot when the vision angle difference is equal or greater than HighElevationMaxAngle. ",
            "当敌人海拔高于机器人，且视线角度差大于或等于 HighElevationMaxAngle 时，机器人发现玩家的速度会按此倍数变慢。"
        },
        {
            "Higher is slower speed, so 1.2 would result in bots taking 20% longer to spot an enemy",
            "数值越高速度越慢，例如 1.2 表示机器人发现敌人所需时间延长 20%"
        },
        {
            "Low Elevation Angle Range",
            "低海拔角度范围"
        },
        {
            "The difference of angle from the bot's vision to the enemy to fully apply LowElevationVisionModifier. ",
            "从机器人视线到敌人的角度差达到此值时，完全生效低海拔视觉倍率。"
        },
        {
            "The modifier is smoothed out by the angle differnce. So 0.85x at -30 degree, 0.95x at -10 degrees...and so on.",
            "该倍率会随角度差平滑过渡，例如 -30 度时为 0.85 倍，-10 度时为 0.95 倍，以此类推。"
        },
        {
            "Low Elevation Vision Modifier",
            "低海拔视觉倍率"
        },
        {
            "Bots will see sprinting players this much slower when the enemy's altitude is lower than the bot when the vision angle difference is equal or greater than LowElevationMaxAngle. ",
            "当敌人海拔低于机器人，且视线角度差大于或等于 LowElevationMaxAngle 时，机器人发现冲刺玩家的速度会按此倍数变慢。"
        },
        {
            "Higher is slower speed, so 0.85 would result in bots taking 15% shorter to spot an enemy",
            "数值越高速度越慢，例如 0.85 表示机器人发现敌人所需时间缩短 15%"
        },
        {
            "Movement Vision Modifier",
            "移动视觉倍率"
        },
        {
            "Bots will see moving players this much faster, at any range.",
            "在任何距离下，机器人发现移动玩家的速度都会按此倍数变快。"
        },
        {
            "Higher is slower speed, so 0.66 would result in bots spotting an enemy who is moving 0.66x faster. So if they usually would take 10 seconds to spot someone, it would instead take around 6.6 seconds.",
            "数值越高速度越慢，例如 0.66 表示机器人发现移动敌人的速度变为 0.66 倍。也就是说，原本需要 10 秒发现目标，现在只需约 6.6 秒。"
        },
        {
            "Personality Enabled",
            "启用性格"
        },
        {
            "Enables or Disables this Personality, if a All Chads, All GigaChads, or AllRats is enabled in global settings, this value is ignored",
            "启用或禁用此性格。若全局设置中启用了 All Chads、All GigaChads 或 AllRats，此值将被忽略"
        },
        {
            "Can Be Randomly Assigned",
            "可被随机分配"
        },
        {
            "A percentage chance that this personality can be applied to any bot, regardless of bot stats, power, player level, or anything else.",
            "此性格被分配给任意机器人的百分比概率，不受机器人属性、战力、玩家等级等任何条件影响。"
        },
        {
            "Randomly Assigned Chance",
            "随机分配概率"
        },
        {
            "If personality can be randomly assigned, this is the chance that will happen",
            "若该性格可被随机分配，这就是实际发生的概率"
        },
        {
            "Minimum Level",
            "最低等级"
        },
        {
            "The min level that a bot can be to be eligible for this personality.",
            "机器人有资格获得此性格的最低等级。"
        },
        {
            "Max Level",
            "最高等级"
        },
        {
            "The max level that a bot can be to be eligible for this personality.",
            "机器人有资格获得此性格的最高等级。"
        },
        {
            "Power Level Scale Start",
            "战力等级缩放起点"
        },
        {
            "When a bot is at, or above this power level, they will start to have a chance to be assigned this personality.",
            "当机器人达到或超过此战力等级时，开始有概率被分配此性格。"
        },
        {
            "Power Level Scale End",
            "战力等级缩放终点"
        },
        {
            "When a bot is at, or above this power level, they will have the full percentage chance to be assigned this personality.",
            "当机器人达到或超过此战力等级时，将获得完整的分配概率。"
        },
        {
            "The lower the power level, the higher the chance",
            "战力等级越低，概率越高"
        },
        {
            "Power Level Minimum",
            "最低战力等级"
        },
        {
            "Minimum Power level for a bot to use this personality.",
            "机器人使用此性格的最低战力等级。"
        },
        {
            "Power Level Maximum",
            "最高战力等级"
        },
        {
            "Maximum Power level for a bot to use this personality.",
            "机器人使用此性格的最高战力等级。"
        },
        {
            "Maximum Chance If Meets Requirements",
            "满足条件时的最高概率"
        },
        {
            "If the bot meets all conditions for this personality, this is the chance the personality will actually be assigned. ",
            "若机器人满足此性格的所有条件，这就是该性格实际被分配的概率。"
        },
        {
            "The percentage chance to be assigned scales if a bots power level falls between Power Level Scale Start and Power Level Scale End, ",
            "若机器人战力等级介于战力等级缩放起点与终点之间，分配概率会按比例缩放，"
        },
        {
            "so if they fall right in the middle, and the value here is 60%, they will have a 30% chance to be assigned.",
            "因此若正好处于中间位置，而此处数值为 60%，则实际分配概率为 30%。"
        },
        {
            "Allowed Bot Types",
            "允许的机器人类型"
        },
        {
            "Linearly increases or decreases search time and hold ground time.",
            "线性增加或减少搜索时间与固守时间。"
        },
        {
            "Kick Open All Possible Doors",
            "踢开所有能踢开的门"
        },
        {
            "If this personality has an enemy, always kick open doors if they can.",
            "若此性格有敌人，只要能踢开就总是踢门。"
        },
        {
            "Dogfight - Path Distance - Start",
            "缠斗 - 路径距离 - 起点"
        },
        {
            "Dogfight - Time Since Seen - End",
            "缠斗 - 发现后经过时间 - 终点"
        },
        {
            "Dogfight - Path Distance - End",
            "缠斗 - 路径距离 - 终点"
        },
        {
            "Hold Ground Base Time",
            "固守基础时间"
        },
        {
            "The base time, before modifiers, that a personality will stand their ground and shoot or return fire on an enemy if caught out of cover.",
            "在受到各种修正之前的基础时间，即此性格在失去掩体时原地站立并向敌人射击或还击的时长。"
        },
        {
            "Suppression Distance - Close",
            "压制距离 - 近"
        },
        {
            "If a enemy's visible path point is closer than this to where a bot thinks they are, they can suppress without checking the angle",
            "若敌人的可见路径点与机器人所认为的位置距离小于此值，机器人无需检查角度即可进行压制"
        },
        {
            "Suppression Distance - Far",
            "压制距离 - 远"
        },
        {
            "If a enemy's visible path point is closer than this to where a bot thinks they are, they can suppress after checking the angle.",
            "若敌人的可见路径点与机器人所认为的位置距离小于此值，机器人检查角度后可进行压制。"
        },
        {
            "Suppression Distance - Far Angle",
            "压制距离 - 远角度"
        },
        {
            "If the horizontal angle from an enemy visible path point to where their last known position is less than this, they can suppress.",
            "若从敌人可见路径点到其最后已知位置的水平角度小于此值，机器人即可进行压制。"
        },
        {
            "Enemy Sniper Reaction",
            "敌人狙击手反应"
        },
        {
            "If a bot thinks it is under fire from a sniper, they will always want to sprint to cover.",
            "若机器人认为自己正被狙击手射击，将总是想冲刺到掩体。"
        },
        {
            "Always Sprint",
            "始终冲刺"
        },
        {
            "If a bot thinks it is under fire from a sniper, they will always sprint while seeking that sniper.",
            "若机器人认为自己正被狙击手射击，在搜寻该狙击手时会始终冲刺。"
        },
        {
            "Distance Under Fire",
            "受击距离"
        },
        {
            "If an enemy is further than this distance, in meters. They will be considered a sniper if shooting at a bot.",
            "若敌人在此距离（米）之外向机器人射击，将被视为狙击手。"
        },
        {
            "Distance Enemy is no longer Sniper",
            "敌人不再视为狙击手的距离"
        },
        {
            "If an enemy is closer than this distance, in meters. They will no longer be considered a sniper if they previously were.",
            "若敌人在此距离（米）以内，即使此前被视为狙击手，也将不再被视为狙击手。"
        },
        {
            "Can Rush Healing/Reloading/Grenade-Pulling Enemies",
            "可突进正在治疗/换弹/拔雷的敌人"
        },
        {
            "Can Jump Push",
            "可跳跃突进"
        },
        {
            "Can this personality jump when rushing an enemy?",
            "此性格在突进敌人时是否可以跳跃？"
        },
        {
            "Jump Push Chance",
            "跳跃突进概率"
        },
        {
            "If a bot can Jump Push, this is the chance they will actually do it.",
            "若机器人可以跳跃突进，这就是实际执行的概率。"
        },
        {
            "Can Bunny Hop during Jump Push",
            "跳跃突进时可连跳"
        },
        {
            "Can this bot hit a clip on you?",
            "这个机器人能对你秀出一段连跳集锦吗？"
        },
        {
            "Bunny Hop Chance",
            "连跳概率"
        },
        {
            "If a bot can bunny hop, this is the chance they will actually do it.",
            "若机器人可以连跳，这就是实际执行的概率。"
        },
        {
            "Heard From Peace Behavior",
            "和平状态听到声响时的行为"
        },
        {
            "When a bot hears an enemy, and was previously at peace, so had no enemy and was in patrol, what is their reaction?",
            "当机器人听到敌人，且此前处于和平状态（没有敌人、正在巡逻）时，会如何反应？"
        },
        {
            "Will this personality type hear and chase after distant gunshots if they aren't fired at them?",
            "此性格类型在未被射击的情况下，是否会听到远处枪声并追过去？"
        },
        {
            "If a sound is further than this, it will be considered chasing a gunshot sound, and will be ignored if WillChaseDistantGunshots is set to off, unless the gunshot is fired at them.",
            "若声音距离超过此值，将被视为追击枪声；若 WillChaseDistantGunshots 已关闭，则会被忽略，除非枪声是朝其射击的。"
        },
        {
            "Start Search Base Time",
            "开始搜索基础时间"
        },
        {
            "The base time, before modifiers, that a personality will usually start searching for their enemy.",
            "在受到各种修正之前的基础时间，即此性格通常开始搜索其敌人的时间。"
        },
        {
            "Search Wait Multiplier",
            "搜索等待倍率"
        },
        {
            "Linearly increases or decreases the time a bot pauses while searching.",
            "线性增加或减少机器人在搜索过程中停顿的时间。"
        },
        {
            "Can Yell Taunts",
            "可喊话嘲讽"
        },
        {
            "Hey you...yeah YOU! FUCK YOU! You heard?",
            "嘿，你……对，就是你！去你的！听到了吗？"
        },
        {
            "Can Yell Taunts Frequently",
            "可频繁喊话嘲讽"
        },
        {
            "HEY COCKSUCKAAAA",
            "嘿，你个混账东西！"
        },
        {
            "Can Yell Taunts Constantly",
            "可不停喊话嘲讽"
        },
        {
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
            "啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊"
        },
        {
            "Will this personality yell back at enemies taunting them",
            "此性格是否会回应嘲讽它的敌人并喊话"
        },
        {
            "easy",
            "简单"
        },
        {
            "normal",
            "普通"
        },
        {
            "hard",
            "困难"
        },
        {
            "impossible",
            "不可能"
        },
        {
            "A Bot's weapon's recoil will get divided by this to calculate how much to rotate their view on each shot, so, for example, with a baseline of 100 - if a bot has 250 total recoil, that number gets divided by this to produce 2.5. Higher = Less recoil for bots. This is basically an average recoil of all possible weapons.",
            "机器人武器的后坐力将除以此值，以计算每次射击时其视角旋转的幅度。例如，基准值为 100 时——如果机器人的总后坐力为 250，该数值会被除以此值，得到 2.5。数值越高，机器人的后坐力越小。这基本上是所有可能武器的平均后坐力。"
        },
        {
            "Bots pick which body part to shoot by weight from the parts they can actually hit. For the old always-center-mass behaviour, set the head, arm and leg weights to 0. Disable to fall back to vanilla behaviour",
            "机器人根据权重，从实际可命中的部位中选择要射击的身体部位。若想沿用旧的“始终瞄准中心”行为，请将头部、手臂和腿部权重设为 0。禁用后回退到原版行为"
        },
        {
            "Bots will see moving players this much faster, at any range.Higher is slower speed, so 0.66 would result in bots spotting an enemy who is moving 0.66x faster. So if they usually would take 10 seconds to spot someone, it would instead take around 6.6 seconds.",
            "在任何距离下，机器人发现移动玩家的速度都会按此倍数变快。数值越高速度越慢，例如 0.66 表示机器人发现移动敌人的速度变为 0.66 倍。也就是说，原本需要 10 秒发现目标，现在只需约 6.6 秒。"
        },
        {
            "Bots will see moving players this much further. Higher is further distance, so 1.75 would result in bots seeing enemies 1.75x further at max player speed. Scales with player velocity.",
            "机器人发现移动玩家的距离会按此倍数增加。数值越高距离越远，例如 1.75 表示玩家以最高速度移动时，机器人发现敌人的距离变为 1.75 倍。随玩家移动速度缩放。"
        },
        {
            "Bots will see players this much slower when the enemy's altitude is higher than the bot when the vision angle difference is equal or greater than HighElevationMaxAngle. Higher is slower speed, so 1.2 would result in bots taking 20% longer to spot an enemy",
            "当敌人海拔高于机器人，且视线角度差大于或等于 HighElevationMaxAngle 时，机器人发现玩家的速度会按此倍数变慢。数值越高速度越慢，例如 1.2 表示机器人发现敌人所需时间延长 20%"
        },
        {
            "Bots will see sprinting players this much slower when the enemy's altitude is lower than the bot when the vision angle difference is equal or greater than LowElevationMaxAngle. Higher is slower speed, so 0.85 would result in bots taking 15% shorter to spot an enemy",
            "当敌人海拔低于机器人，且视线角度差大于或等于 LowElevationMaxAngle 时，机器人发现冲刺玩家的速度会按此倍数变慢。数值越高速度越慢，例如 0.85 表示机器人发现敌人所需时间缩短 15%"
        },
        {
            "By how much to lower visible distance at nighttime in the snow. at the default value of 0.2, bots will see 0.2 times as far, or 20% of their base vision distance at night-time.",
            "夜间下雪时可视距离的降低幅度。默认值 0.2 时，机器人只能看到 0.2 倍远，即夜间基础视距的20%。"
        },
        {
            "By how much to lower visible distance at nighttime. at the default value of 0.2, bots will see 0.2 times as far, or 20% of their base vision distance at night-time.",
            "夜间可视距离的降低幅度。默认值 0.2 时，机器人只能看到 0.2 倍远，即夜间基础视距的20%。"
        },
        {
            "Experimental: Bots will have slightly reduced accuracy and vision speed if you are not looking in their direction. So if a bot notices and starts shooting you while your back is turned, they will be less accurate and notice you more slowly.",
            "实验性：如果你没有朝机器人所在方向看，机器人的精准度和视觉速度会略微降低。因此，若机器人趁你背对时发现你并向你开火，其精准度更低，发现你的速度也更慢。"
        },
        {
            "HIGHER is BETTER. This is the time to wait inbetween shots for every meter.the number is divided by the distance to their target, to get a wait period between shots.For Example. With a setting of 100: if a target is 50m away, they will wait 0.5 sec between shots because 50 / 100 is 0.5.This number is later modified by the Shootability multiplier, to get a final fire-rate that gets sent to a bot.",
            "数值越高越好。这是每米距离在两次射击之间的等待时间。该数值会除以与目标的距离，得出两次射击之间的等待时间。例如，设置为 100 时：如果目标在 50m 外，两次射击之间会等待 0.5 秒，因为 50 / 100 = 0.5。随后该数值会被射击性倍率修正，得出最终发送给机器人的射速。"
        },
        {
            "Higher = Less affected by suppression. A Value of 0 means No Resistance. A Value of 1 means Full Resistance. The final resistance number is the mid-point between their personality and bot type resistance. So a value of 0.25 for personality and a value of 0.75 for bot type would result in 0.5",
            "越高受压制影响越小。0 表示无抗性。1 表示完全抗性。最终抗性取性格抗性与机器人类型抗性的中间值。例如性格为 0.25、机器人类型为 0.75，最终结果为 0.5"
        },
        {
            "How much additional random Spread to add to a bot's aim if the player isn't look at them. 1 means it will randomize in a 1 meter sphere around their original aim target in addition to existing random spread. Higher = More spread and less accurate bots.",
            "玩家未注视机器人时，为其瞄准额外附加的随机散布量。为 1 时，除现有随机散布外，还会在原瞄准点周围 1 米球形范围内随机偏移。数值越高，散布越大、机器人越不准。"
        },
        {
            "If Realism Mod is loaded, use this AC Power value. For each AC level, add X to a bot's power level. So if they have level 4 armor, add this value 4 times.",
            "若加载了 Realism Mod，则使用此 AC 战力值。每级 AC（护甲等级）为机器人战力增加 X 点。例如机器人穿 4 级护甲，则此数值加 4 次。"
        },
        {
            "If the bot meets all conditions for this personality, this is the chance the personality will actually be assigned. The percentage chance to be assigned scales if a bots power level falls between Power Level Scale Start and Power Level Scale End, so if they fall right in the middle, and the value here is 60%, they will have a 30% chance to be assigned.",
            "若机器人满足此性格的所有条件，这就是该性格实际被分配的概率。若机器人战力等级介于战力等级缩放起点与终点之间，分配概率会按比例缩放，因此若正好处于中间位置，而此处数值为 60%，则实际分配概率为 30%。"
        },
        {
            "If the distance to a sound is less and or equal to this number, a bot will perfectly predict the source position, so no randomization or dispersion at all. A value of 0 will disable this.",
            "与声音的距离小于或等于该数值时，机器人会完美判断声源位置，完全没有随机化或散布。设为 0 将禁用该功能。"
        },
        {
            "Instead of randomly calculating an angle to affect bot aim. Use the direction they were hit from, so if they are shot in the right arm, their aim gets kicked to the right. If they are shot in the leg, kick their aim down towards their leg.",
            "不再随机计算影响机器人瞄准的角度。改用中弹方向：若右臂中弹，瞄准会向右偏。若腿部中弹，瞄准会向下偏向腿部。"
        },
        {
            "Limits the cover finder to maximize performance. Reduces frequency on some raycasts. If your PC is CPU limited, this might let you regain some frames lost while using SAIN. Can cause bots to take too long to find cover to go to.",
            "限制掩体搜索以最大化性能，并降低部分射线检测的频率。如果你的电脑受CPU限制，此项可能帮你找回一些使用SAIN后损失的帧数。但可能导致机器人寻找掩体耗时过长。"
        },
        {
            "Lower is BETTER. How Shootable this ammo type is, affects semi auto firerate and full auto burst length.Value is scaled but roughly gives a plus or minus 20% to firerate depending on the value set here.For Example. 9x19 will shoot about 20% faster fire-rate on semi-auto at 50 meters, and fire 20% longer bursts when on full auto",
            "数值越低越好。该弹药类型的射击性，影响半自动射速和全自动点射时长。数值经过缩放，但大致会依据此处设置的数值对射速产生正负 20% 的影响。例如，9x19 在 50 米处半自动射击时，射速约快 20%，全自动时点射时长增加 20%"
        },
        {
            "Lower is BETTER. How Shootable this weapon type is, affects semi auto firerate and full auto burst length.Value is scaled but roughly gives a plus or minus 20% to firerate depending on the value set here.For Example. SMGs will shoot about 20% faster fire-rate on semi-auto at 50 meters, and fire 20% longer bursts when on full auto",
            "数值越低越好。该武器类型的射击性，影响半自动射速和全自动点射时长。数值经过缩放，但大致会依据此处设置的数值对射速产生正负 20% 的影响。例如，冲锋枪在 50 米处半自动射击时，射速约快 20%，全自动时点射时长增加 20%"
        },
        {
            "Max distance a bot can react faster for Faster CQB Reactions. Scales with distance.Example: If Max distance is set to 20 meters, and an enemy is 10 meters away. they will react 2x as fast as usual, or if an enemy is 15 meters away, they will react 1.5x as fast as usual. If the enemy is at 20 meters or further, nothing will happen.",
            "近身战反应加速生效的最大距离，效果随距离变化。例如：最大距离设为 20 米，敌人位于 10 米处，机器人的反应速度将是平时的 2 倍，如果敌人位于 15 米处，反应速度则为平时的 1.5 倍。如果敌人在 20 米或更远，则不会有任何加速。"
        },
        {
            "Modifies how long bots shoot a burst during full auto fire. Higher = longer full auto time. 1.5 = 1.5x longer bursts",
            "调整机器人在全自动射击时单次点射的持续时间。越高全自动射击时间越长。1.5 表示点射时长为 1.5 倍"
        },
        {
            "Modifies how much recoil a bot gets from firing their weapon. Higher = more recoil, more kick. 1.5 = 1.5x more recoil",
            "调整机器人开火时受到的后坐力大小。越高后坐力越大、枪口跳动越明显。1.5 表示后坐力为 1.5 倍"
        },
        {
            "Modifies the time a bot waits between semiauto fire. Higher = faster firerate. 1.5 = 1.5x more shots per second",
            "调整机器人半自动射击之间的间隔时间。越高射速越快。1.5 表示每秒射击次数为 1.5 倍"
        },
        {
            "The Maximum Range that a bot can hear footsteps, sprinting, and jumping, turning, gear sounds, and any movement related sounds, in meters. This is a theoretical max range, actual range heavily changes depending on conditions.",
            "机器人能听到脚步声、冲刺、跳跃、转身、装备声响及任何移动相关声音的最大范围（米）。这是理论最大范围，实际范围会随条件大幅变化。"
        },
        {
            "The Maximum Time that a bot can be shooting at you before the reduced spread not longer has an affect. So if a bot is shooting at you from the back for X seconds, after that time it will no longer reduce their accuracy to give you a better chance to react.",
            "机器人向你射击的最长时间，超过后降低散布的效果将失效。因此，若机器人从背后向你射击 X 秒，此后就不再降低其精准度——原本的降低是为了给你更好的反应机会。"
        },
        {
            "The amount of damage a bot received is divided by this number to produce a multiplier for how much to kick their aim. So if the value here is 50, and a bot is shot by a bullet that does 100 damage, it will result in their hit reaction being 2x, or twice as impactful.",
            "机器人所受伤害除以该数值，得出瞄准偏移的倍率。例如该值为 50，机器人被造成 100 点伤害的子弹击中，则受击反应为 2 倍，即影响翻倍。"
        },
        {
            "The difference of angle from the bot's vision to the enemy to fully apply HighElevationVisionModifier. The modifier is smoothed out by the angle differnce. So 1.2x at +60 degree, 1.1x at +30 degrees...and so on.",
            "从机器人视线到敌人的角度差达到此值时，完全生效高海拔视觉倍率。该倍率会随角度差平滑过渡，例如 +60 度时为 1.2 倍，+30 度时为 1.1 倍，以此类推。"
        },
        {
            "The difference of angle from the bot's vision to the enemy to fully apply LowElevationVisionModifier. The modifier is smoothed out by the angle differnce. So 0.85x at -30 degree, 0.95x at -10 degrees...and so on.",
            "从机器人视线到敌人的角度差达到此值时，完全生效低海拔视觉倍率。该倍率会随角度差平滑过渡，例如 -30 度时为 0.85 倍，-10 度时为 0.95 倍，以此类推。"
        },
        {
            "The distance, in meters, that is considered **Ideal Range** for a Red-dot / Holo. If shooting at a target closer than or equal to this, reduce scatter by **Red-dot / Holo - Ideal Range - Max Buff.**",
            "对红点/全息而言被视为**理想射程**的距离（米）。射击距离小于或等于此值的目标时，按**红点/全息 - 理想射程 - 最大增益**减少散布。"
        },
        {
            "The distance, in meters, that is considered **Out of Range** for a Red-dot / Holo. If shooting at a target further than or equal to this, increase scatter by **Red-dot / Holo - Out of Range - Max Debuff.**",
            "对红点/全息而言被视为**超出射程**的距离（米）。射击距离大于或等于此值的目标时，按**红点/全息 - 超出射程 - 最大减益**增加散布。"
        },
        {
            "The distance, in meters, that is considered **Out of Range** for a ironsights. If shooting at a target further than or equal to this, increase scatter by **Ironsights - Out of Range - Max Debuff.**",
            "对机械瞄具而言被视为**超出射程**的距离（米）。射击距离大于或等于此值的目标时，按**机械瞄具 - 超出射程 - 最大减益**增加散布。"
        },
        {
            "The distance, in meters, that is considered **Out of Range** for a ironsights. If shooting at a target further than or equal to this, start increasing scatter linearly up to **Ironsights - Out of Range - Distance - Scale End** by **Ironsights - Out of Range - Max Debuff.**",
            "对机械瞄具而言被视为**超出射程**的距离（米）。射击距离大于或等于此值的目标时，散布开始线性增加，直至**机械瞄具 - 超出射程 - 距离 - 缩放终点**，增幅上限为**机械瞄具 - 超出射程 - 最大减益**。"
        },
        {
            "The distance, in meters, that is considered too close for a magnified optic. If shooting at a target closer than or equal to this, increase scatter.",
            "对倍镜而言被视为过近的距离（米）。射击距离小于或等于此值的目标时，增加散布。"
        },
        {
            "The distances that a bot prefers to shoot a particular weapon class. Bots will try to close the distance if further than this.",
            "机器人使用特定武器类别时偏好的射击距离。如果距离超过此值，机器人会尝试拉近距离。"
        },
        {
            "When a bot has a bullet fly by them, the dispersion on the source of the gunshot will be X times more random, so a value of 2 will mean that it will multiply the randomized position to be 2x as far as originally calculated.",
            "当有子弹从机器人身边掠过时，其对枪声来源位置的散布会变为原来的 X 倍，因此数值为 2 表示随机化后的位置偏移会达到原本计算值的 2 倍。"
        },
        {
            "Absolute minimum speed (in seconds) that bot can react and shoot",
            "机器人能够反应并射击的绝对最低速度（秒）"
        },
        {
            "Affects Weapon Shootability Calculations, which tells a bot how fast they should shoot, how long they should hold down full auto fire, and how far they will decide to fire full auto or swap to only semi-auto.. Affects how much this type of effect has on how Shootable a bot's weapon is considered. Higher = More effect. So if you set RecoilScaling to 0, recoil will play no part in how fast or slow a bot shoots.",
            "影响武器可射击性计算：该计算决定机器人射击的速度、全自动持续射击的时长，以及多远距离内选择全自动或改用手动半自动。……影响此类效果对机器人武器可射击性判定的权重。数值越高影响越大。因此若将 RecoilScaling 设为 0，后坐力将不再影响机器人射击的快慢。"
        },
        {
            "AmmoCaliberFullAutoMaxDistancesDefaults",
            "各口径全自动射击最大距离默认值"
        },
        {
            "AmmoCaliberShootabilityDefaults",
            "各口径可射击性默认值"
        },
        {
            "Defines the ranges that different tiers of AI limit are set. If a bot is further than this number (in meters) from the closest Human Player, they will be assigned this AI Limit setting.",
            "定义不同等级 AI 限制的生效范围。如果机器人距离最近的人类玩家超过该数值（米），就会被分配这一 AI 限制设置。"
        },
        {
            "EngagementDistanceDefaults",
            "交战距离默认值"
        },
        {
            "HEAR_DISPERSION_VALUES_Defaults",
            "听觉散布默认值"
        },
        {
            "HearingDistancesDefaults",
            "听觉距离默认值"
        },
        {
            "Higher = Less Randomization and more accuracy. The distance to the sound's position, in meters, is divided by the number here. Example: A unsuppressed gunshot is 150 meters away. And the dispersion value for unsuppressed gunfire is 20. So We divide 150 by 20 to result in 7.5, so the randomized position that a bot thinks a gunshot came from is a position within 7.5 meters from the actual source of the gunshot. Note: this randomized position must be somewhere that is walkable so that they can potentially be able the investigate it. It is also not randomized in height to avoid bots having difficulty navigating to where they think a sound came from, so imagine a flat plane around you that extends 7.5 meters away that includes all walkable space, if you shoot - that bot 150 away will estimate you are somewhere within that 7.5 meter radius, on the same height level that you are on. If there is no walkable space around you, it will find the closest walkable place.",
            "数值越高随机性越小、精度越高。与声音位置的距离（米）会除以该数值。例如：未消音枪声在 150 米外，而未消音枪声的散布值为 20，则 150 ÷ 20 = 7.5，机器人在判断枪声来源时会认为其位于距真实枪声位置 7.5 米范围内的某处。注意：该随机位置必须是可通行区域，以便机器人有可能前往调查；同时该位置不会在高度上随机，以避免机器人在寻路时遇到困难——可想象以你为中心展开、半径 7.5 米的平面，覆盖所有可通行空间。若你开枪，150 米外的机器人会认为你位于该 7.5 米半径内、与你处于同一高度层的某处。若你周围没有可通行空间，则会选择最近的可通行位置。"
        },
        {
            "How often (in seconds) to check distances to all human players.",
            "检查与所有人类玩家距离的间隔（秒）。"
        },
        {
            "If a bot is looking at the source of a sound, they will be more accurate in their position prediction, up to the Minimum value here. If it is directly behind them, randomization will be multiplied by the Maximumm value here. It is a linear scale between these, so a sound directly to their right or left, will have the difference between the Maximumm and Minimum. Setting both the Min and the Max to 1.0 will disable this system.",
            "如果机器人正看着声音来源方向，他们的位置预测会更准确，最高可达到此处的最小值；若声音在正后方，随机化程度会乘以此处的最大值。两者之间为线性过渡，因此声音在正右或正左时，随机化程度介于最大值与最小值之间。将最小值和最大值都设为 1.0 可禁用该系统。"
        },
        {
            "If the last known position of an enemy (something heard or reported by their squad) is within X distance (meters) to the place they last saw an enemy, focus on the place they were last seen.",
            "如果敌人的最后已知位置（听到的动静或小队报告）与机器人最后一次看到敌人的位置距离在 X 米以内，则专注于最后看到敌人的位置。"
        },
        {
            "Maximum Power level for a bot to use this personality. Power level is a combined number that takes into account armor, the class of that armor, the attachments a bot has on their weapon, whether they have a faceshield, and the weapon class that is currently used by a bot. Power Level usually falls within 0 to 250 on average, and almost never goes above 500",
            "机器人使用该性格的最高战力等级。战力等级是一个综合数值，考虑了护甲、护甲等级、武器配件、是否佩戴面罩以及当前使用的武器类型。战力等级通常在 0 到 250 之间，几乎不会超过 500。"
        },
        {
            "Minimum Power level for a bot to use this personality. Power level is a combined number that takes into account armor, the class of that armor, the attachments a bot has on their weapon, whether they have a faceshield, and the weapon class that is currently used by a bot. Power Level usually falls within 0 to 250 on average, and almost never goes above 500",
            "机器人使用该性格的最低战力等级。战力等级是一个综合数值，考虑了护甲、护甲等级、武器配件、是否佩戴面罩以及当前使用的武器类型。战力等级通常在 0 到 250 之间，几乎不会超过 500。"
        },
        {
            "Only allow sneaky personality types (rat, snapping turtle) to be stealthy while searching for an enemy, ignored if Stealth Search is disabled above",
            "仅允许潜行型性格（老鼠、缩头龟）在搜索敌人时保持隐蔽；若上方“隐蔽搜索”已禁用，则此选项无效。"
        },
        {
            "REQUIRES RESTART OF GAME. Boss Followers (other than those with separate config options) will have vanilla ai behavior.",
            "需要重启游戏。Boss 随从（拥有独立配置选项的除外）将使用原版 AI 行为。"
        },
        {
            "REQUIRES RESTART OF GAME. Bosses (other than those with separate config options) will have vanilla ai behavior.",
            "需要重启游戏。Boss（拥有独立配置选项的除外）将使用原版 AI 行为。"
        },
        {
            "REQUIRES RESTART OF GAME. Obdolbs (crazy) Scavs and Santa will have vanilla behavior.",
            "需要重启游戏。Obdolbs（疯狂）Scav 和圣诞老人将使用原版行为。"
        },
        {
            "SUPP_AMOUNTS_DEFAULT",
            "压制量默认值"
        },
        {
            "The global minimum time to aim in seconds (1 = 1000 milliseconds = 1 second).",
            "全局最短瞄准时间（秒，1 = 1000 毫秒 = 1 秒）。"
        },
        {
            "WeaponClassShootabilityDefaults",
            "各武器类型可射击性默认值"
        },
        {
            "WeaponPerMeterDefaults",
            "每米武器参数默认值"
        },
    };
}
