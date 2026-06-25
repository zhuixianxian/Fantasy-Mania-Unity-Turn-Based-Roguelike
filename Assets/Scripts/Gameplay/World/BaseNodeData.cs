using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BaseNodeData
{
    //用于存储一个节点可以生成哪些资源
    public string NodeID = "XueXiao";
    public string NodeName = "学校";
    public int DeviationValue = 8798;
    public List<EnemyContentData> enemyContentsData = new List<EnemyContentData>()
    {

    };
    public List<synthesisContentData> synthesisContentsData = new List<synthesisContentData>()
    {

    };
    public List<ChestContentData> chestContentsData = new List<ChestContentData>()
    {

    };
    public List<NPCContentData> NPCContentData = new List<NPCContentData>()
    {

    };
    public List<ShopContentData> shopContentsData = new List<ShopContentData>()
    {

    };

    public List<string> CanDroppedItems = new List<string>() { };
}
