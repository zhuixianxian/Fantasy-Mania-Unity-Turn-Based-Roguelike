using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 战斗场景中角色的数据管理器
/// </summary>
public class BattleSceneChrDataMgr :BaseManager<BattleSceneChrDataMgr>
{
    //角色ID和角色具体数据的字典
    public Dictionary<BattleSceneKeyBag, BSChrData> ChrTeam=new Dictionary<BattleSceneKeyBag, BSChrData>();
    //角色所处位置和角色ID的字典
    public Dictionary<BattleScenePosition, string> ChrTeamPosDic=new Dictionary<BattleScenePosition, string>();

    private BattleSceneChrDataMgr() { }

    /// <summary>
    /// 布置角色的函数
    /// </summary>
    /// <param name="battleChrTeam">传入GameDataManager中的角色队伍数据 </param>
    public void ArrangeChr(Dictionary<TeamPosition, string> battleChrTeam)
    {
        ChrTeam.Clear();
        ChrTeamPosDic.Clear();
        foreach (var BattleChr in battleChrTeam)
        {
            switch (BattleChr.Key)
            {
                case TeamPosition.pos1:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos1, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos1, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos1));
                    break;
                case TeamPosition.pos2:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos2, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos2, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos2));
                    break;
                case TeamPosition.pos3:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos3, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos3, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos3));
                    break;
                case TeamPosition.pos4:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos4, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos4, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos4));
                    break;
                case TeamPosition.pos5:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos5, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos5, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos5));
                    break;
                case TeamPosition.pos6:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos6, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos6, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos6));
                    break;
                case TeamPosition.pos7:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos7, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos7, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos7));
                    break;
                case TeamPosition.pos8:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos8, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos8, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos8));
                    break;
                case TeamPosition.pos9:
                    ChrTeamPosDic.Add(BattleScenePosition.Cpos9, BattleChr.Value);
                    ChrTeam.Add(new BattleSceneKeyBag(BattleScenePosition.Cpos9, BattleChr.Value), new BSChrData(GameDataManager.Instance.CharacterTeam[BattleChr.Value], BattleScenePosition.Cpos9));
                    break;
                default:
                    break;

            }
        }
        
    }

}
