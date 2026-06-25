using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class ShopContentData
{
    //节点组成元素的数据类,用于在json中读取
    public string NodeContentID = "XiaoMaiBu";
    public string NodeContentName="小卖部";
    /// <summary>
    /// 该元素的权重
    /// </summary>
    public int weight = 1;
    public int DeviationValue = 235;

    //public NodeContentType nodeContentType;
    public List<string> CanAppearCommodity = new List<string>();

}
