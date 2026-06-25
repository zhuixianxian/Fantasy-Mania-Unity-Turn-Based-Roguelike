using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BSBaseData
{
    /// <summary>
    /// 判断是否存活，使用ushort尝试做到复活
    /// </summary>
    public ushort isActive;

    /// <summary>
    /// 判断是否存活，使用ushort尝试做到复活
    /// </summary>
    public bool hasCharacter;

    // 核心身份信息
    public string CharacterID;
    public string CharacterName;
    public long Level;

    public Camp camp;

    public BattleScenePosition BSPosition;

    public long health;
    public AttributeValue MaxHealth;

    public long energy;
    public long MaxEnergy;

    public ushort skillPoints;
    public ushort MaxSkillPoints;

    public AttributeValue Attack;
    public AttributeValue Defense;
    public AttributeValue MagicAttack;
    public AttributeValue MagicDefense;
    public AttributeValue Speed;
    public AttributeValue Accuracy;
    public AttributeValue Evasion;
    public AttributeValue Parry;
    public AttributeValue Agility;
    public AttributeValue EffectHit;
    public AttributeValue EffectResistance;

    public AttributeValue DamageReduction;
    public AttributeValue LifeSteal;
    public AttributeValue ReflectedDamage;
    public AttributeValue ReflectionRate;
    public AttributeValue HPRecoveryperTurn;
    public AttributeValue HPRecoveryperAttack;
    public AttributeValue CriticalRate;
    public AttributeValue CriticalDamage;
    public AttributeValue DamageReflectionRatio;
    public AttributeValue CriticalResistance;
    public AttributeValue EffectHitRate;
    public AttributeValue EffectResistanceRate;
    public AttributeValue Penetration;

    /// <summary>
    /// 角色的全部修改器的列表
    /// </summary>
    public List<BaseModifier> charModiList = new List<BaseModifier>();
    //角色身上属性类Buff的管理器
    public BuffComponent buffComponent;

    public BSBaseData() { hasCharacter = false; }

    public void GetAllModifier()
    {
        charModiList.Clear();
        foreach (var modifier in buffComponent.GetStatBuffModi())
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
    /// <summary>
    /// 回复血量
    /// </summary>
    /// <param name="replyHPValue">回复血量的数值</param>
    public void ReplyHealth(long replyHPValue)
    {

        if (MaxHealth.currentValue - health >= replyHPValue)
        {
            health += replyHPValue;
        }
        else
        {
            health = MaxHealth.currentValue;
        }
    }

    /// <summary>
    /// 回复技能点
    /// </summary>
    /// <param name="replyHPValue">回复技能点的数值</param>
    public void ReplyPoints(ushort replyPointsValue)
    {

        if (MaxSkillPoints - skillPoints >= replyPointsValue)
        {
            skillPoints += replyPointsValue;
        }
        else
        {
            skillPoints = MaxSkillPoints;
        }
    }

    /// <summary>
    /// 回复能量
    /// </summary>
    /// <param name="replyHPValue">回复能量的数值</param>
    public void ReplyEnergy(uint replyEnergyValue)
    {
        if (MaxEnergy - energy >= replyEnergyValue)
        {
            energy += replyEnergyValue;
        }
        else
        {
            energy = MaxEnergy;
        }
    }

    public long DamageReceiver(long Damage)
    {
        long RealDamage= (long)(Damage * (float)((100f - DamageReduction.currentValue) / 100f));

        health = health - RealDamage;
        if (health <= 0)
        {
            health = 0;
            isActive--;
            buffComponent.AddBuff(BuffLibrary.Instance.buffLibrary["SiWang"]);//这行代码添加后会报错，只看这段代码，你能列举缘因吗？
        }
        return RealDamage;
    }

    /// <summary>
    /// 根据属性类型枚举判断返回哪个值，用于例如：根据最大生命值的回复，根据防御力的加攻等玩法
    /// </summary>
    /// <param name="statType"></param>
    /// <returns></returns>
    /// <summary>
    /// 根据属性类型枚举返回对应的属性值
    /// </summary>
    public long GetStatByType(StatType statType)
    {
        switch (statType)
        {
            // 资源属性
            case StatType.Health:
            case StatType.CurrentHealth:
                return health;
            case StatType.MaxHealth:
                return MaxHealth.currentValue;
            case StatType.Energy:
            case StatType.CurrentEnergy:
                return energy;
            case StatType.MaxEnergy:
                return MaxEnergy;
            case StatType.SkillPoints:
            case StatType.CurrentSkillPoints:
                return skillPoints;
            case StatType.MaxSkillPoints:
                return MaxSkillPoints;
            case StatType.Level:
                return Level;

            // 第一类加点属性（核心属性）
            case StatType.Attack:
                return Attack.currentValue;
            case StatType.Defense:
                return Defense.currentValue;
            case StatType.MagicAttack:
                return MagicAttack.currentValue;
            case StatType.MagicDefense:
                return MagicDefense.currentValue;
            case StatType.Speed:
                return Speed.currentValue;

            // 第二类加点属性（次要属性）
            case StatType.Accuracy:
                return Accuracy.currentValue;
            case StatType.Evasion:
                return Evasion.currentValue;
            case StatType.Parry:
                return Parry.currentValue;
            case StatType.Agility:
                return Agility.currentValue;
            case StatType.EffectHit:
                return EffectHit.currentValue;
            case StatType.EffectResistance:
                return EffectResistance.currentValue;

            // 仅能从装备中获取的属性
            case StatType.DamageReduction:
                return DamageReduction.currentValue;
            case StatType.LifeSteal:
                return LifeSteal.currentValue;
            case StatType.ReflectedDamage:
                return ReflectedDamage.currentValue;
            case StatType.ReflectionRate:
                return ReflectionRate.currentValue;
            case StatType.HPRecoveryperTurn:
                return HPRecoveryperTurn.currentValue;
            case StatType.HPRecoveryperAttack:
                return HPRecoveryperAttack.currentValue;
            case StatType.CriticalRate:
                return CriticalRate.currentValue;
            case StatType.CriticalDamage:
                return CriticalDamage.currentValue;
            case StatType.DamageReflectionRatio:
                return DamageReflectionRatio.currentValue;
            case StatType.CriticalResistance:
                return CriticalResistance.currentValue;
            case StatType.EffectHitRate:
                return EffectHitRate.currentValue;
            case StatType.EffectResistanceRate:
                return EffectResistanceRate.currentValue;
            case StatType.Penetration:
                return Penetration.currentValue;

            default:
                Debug.LogWarning($"未知的属性类型: {statType}，返回默认值0");
                return 0;
        }
    }
}
