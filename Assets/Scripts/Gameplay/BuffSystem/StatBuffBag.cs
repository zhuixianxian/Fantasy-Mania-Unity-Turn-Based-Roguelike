using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class StatBuffBag
{
    public float statValue;//Buff修改的属性的具体值
    public StatType statType;//Buff修改的属性的类型
    public ModifierType modifierType;//Buff修改器的属性升级方式
    //public Func<uint, float> LevelFunction;//Buff修改器的属性升级方式
    public string LevelFuncStr;//Buff修改器的属性升级方式

    public StatBuffBag(
        float _statValue,
        StatType _statType,
        ModifierType _modifierType,
        string _LevelFuncStr
        )
    {
        statValue = _statValue;
        statType = _statType;
        modifierType = _modifierType;
        LevelFuncStr = _LevelFuncStr;
    }
}
