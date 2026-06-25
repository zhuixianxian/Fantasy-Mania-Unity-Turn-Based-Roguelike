using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class SkillLibrary : BaseManager<SkillLibrary>
{
    private SkillLibrary() { }
    /// <summary>
    /// 对于SkillSkill类型的技能来说，它实际上是消耗技能点的技能，第一个参数是它打几个，第二个参数是耗点数量，第三个是基础等级，第四个是是否切换行动者
    ///如果没有配置消耗事件的话，并不会消耗资源
    ///目前造成伤害的计算方式为：
    ///源的攻击力*技能事件包中的BaseValue这一属性再乘上函数传入技能等级后的返回值再乘上等级再乘4（可能待修改），再除以目标的防御力加1
    ///目前的AddFunc1的等级为1时返回1，每级提升0.02
    /// </summary>
    public Dictionary<string, ISkill> skillLibrary = new Dictionary<string, ISkill>
    {
        {"YiHuiJian",
            new SkillSkill("一洄剑",SputteringType.One,0,1,true)
            .AddEventBagToList(SkillEventType.DamageMainGoal,StatType.Attack,1,GameFunctions.Instance.AddFunc1)
            .AddEventBagToList(SkillEventType.ReplyPointsSource,StatType.None,1,GameFunctions.Instance.NoneFunc)
            .AddEventBagToList(SkillEventType.ReplyEnergySource,StatType.None,120,GameFunctions.Instance.NoneFunc)
        },
        {"DiZiJian",
            new SkillSkill("帝子剑",SputteringType.One,1,1,true)
            .AddEventBagToList(SkillEventType.ConsumeResources,StatType.None,70,GameFunctions.Instance.NoneFunc)//注意：这里，当SkillEventType.ConsumeResources时，只有第一个属性（即SkillEventType.ConsumeResources）有用，其他属性都是冗余属性
            .AddEventBagToList(SkillEventType.DamageMainGoal,StatType.Attack,1.5f,GameFunctions.Instance.AddFunc1)
            .AddEventBagToList(SkillEventType.ReplyEnergySource,StatType.None,120,GameFunctions.Instance.NoneFunc)
        },
        {"WangYangJian",
            new SkillSkill("王扬剑",SputteringType.One,2,1,true)
            .AddEventBagToList(SkillEventType.ConsumeResources,StatType.None,70,GameFunctions.Instance.NoneFunc)//注意：这里，当SkillEventType.ConsumeResources时，只有第一个属性（即SkillEventType.ConsumeResources）有用，其他属性都是冗余属性
            .AddEventBagToList(SkillEventType.DamageMainGoal,StatType.Attack,2f,GameFunctions.Instance.AddFunc1)
            .AddEventBagToList(SkillEventType.ReplyEnergySource,StatType.None,90,GameFunctions.Instance.NoneFunc)
        },
        {"GuiZhongJian",
            new EnergySkill("归终剑",SputteringType.One,120,1,true)
            .AddEventBagToList(SkillEventType.ConsumeResources,StatType.None,70,GameFunctions.Instance.NoneFunc)//注意：这里，当SkillEventType.ConsumeResources时，只有第一个属性（即SkillEventType.ConsumeResources）有用，其他属性都是冗余属性
            .AddEventBagToList(SkillEventType.BuffSource,new List<float>(){0.2f},GameFunctions.Instance.AddFunc1,"XiaoHuoLu")
            .AddEventBagToList(SkillEventType.DamageMainGoal,StatType.Attack,2.5f,GameFunctions.Instance.AddFunc1)
        },
        {"JianYing",
            new SkillSkill("坚硬",SputteringType.One,0,1, true)
            .AddEventBagToList(SkillEventType.BuffSource,new List<float>(){0.2f},GameFunctions.Instance.AddFunc1,"JianYing")
        },
        {"ZiRe",
            new SkillSkill("自热",SputteringType.One,0,1, true)
            .AddEventBagToList(SkillEventType.BuffSource,new List<float>(){0.15f},GameFunctions.Instance.AddFunc1,"JiaSu")
        },
        {"JiaYeDao",
            new SkillSkill("夹页刀",SputteringType.One,0,1,true)
            .AddEventBagToList(SkillEventType.DamageMainGoal,StatType.Attack,1.2f,GameFunctions.Instance.AddFunc1)
            .AddEventBagToList(SkillEventType.ReplyPointsSource,StatType.None,1,GameFunctions.Instance.NoneFunc)
            .AddEventBagToList(SkillEventType.ReplyEnergySource,StatType.None,40,GameFunctions.Instance.NoneFunc)
        },
        {"ShuiPao",
            new SkillSkill("水炮",SputteringType.One,0,1,true)
            .AddEventBagToList(SkillEventType.DamageMainGoal,StatType.MagicAttack,1.2f,GameFunctions.Instance.AddFunc1)
            .AddEventBagToList(SkillEventType.ReplyPointsSource,StatType.None,1,GameFunctions.Instance.NoneFunc)
            .AddEventBagToList(SkillEventType.ReplyEnergySource,StatType.None,40,GameFunctions.Instance.NoneFunc)
        },
        {"FuBai",
            new SkillSkill("腐败",SputteringType.One,0,1,true)
            .AddEventBagToList(SkillEventType.DamageMainGoal,StatType.MagicAttack,1.2f,GameFunctions.Instance.AddFunc1)
            .AddEventBagToList(SkillEventType.ReplyPointsSource,StatType.None,1,GameFunctions.Instance.NoneFunc)
        },
        {"HuiGuo",
            new SkillSkill("回锅",SputteringType.One,0,1,true)
            .AddEventBagToList(SkillEventType.ReplyHealthSource,StatType.Health,0.4f,GameFunctions.Instance.NoneFunc)
        },
        {"JianRen",
            new SkillSkill("坚韧",SputteringType.One,0,1, true)
            .AddEventBagToList(SkillEventType.BuffSource,new List<float>(){0.2f},GameFunctions.Instance.AddFunc1,"JianRen")
        },
        {"ChuLi",
            new SkillSkill("矗立",SputteringType.One,0,1, true)
            .AddEventBagToList(SkillEventType.BuffSource,new List<float>(){0.1f},GameFunctions.Instance.AddFunc1,"JianYing")
            .AddEventBagToList(SkillEventType.BuffSource,new List<float>(){0.1f},GameFunctions.Instance.AddFunc1,"JianRen")
        },
        {"MaoMaoQuan",
            new SkillSkill("猫猫拳",SputteringType.One,0,1,true)
            .AddEventBagToList(SkillEventType.DamageMainGoal,StatType.Attack,1,GameFunctions.Instance.AddFunc1)
            .AddEventBagToList(SkillEventType.ReplyPointsSource,StatType.None,1,GameFunctions.Instance.NoneFunc)
            .AddEventBagToList(SkillEventType.ReplyEnergySource,StatType.None,30,GameFunctions.Instance.NoneFunc)
        },
        // 在 SkillLibrary 的 skillLibrary 字典中添加以下三个技能

        {"DaoCaoLianDao",
            new SkillSkill("稻草镰刀", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.3f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 30, GameFunctions.Instance.NoneFunc)
        },

        {"TiaoYueTiJi",
            new SkillSkill("跳跃踢击", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.8f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.BuffSource, new List<float>(){0.15f}, GameFunctions.Instance.AddFunc1, "JiaSu")
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 20, GameFunctions.Instance.NoneFunc)
        },

        {"DuYePenSa",
            new SkillSkill("毒液喷洒", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.1f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 25, GameFunctions.Instance.NoneFunc)
        },
    
            // ==================== 矿洞敌人技能 ====================

        {"KuangGongChui",
            new SkillSkill("矿工锤", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.4f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 35, GameFunctions.Instance.NoneFunc)
        },

        {
    "ShiTouZhen",
            new SkillSkill("石头阵", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.1f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.BuffSource, new List<float>() { 0.2f }, GameFunctions.Instance.AddFunc1, "JianYing")
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 25, GameFunctions.Instance.NoneFunc)
        },

        {
    "ZuanDi",
            new SkillSkill("钻地", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.3f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.BuffSource, new List<float>() { 0.15f }, GameFunctions.Instance.AddFunc1, "JiaSu")
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 20, GameFunctions.Instance.NoneFunc)
        },

        {
    "YinGuangZhan",
            new SkillSkill("银光斩", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.5f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 40, GameFunctions.Instance.NoneFunc)
        },

        {
    "JinGuangZhan",
            new SkillSkill("金光斩", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.6f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 45, GameFunctions.Instance.NoneFunc)
        },

        {
    "YanJiangPenShe",
            new SkillSkill("岩浆喷射", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.7f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 35, GameFunctions.Instance.NoneFunc)
        },

        {
    "LvGuangBaoZha",
            new SkillSkill("绿光爆炸", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.9f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 50, GameFunctions.Instance.NoneFunc)
        },

        {
    "ZuanShiHuDun",
            new SkillSkill("钻石护盾", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.BuffSource, new List<float>() { 0.3f }, GameFunctions.Instance.AddFunc1, "JianYing")
                .AddEventBagToList(SkillEventType.BuffSource, new List<float>() { 0.2f }, GameFunctions.Instance.AddFunc1, "JianRen")
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 30, GameFunctions.Instance.NoneFunc)
        },

        {
    "ZhenZhuGuangHui",
            new SkillSkill("珍珠光辉", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.4f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyHealthSource, StatType.Health, 0.25f, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 40, GameFunctions.Instance.NoneFunc)
        },
        {"KuQiBo",
            new SkillSkill("哭泣波", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.2f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.BuffMainGoal, new List<float>(){0.1f}, GameFunctions.Instance.AddFunc1, "JianSu")
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 30, GameFunctions.Instance.NoneFunc)
        },
        {"FengRen",
            new SkillSkill("风刃", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.4f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 25, GameFunctions.Instance.NoneFunc)
        },
        {"MuZhen",
            new SkillSkill("木针", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.1f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 20, GameFunctions.Instance.NoneFunc)
        },
        {"JuShiBeng",
            new SkillSkill("巨石崩", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.6f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 40, GameFunctions.Instance.NoneFunc)
        },
        {"YanPen",
            new SkillSkill("焰喷", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.5f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 35, GameFunctions.Instance.NoneFunc)
        },
        {"FengNuQuan",
            new SkillSkill("愤怒拳", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.8f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.BuffSource, new List<float>(){0.1f}, GameFunctions.Instance.AddFunc1, "JiaSu")
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 30, GameFunctions.Instance.NoneFunc)
        },
        {"ShaBao",
            new SkillSkill("沙暴", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.3f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 25, GameFunctions.Instance.NoneFunc)
        },
        {"QiangSuanPen",
            new SkillSkill("强酸喷", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.4f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.BuffMainGoal, new List<float>(){0.15f}, GameFunctions.Instance.AddFunc1, "PoJia")
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 30, GameFunctions.Instance.NoneFunc)
        },
        {"DuWeiCi",
            new SkillSkill("毒尾刺", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.5f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 35, GameFunctions.Instance.NoneFunc)
        },
                // ========== 魔法厨房敌人技能 ==========
        {"TanShi",
            new SkillSkill("贪食", SputteringType.One, 1, 1, true)
                .AddEventBagToList(SkillEventType.ConsumeResources,StatType.None,70,GameFunctions.Instance.NoneFunc)//注意：这里，当SkillEventType.ConsumeResources时，只有第一个属性（即SkillEventType.ConsumeResources）有用，其他属性都是冗余属性
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.Attack, 1.3f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyHealthSource, StatType.Health, 0.2f, GameFunctions.Instance.NoneFunc)
                //.AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 30, GameFunctions.Instance.NoneFunc)
        },
        {"BaoShiGuang",
            new SkillSkill("暴食光", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageDeputyGoal, StatType.Attack, 0.8f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyHealthSource, StatType.Health, 0.15f, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 25, GameFunctions.Instance.NoneFunc)
        },
        {"XiangLiaoFenWu",
            new SkillSkill("香料粉雾", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.2f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 35, GameFunctions.Instance.NoneFunc)
        },
        {"CiJiShu",
            new SkillSkill("刺激术", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageMainGoal, StatType.MagicAttack, 1.0f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 20, GameFunctions.Instance.NoneFunc)
        },
        {"GuoLuHongZha",
            new SkillSkill("锅炉轰炸", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.DamageDeputyGoal, StatType.Attack, 1.2f, GameFunctions.Instance.AddFunc1)
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 45, GameFunctions.Instance.NoneFunc)
        },
        {"YanWuMiMan",
            new SkillSkill("烟雾弥漫", SputteringType.One, 0, 1, true)
                .AddEventBagToList(SkillEventType.BuffSource, new List<float>(){0.2f}, GameFunctions.Instance.AddFunc1, "JiaSu")
                .AddEventBagToList(SkillEventType.BuffMainGoal, new List<float>(){-0.2f}, GameFunctions.Instance.AddFunc1, "JianSu")
                .AddEventBagToList(SkillEventType.ReplyPointsSource, StatType.None, 1, GameFunctions.Instance.NoneFunc)
                .AddEventBagToList(SkillEventType.ReplyEnergySource, StatType.None, 30, GameFunctions.Instance.NoneFunc)
        },
    };
}

