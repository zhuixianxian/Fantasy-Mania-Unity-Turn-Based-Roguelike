using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class synthesisContentData
{
    //节点组成元素的数据类,用于在json中读取
    public string NodeContentID = "ZiXiShi";
    public string NodeContentName = "自习室";
    /// <summary>
    /// 该元素的权重
    /// </summary>
    public int weight = 1;
    /// <summary>
    /// 偏差值，用于在生成时调整随机数
    /// </summary>
    public int DeviationValue = 98;

    /// <summary>
    /// 本结构可以用于合成的东西
    /// </summary>
    public List<string> canSynthesisItem;
}
