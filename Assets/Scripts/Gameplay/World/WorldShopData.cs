using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WorldShopData
{
    /// <summary>
    /// 用来显示在UI中的文字
    /// </summary>
    public string displayText;
    /// <summary>
    /// 本商店采买的东西
    /// </summary>
    public Dictionary<string,int> CanAppearCommodity;

    public WorldShopData()
    { }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="MapID"></param>
    /// <param name="synthesisTableNum">要生成第几个商店数据</param>
    public WorldShopData(string MapID)
    {
        BaseNodeData baseNodeData = DataManager.Instance.singletonMapData[MapID];//获取为哪个地图生成商店
        ushort shopNum = (ushort)Random.Range(0, baseNodeData.shopContentsData.Count);//随机选择一个位置
        displayText = baseNodeData.shopContentsData[shopNum].NodeContentName;//从json数据中获取要生成的商店节点的名字
        CanAppearCommodity = new Dictionary<string, int>();
        List<int> ItemPosList=GetItemListInt(baseNodeData.shopContentsData[shopNum].CanAppearCommodity.Count);
        int itemNum = 0;//物品的数量
        foreach(var i in ItemPosList)
        {
            switch (DataManager.Instance.singletonItemData[baseNodeData.shopContentsData[shopNum].CanAppearCommodity[i]].itemType)
            {
                case ItemType.Normal:
                    itemNum = Random.Range(1, 3);
                    CanAppearCommodity.Add(baseNodeData.shopContentsData[shopNum].CanAppearCommodity[i], itemNum * 5);//库存数量，以十作涨
                    break;
                case ItemType.Equipment:
                    CanAppearCommodity.Add(baseNodeData.shopContentsData[shopNum].CanAppearCommodity[i], 1);
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 获取List列表
    /// </summary>
    /// <param name="itemCount">被选中的商店里面有集中东西可以被采买到</param>
    /// <returns></returns>
    public List<int> GetItemListInt(int itemCount)
    {
        List<int> tempItemPosList = new List<int>();
        int ItemNum = Random.Range(1, itemCount+1);
        for(int i=0;i< ItemNum; )
        {
            int ItemPos= Random.Range(0, itemCount);
            if (!tempItemPosList.Contains(ItemPos))
            {
                tempItemPosList.Add(ItemPos);
                i++;
            }
        }
        return tempItemPosList;
    }

    /// <summary>
    /// 售卖东西
    /// </summary>
    /// <param name="itemID">物品ID</param>
    /// <param name="SellNum">售卖数量</param>

    public void SellItem(string itemID,int SellNum)
    {
        CanAppearCommodity[itemID] -= SellNum;
    }
}
