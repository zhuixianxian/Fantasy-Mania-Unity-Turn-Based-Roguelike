using System;
using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using LitJson;

using Unity.VisualScripting;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class GameDataManager : BaseManager<GameDataManager>
{
    public Dictionary<string, WorldCharacterData> CharacterTeam = new Dictionary<string, WorldCharacterData>();
    public Dictionary<TeamPosition, string> BattleCharacterTeam = new Dictionary<TeamPosition, string>();
    /// <summary>
    /// 游戏种子，用于保持游戏一致性
    /// </summary>
    public int GameSeed;
    /// <summary>
    /// 生成节点的状态机的当前状态
    /// </summary>
    public StateMachineStatus stateMachineStatus = StateMachineStatus.Menu;
    /// <summary>
    /// 节点层数，用于和种子结合生成下一层的节点类型
    /// </summary>
    public int NodeNum = 0;
    /// <summary>
    /// 节点的ID，用于在json中读取应该生成哪些资源在场景中
    /// </summary>
    public string NodeID;
    /// <summary>
    /// 判断能否进入下一层节点
    /// </summary>
    public bool CanToNextNode;
    /// <summary>
    /// 场景数据 
    /// </summary>
    public WorldNodeData nodeData = new WorldNodeData();
    /// <summary>
    /// 偏离值，用于和种子结合生成下一层的节点类型
    /// </summary>
    public int DeviationValue = 0;
    /// <summary>
    /// 金币数量
    /// </summary>
    public long CoinNum = 5000;

    public GamePocket pocket = new GamePocket();

    private GameDataManager() { }
    /// <summary>
    /// 用于在配置菜单向游戏世界场景切换时生成队伍
    /// </summary>
    /// <param name="TeamCharacterIDs"></param>
    public void AddCharacterToTeam(List<string> TeamCharacterIDs)
    {
        CharacterTeam.Clear();
        if (TeamCharacterIDs != null)
        {
            foreach (string id in TeamCharacterIDs)
            {
                CharacterTeam.Add(id, new WorldCharacterData(id));
            }
        }

    }
    /// <summary>
    /// 用于生成种子
    /// </summary>
    public void GetSeed()
    {
        GameSeed = UnityEngine.Random.Range(0, 1296966869);
        //GameSeed = 201;
        Debug.Log(GameSeed);
    }
    /// <summary>
    /// 用于生成节点
    /// </summary>
    public void GenerateNode(string MapID)
    {
        NodeNum++;
        nodeData.GenerateNodeData(GameSeed, NodeNum, MapID);
        GameSeed = GameSeed + DeviationValue + NodeNum;

        DeviationValue = nodeData.DeviationValue;
        stateMachineStatus = StateMachineStatus.Start;
    }
    /// <summary>
    /// 菜单界面到世界界面需要做的事情
    /// </summary>
    public void MenuToWorld(List<string> TeamCharacterIDs)
    {
        AddCharacterToTeam(TeamCharacterIDs);
        GetSeed();
        NodeNum = 0;
        BattleCharacterTeam.Clear();
        CoinNum = 5000;
        GenerateNode("XueXiao");
    }
    /// <summary>
    /// 用于将队伍角色加入到战斗队伍中
    /// </summary>
    /// <param name="teamPosition"></param>
    /// <param name="id"></param>
    public void AddCharacterToBattleTeam(TeamPosition teamPosition, string id)
    {
        BattleCharacterTeam.Add(teamPosition, id);
        CharacterTeam[id].teamPosition = teamPosition;
    }
    /// <summary>
    /// 用于将队伍角色移出战斗队伍
    /// </summary>
    /// <param name="teamPosition"></param>
    public void RemoveCharacterToBattleTeam(TeamPosition teamPosition)
    {
        if (BattleCharacterTeam.ContainsKey(teamPosition))
        {
            string characterID = BattleCharacterTeam[teamPosition];
            BattleCharacterTeam.Remove(teamPosition);
            CharacterTeam[characterID].teamPosition = TeamPosition.pos0;
        }
    }

    public void SetGameDataMgr(string jsonStr)
    {
        // 先反序列化到一个临时对象
        var tempData = JsonMapper.ToObject<SaveGameData>(jsonStr);

        // 然后逐个字段复制到当前实例
        // 对于值类型和字符串，直接赋值
        this.GameSeed = tempData.GameSeed;
        this.stateMachineStatus = tempData.stateMachineStatus;
        this.NodeNum = tempData.NodeNum;
        this.NodeID = tempData.NodeID;
        this.CanToNextNode = tempData.CanToNextNode;
        this.DeviationValue = tempData.DeviationValue;
        this.CoinNum = tempData.CoinNum;

        // 对于 Dictionary，需要清空后重新添加
        this.CharacterTeam.Clear();
        foreach (var kv in tempData.CharacterTeam)
            this.CharacterTeam.Add(kv.Key, kv.Value);

        this.BattleCharacterTeam.Clear();
        foreach (var kv in tempData.BattleCharacterTeam)
            this.BattleCharacterTeam.Add(stringToTeamPos(kv.Key), kv.Value);

        //对于复杂对象 nodeData，需要逐个字段复制（或整体替换但需谨慎）
        // 假设 nodeData 是一个类实例，可以用类似方式更新其内部字段
        if (tempData.nodeData != null)
            this.nodeData.CopyFrom(tempData.nodeData);   
        else
            this.nodeData = new WorldNodeData(); // 默认值

        // 同样处理 pocket
        if (tempData.pocket != null)
            this.pocket.CopyFrom(tempData.pocket);
        else
            this.pocket = new GamePocket();

        this.stateMachineStatus = StateMachineStatus.Start;
    }

    TeamPosition stringToTeamPos(string TeamPosStr)
    {
        return (TeamPosition)Enum.Parse(typeof(TeamPosition), TeamPosStr, true);
    }
}
