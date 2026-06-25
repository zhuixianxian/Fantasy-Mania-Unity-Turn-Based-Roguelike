using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;
/// <summary>
/// 写几个StatBuffBag就在描述位置留几个空{0}
/// </summary>
public class BuffLibrary : BaseManager<BuffLibrary>
{
    private BuffLibrary() { }

    public Dictionary<string, IBaseBuff> buffLibrary = new Dictionary<string, IBaseBuff>
    {
        { "JianSu",
            new StatBuff(
                "JianSu", "减速",false, "降低速度{0}%", 5,
                BuffType.StatBuff, BuffOverlayType.Independent, BuffReduceType.Clear,
                1,
                new List<StatBuffBag>
                {
                    new StatBuffBag(-0.1f,StatType.Speed, ModifierType.Multiply, "NoneFunc" )
                }
            )
        },

        { "JianFang",
            new StatBuff(
                "JianFang", "减防",false, "降低防御{0}%", 4 ,
                BuffType.StatBuff, BuffOverlayType.Independent, BuffReduceType.Clear,
                1,
                new List<StatBuffBag>
                {
                    new StatBuffBag(-0.1f,StatType.Defense, ModifierType.Multiply, "NoneFunc" )
                }
            )
        },
        { "JianYing",
            new StatBuff(
                "JianYing", "坚硬",false, "提高防御比例{0}", 5 ,
                BuffType.StatBuff, BuffOverlayType.OverWrite, BuffReduceType.Clear,
                1,
                new List<StatBuffBag>
                {
                    new StatBuffBag(0.1f,StatType.Defense, ModifierType.Multiply, "NoneFunc" )
                }
            )
        },

        { "JianRen",
            new StatBuff(
                "JianRen", "坚韧",false, "提高特防比例{0}", 5 ,
                BuffType.StatBuff, BuffOverlayType.Independent, BuffReduceType.Clear,
                1,
                new List<StatBuffBag>
                {
                    new StatBuffBag(0.1f,StatType.MagicDefense, ModifierType.Multiply, "NoneFunc" )
                }
            )
        },

        { "ChuLi",
            new StatBuff(
                "ChuLi", "矗立",false, "提高防御比例{0}和特防比例{1}", 5 ,
                BuffType.StatBuff, BuffOverlayType.Independent, BuffReduceType.Clear,
                1,
                new List<StatBuffBag>
                {
                    new StatBuffBag(0.1f,StatType.MagicDefense, ModifierType.Multiply, "NoneFunc" ),
                    new StatBuffBag(0.1f,StatType.Defense, ModifierType.Multiply, "NoneFunc" )
                }
            )
        },

        { "JiaSu",
            new StatBuff(
                "JiaSu", "加速",true, "提高速度比例{0}", 5,
                BuffType.StatBuff, BuffOverlayType.Independent, BuffReduceType.Clear,
                1,
                new List<StatBuffBag>
                {
                    new StatBuffBag(0.1f,StatType.Speed, ModifierType.Multiply, "NoneFunc" )
                }
            )
        },
        { "PoJia",
            new StatBuff(
                "PoJia", "破甲",true, "降低防御比例{0}", 5,
                BuffType.StatBuff, BuffOverlayType.Independent, BuffReduceType.Clear,
                1,
                new List<StatBuffBag>
                {
                    new StatBuffBag(-0.1f,StatType.Defense, ModifierType.Multiply, "NoneFunc" )
                }
            )
        },
        { "XiaoHuoLu",
            new StatBuff(
                "XiaoHuoLu", "小火炉",true, "提高防御比例{0}，提高特防比例{1}，提高攻击比例{2}", 5,
                BuffType.StatBuff, BuffOverlayType.LevelUp, BuffReduceType.LevelDown,
                5,
                new List<StatBuffBag>
                {
                    new StatBuffBag(0.1f,StatType.Defense, ModifierType.Multiply, "AddFunc1" ),
                    new StatBuffBag(0.1f,StatType.MagicDefense, ModifierType.Multiply, "NoneFunc" ),
                    new StatBuffBag(0.2f,StatType.Attack, ModifierType.Multiply, "NoneFunc" )
                }
            )
        },
        { "SiWang",
            new TagBuff(
                "SiWang", "死亡",true, "这家伙已经死了啦！", -1,
                BuffType.TagBuff, BuffOverlayType.Independent, BuffReduceType.Clear,
                1,
                new List<string>
                {
                    "SiWang"
                }
            )
        },
    };
        
       
}
