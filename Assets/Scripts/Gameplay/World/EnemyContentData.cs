using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class EnemyContentData
{
    //节点组成元素的数据类,用于在json中读取，用于保存和判断该种节点能够生成的敌人的种类
    public string EnemyID="ShuGuai";
    public string EnemyName="书怪";
    /// <summary>
    /// 该元素的权重
    /// </summary>
    public int EnemyWeight = 1;
    public int DeviationValue = 88;

    //public NodeContentType nodeContentType;
}
