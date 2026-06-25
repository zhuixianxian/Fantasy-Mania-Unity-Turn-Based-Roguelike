using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance;
    public static BattleManager Instance
    {
        get
        {
            return instance;
        }
    }
    public BattleState battleState=BattleState.None;

    public GameObject victoryUI;
    public GameObject failedUI;

    Queue<BattleSceneKeyBag> speedQueue=new Queue<BattleSceneKeyBag>();

    void Awake() { instance = this; }
    // Start is called before the first frame update
    void Start()
    {
        battleState = BattleState.BeginBattle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case BattleState.BeginBattle:
                //布置角色数据
                BattleSceneChrDataMgr.Instance.ArrangeChr(GameDataManager.Instance.BattleCharacterTeam);
                //布置敌人数据
                BattleSceneEnemyDataMgr.Instance.ArrangeEnemy(BattleLauncher.Instance.enemyTeamPosition);
                battleState = BattleState.BeginRound;
                break;
            case BattleState.BeginRound:
                //按照速度排列出手顺序
                SpeedSort();
                battleState = BattleState.BeginAction;
                break;
            case BattleState.BeginAction:
                battleState = BattleState.BuffProcess;
                break;
            case BattleState.BuffProcess:
                StatBuffProcess();
                battleState = BattleState.DetermineCurrentActor;
                break;
            case BattleState.DetermineCurrentActor:
                if (speedQueue.Count != 0)
                {
                    if (UnActionTag())
                    {
                        BattleSkillManager.Instance.CurrentExecutor = speedQueue.Dequeue();

                        battleState = BattleState.RefreshUI;
                    }
                    else
                    {
                        speedQueue.Dequeue();

                        battleState = BattleState.DetermineCurrentActor;
                    }

                }
                else
                {
                    battleState = BattleState.EndRound;
                }
                break;
            case BattleState.RefreshUI:
                break;
            case BattleState.RefreshUIDone:
                battleState = BattleState.BeginActionOperation;
                break;
            case BattleState.BeginActionOperation:
                BattleSkillManager.Instance.actionState = ActionState.CampJudgment;//将技能管理器的状态调整到阵营判断
                battleState = BattleState.ActionOperation;
                break;
            case BattleState.ActionOperation:
                BattleSkillManager.Instance.OnUpdate();
                break;
            case BattleState.EndRound:
                BuffDuraNumReduce();
                battleState = BattleState.BeginRound;
                break;

            case BattleState.VictorySettlement:
                victoryUI.SetActive(true);
                victoryUI.GetComponentInChildren<BattleSceneVictUIMgr>().SetText(BattleLauncher.Instance.VictorySettlement());
                
                battleState = BattleState.None;
                
                break;
            case BattleState.VictorySwitch:
                GameDataManager.Instance.stateMachineStatus = StateMachineStatus.BattleToWorld;
                SceneMgr.Instance.LoadScene("WorldScene");
                break;
            case BattleState.FailedSettlement:
                DataManager.Instance.ClearGameData("HXJY_GameData");
                SceneMgr.Instance.LoadScene("StartScene");
                break;
        }
    }

    void SpeedSort()
    {
        List<KeyValuePair<BattleSceneKeyBag, long>> SpeedList = new List<KeyValuePair<BattleSceneKeyBag, long>>();
        //print(BattleSceneChrDataMgr.Instance.ChrTeam.Count);

        foreach (var i in BattleSceneChrDataMgr.Instance.ChrTeam)
        {
            SpeedList.Add(new KeyValuePair<BattleSceneKeyBag, long>(i.Key,i.Value.Speed.currentValue));
        }
        foreach (var i in BattleSceneEnemyDataMgr.Instance.EnemyTeam)
        {
            SpeedList.Add(new KeyValuePair<BattleSceneKeyBag, long>(i.Key, i.Value.Speed.currentValue));
        }
        SpeedList.Sort((a, b) => b.Value.CompareTo(a.Value));

        foreach (var i in SpeedList)
        {
            speedQueue.Enqueue(i.Key);
        }
    }
    /// <summary>
    /// 判断当前行动者身上是否带有不能行动的Tag
    /// 返回false,重新选择行动者
    /// 返回true,行动
    /// </summary>
    bool UnActionTag()
    {
        if (speedQueue.Peek().battleScenePosition <= BattleScenePosition.Cpos9)
        {
            if (BattleSceneChrDataMgr.Instance.ChrTeam[speedQueue. Peek()].buffComponent.GetTagBuffTag().Contains("SiWang"))
            {
                return false;
            }
        }
        if (speedQueue.Peek().battleScenePosition > BattleScenePosition.Cpos9)
        {
            if (BattleSceneEnemyDataMgr.Instance.EnemyTeam[speedQueue.Peek()].buffComponent.GetTagBuffTag().Contains("SiWang"))
            {
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// 削减所有的Buff持续时间
    /// </summary>
    void BuffDuraNumReduce()
    {
        foreach(var i in BattleSceneChrDataMgr.Instance.ChrTeam)
        {
            i.Value.buffComponent.ReduceDuration();
        }
        foreach (var i in BattleSceneEnemyDataMgr.Instance.EnemyTeam)
        {
            i.Value.buffComponent.ReduceDuration();
        }
    }
    /// <summary>
    /// 处理所有的属性类Buff
    /// </summary>
    void StatBuffProcess()
    {
        foreach (var i in BattleSceneChrDataMgr.Instance.ChrTeam)
        {
            i.Value.AllocateModifier();
        }
        foreach (var i in BattleSceneEnemyDataMgr.Instance.EnemyTeam)
        {
            i.Value.AllocateModifier();
        }
    }


    
}
