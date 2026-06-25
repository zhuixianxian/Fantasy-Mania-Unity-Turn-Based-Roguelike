using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public struct SkillEventBag
{
    public SkillEventType skillEventType;
    public StatType statType;//根据哪个属性判断这次的值
    private float EventBaseValue;
    public string BuffID;
    public List<float> EventModifyBuffValue { get; private set; }//修改Buff的列表
    private Func<uint, float> EventBaseValueFunc;//根据技能等级修改技能事件的真实值
    public SkillEventBag
        (
        SkillEventType _skillEventType,
        StatType _statType,
        List<float> _EventModifyBuffValue,
        float _EventBaseValue = 0,
        Func<uint, float> _EventBaseValueFunc = null,
        string _BuffID = "none"
        )
    {
        skillEventType = _skillEventType;
        statType = _statType;
        EventBaseValue = _EventBaseValue;
        BuffID = _BuffID;
        EventBaseValueFunc = _EventBaseValueFunc;
        EventModifyBuffValue = new List<float>();
        foreach (var i in _EventModifyBuffValue)
        { 
            EventModifyBuffValue.Add(i); 
        }
    }

    /// <summary>
    /// 给伤害型，回复型的事件包的构造函数
    /// </summary>
    /// <param name="_skillEventType"></param>
    /// <param name="_statType">用哪个属性判断作用</param>
    /// <param name="_EventBaseValue">基础属性</param>
    /// <param name="_EventBaseValueFunc">属性函数，用来根据技能等级判断属性的变化</param>
    public SkillEventBag
        (
        SkillEventType _skillEventType,
        StatType _statType,
    float _EventBaseValue,
    Func<uint, float> _EventBaseValueFunc
        )
    {
        skillEventType = _skillEventType;
        statType = _statType;
        EventBaseValue = _EventBaseValue;
        BuffID = "none";
        EventBaseValueFunc = _EventBaseValueFunc;
        EventModifyBuffValue = new List<float>();
    }
    /// <summary>
    /// 给Buff型事件的包的构造函数
    /// </summary>
    /// <param name="_skillEventType">事件类型，用于分发</param>
    /// <param name="_EventModifyBuffValue">对Buff的数据进行修改的列表</param>
    /// <param name="_EventBaseValueFunc"></param>
    /// <param name="_BuffID">从Buff库中取原型的依据</param>
    public SkillEventBag
        (
        SkillEventType _skillEventType,
        List<float> _EventModifyBuffValue,
    Func<uint, float> _EventBaseValueFunc = null,
        string _BuffID = "none"
        )
    {
        skillEventType = _skillEventType;
        statType = StatType.None;
        EventBaseValue = 0;
        BuffID = _BuffID;
        EventBaseValueFunc = _EventBaseValueFunc;
        EventModifyBuffValue = new List<float>();
        foreach (var i in _EventModifyBuffValue)
        {
            EventModifyBuffValue.Add(i);
        }
    }

    public SkillEventBag
        (SkillEventBag other)
    {
        skillEventType = other.skillEventType;
        statType = other.statType;
        EventBaseValue = other.EventBaseValue;
        BuffID = other.BuffID;
        EventBaseValueFunc = other.EventBaseValueFunc;
        EventModifyBuffValue = new List<float>();
        foreach(var i in other.EventModifyBuffValue)
        {
            EventModifyBuffValue.Add(i);
        }
    }

    public float GetSkillEventValue(ushort SkillLevel)
    {
        return EventBaseValue * EventBaseValueFunc(SkillLevel);
    }

    public List<float> GetEventModifyBuffValue(ushort SkillLevel)
    {
        List<float> tempEventModifyBuffValue = new List<float>();
        for (int i=0;i< EventModifyBuffValue.Count;i++)
        {
            tempEventModifyBuffValue.Add(EventModifyBuffValue[i]* EventBaseValueFunc(SkillLevel));
        }
        return tempEventModifyBuffValue;
    }
}
