using System.Collections;
using System.Collections.Generic;
using System.Data;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 武器可出现属性数值的包
/// </summary>
public class BaseEquiStatBag
{
    public StatType statType;//属性种类
    public ModifierType modifierType;//属性运算方式
    public long AddMinNum;
    public long AddMaxNum;

    public float multMinNum;
    public float multMaxNum;

    public BaseEquiStatBag() { }

    public BaseEquiStatBag(BaseEquiStatBag other)
    {
        if (other == null) return;

        statType = other.statType;
        modifierType = other.modifierType;
        AddMinNum = other.AddMinNum;
        AddMaxNum = other.AddMaxNum;
        multMinNum = other.multMinNum;
        multMaxNum = other.multMaxNum;
    }

}
