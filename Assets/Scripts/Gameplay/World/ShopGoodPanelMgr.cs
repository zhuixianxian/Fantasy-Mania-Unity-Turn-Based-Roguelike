using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class ShopGoodPanelMgr:MonoBehaviour
{
    public Button BuyButton;//触发购买事件的按钮
    string GoodsID;//预制体所代表的商品ID
    public TextMeshProUGUI GoodsNameText;//商品名称显示处
    public TextMeshProUGUI GoodsNumText;//商品数量显示处
    public TextMeshProUGUI GoodsPriceText;//商品价格显示处


    private void Start()
    {
        BuyButton.onClick.AddListener(() =>
        {
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_BuyShopGoods, GoodsID);
        });
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_GoodsPosNum">商店中预制体所代表的商品位置信息</param>
    /// <param name="goodsName"></param>
    /// <param name="goodsNum">商品的剩余数量</param>
    public void SetText(string _GoodsID, string goodsName, uint goodsPrice,int goodsNum)
    {
        GoodsID = _GoodsID;
        GoodsNameText.text = goodsName;
        GoodsNumText.text = goodsNum.ToString();
        GoodsPriceText.text = goodsPrice.ToString();
    }

    public void RefreshNum(int goodsNum)
    {
        GoodsNumText.text = goodsNum.ToString();
    }
}
