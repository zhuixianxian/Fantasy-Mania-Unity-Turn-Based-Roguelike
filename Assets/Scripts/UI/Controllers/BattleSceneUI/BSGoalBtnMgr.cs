using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BSGoalBtnMgr : MonoBehaviour
{
    //战斗场景中选取目标和显示血量，能量等的按钮的管理器
    public Button GoalButton;//主要的用来选择目标的按钮

    public BattleScenePosition battleScenePosition;//战斗场景中敌人和友方的枚举

    public TextMeshProUGUI ChrName;//角色名称显示区
    public TextMeshProUGUI HPNum;//角色当前血量显示区
    public TextMeshProUGUI HP;//角色血量
    public TextMeshProUGUI EnergyNum;//角色当前能量显示区
    public TextMeshProUGUI Energy;//角色能量
    public TextMeshProUGUI PointsNum;//角色当前技能点显示区
    public TextMeshProUGUI Points;//角色技能点文本（例：技能点：3）


    // Start is called before the first frame update
    void Start()
    {
        GoalButton.onClick.AddListener(() =>
        {
            if (BattleSkillManager.Instance.actionState == ActionState.ChrSkillExecute_2)
            {
                    BattleSkillManager.Instance.ChrSkillExecute_2(battleScenePosition);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string _ChrName,
        string _EnergyNum,
        string _HPNum,
           string _PointsNum)
    {
        ChrName.text = _ChrName;
        HPNum.text = _HPNum;
        EnergyNum.text = _EnergyNum;
        PointsNum.text = _PointsNum;
    }

    public void SetText()
    {
        BSBaseData tempData = new BSBaseData();
        if (battleScenePosition <= BattleScenePosition.Cpos9)
        {
            if (BattleSceneChrDataMgr.Instance.ChrTeamPosDic.ContainsKey(battleScenePosition))
            {
                tempData=BattleSceneChrDataMgr.Instance.ChrTeam[new BattleSceneKeyBag(battleScenePosition,
                    BattleSceneChrDataMgr.Instance.ChrTeamPosDic[battleScenePosition])];
            }
        }
        else
        {
            if (BattleSceneEnemyDataMgr.Instance.EnemyTeamPosDic.ContainsKey(battleScenePosition))
            {
                tempData = BattleSceneEnemyDataMgr.Instance.EnemyTeam[new BattleSceneKeyBag(battleScenePosition,
                    BattleSceneEnemyDataMgr.Instance.EnemyTeamPosDic[battleScenePosition])];
            }
        }
        if (tempData != null)
        {
            if (tempData.hasCharacter)
            {
                HPNum.color = new Color(HPNum.color.r, HPNum.color.g, HP.color.b, 1);
                HP.color = new Color(HP.color.r, HP.color.g, HP.color.b, 1);
                EnergyNum.color = new Color(EnergyNum.color.r, EnergyNum.color.g, EnergyNum.color.b, 1);
                Energy.color = new Color(Energy.color.r, Energy.color.g, Energy.color.b, 1);
                PointsNum.color = new Color(PointsNum.color.r, PointsNum.color.g, PointsNum.color.b, 1);
                Points.color = new Color(Points.color.r, Points.color.g, Points.color.b, 1);
                if (battleScenePosition == BattleSkillManager.Instance.CurrentExecutor.battleScenePosition)
                {
                    ChrName.text = "<color=red>" + tempData.CharacterName + "</color>";

                }
                else
                {
                    ChrName.text = tempData.CharacterName;
                }
                HPNum.text = tempData.health.ToString();
                EnergyNum.text = tempData.energy.ToString();
                PointsNum.text = tempData.skillPoints.ToString();
            }
            else
            {
                HPNum.color = new Color(HPNum.color.r, HPNum.color.g, HP.color.b, 0);
                HP.color = new Color(HP.color.r, HP.color.g, HP.color.b, 0);
                EnergyNum.color = new Color(EnergyNum.color.r, EnergyNum.color.g, EnergyNum.color.b, 0);
                Energy.color = new Color(Energy.color.r, Energy.color.g, Energy.color.b, 0);
                PointsNum.color = new Color(PointsNum.color.r, PointsNum.color.g, PointsNum.color.b, 0);
                Points.color = new Color(Points.color.r, Points.color.g, Points.color.b, 0);
            }
        }
            
    }
}
