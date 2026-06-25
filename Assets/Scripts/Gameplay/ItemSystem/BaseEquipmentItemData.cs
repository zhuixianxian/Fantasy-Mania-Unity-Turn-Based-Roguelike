using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 在DataManager中保存武器物品json数据的基类
/// </summary>

public class BaseEquipmentItemData : BaseItemData
{
    public long baseCoin;//基础的升级花费
    public EquipmentType equipmentType;
    public List<BaseEquiStatBag> baseEquiStatBags;//可以出现的属性的列表


    public BaseEquipmentItemData()
    {
        baseEquiStatBags = new List<BaseEquiStatBag>();
    }
    public BaseEquipmentItemData(BaseEquipmentItemData other)
    {
        if (other == null) return;

        id = other.id;
        itemName = other.itemName;
        description = other.description;
        canStack = other.canStack;
        itemType = other.itemType;
        price = other.price;
        baseCoin = other.baseCoin;
        equipmentType = other.equipmentType;  // 新增：复制装备部位类型
        if (other.baseEquiStatBags != null)
        {
            baseEquiStatBags = new List<BaseEquiStatBag>();
            foreach (var bag in other.baseEquiStatBags)
            {
                baseEquiStatBags.Add(new BaseEquiStatBag(bag));
            }
        }
        else
        {
            baseEquiStatBags = null;
        }
    }
}
