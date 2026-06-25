using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 战斗场景中敌人的数据管理器
/// </summary>
public class BattleSceneEnemyDataMgr : BaseManager<BattleSceneEnemyDataMgr>
{
    //敌人ID和敌人具体数据的字典
    public Dictionary<BattleSceneKeyBag, BSEnemyData> EnemyTeam = new Dictionary<BattleSceneKeyBag, BSEnemyData>();
    //敌人所处位置和敌人ID的字典
    public Dictionary<BattleScenePosition, string> EnemyTeamPosDic = new Dictionary<BattleScenePosition, string>();

    private BattleSceneEnemyDataMgr() { }


    /// <summary>
    /// 布置敌人的函数
    /// </summary>
    /// <param name="battleChrTeam">传入BattleLauncher中的敌人是敌人列表中的第几位 </param>
    public void ArrangeEnemy(int EnemyTeamNum)
    {
        EnemyTeam.Clear();
        EnemyTeamPosDic.Clear();
        WorldTeamEnemyData worldTeamEnemyData = GameDataManager.Instance.nodeData.enemyTeamDatas[EnemyTeamNum];
        foreach(var BattleEnemy in worldTeamEnemyData.enemyDatas)
        {
            switch (BattleEnemy.teamPosition)
            {
                case 1:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos1, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos1, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos1));
                    break;
                case 2:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos2, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos2, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos2));
                    break;
                case 3:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos3, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos3, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos3));
                    break;
                case 4:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos4, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos4, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos4));
                    break;
                case 5:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos5, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos5, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos5));
                    break;
                case 6:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos6, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos6, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos6));
                    break;
                case 7:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos7, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos7, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos7));
                    break;
                case 8:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos8, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos8, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos8));
                    break;
                case 9:
                    EnemyTeamPosDic.Add(BattleScenePosition.Epos9, BattleEnemy.EnemyID);
                    EnemyTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Epos9, BattleEnemy.EnemyID), new BSEnemyData(BattleEnemy, BattleScenePosition.Epos9));
                    break;
            }
        }
    }
}
