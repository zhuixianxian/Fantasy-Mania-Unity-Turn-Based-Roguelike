using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using Unity.VisualScripting;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class EquipmentComponent
{
    public WorldEquipmentData Helmet;
    public WorldEquipmentData Chestplate;
    public WorldEquipmentData Weapon;
    public WorldEquipmentData Leggings;
    public WorldEquipmentData Bracers;
    public WorldEquipmentData Boots;

    public List<BaseModifier> equiModi;//武器属性修改器列表

    public EquipmentComponent()
    {
        // 初始化为 null，表示未装备任何装备
        Helmet = null;
        Chestplate = null;
        Weapon = null;
        Leggings = null;
        Bracers = null;
        Boots = null;
        equiModi = new List<BaseModifier>();
    }

    /// <summary>
    /// 装备一件装备
    /// </summary>
    /// <param name="equipment">要装备的装备数据（来自背包）</param>
    public void EquipEquipment(WorldEquipmentData equipment)
    {
        if (equipment == null) return;

        //根据传入的装备类型判断向哪个空位中传递数据
        switch (equipment.equipmentType)
        {
            case EquipmentType.Helmet:
                if (Helmet != null)
                {
                    Debug.Log("头盔部位已有装备，无法装备");
                    return;
                }
                Helmet = new WorldEquipmentData(equipment);
                break;
            case EquipmentType.Chestplate:
                if (Chestplate != null)
                {
                    Debug.Log("胸甲部位已有装备，无法装备");
                    return;
                }
                Chestplate = new WorldEquipmentData(equipment);
                break;
            case EquipmentType.Weapon:
                if (Weapon != null)
                {
                    Debug.Log("武器部位已有装备，无法装备");
                    return;
                }
                Weapon = new WorldEquipmentData(equipment);
                Debug.Log(Weapon.itemName);
                break;
            case EquipmentType.Leggings:
                if (Leggings != null)
                {
                    Debug.Log("裤子部位已有装备，无法装备");
                    return;
                }
                Leggings = new WorldEquipmentData(equipment);
                break;
            case EquipmentType.Bracers:
                if (Bracers != null)
                {
                    Debug.Log("护腕部位已有装备，无法装备");
                    return;
                }
                Bracers = new WorldEquipmentData(equipment);
                break;
            case EquipmentType.Boots:
                if (Boots != null)
                {
                    Debug.Log("鞋子部位已有装备，无法装备");
                    return;
                }
                Boots = new WorldEquipmentData(equipment);
                break;
            default:
                Debug.LogError($"未知的装备类型: {equipment.equipmentType}");
                return;
        }

        // 装备成功后，将背包中的原装备堆叠数设为0，并清理背包
        equipment.StackNum = 0;
        GameDataManager.Instance.pocket.RemoveStack0();
    }
    /// <summary>
    /// 移除一件装备
    /// </summary>
    public void UnEquipEquipment(EquipmentType equipmentType)
    {
        WorldEquipmentData unequipped = null;

        //根据传入的装备类型判断移除哪个位置的装备数据
        switch (equipmentType)
        {
            case EquipmentType.Helmet:
                unequipped = Helmet;
                Helmet = null;
                break;
            case EquipmentType.Chestplate:
                unequipped = Chestplate;
                Chestplate = null;
                break;
            case EquipmentType.Weapon:
                unequipped = Weapon;
                Weapon = null;
                break;
            case EquipmentType.Leggings:
                unequipped = Leggings;
                Leggings = null;
                break;
            case EquipmentType.Bracers:
                unequipped = Bracers;
                Bracers = null;
                break;
            case EquipmentType.Boots:
                unequipped = Boots;
                Boots = null;
                break;
        }

        if (unequipped != null)
        {
            GameDataManager.Instance.pocket.AddEquipment(unequipped); // 需要你在 GamePocket 中实现 AddEquipment 方法
            Debug.Log($"已卸下 {unequipped.itemName}");
        }
    }


    public List<BaseModifier> GetAllModifier()
    {
        equiModi.Clear(); // 清空旧数据
        AddModifiersFrom(Helmet);
        AddModifiersFrom(Chestplate);
        AddModifiersFrom(Weapon);
        AddModifiersFrom(Leggings);
        AddModifiersFrom(Bracers);
        AddModifiersFrom(Boots);
        return equiModi;
    }

    private void AddModifiersFrom(WorldEquipmentData equip)
    {
        if (equip?.equipmentModiBags != null)
            equiModi.AddRange(equip.equipmentModiBags);
    }
}