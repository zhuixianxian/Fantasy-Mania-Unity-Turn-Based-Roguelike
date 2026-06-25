using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class NPCContentData
{
    //节点组成元素的数据类,用于在json中读取
    public string NodeContentID = "BanZhang";
    public string NodeContentName="班长";
    /// <summary>
    /// 该元素的权重
    /// </summary>
    public int weight = 1;
    /// <summary>
    /// 偏差值，用于在生成时调整随机数
    /// </summary>
    public int DeviationValue = 98;

    //public NodeContentType nodeContentType;
    public Dictionary<string, int> NPCRelatedTasks = new Dictionary<string, int>()
    {{"DaiFan",1 }
    };
}
