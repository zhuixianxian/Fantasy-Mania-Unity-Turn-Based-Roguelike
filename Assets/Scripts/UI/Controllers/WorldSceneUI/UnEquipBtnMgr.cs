using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class UnEquipBtnMgr : MonoBehaviour
{
    public EquipmentType equipmentType;//本按钮所代表的装备类型

    public Button UnEquipBtn;//本管理器所挂载的按钮

    // Start is called before the first frame update
    void Start()
    {
        UnEquipBtn.onClick.AddListener(() =>
        {
            EventCenter.Instance.EventTrigger<EquipmentType>(E_EventType.E_UnEquipEquipment, equipmentType);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
