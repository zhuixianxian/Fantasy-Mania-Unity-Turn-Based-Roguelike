using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class ChestContentData
{
    //节点组成元素的数据类,用于在json中读取
    public string NodeContentID="JiaoXueLou";
    public string NodeContentName="教学楼";
    /// <summary>
    /// 该元素的权重
    /// </summary>
    public int weight=1;
    public int DeviationValue = 21;
    //public NodeContentType nodeContentType;
    public Dictionary<string, int> CanAppearItem = new Dictionary<string, int>()
    {
        {"YiZi",1 }
    };

}
