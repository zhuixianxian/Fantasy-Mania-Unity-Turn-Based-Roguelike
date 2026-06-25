using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;
namespace FantasyMania.TurnBasedCombat
{
    public interface IModifier
    {
        /// <summary>
        /// 修改器的基础数值
        /// </summary>
        float modifierValue { get; set; }
        /// <summary>
        /// 应用修改，返回修改后的值
        /// </summary>
        long ReturnModifierValue(long currentValue);

        /// <summary>
        /// 优先级（越小越先执行）
        /// </summary>
        int priority { get; set; }
        /// <summary>
        /// 修改器等级
        /// </summary>
        uint modifierLevel { get; set; }

        /// <summary>
        /// 修改器类型（用于识别）
        /// </summary>
        ModifierType type { get; set; }

        /// <summary>
        /// 属性类型，用于将修改器分配出去
        /// </summary>
        StatType statType { get; set; }

        /// <summary>
        /// 来源标识（用于移除特定来源的修改器）
        /// </summary>
        string sourceId { get; set; }

        ///// <summary>
        ///// 是否已过期
        ///// </summary>
        //bool IsExpired { get; }
        /// <summary>
        /// 等级所对应的具体修改值
        /// </summary>
        //Func<uint, float> levelFunction { get; set; }
        string levelFuncStr { get; }
    }
}