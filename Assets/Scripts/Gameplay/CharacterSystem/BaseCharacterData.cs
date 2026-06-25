using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace FantasyMania.TurnBasedCombat
{
    [System.Serializable]
    /// <summary>
    /// 参与战斗的英雄的对象模型
    /// </summary>
    public class BaseCharacterData
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID="默认ID";
        /// <summary>
        /// 英雄名字
        /// </summary>
        public string Name="默认名称";
        ///// <summary>
        ///// 头像路径
        ///// </summary>
        //public string Ico;
        /// <summary>
        /// 英雄等级
        /// </summary>
        public int BaseLevel=0;
        /// <summary>
        /// 英雄经验
        /// </summary>
        public int BaseExperience=100;
        ///// <summary>
        ///// 英雄星级
        ///// </summary>
        //public Global.StarLevel StarLevel;
        /// <summary>
        /// 生命值
        /// </summary>
        public long BaseHealth=50;
        /// <summary>
        /// 魔力值
        /// </summary>
        public long BaseEnergy=30;
        /// <summary>
        /// 物理攻击力
        /// </summary>
        public long BaseAttack=10;
        /// <summary>
        /// 物理防御力
        /// </summary>
        public long BaseDefense=8;
        /// <summary>
        /// 魔法攻击力
        /// </summary>
        public long BaseMagicAttack=10;
        /// <summary>
        /// 魔法防御力
        /// </summary>
        public long BaseMagicDefense=8;
        /// <summary>
        /// 速度
        /// </summary>
        public long BaseSpeed=9;
        /// <summary>
        /// 命中
        /// </summary>
        public long BaseAccuracy = 10;
        /// <summary>
        /// 闪避
        /// </summary>
        public long BaseEvasion = 10;
        /// <summary>
        /// 招架
        /// </summary>
        public long BaseParry = 10;
        /// <summary>
        /// 敏捷
        /// 与招架相对应
        /// </summary>
        public long BaseAgility = 10;
        /// <summary>
        /// 效果命中
        /// </summary>
        public long BaseEffectHit = 10;
        /// <summary>
        /// 效果抵抗
        /// </summary>
        public long BaseEffectResistance = 10;

        /// <summary>
        /// 英雄的技能
        /// </summary>
        public List<BaseSkillData> Skills;
        /// <summary>
        /// 英雄的描述
        /// </summary>
        public string Description="默认描述";

        /// <summary>
        /// 空的构造函数
        /// </summary>
        public BaseCharacterData() { }

        private void SetDefaultValues()
        {
            this.ID = "default_" + System.Guid.NewGuid().ToString().Substring(0, 8);
            this.Name = "默认英雄";
            this.BaseLevel = 1;
            this.BaseExperience = 100;

            this.BaseHealth = 100;
            this.BaseEnergy = 100;

            this.BaseAttack = 10;
            this.BaseDefense = 5;
            this.BaseMagicAttack = 15;
            this.BaseMagicDefense = 10;
            this.BaseSpeed = 15;

            this.BaseAccuracy = 10;
            this.BaseEvasion = 10;

            this.BaseParry = 10;
            this.BaseAgility = 10;

            this.Skills = new List<BaseSkillData>();
            this.Description = "默认描述";
        }
    }
}
