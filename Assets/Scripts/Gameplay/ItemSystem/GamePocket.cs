using System.Collections;
using System.Collections.Generic;

using LitJson;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class GamePocket
{
    public Dictionary<string, PocketItemTypePosBag> itemPosTypeBag;
    public List<WorldNormalItemData> worldNormalItemDatas;
    public List<WorldEquipmentData> worldEquipmentDatas;
    //public List<WorldNormalItemData> worldNormalItemDatas;

    public GamePocket()
    {
        itemPosTypeBag = new Dictionary<string, PocketItemTypePosBag>();
        worldNormalItemDatas = new List<WorldNormalItemData>();
        worldEquipmentDatas = new List<WorldEquipmentData>();
    }

    /// <summary>
    /// 添加一个物品
    /// </summary>
    /// <param name="itemID">被添加物品的ID</param>
    public void AddItem(string itemID)
    {
        BaseItemData tempItemData = DataManager.Instance.singletonItemData[itemID];
        Debug.Log(tempItemData.id + tempItemData.itemType);
        switch (tempItemData.itemType)
        {
            case ItemType.Equipment:
                worldEquipmentDatas.Add(new WorldEquipmentData(tempItemData as BaseEquipmentItemData));
                break;
            case ItemType.Normal:
                if (!itemPosTypeBag.ContainsKey(itemID))
                {
                    worldNormalItemDatas.Add(new WorldNormalItemData(tempItemData as BaseNormalItemData));
                    itemPosTypeBag.Add(itemID, new PocketItemTypePosBag(ItemType.Normal, worldNormalItemDatas.Count - 1));
                }
                else
                {
                    worldNormalItemDatas[itemPosTypeBag[itemID].itemPos].StackNum++;
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 添加多个物品
    /// </summary>
    /// <param name="itemID">被添加物品的ID</param>
    /// <param name="stackNum">需要添加的物品数量</param>
    public string AddItems(string itemID, int stackNum)
    {
        BaseItemData tempItemData = DataManager.Instance.singletonItemData[itemID];
        if (stackNum == 0) return "";
        switch (tempItemData.itemType)
        {
            case ItemType.Equipment:
                for (int i = 0; i < stackNum; i++)
                {
                    worldEquipmentDatas.Add(new WorldEquipmentData(tempItemData as BaseEquipmentItemData));
                }
                break;
            case ItemType.Normal:
                if (!itemPosTypeBag.ContainsKey(itemID))
                {
                    worldNormalItemDatas.Add(new WorldNormalItemData(tempItemData as BaseNormalItemData));
                    itemPosTypeBag.Add(itemID, new PocketItemTypePosBag(ItemType.Normal, worldNormalItemDatas.Count - 1));
                    worldNormalItemDatas[itemPosTypeBag[itemID].itemPos].StackNum = stackNum;
                }
                else
                {
                    worldNormalItemDatas[itemPosTypeBag[itemID].itemPos].StackNum += stackNum;
                }
                break;
            default:
                break;
        }
        return tempItemData.itemName + "x" + stackNum;

    }

    //同加法在背包中定义不同，减法的定义应该在物品本身中，自己负责削减自己的堆叠数，并由背包中统一去除堆叠为0的物品

    /// <summary>
    /// 去除堆叠数为0的所有物品
    /// </summary>
    public void RemoveStack0()
    {
        worldNormalItemDatas.RemoveAll(p => p.StackNum <= 0);
        worldEquipmentDatas.RemoveAll(p => p.StackNum <= 0);

        itemPosTypeBag.Clear();

        int _itemPos = 0;

        foreach (var i in worldNormalItemDatas)
        {
            //重新设置ID和位置的对应
            itemPosTypeBag.Add(i.id, new PocketItemTypePosBag(_itemPos, ItemType.Normal));
            _itemPos++;
        }

    }

    /// <summary>
    /// 向武器背包中添加武器
    /// </summary>
    public void AddEquipment(WorldEquipmentData equipmentData)
    {
        worldEquipmentDatas.Add(equipmentData);
    }

    /// <summary>
    /// 从另一个 GamePocket 复制完整数据（深拷贝）
    /// </summary>
    public void CopyFrom(GamePocket gamePocket)
    {
        if (gamePocket == null)
        {
            Debug.LogError("GamePocket.CopyFrom: source is null");
            return;
        }

        // 利用 LitJson 深拷贝整个对象（一行搞定）
        string json = JsonMapper.ToJson(gamePocket);
        var copy = JsonMapper.ToObject<GamePocket>(json);

        // 将拷贝的数据赋值给当前实例
        this.itemPosTypeBag = copy.itemPosTypeBag;
        this.worldNormalItemDatas = copy.worldNormalItemDatas;
        this.worldEquipmentDatas = copy.worldEquipmentDatas;
    }
}
