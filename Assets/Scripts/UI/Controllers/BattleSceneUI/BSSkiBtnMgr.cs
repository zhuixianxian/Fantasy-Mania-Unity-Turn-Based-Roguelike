using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BSSkiBtnMgr : MonoBehaviour
{
    //战斗场景中技能点按钮所需要挂载的管理器

    public BSSkillData hasBSSkiData;//存储的技能数据

    public Button mountButton;//挂载的按钮

    public TextMeshProUGUI usageConditions;//使用条件是什么的显示区
    public TextMeshProUGUI usageConditionsNum;//使用条件数值的显示区
    public TextMeshProUGUI SkillName;//技能名字的显示区
    // Start is called before the first frame update
    void Start()
    {
        hasBSSkiData = new BSSkillData();
        mountButton.onClick.AddListener(() =>
        {
            if (BattleSkillManager.Instance.actionState == ActionState.ChrSkillExecute_1|| BattleSkillManager.Instance.actionState == ActionState.ChrSkillExecute_2)
            {

                if (hasBSSkiData != null)
                {
                    BattleSkillManager.Instance.ChrSkillExecute_1(hasBSSkiData);
                }
            }
        }
            );
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 设置按钮匹配技能数据
    /// </summary>
    public void SetSkiDataText(string _usageConditions,
                            string _usageConditionsNum,
                            string _SkillName)
    {
        SkillName.text = _SkillName;
        usageConditionsNum.text = _usageConditionsNum;
        usageConditions.text = _usageConditions;
    }

    public void ClearButtonData()
    {
        SkillName.text = "";
        usageConditionsNum.text = "";
        usageConditions.text = "";
        hasBSSkiData = null;
    }
}
