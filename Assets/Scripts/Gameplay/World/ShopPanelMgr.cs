using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class ShopPanelMgr : MonoBehaviour
{
    public Button LeaveButton;//离开按钮
    public GameObject ShopPanel;//合成面板

    public GameObject goodsPrefabs;//商品预制体
    public Transform goodsPos;//商品的生成位置

    public TextMeshProUGUI coinsNumText;//玩家的金币数量

    Dictionary<string, int> tempGoodsDic;

    private Dictionary<string,GameObject> goodsPrefabsList = new Dictionary<string, GameObject>();//显示出的商店商品的列表

    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(() =>
        {
            ShopPanel.SetActive(false);
            GameDataManager.Instance.stateMachineStatus = StateMachineStatus.CoinFlash;
        });
        EventCenter.Instance.Clear(E_EventType.E_BuyShopGoods);
        EventCenter.Instance.AddEventListener<string>(E_EventType.E_BuyShopGoods, (GoodsID) =>
        {
            BuyShopGoods(GoodsID);
            Debug.Log("E_EventType.E_BuyShopGoods");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        ClearShopGoods();
    }

    /// <summary>
    /// 刷新商店中的商品
    /// </summary>
    public void DispShopGoods(ushort shopPos)
    {
        //ClearShopGoods();
        coinsNumText.text = GameDataManager.Instance.CoinNum.ToString();
        tempGoodsDic = GameDataManager.Instance.nodeData.shopDatas[shopPos].CanAppearCommodity;//临时引用的商品字典
        foreach (var i in tempGoodsDic)
        {
            GameObject newPanel = Instantiate(goodsPrefabs, goodsPos);//待修改
            newPanel.GetComponentInChildren<ShopGoodPanelMgr>().SetText(i.Key,
                DataManager.Instance.singletonItemData[i.Key].itemName,
                DataManager.Instance.singletonItemData[i.Key].price,
                i.Value);
            goodsPrefabsList.Add(i.Key,newPanel);
        }
    }

    void RefreshGoodsNum()
    {

    }

    void ClearShopGoods()
    {
        foreach(var i in goodsPrefabsList)
        {
            Destroy(i.Value);
        }
        goodsPrefabsList.Clear();
    }

    void BuyShopGoods(string GoodsID)
    {
        if(tempGoodsDic==null){
            Debug.Log("tempGoodsDic==null");
            return;
        }
        if (!tempGoodsDic.ContainsKey(GoodsID))
        {
            Debug.Log("!tempGoodsDic.ContainsKey(GoodsID)");
            return;
        }

        if (goodsPrefabsList == null)
        {
            Debug.Log("goodsPrefabsList==null");
            return;
        }
        if (!goodsPrefabsList.ContainsKey(GoodsID))
        {
            Debug.Log("!goodsPrefabsList.ContainsKey(GoodsID)");
            return;
        }
        if (tempGoodsDic[GoodsID] <= 0) return;
        if (GameDataManager.Instance.CoinNum>=
            DataManager.Instance.singletonItemData[GoodsID].price)
        {
            GameDataManager.Instance.CoinNum -= DataManager.Instance.singletonItemData[GoodsID].price;
            coinsNumText.text = GameDataManager.Instance.CoinNum.ToString();
            GameDataManager.Instance.pocket.AddItem(GoodsID);
            tempGoodsDic[GoodsID]--;

            goodsPrefabsList[GoodsID].GetComponentInChildren<ShopGoodPanelMgr>().RefreshNum(tempGoodsDic[GoodsID]);
        }

    }
}
