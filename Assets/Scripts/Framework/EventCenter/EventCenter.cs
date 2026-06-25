using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 用于 里式替换原则 装载 子类的父类
/// </summary>
public abstract class EventInfoBase{ }

/// <summary>
/// 用来包裹 对应观察者 函数委托的 类
/// </summary>
/// <typeparam name="T"></typeparam>
// 原有的无返回值版本（保持不变）
public class EventInfo<T> : EventInfoBase
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action) { actions += action; }
}

// 新增的带返回值版本
//public class EventInfo<T, K> : EventInfoBase
//{
//    public Func<T, K> actions;
//    public EventInfo(Func<T, K> action) { actions += action; }
//}

/// <summary>
/// 主要用来记录无参无返回值委托
/// </summary>
public class EventInfo: EventInfoBase
{
    public UnityAction actions;
     
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}


/// <summary>
/// 事件中心模块 
/// </summary>
public class EventCenter: BaseManager<EventCenter>
{
    //用于记录对应事件 关联的 对应的逻辑
    private Dictionary<E_EventType, EventInfoBase> eventDic = new Dictionary<E_EventType, EventInfoBase>();

    private EventCenter() { }

    /// <summary>
    /// 触发事件 
    /// </summary>
    /// <param name="eventName">事件名字</param>
    public void EventTrigger<T>(E_EventType eventName, T info)
    {
        //存在关心我的人 才通知别人去处理逻辑
        if(eventDic.ContainsKey(eventName))
        {
            //去执行对应的逻辑
            (eventDic[eventName] as EventInfo<T>).actions?.Invoke(info);
        }
    }

    //public K EventTrigger<T, K>(E_EventType eventName, T info)
    //{
    //    if (eventDic.TryGetValue(eventName, out var value) && value is EventInfo<T, K> eventInfo)
    //    {
    //        // 假设 eventInfo.actions 是 Func<T, K> 类型
    //        if (eventInfo.actions != null)
    //        {
    //            return eventInfo.actions(info);
    //        }
    //    }
    //    return default(K);
    //}


    /// <summary>
    /// 触发事件 无参数
    /// </summary>
    /// <param name="eventName"></param>
    public void EventTrigger(E_EventType eventName)
    {
        //存在关心我的人 才通知别人去处理逻辑
        if (eventDic.ContainsKey(eventName))
        {
            //去执行对应的逻辑
            (eventDic[eventName] as EventInfo).actions?.Invoke();
        }
    }


    /// <summary>
    /// 添加事件监听者
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="func"></param>
    public void AddEventListener<T>(E_EventType eventName, UnityAction<T> func)
    {
        //如果已经存在关心事件的委托记录 直接添加即可
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions += func;
        }
        else
        {
            eventDic.Add(eventName, new EventInfo<T>(func));
        }
    }

    public void AddEventListener(E_EventType eventName, UnityAction func)
    {
        //如果已经存在关心事件的委托记录 直接添加即可
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions += func;
        }
        else
        {
            eventDic.Add(eventName, new EventInfo(func));
        }
    }

    /// <summary>
    /// 移除事件监听者
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="func"></param>
    public void RemoveEventListener<T>(E_EventType eventName, UnityAction<T> func)
    {
        if (eventDic.ContainsKey(eventName))
            (eventDic[eventName] as EventInfo<T>).actions -= func;
    }

    public void RemoveEventListener(E_EventType eventName, UnityAction func)
    {
        if (eventDic.ContainsKey(eventName))
            (eventDic[eventName] as EventInfo).actions -= func;
    }

    /// <summary>
    /// 清空所有事件的监听
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }

    /// <summary>
    /// 清除指定某一个事件的所有监听
    /// </summary>
    /// <param name="eventName"></param>
    public void Clear(E_EventType eventName)
    {
        if (eventDic.ContainsKey(eventName))
            eventDic.Remove(eventName);
    }
}
