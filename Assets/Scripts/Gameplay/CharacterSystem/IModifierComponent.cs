using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public interface IModifierComponent
{
    /// <summary>
    /// 该组件的修改器列表
    /// </summary>
    Dictionary<StatType,IModifier> CompModiDict { get; }
}
