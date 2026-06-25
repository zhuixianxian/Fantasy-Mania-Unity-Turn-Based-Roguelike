using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class TagBuff : IBaseBuff
{
    public string BuffID { get; private set; }
    public string BuffName { get; private set; }
    public bool isBufforDebuff { get; private set; }
    public string BuffDescription { get; private set; }
    public short BuffDuration { get; set; }      // 初始持续回合数，-1为永续
    public short currentBuffDuration { get; set; }      // 剩余持续回合数，-1为永续

    public BuffType buffType { get; private set; }
    public BuffOverlayType buffOverlayType { get; private set; }
    public BuffReduceType BuffReduceType { get; private set; }
    //public float BuffValue { get; private set; }
    public ushort BuffLevel { get; set; }
    public ushort BuffMaxLevel { get; private set; }
    public List<string> BuffTags = new List<string>();
    public TagBuff
    (
    string buffId,
    string buffName,
    bool _isBufforDebuff,
    string description,
    short duration,
    BuffType type,
    BuffOverlayType overlayType,
    BuffReduceType reduceType,
    //long value,
    ushort maxLevel,
    List<string> TagList
    )
    {
        BuffID = buffId;
        BuffName = buffName;
        isBufforDebuff = _isBufforDebuff;
        BuffDescription = description;
        BuffDuration = duration;
        currentBuffDuration = duration;

        buffType = type;
        buffOverlayType = overlayType;
        BuffReduceType = reduceType;
        //BuffValue = value;
        BuffMaxLevel = maxLevel;
        BuffLevel = 1;                     // 初始等级，可根据需要设为参数或默认1
        BuffTags = new List<string>();
        foreach (var i in TagList)
        {
            BuffTags.Add(i);
        }
    }

    /// <summary>
    /// 复制构造函数
    /// </summary>
    /// <param name="_statBuff"></param>
    public TagBuff(TagBuff _tagBuff)
    {
        BuffID = _tagBuff.BuffID;
        BuffName = _tagBuff.BuffName;
        BuffDescription = _tagBuff.BuffDescription;
        BuffDuration = _tagBuff.BuffDuration;
        currentBuffDuration = _tagBuff.BuffDuration;

        buffType = _tagBuff.buffType;
        buffOverlayType = _tagBuff.buffOverlayType;
        BuffReduceType = _tagBuff.BuffReduceType;
        BuffMaxLevel = _tagBuff.BuffMaxLevel;
        BuffLevel = _tagBuff.BuffLevel;
        // 深拷贝 modifier 列表
        BuffTags = new List<string>();
        foreach (var tag in _tagBuff.BuffTags)
        {
            BuffTags.Add(tag);
        }
    }

    public string GetDescription()
    {
        string result = BuffDescription;
        return result;
    }

    public IBaseBuff ModifyBuffValue(List<float> modValueList)
    {
        throw new System.NotImplementedException();
    }
}
