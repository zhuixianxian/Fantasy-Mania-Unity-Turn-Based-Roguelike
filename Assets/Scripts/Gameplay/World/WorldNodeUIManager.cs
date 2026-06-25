using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;


public class WorldNodeUIManager : MonoBehaviour
{
    public Button LaunchButton;
    public Transform LaunchButtonPos;
    public Transform nextnodeLaunchButtonPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameDataManager.Instance.stateMachineStatus == StateMachineStatus.Start)
        {
            NodeUpdate();
            GameDataManager.Instance.stateMachineStatus = StateMachineStatus.CoinFlash;
        }
        if (GameDataManager.Instance.stateMachineStatus == StateMachineStatus.BattleToWorld)
        {
            NodeUpdate();
            GameDataManager.Instance.stateMachineStatus = StateMachineStatus.CoinFlash;

        }
    }

    /// <summary>
    /// 每次进入新场景的场景刷新
    /// </summary>
    public void NodeUpdate()
    {
        if (nextnodeLaunchButtonPos.childCount != 0)
        {
            for (int i = nextnodeLaunchButtonPos.childCount - 1; i >= 0; i--)
            {
                Destroy(nextnodeLaunchButtonPos.GetChild(i).gameObject);
            }
        }

        if (LaunchButtonPos.childCount != 0)
        {
            for (int i = LaunchButtonPos.childCount - 1; i >= 0; i--)
            {
                Destroy(LaunchButtonPos.GetChild(i).gameObject);
            }
        }
        //已生成了多少按钮
        //int NodeNum = 0;
        //int enemyNum = GameDataManager.Instance.nodeData.GetNodeEnemyNum();
        //已生成了多少敌人
        ushort enemyNum = 0;
        //for (int i = 0; i < enemyNum; i++)
        foreach(var enemyTeam in GameDataManager.Instance.nodeData.enemyTeamDatas)
        {
            ushort tempEnemyNum = enemyNum;
            // 每循环一次，就复印一个新的按钮
            Button newButton = Instantiate(LaunchButton, LaunchButtonPos);
            newButton.GetComponentInChildren<LaunchButtonMgr>().SetTextAndType($"<color=red>{enemyTeam.displayText}</color>", tempEnemyNum, LaunchType.Enemy);
            enemyNum++;
        }

        //已生成了多少合成台
        ushort synthesisTableNum = 0;
        //for (int i = 0; i < enemyNum; i++)
        foreach (var synData in GameDataManager.Instance.nodeData.worldSynthesisDatas)
        {
            ushort tempsynTableNum = synthesisTableNum;
            // 每循环一次，就复印一个新的按钮
            Button newButton = Instantiate(LaunchButton, LaunchButtonPos);
            newButton.GetComponentInChildren<LaunchButtonMgr>().SetTextAndType($"<color=#87CEEB>{synData.displayText}</color>", tempsynTableNum, LaunchType.synthesis);
            synthesisTableNum++;
        }

        //已生成了多少商店
        ushort ShopNum = 0;
        //for (int i = 0; i < enemyNum; i++)
        foreach (var shopData in GameDataManager.Instance.nodeData.shopDatas)
        {
            ushort tempShopNum = ShopNum;
            // 每循环一次，就复印一个新的按钮
            Button newButton = Instantiate(LaunchButton, LaunchButtonPos);
            newButton.GetComponentInChildren<LaunchButtonMgr>().SetTextAndType($"<color=#228B22>{shopData.displayText}</color>", tempShopNum, LaunchType.shop);
            ShopNum++;
        }

        //已生成了多少商店
        ushort nextNodeNum = 0;
        //for (int i = 0; i < enemyNum; i++)
        foreach (var shopData in GameDataManager.Instance.nodeData.nextNodeDatas)
        {
            ushort tempNextNodeNum = nextNodeNum;
            // 每循环一次，就复印一个新的按钮
            Button newButton = Instantiate(LaunchButton, nextnodeLaunchButtonPos);
            newButton.GetComponentInChildren<LaunchButtonMgr>().SetTextAndType($"<color=#FFC0CB>{shopData.displayText}</color>", tempNextNodeNum, LaunchType.nextNode);
            nextNodeNum++;
        }
    }
    ///// <summary>
    ///// 战斗场景到世界场景的节点刷新
    ///// </summary>
    //public void BtoWNodeUpdate()
    //{
    //    ushort enemyNum = 0;
    //    //for (int i = 0; i < enemyNum; i++)
    //    foreach (var enemyTeam in GameDataManager.Instance.nodeData.enemyTeamDatas)
    //    {
    //        int tempEnemyNum = enemyNum;
    //        // 每循环一次，就复印一个新的按钮
    //        Button newButton = Instantiate(LaunchButton, LaunchButtonPos);
    //        newButton.GetComponentInChildren<LaunchButtonMgr>().SetTextAndType($"<color=red>{enemyTeam.displayText}</color>", enemyNum, LaunchType.Enemy);
    //        enemyNum++;
    //    }
    //}
}
