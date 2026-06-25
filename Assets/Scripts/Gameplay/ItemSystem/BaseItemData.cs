using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 在DataManager中保存物品json数据的基类
/// </summary>
public class BaseItemData
{
    public string id;
    public string itemName;
    public string description;//物品描述
    //public int maxStackSize = 1;//最大堆叠
    public bool canStack = true;//能否堆叠
    public ItemType itemType;//物品类型
    public uint price;//物品价值
}
