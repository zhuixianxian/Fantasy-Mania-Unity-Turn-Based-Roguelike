using System;
using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 世界场景中的技能组件
/// </summary>
public class SkillComponent
{
    // 序列化时排除，避免无限循环
    //public WorldCharacterData Owner;
    public string OwnerChrID;

    public string NormalAttack;
    public List<string> SkillList = new List<string>();
    public List<string> EnergySkillList = new List<string>();
    public List<string> WholeTeamSkillList = new List<string>();
    public List<string> CDSkillList = new List<string>();

    public List<string> ComboSkillList = new List<string>();
    public List<string> CounterSkillList = new List<string>();
    public List<string> FollowupSkillList = new List<string>();

    public ushort SkiNum;//该角色身上当前的技能数量

    public Dictionary<string, WSceneSkillData> Skill = new Dictionary<string, WSceneSkillData>();
    public SkillComponent() { }
    public SkillComponent(string _ownerChrID)
    {
        OwnerChrID = _ownerChrID;
        SkiNum = 0;
    }

    public ConfigSkillType SkillConfig(WSceneSkillData skill)
    {
        switch (skill.skillType)
        {
            case SkillType.NormalAttack:
                // 普通攻击：相同则卸下（置空），不同则覆盖
                if (NormalAttack == skill.SkillID)
                {
                    NormalAttack = null;
                    SkiNum--;
                    return ConfigSkillType.Remove;
                }
                else
                {
                    SkiNum++;
                    NormalAttack = skill.SkillID;
                    return ConfigSkillType.Join;
                }

            case SkillType.Skill:
                return ToggleSkillInList(SkillList, skill, maxCount: 2);

            case SkillType.EnergySkill:
                return ToggleSkillInList(EnergySkillList, skill, maxCount: 1);

            case SkillType.CDSkill:
                return ToggleSkillInList(CDSkillList, skill, maxCount: 3); // 无限制

            case SkillType.WholeTeamSkill:
                return ToggleSkillInList(WholeTeamSkillList, skill, maxCount: 1);

            case SkillType.ComboSkill:
                return ToggleSkillInList(ComboSkillList, skill, maxCount: null);

            case SkillType.CounterSkill:
                return ToggleSkillInList(CounterSkillList, skill, maxCount: null);

            case SkillType.FollowupSkill:
                return ToggleSkillInList(FollowupSkillList, skill, maxCount: null);
            default:
                return ConfigSkillType.None;
        }
    }

    /// <summary>
    /// 辅助方法：如果技能已在列表中则移除，否则尝试添加（不超过最大数量）
    /// </summary>
    /// <param name="list">目标列表</param>
    /// <param name="skill">要切换的技能</param>
    /// <param name="maxCount">最大允许数量，null 表示无限制</param>
    private ConfigSkillType ToggleSkillInList(List<string> list, WSceneSkillData skill, int? maxCount)
    {
        if (list.Contains(skill.SkillID))
        {
            SkiNum--;
            list.Remove(skill.SkillID);
            return ConfigSkillType.Remove;
        }

        // 有上限且已达上限则无法添加
        if (maxCount.HasValue && list.Count >= maxCount.Value)
        {
            Debug.LogWarning($"无法添加技能 {skill.SkillName}，{skill.skillType} 类型已达到上限 {maxCount.Value}");
            return ConfigSkillType.Full;
        }
        SkiNum++;
        list.Add(skill.SkillID);
        return ConfigSkillType.Join;
    }
}
