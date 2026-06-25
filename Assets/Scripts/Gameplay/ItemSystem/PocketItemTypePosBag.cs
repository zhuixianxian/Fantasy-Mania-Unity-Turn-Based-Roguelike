using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 背包的数组存储位置、类型组
/// </summary>
public class PocketItemTypePosBag
{
    public ItemType itemType;
    public int itemPos;

    public PocketItemTypePosBag()
    {
    }

    public PocketItemTypePosBag(ItemType _itemType, int _itemPos)
    {
        itemType = _itemType;
        itemPos = _itemPos;
    }

    public PocketItemTypePosBag(int _itemPos,ItemType _itemType)
    {
        itemType = _itemType;
        itemPos = _itemPos;
    }
}
