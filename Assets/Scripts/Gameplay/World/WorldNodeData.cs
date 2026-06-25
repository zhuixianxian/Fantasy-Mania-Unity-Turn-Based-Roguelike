using System.Collections;
using System.Collections.Generic;
using System.Linq;

using LitJson;

using UnityEngine;

/// <summary>
/// 纯数据容器，在世界场景中存储所有世界场景相关资源的容器
/// </summary>
public class WorldNodeData
{
    /// <summary>
    /// 节点的ID，用于在json中读取应该生成哪些资源在场景中
    /// </summary>
    public string NodeID;
    public string NodeName;
    //public int DeviationValue;
    /// <summary>
    /// 在gameDataManager中，存储着一个随机数，整个游戏会根据这个随机数生成节点类型。而为了
    /// 避免以后可以存档时，出现一层中进入每一个下一层，所对应的下下层都是一样的这种情况，我为每个
    /// 节点都会设置一个偏差值，来使得上述情况的可能性降低
    /// </summary>
    public int DeviationValue;
    public int NodeElementNum;

    public List<WorldTeamEnemyData> enemyTeamDatas=new List<WorldTeamEnemyData>();
    public List<WorldSynthesisData> worldSynthesisDatas = new List<WorldSynthesisData>();//这个节点生成的所有可以用来合成的结构的数据的保存
    public List<WorldShopData> shopDatas=new List<WorldShopData>();
    //public List<TreasureChestData> treasureChestDatas;
    //public List<NPCData> NPCDatas;
    public List<WorldNextNodeData> nextNodeDatas=new List<WorldNextNodeData>();
    public List<string> canDroppedItems = new List<string>();

    /// <summary>
    /// 用于生成场景中的元素
    /// </summary>
    public void GenerateNodeData(int GenerateSeed,int NodeNum,string MapID)
    {
        int MapsNum = DataManager.Instance.singletonMapData.Count;
        //Random.InitState(GenerateSeed);
        BaseNodeData BaseNode = DataManager.Instance.singletonMapData[MapID];
        NodeID = BaseNode.NodeID;
        NodeName = BaseNode.NodeName;
        //Debug.Log(JsonMapper.ToJson(BaseNode));
        //Debug.Log(BaseNode.NodeName+"BaseNode.NodeName");
        int EnemyTeamCount = Random.Range(1, 3);
        enemyTeamDatas.Clear();
        for (int i = 0; i < EnemyTeamCount; i++)
        {
            enemyTeamDatas.Add(new WorldTeamEnemyData(BaseNode.NodeID,NodeNum));
        }

        int SynthesisCount = Random.Range(1, 3);
        worldSynthesisDatas.Clear();
        for (int i = 0; i < SynthesisCount; i++)
        {
            worldSynthesisDatas.Add(new WorldSynthesisData(BaseNode.NodeID));
        }

        int ShopCount = Random.Range(1, 3);
        shopDatas.Clear();
        for (int i = 0; i < ShopCount; i++)
        {
            shopDatas.Add(new WorldShopData(BaseNode.NodeID));
        }

        int nextNodeCount = Random.Range(1, 4);
        nextNodeDatas.Clear();
        for (int i = 0; i < nextNodeCount; i++)
        {
            List<string> keys = new List<string>(DataManager.Instance.singletonMapData.Keys);
            if (keys.Count > 0)
            {
                int idx = Random.Range(0, keys.Count);
                string randomKey = keys[idx];
                nextNodeDatas.Add(new WorldNextNodeData(randomKey));
            }
        }

        canDroppedItems = BaseNode.CanDroppedItems;
    }

    /// <summary>
    /// 用来获取生成出的节点中有多少元素
    /// </summary>
    /// <returns></returns>
    public int GetNodeElementNum()
    {
        return enemyTeamDatas.Count;
    }
    public int GetNodeEnemyNum()
    {
        return enemyTeamDatas.Count;
    }

    /// <summary>
    /// 从另一个 WorldNodeData 复制完整数据（深拷贝）
    /// </summary>
    public void CopyFrom(WorldNodeData worldNodeData)
    {
        if (worldNodeData == null)
        {
            Debug.LogError("WorldNodeData.CopyFrom: source is null");
            return;
        }

        // 1. 复制值类型和字符串字段
        this.NodeID = worldNodeData.NodeID;
        this.NodeName = worldNodeData.NodeName;
        this.DeviationValue = worldNodeData.DeviationValue;
        this.NodeElementNum = worldNodeData.NodeElementNum;

        // 2. 复制 List<string>（字符串是不可变引用类型，直接新建列表即可）
        this.canDroppedItems = new List<string>(worldNodeData.canDroppedItems);

        // 3. 复制复杂对象的列表（深拷贝每个元素）
        this.enemyTeamDatas = DeepCopyList(worldNodeData.enemyTeamDatas);
        this.worldSynthesisDatas = DeepCopyList(worldNodeData.worldSynthesisDatas);
        this.shopDatas = DeepCopyList(worldNodeData.shopDatas);
        this.nextNodeDatas = DeepCopyList(worldNodeData.nextNodeDatas);
    }

    /// <summary>
    /// 泛型深拷贝列表（要求 T 支持通过 LitJson 序列化/反序列化）
    /// </summary>
    private List<T> DeepCopyList<T>(List<T> source) where T : class
    {
        if (source == null) return new List<T>();
        if (source.Count == 0) return new List<T>();

        // 利用 LitJson 序列化再反序列化实现深拷贝（简单可靠）
        string json = JsonMapper.ToJson(source);
        return JsonMapper.ToObject<List<T>>(json);
    }
}
