using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class StatBuff : IBaseBuff
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
    public List<BaseModifier> BuffStatModifier = new List<BaseModifier>();
    public StatBuff
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
    List<StatBuffBag> modiBagList
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
        BuffStatModifier = new List<BaseModifier>();
        foreach (var i in modiBagList)
        {
            BuffStatModifier.Add(new BaseModifier(i.statValue, "Buff", 1, BuffLevel, i.modifierType, i.statType, i.LevelFuncStr));
        }
    }

    /// <summary>
    /// 复制构造函数
    /// </summary>
    /// <param name="_statBuff"></param>
    public StatBuff(StatBuff _statBuff)
    {
        BuffID = _statBuff.BuffID;
        BuffName = _statBuff.BuffName;
        BuffDescription = _statBuff.BuffDescription;
        BuffDuration = _statBuff.BuffDuration;
        currentBuffDuration = _statBuff.currentBuffDuration;
        buffType = _statBuff.buffType;
        buffOverlayType = _statBuff.buffOverlayType;
        BuffReduceType = _statBuff.BuffReduceType;
        BuffMaxLevel = _statBuff.BuffMaxLevel;
        BuffLevel = _statBuff.BuffLevel;
        // 深拷贝 modifier 列表
        BuffStatModifier = new List<BaseModifier>();
        foreach (var mod in _statBuff.BuffStatModifier)
        {
            BuffStatModifier.Add(new BaseModifier(mod));
        }
    }
    /// <summary>
    /// 修改Buff的具体数据
    /// </summary>
    /// <param name="modValueList"></param>
    /// <returns></returns>
    public IBaseBuff ModifyBuffValue(List<float> modValueList)
    {
        if (modValueList == null) return this;
        int modValueListNum = 0;
        foreach (var i in modValueList)
        {
            if (modValueListNum < BuffStatModifier.Count)
            {
                BuffStatModifier[modValueListNum].modifierValue = i;
            }
            modValueListNum++;
        }
        return this;
    }
    /// <summary>
    /// Buff等级提升
    /// </summary>
    public void BuffLevelUp()
    {
        if (BuffLevel < BuffMaxLevel)
        {
            BuffLevel++;

            foreach (var i in BuffStatModifier)
            {

                i.modifierLevel = BuffLevel;
                //Debug.Log(i.ReturnModifierValue());

            }
        }
    }

    /// <summary>
    /// Buff等级提升
    /// </summary>
    public void BuffLevelDown()
    {
        if (BuffLevel >0)
        {
            BuffLevel--;

            foreach (var i in BuffStatModifier)
            {

                i.modifierLevel = BuffLevel;
                //Debug.Log(i.ReturnModifierValue());

            }
        }
    }

    public string GetDescription()
    {
        string result = BuffDescription;
        for (int i = 0; i < BuffStatModifier.Count; i++)
        {
            string placeholder = "{" + i + "}";
            if (result.Contains(placeholder))
            {
                result = result.Replace(placeholder,
                    //BuffStatModifier[i].ReturnModifierValue().ToString()
                    GetStatNumDesp(
                        BuffStatModifier[i].ReturnModifierValue(),
                        BuffStatModifier[i].type
                        )
                    );
            }
        }
        result = System.Text.RegularExpressions.Regex.Replace(result, @"\{(\d+)\}", "0");

        return result;
    }

    string GetStatNumDesp(float modiNum, ModifierType modifierType)
    {
        switch (modifierType)
        {
            case ModifierType.Add:
                return modiNum.ToString();
            case ModifierType.Multiply:
                return (modiNum*100f).ToString() + "%";
            default:
                return modiNum.ToString();
        }
    }
}
