using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class NextNodeLauncher : MonoBehaviour
{
    public int nextNodePosition;//调用的是节点中的哪个下一个节点

    //public GameObject shopPanel;//合成台面板

    // 单例实例
    public static NextNodeLauncher Instance { get; private set; }


    private void Awake()
    {
        // 实现单例逻辑
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 商店唤起的统一调用
    /// </summary>
    /// <param name="shopPos">调用的是节点中的哪个商店</param>
    public void LaunchToNextNode(ushort nextNodePos)
    {
        //待修改
        if (CanToNextNode())
        {
            GameDataManager.Instance.GenerateNode(
                GameDataManager.Instance.nodeData.nextNodeDatas[nextNodePos].nextNodeMapID
                );
            //Debug.Log(GameDataManager.Instance.nodeData.nextNodeDatas[nextNodePos].nextNodeMapID);
        }
        else
        {
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_PromptPanelDisplay, "有群家伙拦下了你！");
        }
    }

    bool CanToNextNode()
    {
        foreach(var i in GameDataManager.Instance.nodeData.enemyTeamDatas)
        {
            if (i.isActive) return false;
        }
        return true;
    }
}
