using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class SkillLevelUpUI : MonoBehaviour
{
    public string chrCarrySkillID;
    public TextMeshProUGUI SkillNameText;//技能名字显示处
    public TextMeshProUGUI SkillTypeText;//技能类型显示处
    public Button DescButton;//显示技能描述的按钮
    public Button ConfigButton;//配置角色技能的按钮
    public Button LevelUpButton;//技能升级按钮
    // Start is called before the first frame update
    void Start()
    {
        DescButton.onClick.AddListener(() => {
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_SkillDescription, chrCarrySkillID);
        });
        LevelUpButton.onClick.AddListener(() => {
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_SkillLevelUp, chrCarrySkillID);
        });
        ConfigButton.onClick.AddListener(() => {
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_SkillConfiguration, chrCarrySkillID);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSkillNameText(string skillName,SkillType skillType)
    {
        SkillNameText.text = skillName;
        switch (skillType)
        {
            case SkillType.NormalAttack:
                SkillTypeText.text = "普攻";
                break;
            case SkillType.Skill:
                SkillTypeText.text = "技能点技能";
                break;
            case SkillType.EnergySkill:
                SkillTypeText.text = "能量技能";
                break;
            case SkillType.CDSkill:
                SkillTypeText.text = "冷却技能";
                break;
            case SkillType.WholeTeamSkill:
                SkillTypeText.text = "全队技能";
                break;
            case SkillType.ComboSkill:
                SkillTypeText.text = "连击";
                break;
            case SkillType.CounterSkill:
                SkillTypeText.text = "反击";
                break;
            case SkillType.FollowupSkill:
                SkillTypeText.text = "追击";
                break;


        }
    }
}
