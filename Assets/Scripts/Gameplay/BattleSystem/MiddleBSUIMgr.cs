using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class MiddleBSUIMgr : MonoBehaviour
{
    public Button ChrButtonPos1;
    public Button ChrButtonPos2;
    public Button ChrButtonPos3;
    public Button ChrButtonPos4;
    public Button ChrButtonPos5;
    public Button ChrButtonPos6;
    public Button ChrButtonPos7;
    public Button ChrButtonPos8;
    public Button ChrButtonPos9;

    public Button EnemyButtonPos1;
    public Button EnemyButtonPos2;
    public Button EnemyButtonPos3;
    public Button EnemyButtonPos4;
    public Button EnemyButtonPos5;
    public Button EnemyButtonPos6;
    public Button EnemyButtonPos7;
    public Button EnemyButtonPos8;
    public Button EnemyButtonPos9;

    public Button SkillButton1;
    public Button SkillButton2;
    public Button SkillButton3;
    public Button SkillButton4;
    public Button SkillButton5;
    public Button SkillButton6;
    public Button SkillButton7;
    public Button SkillButton8;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BattleManager.Instance.battleState == BattleState.RefreshUI)
        {
            StartCoroutine(RoundRoutine());
            BattleManager.Instance.battleState = BattleState.RefreshUIDone;
        }

        if (BattleSkillManager.Instance.actionState == ActionState.RefreshUI)
        {
            StartCoroutine(RoundRoutine());
            BattleSkillManager.Instance.actionState =  ActionState.RefreshUIDone;
        }
    }

    IEnumerator RoundRoutine()
    {
        refreshGoalBtn();
        refreshSkiBtn();

        yield return null;
    }
    //newButton.GetComponentInChildren<TextMeshProUGUI>().text = DataManager.Instance.singletonCharacterData[kvp.Key].Name;
    //string GetChrText(BattleSceneKeyBag ChrTeamKey)
    //{
    //    if (BattleSkillManager.Instance.CurrentExecutor == ChrTeamKey)
    //    {
    //        return "<color=red>" + BattleSceneChrDataMgr.Instance.ChrTeam[ChrTeamKey].CharacterName + "</color>";
    //    }
    //    else
    //    {
    //        return BattleSceneChrDataMgr.Instance.ChrTeam[ChrTeamKey].CharacterName;
    //    }
    //}

    //string GetEnemyText(BattleSceneKeyBag EnemyTeamKey)
    //{
    //    if (BattleSkillManager.Instance.CurrentExecutor == EnemyTeamKey)
    //    {
    //        return "<color=red>" + BattleSceneEnemyDataMgr.Instance.EnemyTeam[EnemyTeamKey].CharacterName + "</color>";
    //    }
    //    else
    //    {
    //        return BattleSceneEnemyDataMgr.Instance.EnemyTeam[EnemyTeamKey].CharacterName;
    //    }
    //}

    void refreshGoalBtn()
    {
        ChrButtonPos1.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        ChrButtonPos2.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        ChrButtonPos3.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        ChrButtonPos4.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        ChrButtonPos5.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        ChrButtonPos6.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        ChrButtonPos7.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        ChrButtonPos8.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        ChrButtonPos9.GetComponentInChildren<BSGoalBtnMgr>().SetText();

        EnemyButtonPos1.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        EnemyButtonPos2.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        EnemyButtonPos3.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        EnemyButtonPos4.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        EnemyButtonPos5.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        EnemyButtonPos6.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        EnemyButtonPos7.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        EnemyButtonPos8.GetComponentInChildren<BSGoalBtnMgr>().SetText();
        EnemyButtonPos9.GetComponentInChildren<BSGoalBtnMgr>().SetText();
    }

    void refreshSkiBtn()
    {
        ClearButtonData();

        if (BattleSceneChrDataMgr.Instance.ChrTeam.ContainsKey(BattleSkillManager.Instance.CurrentExecutor))
        {
            if (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].camp == Camp.Character)
            {

                string _usageConditions = "";
                string _usageConditionsNum = "";
                string _SkillName = "";
                for (int i = 0; i < BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList.Count; i++)
                {

                    switch (i)
                    {
                        case 0:

                            switch (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].skillType)
                            {
                                case SkillType.NormalAttack:
                                case SkillType.Skill:

                                    _usageConditions = "技能点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                case SkillType.EnergySkill:

                                    _usageConditions = "能量";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillEnergy.ToString();
                                    break;
                                case SkillType.WholeTeamSkill:

                                    _usageConditions = "全队点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                default:
                                    break;
                            }
                            _SkillName = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillName;
                            SkillButton1.GetComponentInChildren<BSSkiBtnMgr>().SetSkiDataText(_usageConditions, _usageConditionsNum, _SkillName);
                            SkillButton1.GetComponentInChildren<BSSkiBtnMgr>().hasBSSkiData = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i];
                            break;
                        case 1:

                            switch (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].skillType)
                            {
                                case SkillType.NormalAttack:
                                case SkillType.Skill:
                                    _usageConditions = "技能点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                case SkillType.EnergySkill:
                                    _usageConditions = "能量";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillEnergy.ToString();
                                    break;
                                case SkillType.WholeTeamSkill:
                                    _usageConditions = "全队点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                default:
                                    break;
                            }
                            _SkillName = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillName;
                            SkillButton2.GetComponentInChildren<BSSkiBtnMgr>().SetSkiDataText(_usageConditions, _usageConditionsNum, _SkillName);
                            SkillButton2.GetComponentInChildren<BSSkiBtnMgr>().hasBSSkiData = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i];

                            break;
                        case 2:
                            switch (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].skillType)
                            {
                                case SkillType.NormalAttack:
                                case SkillType.Skill:
                                    _usageConditions = "技能点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                case SkillType.EnergySkill:
                                    _usageConditions = "能量";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillEnergy.ToString();
                                    break;
                                case SkillType.WholeTeamSkill:
                                    _usageConditions = "全队点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                default:
                                    break;
                            }
                            _SkillName = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillName;
                            SkillButton3.GetComponentInChildren<BSSkiBtnMgr>().SetSkiDataText(_usageConditions, _usageConditionsNum, _SkillName);
                            SkillButton3.GetComponentInChildren<BSSkiBtnMgr>().hasBSSkiData = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i];

                            break;
                        case 3:
                            switch (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].skillType)
                            {
                                case SkillType.NormalAttack:
                                case SkillType.Skill:
                                    _usageConditions = "技能点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                case SkillType.EnergySkill:
                                    _usageConditions = "能量";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillEnergy.ToString();
                                    break;
                                case SkillType.WholeTeamSkill:
                                    _usageConditions = "全队点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                default:
                                    break;
                            }
                            _SkillName = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillName;
                            SkillButton4.GetComponentInChildren<BSSkiBtnMgr>().SetSkiDataText(_usageConditions, _usageConditionsNum, _SkillName);
                            SkillButton4.GetComponentInChildren<BSSkiBtnMgr>().hasBSSkiData = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i];

                            break;
                        case 4:
                            switch (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].skillType)
                            {
                                case SkillType.NormalAttack:
                                case SkillType.Skill:
                                    _usageConditions = "技能点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                case SkillType.EnergySkill:
                                    _usageConditions = "能量";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillEnergy.ToString();
                                    break;
                                case SkillType.WholeTeamSkill:
                                    _usageConditions = "全队点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                default:
                                    break;
                            }
                            _SkillName = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillName;
                            SkillButton5.GetComponentInChildren<BSSkiBtnMgr>().SetSkiDataText(_usageConditions, _usageConditionsNum, _SkillName);
                            SkillButton5.GetComponentInChildren<BSSkiBtnMgr>().hasBSSkiData = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i];

                            break;
                        case 5:
                            switch (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].skillType)
                            {
                                case SkillType.NormalAttack:
                                case SkillType.Skill:
                                    _usageConditions = "技能点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                case SkillType.EnergySkill:
                                    _usageConditions = "能量";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillEnergy.ToString();
                                    break;
                                case SkillType.WholeTeamSkill:
                                    _usageConditions = "全队点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                default:
                                    break;
                            }
                            _SkillName = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillName;
                            SkillButton6.GetComponentInChildren<BSSkiBtnMgr>().SetSkiDataText(_usageConditions, _usageConditionsNum, _SkillName);
                            SkillButton6.GetComponentInChildren<BSSkiBtnMgr>().hasBSSkiData = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i];
                            break;
                        case 6:
                            switch (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].skillType)
                            {
                                case SkillType.NormalAttack:
                                case SkillType.Skill:
                                    _usageConditions = "技能点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                case SkillType.EnergySkill:
                                    _usageConditions = "能量";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillEnergy.ToString();
                                    break;
                                case SkillType.WholeTeamSkill:
                                    _usageConditions = "全队点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                default:
                                    break;
                            }
                            _SkillName = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillName;
                            SkillButton7.GetComponentInChildren<BSSkiBtnMgr>().SetSkiDataText(_usageConditions, _usageConditionsNum, _SkillName);
                            SkillButton7.GetComponentInChildren<BSSkiBtnMgr>().hasBSSkiData = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i];
                            break;
                        case 7:
                            switch (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].skillType)
                            {
                                case SkillType.NormalAttack:
                                case SkillType.Skill:
                                    _usageConditions = "技能点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                case SkillType.EnergySkill:
                                    _usageConditions = "能量";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillEnergy.ToString();
                                    break;
                                case SkillType.WholeTeamSkill:
                                    _usageConditions = "全队点";
                                    _usageConditionsNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillPoints.ToString();
                                    break;
                                default:
                                    break;
                            }
                            _SkillName = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i].SkillName;
                            SkillButton8.GetComponentInChildren<BSSkiBtnMgr>().SetSkiDataText(_usageConditions, _usageConditionsNum, _SkillName);
                            SkillButton8.GetComponentInChildren<BSSkiBtnMgr>().hasBSSkiData = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList[i];

                            break;
                    }
                }
            }
        }

    }

    void ClearButtonData()
    {
        SkillButton1.GetComponentInChildren<BSSkiBtnMgr>().ClearButtonData();
        SkillButton2.GetComponentInChildren<BSSkiBtnMgr>().ClearButtonData();
        SkillButton3.GetComponentInChildren<BSSkiBtnMgr>().ClearButtonData();
        SkillButton4.GetComponentInChildren<BSSkiBtnMgr>().ClearButtonData();
        SkillButton5.GetComponentInChildren<BSSkiBtnMgr>().ClearButtonData();
        SkillButton6.GetComponentInChildren<BSSkiBtnMgr>().ClearButtonData();
        SkillButton7.GetComponentInChildren<BSSkiBtnMgr>().ClearButtonData();
        SkillButton8.GetComponentInChildren<BSSkiBtnMgr>().ClearButtonData();
    }
}
