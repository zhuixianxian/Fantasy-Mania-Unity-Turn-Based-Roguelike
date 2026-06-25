using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BattleSkillManager : SingletonMono<BattleSkillManager>
{
    private BattleSkillManager() { }
    /// <summary>
    /// 当前执行者，通过速度计算后，队列中先进先出得到
    /// </summary>
    public BattleSceneKeyBag CurrentExecutor;


    public bool NeedSwitchAction;//此技能是否需要切换行动

    private BSSkillData CurrentChooseSki;//用来存储当前被选中的技能的数据
    private BattleScenePosition ChooseGoal;//被选中的目标的位置

    public ActionState actionState = ActionState.None;

    Queue<ISkill> skillQueue = new Queue<ISkill>();//技能的执行队列，技能先进先出，后进后出，

    //行动的具体执行
    public void OnUpdate()
    {
        switch (actionState)
        {
            case ActionState.CampJudgment:
                if (BattleSceneChrDataMgr.Instance.ChrTeam.ContainsKey(BattleSkillManager.Instance.CurrentExecutor))
                {
                    if (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].camp == Camp.Character)
                    {

                        actionState = ActionState.ChrAction;
                    }
                }

                else if (BattleSceneEnemyDataMgr.Instance.EnemyTeam.ContainsKey(BattleSkillManager.Instance.CurrentExecutor))
                {
                    if (BattleSceneEnemyDataMgr.Instance.EnemyTeam[BattleSkillManager.Instance.CurrentExecutor].camp == Camp.Enemy)
                    {

                        actionState = ActionState.EnemyAction;
                    }
                }
                else
                {
                    BattleManager.Instance.battleState = BattleState.DetermineCurrentActor;
                    return;
                }
                break;
            case ActionState.ChrAction:
                if (BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList.Count == 0)
                {
                    BattleManager.Instance.battleState = BattleState.DetermineCurrentActor;
                    return;
                }
                else
                {
                    actionState = ActionState.ChrSkillExecute_1;
                    break;
                }
            case ActionState.ChrSkillExecute_1:
                break;
            case ActionState.ChrSkillExecute_2:
                break;
            case ActionState.ChrSkillExecute_3:
                ChrSkillExecute_3();
                break;
            case ActionState.ChrSkillExecute_4:
                ChrSkillExecute_4();
                break;
            case ActionState.ChrSkillExecute_5:
                ChrSkillExecute_5();
                actionState = ActionState.UseSkillEvent;
                break;
            case ActionState.UseSkillEvent:
                UseSkillEvent();
                actionState = ActionState.RefreshUI;
                break;

            case ActionState.RefreshUI:
                break;
            case ActionState.RefreshUIDone:
                actionState = ActionState.EndAction;
                break;
            case ActionState.EndAction:
                switch (VictoryJudgment())
                {
                    case BattleVictoryJudgment.Victory:
                        BattleManager.Instance.battleState = BattleState.VictorySettlement;
                        break;
                    case BattleVictoryJudgment.None:
                        BattleManager.Instance.battleState = BattleState.BeginAction;
                        break;
                    case BattleVictoryJudgment.Failure:
                        BattleManager.Instance.battleState = BattleState.FailedSettlement;
                        break;

                }
                break;

            case ActionState.EnemyAction:
                if (BattleSceneEnemyDataMgr.Instance.EnemyTeam[BattleSkillManager.Instance.CurrentExecutor].skiComp.BSSkillList.Count == 0)
                {
                    BattleManager.Instance.battleState = BattleState.DetermineCurrentActor;
                    return;
                }
                else
                {
                    actionState = ActionState.EnemySkillExecute_1;
                    break;
                }
            case ActionState.EnemySkillExecute_1:
                EnemySkillExecute_1();
                break;
            case ActionState.EnemySkillExecute_2:
                EnemySkillExecute_2();
                break;
            case ActionState.EnemySkillExecute_3:
                EnemySkillExecute_3();
                break;
            case ActionState.EnemySkillExecute_4:
                EnemySkillExecute_4();
                break;
            case ActionState.EnemyThink:
                StartCoroutine(EnemyThink());
                actionState = ActionState.EnemyThinking;
                break;
            case ActionState.EnemyThinking:
                break;
            case ActionState.EnemySkillExecute_5:
                EnemySkillExecute_5();
                actionState = ActionState.UseSkillEvent;
                break;
        }
    }

    #region 角色
    /// <summary>
    /// 角色使用技能时的装配阶段1，用于通过按钮事件接收要使用角色身上的哪个技能
    /// </summary>
    /// <param name="skillID"></param>
    public void ChrSkillExecute_1(BSSkillData skillData)
    {
        ushort ChrCurrentNum = 0;//角色当前的资源数量
        bool CanUseSkill = false;
        switch (skillData.skillType)
        {
            case SkillType.Skill:
            case SkillType.NormalAttack:
                if (BattleSceneChrDataMgr.Instance.ChrTeam.ContainsKey(BattleSkillManager.Instance.CurrentExecutor))
                {
                    ChrCurrentNum = BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].skillPoints;
                    if (SkillLibrary.Instance.skillLibrary.ContainsKey(skillData.SkillID))
                    {
                        CanUseSkill = SkillLibrary.Instance.skillLibrary[skillData.SkillID].TryUseSkill(ChrCurrentNum);

                    }
                }
                break;
            case SkillType.EnergySkill:
                if (BattleSceneChrDataMgr.Instance.ChrTeam.ContainsKey(BattleSkillManager.Instance.CurrentExecutor))
                {
                    ChrCurrentNum = (ushort)BattleSceneChrDataMgr.Instance.ChrTeam[BattleSkillManager.Instance.CurrentExecutor].energy;
                    if (SkillLibrary.Instance.skillLibrary.ContainsKey(skillData.SkillID))
                    {
                        CanUseSkill = SkillLibrary.Instance.skillLibrary[skillData.SkillID].TryUseSkill(ChrCurrentNum);

                    }
                }
                break;
        }

        if (CanUseSkill)
        {
            CurrentChooseSki = skillData;
            actionState = ActionState.ChrSkillExecute_2;//如果可以使用，切换到下一状态
        }
        else
        {
            actionState = ActionState.ChrSkillExecute_1;//如果不能，保持在此阶段
        }
    }


    public void ChrSkillExecute_2(BattleScenePosition position)
    {
        if (!BattleSceneChrDataMgr.Instance.ChrTeamPosDic.Keys.Contains(position) &&
            !BattleSceneEnemyDataMgr.Instance.EnemyTeamPosDic.Keys.Contains(position))
        {
            actionState = ActionState.ChrSkillExecute_2;
        }
        else
        {
            ChooseGoal = position;
            actionState = ActionState.ChrSkillExecute_3;

        }
    }

    public void ChrSkillExecute_3()
    {
        switch (CurrentChooseSki.skillType)
        {
            case SkillType.NormalAttack:
            case SkillType.Skill:
                if (SkillLibrary.Instance.skillLibrary.ContainsKey(CurrentChooseSki.SkillID))
                {
                    skillQueue.Enqueue(new SkillSkill(SkillLibrary.Instance.skillLibrary[CurrentChooseSki.SkillID] as SkillSkill));
                    actionState = ActionState.ChrSkillExecute_4;
                    break;
                }
                else
                {
                    actionState = ActionState.ChrSkillExecute_1;
                    return;
                }
            case SkillType.EnergySkill:
                if (SkillLibrary.Instance.skillLibrary.ContainsKey(CurrentChooseSki.SkillID))
                {
                    skillQueue.Enqueue(new EnergySkill(SkillLibrary.Instance.skillLibrary[CurrentChooseSki.SkillID] as EnergySkill));
                    actionState = ActionState.ChrSkillExecute_4;
                    break;
                }
                else
                {
                    actionState = ActionState.ChrSkillExecute_1;
                    return;
                }
            default:
                actionState = ActionState.ChrSkillExecute_1;
                return;
        }
    }

    public void ChrSkillExecute_4()
    {
        //if (BattleSceneChrDataMgr.Instance.ChrTeamPosDic.ContainsKey(ChooseGoal))
        //{
        //    skillQueue.Peek().SetSkillLevel(CurrentChooseSki.skillLevel);
        //    skillQueue.Peek().SetSkillSource(BattleSceneChrDataMgr.Instance.ChrTeam[CurrentExecutor]);
        //    skillQueue.Peek().SetSkillMainGoal(ChooseGoal);
        //    actionState = ActionState.ChrSkillExecute_5;
        //}
        //else if (BattleSceneEnemyDataMgr.Instance.EnemyTeamPosDic.ContainsKey(ChooseGoal))
        //{
        skillQueue.Peek().SetSkillLevel(CurrentChooseSki.skillLevel);
        skillQueue.Peek().SetSkillSource(BattleSceneChrDataMgr.Instance.ChrTeam[CurrentExecutor]);
        skillQueue.Peek().SetSkillMainGoal(ChooseGoal);
        actionState = ActionState.ChrSkillExecute_5;
        //}
        //else
        //{
        //    actionState = ActionState.ChrSkillExecute_2;
        //}
    }

    public void ChrSkillExecute_5()
    {
        skillQueue.Peek().AddEventFromBag();
    }

    public void UseSkillEvent()
    {
        skillQueue.Dequeue().UseSkillEvent();
    }
    #endregion

    #region 敌人
    public void EnemySkillExecute_1()
    {
        ushort EnemyCurrentNum = 0;//敌人当前的资源数量
        bool CanUseSkill = false;
        BSEnemyData tempBSEnemyData = new();
        BSSkillData skillData = new BSSkillData();
        if (BattleSceneEnemyDataMgr.Instance.EnemyTeam.ContainsKey(BattleSkillManager.Instance.CurrentExecutor))
        {
            tempBSEnemyData = BattleSceneEnemyDataMgr.Instance.EnemyTeam[BattleSkillManager.Instance.CurrentExecutor];
            ushort SkiNum = (ushort)Random.Range(0, tempBSEnemyData.skiComp.BSSkillList.Count);//用第几个技能
            skillData = tempBSEnemyData.skiComp.BSSkillList[SkiNum];
        }
        switch (skillData.skillType)
        {
            case SkillType.Skill:
            case SkillType.NormalAttack:
                if (BattleSceneEnemyDataMgr.Instance.EnemyTeam.ContainsKey(BattleSkillManager.Instance.CurrentExecutor))
                {
                    EnemyCurrentNum = BattleSceneEnemyDataMgr.Instance.EnemyTeam[BattleSkillManager.Instance.CurrentExecutor].skillPoints;
                    if (SkillLibrary.Instance.skillLibrary.ContainsKey(skillData.SkillID))
                    {
                        CanUseSkill = SkillLibrary.Instance.skillLibrary[skillData.SkillID].TryUseSkill(EnemyCurrentNum);

                    }
                }
                break;
        }

        if (CanUseSkill)
        {
            CurrentChooseSki = skillData;
            actionState = ActionState.EnemySkillExecute_2;//如果可以使用，切换到下一状态
        }
        else
        {
            actionState = ActionState.EnemySkillExecute_1;//如果不能，保持在此阶段
        }
    }

    public void EnemySkillExecute_2()
    {
        List<BattleScenePosition> tempPosList = new List<BattleScenePosition>();
        foreach (var i in BattleSceneChrDataMgr.Instance.ChrTeamPosDic)
        {
            tempPosList.Add(i.Key);
        }

        ChooseGoal = tempPosList[Random.Range(0, tempPosList.Count)];
        actionState = ActionState.EnemySkillExecute_3;
    }


    IEnumerator EnemyThink()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        actionState = ActionState.EnemySkillExecute_5;

    }

    public void EnemySkillExecute_3()
    {
        switch (CurrentChooseSki.skillType)
        {
            case SkillType.NormalAttack:
            case SkillType.Skill:
                if (SkillLibrary.Instance.skillLibrary.ContainsKey(CurrentChooseSki.SkillID))
                {
                    skillQueue.Enqueue(new SkillSkill(SkillLibrary.Instance.skillLibrary[CurrentChooseSki.SkillID] as SkillSkill));
                    actionState = ActionState.EnemySkillExecute_4;
                    break;
                }
                else
                {
                    actionState = ActionState.EnemySkillExecute_1;
                    return;
                }

            default:
                actionState = ActionState.EnemySkillExecute_1;
                return;
        }
    }

    public void EnemySkillExecute_4()
    {

        skillQueue.Peek().SetSkillLevel(CurrentChooseSki.skillLevel);
        skillQueue.Peek().SetSkillSource(BattleSceneEnemyDataMgr.Instance.EnemyTeam[CurrentExecutor]);
        skillQueue.Peek().SetSkillMainGoal(ChooseGoal);
        actionState = ActionState.EnemyThink;

    }

    public void EnemySkillExecute_5()
    {
        skillQueue.Peek().AddEventFromBag();
    }
    #endregion

    BattleVictoryJudgment VictoryJudgment()
    {
        bool isEnemyDied = true;
        bool isChrDied = true;
        //判断敌我双方是否有一方全部死亡
        foreach (var i in BattleSceneEnemyDataMgr.Instance.EnemyTeam)
        {
            if (!i.Value.buffComponent.GetTagBuffTag().Contains("SiWang"))
            {
                isEnemyDied = false;

            }
        }
        foreach (var i in BattleSceneChrDataMgr.Instance.ChrTeam)
        {
            if (!i.Value.buffComponent.GetTagBuffTag().Contains("SiWang"))
            {
                isChrDied = false;

            }
        }

        if (isEnemyDied && !isChrDied)
        {
            return BattleVictoryJudgment.Victory;
        }
        else if (!isEnemyDied && isChrDied)
        {
            return BattleVictoryJudgment.Failure;
        }
        else if (!isEnemyDied && !isChrDied)
        {
            return BattleVictoryJudgment.None;
        }
        else
        {
            return BattleVictoryJudgment.Victory;
        }
    }
}
