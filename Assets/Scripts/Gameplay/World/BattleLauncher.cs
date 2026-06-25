using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BattleLauncher : SingletonMono<BattleLauncher>
{
    public int enemyTeamPosition;
    // Start is called before the first frame update

    //public GameObject promptPanel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateEnemyEvent()
    {

    }

    public void LaunchToBattle(ushort enemyTeamPos)
    {
        if (GameDataManager.Instance.BattleCharacterTeam.Count != 0)
        {
            if (GameDataManager.Instance.nodeData.enemyTeamDatas[enemyTeamPos].isActive)
            {
                if (SkillNumConfirm())
                {
                    enemyTeamPosition = enemyTeamPos;
                    SceneMgr.Instance.LoadSceneAsyn("BattleScene");

                }
                else
                {
                    EventCenter.Instance.EventTrigger<string>(E_EventType.E_PromptPanelDisplay, "你队伍里似乎有人在摆烂不放技能哦");

                    //promptPanel.GetComponentInChildren<WSPromptPanelMgr>().SetText("你队伍里似乎有人在摆烂不放技能哦");
                    //promptPanel.SetActive(true);
                    print("你队伍里似乎有人在摆烂不放技能哦");

                }
            }
            else
            {
                EventCenter.Instance.EventTrigger<string>(E_EventType.E_PromptPanelDisplay, "这堆家伙已经被你打跑了！");

                //promptPanel.GetComponentInChildren<WSPromptPanelMgr>().SetText("这堆家伙已经被你打跑了！");
                //promptPanel.SetActive(true);
                print("这堆家伙已经被你打跑了！");
            }
        }
        else
        {

            EventCenter.Instance.EventTrigger<string>(E_EventType.E_PromptPanelDisplay, "队伍为空");
            //promptPanel.SetActive(true);
            print("队伍为空");
        }
    }

    /// <summary>
    /// 胜利时需要做的结算工作
    /// </summary>
    public List<string> VictorySettlement()
    {
        //金币的给予，待修改
        int CoinNum = (GameDataManager.Instance.NodeNum / 10 + 1) * 500;
        GameDataManager.Instance.CoinNum = GameDataManager.Instance.CoinNum + CoinNum;

        GameDataManager.Instance.nodeData.enemyTeamDatas[enemyTeamPosition].isActive = false;
        int expNum=ChrLevelUp();

        List<string> VictorySettlementStr = new List<string>();
        VictorySettlementStr.Add("金币" + "x" + CoinNum.ToString() + "\n");
        VictorySettlementStr.Add("经验" + "x" + expNum.ToString() +"/角色"+ "\n");
        VictorySettlementStr.AddRange(GetDroppedItemList());

        return VictorySettlementStr;
    }

    /// <summary>
    /// 统计技能的数量是否允许开始战斗
    /// </summary>
    /// <returns></returns>
    bool SkillNumConfirm()
    {
        bool ChrHasSki = true;
        foreach (var i in GameDataManager.Instance.BattleCharacterTeam)
        {
            if (GameDataManager.Instance.CharacterTeam[i.Value].skillComponent.SkiNum == 0)
            {
                ChrHasSki = false;
                break;
            }
        }
        return ChrHasSki;
    }

    int ChrLevelUp()
    {
        int expNum = (GameDataManager.Instance.NodeNum + 1) * 500;
        foreach (var i in GameDataManager.Instance.BattleCharacterTeam)
        {
            GameDataManager.Instance.CharacterTeam[i.Value].LevelUp(expNum);
        }
        return expNum;
    }

    List<string> GetDroppedItemList()
    {
        ushort droppedItemNum = (ushort)Random.Range(1, 6);//需要给予几份掉落物
        List<int> ItemPosList = GetItemListInt(GameDataManager.Instance.nodeData.canDroppedItems.Count);
        int itemNum = 0;//物品的数量
        List<string> itemListTexts = new List<string>();
        foreach (var i in ItemPosList)
        {
            switch (DataManager.Instance.singletonItemData[GameDataManager.Instance.nodeData.canDroppedItems[i]].itemType)
            {
                case ItemType.Normal:
                    itemNum = Random.Range(0, 3);
                    itemListTexts.Add(
                    GameDataManager.Instance.pocket.AddItems(GameDataManager.Instance.nodeData.canDroppedItems[i], itemNum * 3)//库存数量，以三作涨
                        );
                    break;
                case ItemType.Equipment:

                    itemListTexts.Add(
                    GameDataManager.Instance.pocket.AddItems(GameDataManager.Instance.nodeData.canDroppedItems[i], 1)
                    );
                    break;
                default:
                    break;
            }
        }
        return itemListTexts;
    }

    List<int> GetItemListInt(int itemCount)
    {
        List<int> tempItemPosList = new List<int>();
        ushort droppedItemNum = (ushort)Random.Range(1, 10);//需要给予几份掉落物
        for (int i = 0; i < droppedItemNum;)
        {
            int ItemPos = Random.Range(0, itemCount);
            tempItemPosList.Add(ItemPos);
            i++;

        }
        return tempItemPosList;
    }
}
