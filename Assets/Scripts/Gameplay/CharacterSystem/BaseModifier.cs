using System;
using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;
namespace FantasyMania.TurnBasedCombat
{
    public class BaseModifier //: IModifier
    {
        public float modifierValue { get; set; }//修改器的初始值
        public int priority { get;  set; }
        public uint modifierLevel { get;  set; }
        public ModifierType type { get;  set; }
        public StatType statType { get;  set; }
        public string sourceId { get;  set; }

        public string levelFuncStr { get; set; }

        //public Dictionary<uint, float> levelFunction { get;  set; }
        Func<uint, float> levelFunction { get;  set; }

        // 无参构造函数 – 供 LitJson 反序列化使用
        public BaseModifier()
        {
        }

        public BaseModifier(float _modifierValue, string _sourceId, int _priority, uint _modifierLevel,
                              ModifierType _type, StatType _statType, string _levelFuncStr)
        {
            modifierValue = _modifierValue;
            sourceId = _sourceId;
            priority = _priority;
            modifierLevel = _modifierLevel;
            type = _type;
            statType = _statType;
            levelFuncStr = _levelFuncStr;

            //levelFunction = GameFunctions.Instance.CallFloatFunc(levelFuncStr);
        }

        public BaseModifier(BaseModifier modifier)
        {
            modifierValue = modifier.modifierValue;
            sourceId = modifier.sourceId;
            priority = modifier.priority;
            modifierLevel = modifier.modifierLevel;
            type = modifier.type;
            statType = modifier.statType;
            levelFuncStr = modifier.levelFuncStr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentValue">修改前的属性的当前值</param>
        /// <returns></returns>
        public long ReturnModifierValue(long currentValue)
        {
            
            switch (type)
            {
                case ModifierType.AddBase:
                    return Convert.ToInt64(currentValue + modifierValue * modifierLevel);
                case ModifierType.Add:
                    
                    return Convert.ToInt64(currentValue + modifierValue * 
                        GameFunctions.Instance.CallFloatFunc(levelFuncStr, modifierLevel));
                case ModifierType.Multiply:
                    
                    return Convert.ToInt64(currentValue + currentValue * modifierValue * 
                        GameFunctions.Instance.CallFloatFunc(levelFuncStr, modifierLevel));
                case ModifierType.Override:
                    
                    return Convert.ToInt64(modifierValue * 
                        GameFunctions.Instance.CallFloatFunc(levelFuncStr, modifierLevel));
                default:
                    return currentValue;
            }
        }

        public float ReturnModifierValue()
        {

            switch (type)
            {
                case ModifierType.AddBase:
                    return modifierValue * modifierLevel;
                case ModifierType.Add:
                    return modifierValue * GameFunctions.Instance.CallFloatFunc(levelFuncStr, modifierLevel);
                case ModifierType.Multiply:
                    Debug.Log("modifierValue"+ modifierValue);
                    Debug.Log(levelFuncStr);
                    Debug.Log("GameFunctions.Instance.CallFloatFunc(levelFuncStr, modifierLevel)"
                        + GameFunctions.Instance.CallFloatFunc(levelFuncStr, modifierLevel));

                    return 1 * modifierValue * GameFunctions.Instance.CallFloatFunc(levelFuncStr, modifierLevel);
                case ModifierType.Override:
                    return modifierValue * GameFunctions.Instance.CallFloatFunc(levelFuncStr, modifierLevel);
                default:
                    return 0;
            }
        }
    }
}