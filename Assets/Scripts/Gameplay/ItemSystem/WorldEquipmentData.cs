using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WorldEquipmentData : WorldBaseItemData
{
    public uint EquipmentLevel;
    public EquipmentType equipmentType;
    public List<BaseModifier> equipmentModiBags;

    public WorldEquipmentData() { }

    public WorldEquipmentData(BaseEquipmentItemData baseEquipmentItemData)
    {
        id = baseEquipmentItemData.id;
        itemName = baseEquipmentItemData.itemName;
        description = baseEquipmentItemData.description;
        canStack = baseEquipmentItemData.canStack;
        StackNum = 1;
        itemType = baseEquipmentItemData.itemType;
        price = baseEquipmentItemData.price;
        equipmentType = baseEquipmentItemData.equipmentType;

        Debug.Log(baseEquipmentItemData.id + baseEquipmentItemData.itemType+ "WorldEquipmentData");
        EquipmentLevel = 1;
        BaseEquipmentItemData tempbaseEquData = new BaseEquipmentItemData(baseEquipmentItemData);
        equipmentModiBags = new List<BaseModifier>();
        ushort StatNum = (ushort)Random.Range(1, baseEquipmentItemData.baseEquiStatBags.Count + 1);//需要生成几条属性
        //List<ushort> StatPos = new List<ushort>();

        for (int i = 0; i < StatNum; i++)
        {
            ushort StatPos = (ushort)Random.Range(0, baseEquipmentItemData.baseEquiStatBags.Count);//需要生成哪个位置的属性
            BaseEquiStatBag tempEquiStatBag = new BaseEquiStatBag(tempbaseEquData.baseEquiStatBags[StatPos]);
            if(tempEquiStatBag.modifierType== ModifierType.Multiply)
            {
                equipmentModiBags.Add(new BaseModifier(
                Random.Range(tempEquiStatBag.multMinNum,tempEquiStatBag.multMaxNum),
                "Equipment",
                2,
                EquipmentLevel,
                tempEquiStatBag.modifierType,
                tempEquiStatBag.statType,
                "MEquiLevelUpFunc"
                ));
            }
            else if (tempEquiStatBag.modifierType == ModifierType.Add)
            {
                equipmentModiBags.Add(new BaseModifier(
                (int)Random.Range(tempEquiStatBag.AddMinNum, tempEquiStatBag.AddMaxNum),
                "Equipment",
                2,
                EquipmentLevel,
                tempEquiStatBag.modifierType,
                tempEquiStatBag.statType,
                "AEquiLevelUpFunc"
                ));
            }


        }
        //equipmentModiBags.Add()
    }
    /// <summary>
    /// 待修改
    /// </summary>
    public void AddLevelUp()
    {

    }

    public string GetDescription()
    {
        string tempDescription="";
        tempDescription = tempDescription+itemName+"\n";
        tempDescription = tempDescription + "价值：" + price.ToString() + "\n";
        tempDescription = tempDescription + description + "\n";
        foreach(var i in equipmentModiBags)
        {
            tempDescription = tempDescription + GetStatDescription(i.statType) +
                //i.ReturnModifierValue().ToString() 
                GetStatNumDesp(i.ReturnModifierValue(),i.type)
                + "\n";
        }

        return tempDescription;

    }

    string GetStatDescription(StatType statType)
    {
        switch (statType)
        {
            case StatType.Health:
                return "生命";
            case StatType.Attack:
                return "攻击";
            case StatType.Defense:
                return "防御";
            case StatType.MagicAttack:
                return "魔法攻击";
            case StatType.MagicDefense:
                return "魔法防御";
            case StatType.Speed:
                return "速度";
            case StatType.Accuracy:
                return "命中";
            case StatType.Evasion:
                return "闪避";
            case StatType.Parry:
                return "招架";
            case StatType.Agility:
                return "敏捷";
            case StatType.EffectHit:
                return "效果命中";
            case StatType.EffectResistance:
                return "效果抵抗";
            case StatType.DamageReduction:
                return "免伤";
            case StatType.LifeSteal:
                return "吸血";
            case StatType.ReflectedDamage:
                return "反震伤害";
            case StatType.ReflectionRate:
                return "反震率";
            case StatType.HPRecoveryperTurn:
                return "回合回复";
            case StatType.HPRecoveryperAttack:
                return "攻击回复";
            case StatType.CriticalRate:
                return "暴击率";
            case StatType.CriticalDamage:
                return "暴击伤害";
            case StatType.DamageReflectionRatio:
                return "反伤比例";
            case StatType.CriticalResistance:
                return "暴击抗性";
            case StatType.EffectHitRate:
                return "效果命中率";
            case StatType.EffectResistanceRate:
                return "效果抵抗率";
            case StatType.Penetration:
                return "护甲穿透";
            default:
                return statType.ToString();
        }
    }

    string GetStatNumDesp(float modiNum,ModifierType modifierType)
    {
        switch (modifierType)
        {
            case ModifierType.Add:
                return modiNum.ToString();
            case ModifierType.Multiply:
                return (modiNum * 100f).ToString() + "%";
            default:
                return modiNum.ToString();
        }
    }

    public WorldEquipmentData(WorldEquipmentData other)
    {
        // 1. 复制基类数据
        id = other.id;
        itemName = other.itemName;
        description = other.description;
        canStack = other.canStack;
        StackNum = other.StackNum;
        itemType = other.itemType;
        price = other.price;

        // 2. 复制装备等级
        EquipmentLevel = other.EquipmentLevel;
        equipmentType = other.equipmentType;
        // 3. 深拷贝属性修饰器列表
        equipmentModiBags = new List<BaseModifier>(other.equipmentModiBags.Count);
        foreach (var mod in other.equipmentModiBags)
        {
            equipmentModiBags.Add(new BaseModifier(mod)); // 需要 BaseModifier 的复制构造函数
        }
    }
}
