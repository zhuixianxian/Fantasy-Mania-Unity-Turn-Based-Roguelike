using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class UPBSUIMgr : MonoBehaviour
{
    public Button StatButton;//用于显示战斗时属性面板的按钮
    public Button SettingButton;//用于显示战斗时属性面板的按钮

    public GameObject StatPanel;//具体的属性显示面板
    public GameObject SettingPanel;//具体的属性显示面板



    // Start is called before the first frame update
    void Start()
    {
        StatButton.onClick.AddListener(() =>
        {
            if(BattleSkillManager.Instance.actionState== ActionState.ChrSkillExecute_1||
            BattleSkillManager.Instance.actionState == ActionState.ChrSkillExecute_2)
            {
                StatPanel.SetActive(true);
            }
        });

        SettingButton.onClick.AddListener(() =>
        {
            if (BattleSkillManager.Instance.actionState == ActionState.ChrSkillExecute_1 ||
            BattleSkillManager.Instance.actionState == ActionState.ChrSkillExecute_2)
            {
                SettingPanel.SetActive(true);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
