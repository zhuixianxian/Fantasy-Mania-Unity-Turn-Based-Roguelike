using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

[System.Serializable]
public class SaveGameData
{
    public Dictionary<string, WorldCharacterData> CharacterTeam = new Dictionary<string, WorldCharacterData>();
    public Dictionary<string, string> BattleCharacterTeam = new Dictionary<string, string>();
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

    public SaveGameData()
    {
        // 从 GameDataManager 安全获取当前队伍数据
        if (GameDataManager.Instance != null)
        {
            CharacterTeam =GameDataManager.Instance.CharacterTeam;
            foreach(var i in GameDataManager.Instance.BattleCharacterTeam)
            {
                BattleCharacterTeam.Add(i.Key.ToString(), i.Value);
            }
        }
        else
        {
            Debug.LogWarning("SaveGameData: GameDataManager.Instance is null, using empty teams.");
            CharacterTeam = new Dictionary<string, WorldCharacterData>();
            BattleCharacterTeam = new Dictionary<string, string>();
        }

        // 其他字段保留默认值（或从其他全局管理器获取）
        // 例如从 GameManager 获取 GameSeed, NodeNum, NodeID 等
        GameSeed = GameDataManager.Instance.GameSeed;
        NodeNum = GameDataManager.Instance.NodeNum;
        NodeID = GameDataManager.Instance.NodeID;
        CanToNextNode = GameDataManager.Instance.CanToNextNode;
        stateMachineStatus = GameDataManager.Instance.stateMachineStatus;
        DeviationValue = GameDataManager.Instance.DeviationValue;

        CoinNum = GameDataManager.Instance.CoinNum;
        pocket = GameDataManager.Instance.pocket;
        nodeData = GameDataManager.Instance.nodeData;
    }
}
