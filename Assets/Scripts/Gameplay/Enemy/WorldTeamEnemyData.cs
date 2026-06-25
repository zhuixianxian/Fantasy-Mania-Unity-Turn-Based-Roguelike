using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WorldTeamEnemyData
{
    /// <summary>
    /// 队伍生成在世界的哪个位置
    /// </summary>
    //public TeamPosition teamPosition;

    /// <summary>
    /// 用来显示在UI中的文字
    /// </summary>
    public string displayText;

    /// <summary>
    /// 判断该小队是否存活
    /// </summary>
    public bool isActive;
    /// <summary>
    /// 该队伍中有哪些敌人
    /// </summary>
    public List<WorldEnemyData> enemyDatas=new List<WorldEnemyData>();
    public WorldTeamEnemyData() { }
    public WorldTeamEnemyData(string MapID,int NodeNum)
    {
        int EnemyCount=Random.Range(3,7);//每队可能出现的敌人的数量
        List<int> EnemyPosList = GetEnemyPos(EnemyCount);
        BaseNodeData nodeData = DataManager.Instance.singletonMapData[MapID];//获取为哪个地图生成敌人
        for(int i = 0; i < EnemyCount; i++)
        {
            EnemyContentData enemy = nodeData.enemyContentsData[Random.Range(0, nodeData.enemyContentsData.Count)];
            string EnemyID;
            int EnemyDeviationValue;
            EnemyID = enemy.EnemyID;
            EnemyDeviationValue = enemy.DeviationValue;
            enemyDatas.Add(new WorldEnemyData(EnemyID,NodeNum, EnemyDeviationValue, EnemyPosList[i]));
        }
        displayText = enemyDatas[0].EnemyName;
        isActive = true;
    }

    private List<int> GetEnemyPos(int enemyCount)
    {
        List<int> EnemyPosList = new List<int>();
        for(int i = 0; i < enemyCount; )
        {
            int posNum = Random.Range(1, 10);
            if (!EnemyPosList.Contains(posNum))
            {
                EnemyPosList.Add(posNum);
                i++;
            }
        }
        return EnemyPosList;
    }
}
