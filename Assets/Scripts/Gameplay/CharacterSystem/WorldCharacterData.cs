using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.Events;

using static FantasyMania.TurnBasedCombat.GameEnums;

namespace FantasyMania.TurnBasedCombat
{
    // WorldCharacterData.cs
    //在游戏中的世界场景中，角色的数据存储类
    [System.Serializable]
    public class WorldCharacterData
    {
        // 核心身份信息
        public string CharacterID;
        public string CharacterName;
        //public SimpleStat Level = new SimpleStat(StatId.Level, "等级", StatType.Level, 0);
        public long Level;
        //public SimpleStat CurrentExperience = new SimpleStat(StatId.CurrentExperience, "当前经验", StatType.CurrentExperience, 0);
        public long CurrentExperience;
        //public SimpleStat MaxExperience = new SimpleStat(StatId.MaxExperience, "最大经验", StatType.MaxExperience, 0);
        public long MaxExperience;

        public TeamPosition teamPosition;

        //public ResourceStat Health = new ResourceStat(StatId.Health, "生命值", StatType.Health, 200);
        public long health;
        public AttributeValue MaxHealth;

        //public ResourceStat Mana = new ResourceStat(StatId.Mana, "魔力值", StatType.Mana, 100);
        public long energy;
        public long MaxEnergy;
        //public ResourceStat SkillPoints = new ResourceStat(StatId.SkillPoints, "技能点", StatType.SkillPoints, 100);
        public ushort skillPoints;
        public ushort MaxSkillPoints;

        //public SimpleStat Attack = new SimpleStat(StatId.Attack, "攻击", StatType.Attack, 10);
        public AttributeValue Attack;
        //public SimpleStat Defense = new SimpleStat(StatId.Defense, "防御", StatType.Defense, 8);
        public AttributeValue Defense;
        //public SimpleStat MagicAttack = new SimpleStat(StatId.MagicAttack, "魔法攻击", StatType.MagicAttack, 10);
        public AttributeValue MagicAttack;
        //public SimpleStat MagicDefense = new SimpleStat(StatId.MagicDefense, "魔法防御", StatType.MagicDefense, 8);
        public AttributeValue MagicDefense;
        //public SimpleStat Speed = new SimpleStat(StatId.Speed, "速度", StatType.Speed, 9);
        public AttributeValue Speed;
        //public SimpleStat Accuracy = new SimpleStat(StatId.Accuracy, "命中", StatType.Accuracy, 20);
        public AttributeValue Accuracy;
        //public SimpleStat Evasion = new SimpleStat(StatId.Evasion, "闪避", StatType.Evasion, 15);
        public AttributeValue Evasion;
        //public SimpleStat Parry = new SimpleStat(StatId.Parry, "招架", StatType.Parry, 20);
        public AttributeValue Parry;
        //public SimpleStat Agility = new SimpleStat(StatId.Agility, "敏捷", StatType.Agility, 15);
        public AttributeValue Agility;
        //public SimpleStat EffectHit = new SimpleStat(StatId.EffectHit, "效果命中", StatType.EffectHit, 20);
        public AttributeValue EffectHit;
        //public SimpleStat EffectResistance = new SimpleStat(StatId.EffectResistance, "效果抵抗", StatType.EffectResistance, 15);
        public AttributeValue EffectResistance;

        //public PercentageStat DamageReduction = new PercentageStat(StatId.DamageReduction, "免伤", StatType.DamageReduction, 0);
        public AttributeValue DamageReduction = new AttributeValue(0);
        //public PercentageStat LifeSteal = new PercentageStat(StatId.LifeSteal, "吸血", StatType.LifeSteal, 0);
        public AttributeValue LifeSteal = new AttributeValue(0);
        //public SimpleStat ReflectedDamage = new SimpleStat(StatId.ReflectedDamage, "反震伤害", StatType.ReflectedDamage, 0);
        public AttributeValue ReflectedDamage = new AttributeValue(0);
        //public PercentageStat ReflectionRate = new PercentageStat(StatId.ReflectionRate, "反震率", StatType.ReflectionRate, 0);
        public AttributeValue ReflectionRate = new AttributeValue(0);
        //public SimpleStat HPRecoveryperTurn = new SimpleStat(StatId.HPRecoveryperTurn, "回合回复", StatType.HPRecoveryperTurn, 0);
        public AttributeValue HPRecoveryperTurn = new AttributeValue(0);
        //public SimpleStat HPRecoveryperAttack = new SimpleStat(StatId.HPRecoveryperAttack, "攻击回复", StatType.HPRecoveryperAttack, 0);
        public AttributeValue HPRecoveryperAttack = new AttributeValue(0);
        //public PercentageStat CriticalRate = new PercentageStat(StatId.CriticalRate, "暴击率", StatType.CriticalRate, 0);
        public AttributeValue CriticalRate = new AttributeValue(0);
        //public PercentageStat CriticalDamage = new PercentageStat(StatId.CriticalDamage, "暴击伤害", StatType.CriticalDamage, 0);
        public AttributeValue CriticalDamage = new AttributeValue(0);
        //public PercentageStat DamageReflectionRatio = new PercentageStat(StatId.DamageReflectionRatio, "反伤比例", StatType.DamageReflectionRatio, 0);
        public AttributeValue DamageReflectionRatio = new AttributeValue(0);
        //public PercentageStat CriticalResistance = new PercentageStat(StatId.CriticalResistance, "暴击抗性", StatType.CriticalResistance, 0);
        public AttributeValue CriticalResistance = new AttributeValue(0);
        //public PercentageStat EffectHitRate = new PercentageStat(StatId.EffectHitRate, "效果命中率", StatType.EffectHitRate, 0);
        public AttributeValue EffectHitRate = new AttributeValue(0);
        //public PercentageStat EffectResistanceRate = new PercentageStat(StatId.EffectResistanceRate, "效果抵抗率", StatType.EffectResistanceRate, 0);
        public AttributeValue EffectResistanceRate = new AttributeValue(0);
        //public PercentageStat Penetration = new PercentageStat(StatId.Penetration, "护甲穿透", StatType.Penetration, 0);
        public AttributeValue Penetration = new AttributeValue(0);

