using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 用于将物品添加到合成台字典中的包
/// </summary>
public class AddItemToDicBag
{
    public int itemPos;//物品的位置
    public ItemType itemType;//物品的类型

    public AddItemToDicBag(int _itemPos, ItemType _itemType)
    {
        itemPos = _itemPos;
        itemType = _itemType;
    }
}
