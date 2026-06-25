using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 战斗事件打印处的管理器
/// </summary>
public class BattleEventPrintMgr : MonoBehaviour
{
    private static BattleEventPrintMgr instance;
    public static BattleEventPrintMgr Instance
    {
        get
        {
            return instance;
        }
    }
    public ScrollRect scrollRect;
    public TextMeshProUGUI BattleEventPrintPref;//显示打印文本的预制体
    public Transform EventPrintPos;//文本打印的位置

    private Queue<TextMeshProUGUI> EventPrintQueue;

    // Start is called before the first frame update
    void Start()
    {
        EventPrintQueue = new Queue<TextMeshProUGUI>();
        EventCenter.Instance.Clear(E_EventType.E_BattleEventPrint);
        EventCenter.Instance.AddEventListener<string>(E_EventType.E_BattleEventPrint, (eventText) =>
        {
            InstantiateEventPrint(eventText);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 实例化事件文本打印
    /// </summary>
    /// <param name="eventText"></param>
    void InstantiateEventPrint(string eventText)
    {
        TextMeshProUGUI newEventPrint = Instantiate(BattleEventPrintPref, EventPrintPos);
        newEventPrint.GetComponentInChildren<BattleEventPrintPrefMgr>().SetText(eventText);
        EventPrintQueue.Enqueue(newEventPrint);
        scrollRect.verticalNormalizedPosition = 0f;
        if (EventPrintQueue.Count > 10)
        {
            Destroy(EventPrintQueue.Dequeue().gameObject);
        }
    }
}