        public uint AttributePoints_1 = 0;
        public uint AttributePoints_2 = 0;

        /// <summary>
        /// 角色的全部修改器的列表
        /// </summary>
        public List<BaseModifier> charModiList = new List<BaseModifier>();

        public AddPointsComponent addPointsComponent;
        public EquipmentComponent equipmentComponent;

        public SkillComponent skillComponent;

        //属性数值更新时通知外部更新的事件
        //public event UnityAction<WorldCharacterData> updateEvent;
        // 属性系统
        //public CharacterAttributes Attributes;
        //public EquipmentSet EquippedItems;
        //public TalentTree ActivatedTalents;
        //public List<WSceneSkillData> Skill=new List<WSceneSkillData>();

        /// <summary>
        /// 获取加点，武器等组件的所有修改器
        /// </summary>
        public void GetAllModifier()
        {
            charModiList.Clear();
            foreach (var modifier in addPointsComponent.CompModiDict)
            {
                charModiList.Add(modifier.Value);
            }

            foreach(var modifier in equipmentComponent.GetAllModifier())
            {
                charModiList.Add(modifier);
            }
        }
        /// <summary>
        /// 分配出去所有的修改器
        /// </summary>
        public void AllocateModifier()
        {
            GetAllModifier();


            MaxHealth.ClearModifier();
            // 第一类属性点（核心属性）
            Attack.ClearModifier();
            Defense.ClearModifier();
            MagicAttack.ClearModifier();
            MagicDefense.ClearModifier();
            Speed.ClearModifier();

            // 第二类属性点（次要属性）
            Accuracy.ClearModifier();
            Evasion.ClearModifier();
            Parry.ClearModifier();
            Agility.ClearModifier();
            EffectHit.ClearModifier();
            EffectResistance.ClearModifier();

            // 仅能从装备中获取的属性
            DamageReduction.ClearModifier();
            LifeSteal.ClearModifier();
            ReflectedDamage.ClearModifier();
            ReflectionRate.ClearModifier();
            HPRecoveryperTurn.ClearModifier();
            HPRecoveryperAttack.ClearModifier();
            CriticalRate.ClearModifier();
            CriticalDamage.ClearModifier();
            DamageReflectionRatio.ClearModifier();
            CriticalResistance.ClearModifier();
            EffectHitRate.ClearModifier();
            EffectResistanceRate.ClearModifier();
            Penetration.ClearModifier();


            foreach (BaseModifier modifier in charModiList)
            {
                switch (modifier.statType)
                {
                    // 血量
                    case StatType.Health:
                        MaxHealth.AddModifier(modifier);
                        break;

                    // 第一类属性点（核心属性）
                    case StatType.Attack:
                        Attack.AddModifier(modifier);
                        break;
                    case StatType.Defense:
                        Defense.AddModifier(modifier);
                        break;
                    case StatType.MagicAttack:
                        MagicAttack.AddModifier(modifier);
                        break;
                    case StatType.MagicDefense:
                        MagicDefense.AddModifier(modifier);
                        break;
                    case StatType.Speed:
                        Speed.AddModifier(modifier);
                        break;

                    // 第二类属性点（次要属性）
                    case StatType.Accuracy:
                        Accuracy.AddModifier(modifier);
                        break;
                    case StatType.Evasion:
                        Evasion.AddModifier(modifier);
                        break;
                    case StatType.Parry:
                        Parry.AddModifier(modifier);
                        break;
                    case StatType.Agility:
                        Agility.AddModifier(modifier);
                        break;
                    case StatType.EffectHit:
                        EffectHit.AddModifier(modifier);
                        break;
                    case StatType.EffectResistance:
                        EffectResistance.AddModifier(modifier);
                        break;

                    // 仅能从装备中获取的属性
                    case StatType.DamageReduction:
                        DamageReduction.AddModifier(modifier);
                        break;
                    case StatType.LifeSteal:
                        LifeSteal.AddModifier(modifier);
                        break;
                    case StatType.ReflectedDamage:
                        ReflectedDamage.AddModifier(modifier);
                        break;
                    case StatType.ReflectionRate:
                        ReflectionRate.AddModifier(modifier);
                        break;
                    case StatType.HPRecoveryperTurn:
                        HPRecoveryperTurn.AddModifier(modifier);
                        break;
                    case StatType.HPRecoveryperAttack:
                        HPRecoveryperAttack.AddModifier(modifier);
                        break;
                    case StatType.CriticalRate:
                        CriticalRate.AddModifier(modifier);
                        break;
                    case StatType.CriticalDamage:
                        CriticalDamage.AddModifier(modifier);
                        break;
                    case StatType.DamageReflectionRatio:
                        DamageReflectionRatio.AddModifier(modifier);
                        break;
                    case StatType.CriticalResistance:
                        CriticalResistance.AddModifier(modifier);
                        break;
                    case StatType.EffectHitRate:
                        EffectHitRate.AddModifier(modifier);
                        break;
                    case StatType.EffectResistanceRate:
                        EffectResistanceRate.AddModifier(modifier);
                        break;
                    case StatType.Penetration:
                        Penetration.AddModifier(modifier);
                        break;

                    // 默认情况，处理未知属性或记录警告
                    default:
                        Debug.LogWarning($"未知的属性类型: {modifier.statType}，无法添加修改器");
                        break;
                }
            }
        }

