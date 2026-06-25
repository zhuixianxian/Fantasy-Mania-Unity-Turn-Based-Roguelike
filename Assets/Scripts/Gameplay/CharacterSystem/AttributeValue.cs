using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static UnityEngine.Rendering.DebugUI;
namespace FantasyMania.TurnBasedCombat
{
    public class AttributeValue
    {
        /// <summary>
        /// 当前值
        /// </summary>
        public long currentValue;
        /// <summary>
        /// 基础值
        /// </summary>
        public long baseValue;
        /// <summary>
        /// 属性修改器列表
        /// </summary>
        public List<BaseModifier> attriModiList = new List<BaseModifier>();
        public AttributeValue()
        {
            baseValue = 0;
            currentValue = 0;
        }

        public AttributeValue(long value)
        {
            baseValue = value;
            currentValue = value;
        }
        public AttributeValue(float value)
        {
            baseValue = Convert.ToInt64(value);
            currentValue = Convert.ToInt64(value);
        }
        //修改器优先级排序函数
        private void SortModifiers()
        {
            attriModiList.Sort((a, b) => a.priority.CompareTo(b.priority));
        }
        //添加修改器
        public void AddModifier(BaseModifier modifier)
        {
            attriModiList.Add(modifier);
            SortModifiers();
            UseModifier();
        }

        //移除修改器
        public void RemoveModifier(string _sourceID)
        {
            attriModiList.RemoveAll(item => item.sourceId == _sourceID);
            SortModifiers();
            UseModifier();
        }
        //清空修改器
        public void ClearModifier()
        {
            attriModiList.Clear();
            UseModifier();
        }
        //作用修改器
        private void UseModifier()
        {
            currentValue = baseValue;
            foreach (var _modifier in attriModiList)
            {
                currentValue = _modifier.ReturnModifierValue(currentValue);
            }

        }
    }
}
