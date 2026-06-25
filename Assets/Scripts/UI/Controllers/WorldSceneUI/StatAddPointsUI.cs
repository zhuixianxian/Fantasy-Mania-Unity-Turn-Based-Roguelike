using System.Collections;
using System.Collections.Generic;
using System.Data;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class StatAddPointsUI : MonoBehaviour
{
    public StatType statType;

    public Button AddPointButton;
    public Button ReducePointButton;
    public Button Add10PointsButton;
    public Button Reduce10PointsButton;
    public Button ClearPointsButton;
    // Start is called before the first frame update
    void Start()
    {
        AddPointButton.onClick.AddListener(() => {
            Debug.Log(statType.ToString());
            EventCenter.Instance.EventTrigger<StatType>(E_EventType.E_AddPointEvent, statType);
        });
        ReducePointButton.onClick.AddListener(() => {
            EventCenter.Instance.EventTrigger<StatType>(E_EventType.E_ReducePointEvent, statType);
        });
        Add10PointsButton.onClick.AddListener(() => {
            EventCenter.Instance.EventTrigger<StatType>(E_EventType.E_Add10PointsEvent, statType);
        });
        Reduce10PointsButton.onClick.AddListener(() => {
            EventCenter.Instance.EventTrigger<StatType>(E_EventType.E_Reduce10PointsEvent, statType);
        });
        ClearPointsButton.onClick.AddListener(() => {
            EventCenter.Instance.EventTrigger<StatType>(E_EventType.E_ClearPointsEvent, statType);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
