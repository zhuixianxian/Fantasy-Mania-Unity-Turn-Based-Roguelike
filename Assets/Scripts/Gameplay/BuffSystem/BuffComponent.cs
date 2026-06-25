using System;
using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;
/// <summary>
/// 战斗场景中的Buff组件
/// </summary>
public class BuffComponent
{
    [NonSerialized]
    public BSBaseData Owner;

    public List<StatBuff> statBuffs;
    public List<TagBuff> tagBuffs;
    //public List<TurnTriggerBuff> turnTriggerBuffs;
    //public List<OnAttackTriggerBuff> onAttackTriggerBuffs;
    //public List<OnHitTriggerBuff> onHitTriggerBuffs;

    public BuffComponent(BSBaseData owner)
    {
        Owner = owner;

        statBuffs = new List<StatBuff>();
        tagBuffs = new List<TagBuff>();
    }
    /// <summary>
    /// 复制世界场景中的Buff，但应该不符合需求，待修改
    /// </summary>
    /// <param name="WSBuffComp">世界场景中的Buff组件，用于管理世界场景中的各种Buff</param>
    public void SetBuffFromWorld(BuffComponent WSBuffComp)
    {
        foreach (var buff in WSBuffComp.statBuffs)
        {
            statBuffs.Add(new StatBuff(buff));  // 使用 StatBuff 的复制构造函数
        }
    }
    /// <summary>
    /// 根据传入的Buff向数组中添加Buff
    /// </summary>
    /// <param name="Buff">传入的Buff</param>
    public void AddBuff(IBaseBuff Buff)
    {
        switch (Buff.buffType)
        {
            case BuffType.StatBuff:
                AddStatBuff(Buff as StatBuff);
                break;
            case BuffType.TagBuff:
                AddTagBuff(Buff as TagBuff);
                break;
            default:
                break;
        }
    }

    private void AddStatBuff(StatBuff statBuff)
    {
        StatBuff tempStatBuff = new StatBuff(statBuff);
        switch (tempStatBuff.buffOverlayType)
        {
            case BuffOverlayType.OverWrite:
                statBuffs.RemoveAll(b => b.BuffID == tempStatBuff.BuffID);
                statBuffs.Add(tempStatBuff);
                break;
            case BuffOverlayType.Independent:
                statBuffs.Add(tempStatBuff);
                break;
            case BuffOverlayType.LevelUp:
                bool isLvlUp = false;
                foreach (var i in statBuffs)
                {
                    if (i.BuffID == tempStatBuff.BuffID)
                    {
                        i.BuffLevelUp();
                        i.currentBuffDuration = i.BuffDuration;

                        isLvlUp = true;
                    }
                }
                if (!isLvlUp)
                {
                    statBuffs.Add(tempStatBuff);
                }
                break;
            default:
                break;
        }
    }


    private void AddTagBuff(TagBuff tagBuff)
    {
        TagBuff tempTagBuff = new TagBuff(tagBuff);
        tagBuffs.Add(tempTagBuff);

    }

    /// <summary>
    /// 削减Buff的持续时间
    /// </summary>
    public void ReduceDuration()
    {
        for (int i = statBuffs.Count - 1; i >= 0; i--)
        {
            ReduceStatBuff(statBuffs[i]);
        }

        for (int i = tagBuffs.Count - 1; i >= 0; i--)
        {
            ReduceTagBuff(tagBuffs[i]);
        }
    }
    /// <summary>
    /// 实际如何削减Buff
    /// </summary>
    public void ReduceStatBuff(StatBuff buff)
    {
        if (buff.currentBuffDuration > 0)
        {
            buff.currentBuffDuration--;
        }
        else if (buff.currentBuffDuration == 0)
        {
            if (buff.BuffReduceType == BuffReduceType.Clear)
            {
                statBuffs.Remove(buff);
            }
            else if(buff.BuffReduceType == BuffReduceType.LevelDown)
            {
                if (buff.BuffLevel <= 1)
                    statBuffs.Remove(buff);
                else
                {
                    buff.BuffLevelDown();
                    buff.currentBuffDuration = buff.BuffDuration;
                }
            }
        }
    }

    public void ReduceTagBuff(TagBuff buff)
    {
        if (buff.currentBuffDuration > 0)
        {
            buff.currentBuffDuration--;
        }
        else if (buff.currentBuffDuration == 0)
        {
            if (buff.BuffReduceType == BuffReduceType.Clear)
            {
                tagBuffs.Remove(buff);
            }
            else 
            {
                if (buff.BuffLevel <= 1)
                    tagBuffs.Remove(buff);
                else
                {
                    buff.BuffLevel--;
                    buff.currentBuffDuration = buff.BuffDuration;
                }
            }
        }
    }

    /// <summary>
    /// 获取属性buff的修改器
    /// </summary>
    /// <returns></returns>
    public List<BaseModifier> GetStatBuffModi()
    {
        List<BaseModifier> tempModiList = new List<BaseModifier>();
        foreach (var i in statBuffs)
        {
            tempModiList.AddRange(i.BuffStatModifier);
        }
        return tempModiList;
    }
    /// <summary>
    /// 获取TagBuff的所有Tag
    /// </summary>
    /// <returns></returns>
    public List<string> GetTagBuffTag()
    {
        List<string> tempTagList = new List<string>();
        foreach (var i in tagBuffs)
        {
            tempTagList.AddRange(i.BuffTags);
        }
        return tempTagList;
    }
    public List<BuffStringBag> GetAllBuffDesc()
    {
        List<BuffStringBag> tempStringList = new List<BuffStringBag>();
        for (int i = statBuffs.Count - 1; i >= 0; i--)
        {
            tempStringList.Add(new BuffStringBag(statBuffs[i].GetDescription(), statBuffs[i].BuffName, statBuffs[i].currentBuffDuration.ToString()));
        }
        for (int i = tagBuffs.Count - 1; i >= 0; i--)
        {
            tempStringList.Add(new BuffStringBag(tagBuffs[i].GetDescription(), tagBuffs[i].BuffName, tagBuffs[i].currentBuffDuration.ToString()));
        }
        return tempStringList;
    }
}