        //// 进度系统
        //public long Experience;
        //public int AvailableAttributePoints;
        //public int AvailableTalentPoints;

        //// 元数据
        //public DateTime CreateTime;
        //public DateTime LastSaveTime;
        //public string SaveVersion;

        // 只包含数据，不包含逻辑
        public WorldCharacterData() { }

        public WorldCharacterData(string id)
        {
            if (DataManager.Instance.singletonCharacterData[id] != null)
            {
                CharacterID = id;
                Debug.Log(id);
                teamPosition = TeamPosition.pos0;
                CharacterName = DataManager.Instance.singletonCharacterData[id].Name;

                Level = DataManager.Instance.singletonCharacterData[id].BaseLevel;
                CurrentExperience = 0L;
                MaxExperience = DataManager.Instance.singletonCharacterData[id].BaseExperience;

                MaxHealth = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseHealth);
                health = DataManager.Instance.singletonCharacterData[id].BaseHealth;

                energy = 0L;
                MaxEnergy = DataManager.Instance.singletonCharacterData[id].BaseEnergy;

                skillPoints = 1;
                MaxSkillPoints = 3;

                // 核心属性
                Attack = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseAttack);
                Defense = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseDefense);
                MagicAttack = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseMagicAttack);
                MagicDefense = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseMagicDefense);
                Speed = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseSpeed);

                // 次要属性
                Accuracy = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseAccuracy);
                Evasion = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseEvasion);
                Parry = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseParry);
                Agility = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseAgility);
                EffectHit = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseEffectHit);
                EffectResistance = new AttributeValue(DataManager.Instance.singletonCharacterData[id].BaseEffectResistance);

                AttributePoints_1 = 100;
                AttributePoints_2 = 100;

                addPointsComponent = new AddPointsComponent(this.CharacterID);
                equipmentComponent = new EquipmentComponent();
                skillComponent = new SkillComponent(this.CharacterID);
                foreach (var i in DataManager.Instance.singletonCharacterData[id].Skills)
                {
                    skillComponent.Skill.Add(i.SkillID, new WSceneSkillData(i));
                }
            }
            //Attributes = new CharacterAttributes();
            //EquippedItems = new EquipmentSet();
            //ActivatedTalents = new TalentTree();
            //CreateTime = DateTime.Now;
            //SaveVersion = Application.version;
        }


        /// <summary>
        /// 升级的判断处，支持多段升级（连续升多级）
        /// </summary>
        /// <param name="expNum">本次战斗结束增加的经验点数</param>
        public void LevelUp(long expNum)
        {
            if (expNum <= 0) return;
            CurrentExperience += expNum;

            while (CurrentExperience >= MaxExperience)
            {
                CurrentExperience -= MaxExperience;
                Level++;

                AttributePoints_1 += 10;
                AttributePoints_2 += 10;

                MaxExperience = GameFunctions.Instance.ExpGroethFunc(MaxExperience);

            }

            if (CurrentExperience < 0) CurrentExperience = 0;
        }

        
        //public void SetComponentOwner()
        //{
        //    addPointsComponent.OwnerChrID = this.CharacterID;
        //    skillComponent.OwnerChrID = this.CharacterID;
        //}
    }
}