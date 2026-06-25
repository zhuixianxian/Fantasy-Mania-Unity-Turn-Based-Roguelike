using System;
using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class AddPointsComponent
{
    // 序列化时排除，避免无限循环
    //[JsonIgnore]
    //public WorldCharacterData Owner;
    public string OwnerChrID;

    private float PointChangeHealthValue;
    private float PointChangeAttackValue;
    private float PointChangeDefenseValue;
    private float PointChangeMAttackValue;
    private float PointChangeMDefenseValue;
    private float PointChangeSpeedValue;
    private float PointChangeAccuracyValue;
    private float PointChangeEvasionValue;
    private float PointChangeParryValue;
    private float PointChangeAgilityValue;
    private float PointChangeEffectHitValue;
    private float PointChangeEffectResistanceValue;

    public uint HealthPointsNum;
    public uint AttackPointsNum;
    public uint DefensePointsNum;
    public uint MAttackPointsNum;
    public uint MDefensePointsNum;
    public uint SpeedPointsNum;
    public uint AccuracyPointsNum;
    public uint EvasionPointsNum;
    public uint ParryPointsNum;
    public uint AgilityPointsNum;
    public uint EffectHitPointsNum;
    public uint EffectResistancePointsNum;

    //public Dictionary<StatType, IModifier> CompModiDict { get; protected set; }
    public Dictionary<string, BaseModifier> CompModiDict;
    public AddPointsComponent() { }

    public AddPointsComponent(string ownerID)
    {
        OwnerChrID = ownerID;
        PointChangeHealthValue = 4;
        PointChangeAttackValue = 1;
        PointChangeDefenseValue = 1;
        PointChangeMAttackValue = 1;
        PointChangeMDefenseValue = 1;
        PointChangeSpeedValue = 1;
        PointChangeAccuracyValue = 1;
        PointChangeEvasionValue = 1;
        PointChangeParryValue = 1;
        PointChangeAgilityValue = 1;
        PointChangeEffectHitValue = 1;
        PointChangeEffectResistanceValue = 1;

        HealthPointsNum = 0;
        AttackPointsNum = 0;
        DefensePointsNum = 0;
        MAttackPointsNum = 0;
        MDefensePointsNum = 0;
        SpeedPointsNum = 0;
        AccuracyPointsNum = 0;
        EvasionPointsNum = 0;
        ParryPointsNum = 0;
        AgilityPointsNum = 0;
        EffectHitPointsNum = 0;
        EffectResistancePointsNum = 0;

        CompModiDict = new Dictionary<string, BaseModifier>
{
    { StatType.Health.ToString(), new BaseModifier(PointChangeHealthValue,"AddPoints",0,HealthPointsNum,ModifierType.AddBase,StatType.Health,"NoneFunc") },
    { StatType.Attack.ToString(), new BaseModifier(PointChangeAttackValue,"AddPoints",0,AttackPointsNum,ModifierType.AddBase,StatType.Attack,"NoneFunc") },
    { StatType.Defense.ToString(), new BaseModifier(PointChangeDefenseValue,"AddPoints",0,DefensePointsNum,ModifierType.AddBase,StatType.Defense,"NoneFunc") },
    { StatType.MagicAttack.ToString(), new BaseModifier(PointChangeMAttackValue,"AddPoints",0,MAttackPointsNum,ModifierType.AddBase,StatType.MagicAttack,"NoneFunc") },
    { StatType.MagicDefense.ToString(), new BaseModifier(PointChangeMDefenseValue,"AddPoints",0,MDefensePointsNum,ModifierType.AddBase,StatType.MagicDefense,"NoneFunc") },
    { StatType.Speed.ToString(), new BaseModifier(PointChangeSpeedValue,"AddPoints",0,SpeedPointsNum,ModifierType.AddBase,StatType.Speed,"NoneFunc") },
    { StatType.Accuracy.ToString(), new BaseModifier(PointChangeAccuracyValue,"AddPoints",0,AccuracyPointsNum,ModifierType.AddBase,StatType.Accuracy,"NoneFunc") },
    { StatType.Evasion.ToString(), new BaseModifier(PointChangeEvasionValue,"AddPoints",0,EvasionPointsNum,ModifierType.AddBase,StatType.Evasion,"NoneFunc") },
    { StatType.Parry.ToString(), new BaseModifier(PointChangeParryValue,"AddPoints",0,ParryPointsNum,ModifierType.AddBase,StatType.Parry,"NoneFunc") },
    { StatType.Agility.ToString(), new BaseModifier(PointChangeAgilityValue,"AddPoints",0,AgilityPointsNum,ModifierType.AddBase,StatType.Agility,"NoneFunc") },
    { StatType.EffectHit.ToString(), new BaseModifier(PointChangeEffectHitValue,"AddPoints",0,EffectHitPointsNum,ModifierType.AddBase,StatType.EffectHit,"NoneFunc") },
    { StatType.EffectResistance.ToString(), new BaseModifier(PointChangeEffectResistanceValue,"AddPoints",0,EffectResistancePointsNum,ModifierType.AddBase,StatType.EffectResistance,"NoneFunc") },
};
    }

    public void AddPoints(uint pointsValue, StatType statType)
    {
        if (!GameDataManager.Instance.CharacterTeam.ContainsKey(OwnerChrID)) return;

        WorldCharacterData Owner = GameDataManager.Instance.CharacterTeam[OwnerChrID];
        //分类为属性增加属性点
        switch (statType)
        {
            case StatType.Health:
                if (Owner.AttributePoints_1 >= pointsValue)
                {
                    HealthPointsNum += pointsValue;
                    Owner.AttributePoints_1 -= pointsValue;
                }
                else
                {
                    HealthPointsNum += Owner.AttributePoints_1;
                    Owner.AttributePoints_1 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = HealthPointsNum;
                break;

            case StatType.Attack:
                if (Owner.AttributePoints_1 >= pointsValue)
                {
                    AttackPointsNum += pointsValue;
                    Owner.AttributePoints_1 -= pointsValue;
                }
                else
                {
                    AttackPointsNum += Owner.AttributePoints_1;
                    Owner.AttributePoints_1 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = AttackPointsNum;
                break;

            case StatType.Defense:
                if (Owner.AttributePoints_1 >= pointsValue)
                {
                    DefensePointsNum += pointsValue;
                    Owner.AttributePoints_1 -= pointsValue;
                }
                else
                {
                    DefensePointsNum += Owner.AttributePoints_1;
                    Owner.AttributePoints_1 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = DefensePointsNum;
                break;

            case StatType.MagicAttack:
                if (Owner.AttributePoints_1 >= pointsValue)
                {
                    MAttackPointsNum += pointsValue;
                    Owner.AttributePoints_1 -= pointsValue;
                }
                else
                {
                    MAttackPointsNum += Owner.AttributePoints_1;
                    Owner.AttributePoints_1 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = MAttackPointsNum;
                break;

            case StatType.MagicDefense:
                if (Owner.AttributePoints_1 >= pointsValue)
                {
                    MDefensePointsNum += pointsValue;
                    Owner.AttributePoints_1 -= pointsValue;
                }
                else
                {
                    MDefensePointsNum += Owner.AttributePoints_1;
                    Owner.AttributePoints_1 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = MDefensePointsNum;
                break;

            case StatType.Speed:
                if (Owner.AttributePoints_1 >= pointsValue)
                {
                    SpeedPointsNum += pointsValue;
                    Owner.AttributePoints_1 -= pointsValue;
                }
                else
                {
                    SpeedPointsNum += Owner.AttributePoints_1;
                    Owner.AttributePoints_1 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = SpeedPointsNum;
                break;

            case StatType.Accuracy:
                if (Owner.AttributePoints_2 >= pointsValue)
                {
                    AccuracyPointsNum += pointsValue;
                    Owner.AttributePoints_2 -= pointsValue;
                }
                else
                {
                    AccuracyPointsNum += Owner.AttributePoints_2;
                    Owner.AttributePoints_2 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = AccuracyPointsNum;
                break;

            case StatType.Evasion:
                if (Owner.AttributePoints_2 >= pointsValue)
                {
                    EvasionPointsNum += pointsValue;
                    Owner.AttributePoints_2 -= pointsValue;
                }
                else
                {
                    EvasionPointsNum += Owner.AttributePoints_2;
                    Owner.AttributePoints_2 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = EvasionPointsNum;
                break;

            case StatType.Parry:
                if (Owner.AttributePoints_2 >= pointsValue)
                {
                    ParryPointsNum += pointsValue;
                    Owner.AttributePoints_2 -= pointsValue;
                }
                else
                {
                    ParryPointsNum += Owner.AttributePoints_2;
                    Owner.AttributePoints_2 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = ParryPointsNum;
                break;

            case StatType.Agility:
                if (Owner.AttributePoints_2 >= pointsValue)
                {
                    AgilityPointsNum += pointsValue;
                    Owner.AttributePoints_2 -= pointsValue;
                }
                else
                {
                    AgilityPointsNum += Owner.AttributePoints_2;
                    Owner.AttributePoints_2 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = AgilityPointsNum;
                break;

            case StatType.EffectHit:
                if (Owner.AttributePoints_2 >= pointsValue)
                {
                    EffectHitPointsNum += pointsValue;
                    Owner.AttributePoints_2 -= pointsValue;
                }
                else
                {
                    EffectHitPointsNum += Owner.AttributePoints_2;
                    Owner.AttributePoints_2 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = EffectHitPointsNum;
                break;

            case StatType.EffectResistance:  // 修正：应该是EffectResistance，不是EffectHitRate
                if (Owner.AttributePoints_2 >= pointsValue)
                {
                    EffectResistancePointsNum += pointsValue;
                    Owner.AttributePoints_2 -= pointsValue;
                }
                else
                {
                    EffectResistancePointsNum += Owner.AttributePoints_2;
                    Owner.AttributePoints_2 = 0;
                }
                CompModiDict[statType.ToString()].modifierLevel = EffectResistancePointsNum;
                break;

            default:
                Debug.LogWarning($"未知的属性类型: {statType}");
                break;
        }
    }

    public void ReducePoints(uint pointsValue, StatType statType)
    {
        if (!GameDataManager.Instance.CharacterTeam.ContainsKey(OwnerChrID)) return;

        WorldCharacterData Owner = GameDataManager.Instance.CharacterTeam[OwnerChrID];

        //分类为属性减少属性点
        switch (statType)
        {
            case StatType.Health:
                if (HealthPointsNum == 0) { }
                else if (HealthPointsNum < pointsValue)
                {
                    Owner.AttributePoints_1 += HealthPointsNum;  // 返还剩余点数
                    HealthPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_1 += pointsValue;  // 返还指定点数
                    HealthPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = HealthPointsNum;
                break;

            case StatType.Attack:
                if (AttackPointsNum == 0) { }
                else if (AttackPointsNum < pointsValue)
                {
                    Owner.AttributePoints_1 += AttackPointsNum;  // 返还剩余点数
                    AttackPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_1 += pointsValue;  // 返还指定点数
                    AttackPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = AttackPointsNum;
                break;

            case StatType.Defense:
                if (DefensePointsNum == 0) { }
                else if (DefensePointsNum < pointsValue)
                {
                    Owner.AttributePoints_1 += DefensePointsNum;  // 返还剩余点数
                    DefensePointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_1 += pointsValue;  // 返还指定点数
                    DefensePointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = DefensePointsNum;
                break;

            case StatType.MagicAttack:
                if (MAttackPointsNum == 0) { }
                else if (MAttackPointsNum < pointsValue)
                {
                    Owner.AttributePoints_1 += MAttackPointsNum;  // 返还剩余点数
                    MAttackPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_1 += pointsValue;  // 返还指定点数
                    MAttackPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = MAttackPointsNum;
                break;

            case StatType.MagicDefense:
                if (MDefensePointsNum == 0) { }
                else if (MDefensePointsNum < pointsValue)
                {
                    Owner.AttributePoints_1 += MDefensePointsNum;  // 返还剩余点数
                    MDefensePointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_1 += pointsValue;  // 返还指定点数
                    MDefensePointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = MDefensePointsNum;
                break;

            case StatType.Speed:
                if (SpeedPointsNum == 0) { }
                else if (SpeedPointsNum < pointsValue)
                {
                    Owner.AttributePoints_1 += SpeedPointsNum;  // 返还剩余点数
                    SpeedPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_1 += pointsValue;  // 返还指定点数
                    SpeedPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = SpeedPointsNum;
                break;

            case StatType.Accuracy:
                if (AccuracyPointsNum == 0) { }
                else if (AccuracyPointsNum < pointsValue)
                {
                    Owner.AttributePoints_2 += AccuracyPointsNum;  // 返还剩余点数
                    AccuracyPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_2 += pointsValue;  // 返还指定点数
                    AccuracyPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = AccuracyPointsNum;
                break;

            case StatType.Evasion:
                if (EvasionPointsNum == 0) { }
                else if (EvasionPointsNum < pointsValue)
                {
                    Owner.AttributePoints_2 += EvasionPointsNum;  // 返还剩余点数
                    EvasionPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_2 += pointsValue;  // 返还指定点数
                    EvasionPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = EvasionPointsNum;
                break;

            case StatType.Parry:
                if (ParryPointsNum == 0) { }
                else if (ParryPointsNum < pointsValue)
                {
                    Owner.AttributePoints_2 += ParryPointsNum;  // 返还剩余点数
                    ParryPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_2 += pointsValue;  // 返还指定点数
                    ParryPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = ParryPointsNum;
                break;

            case StatType.Agility:
                if (AgilityPointsNum == 0) { }
                else if (AgilityPointsNum < pointsValue)
                {
                    Owner.AttributePoints_2 += AgilityPointsNum;  // 返还剩余点数
                    AgilityPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_2 += pointsValue;  // 返还指定点数
                    AgilityPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = AgilityPointsNum;
                break;

            case StatType.EffectHit:
                if (EffectHitPointsNum == 0) { }
                else if (EffectHitPointsNum < pointsValue)
                {
                    Owner.AttributePoints_2 += EffectHitPointsNum;  // 返还剩余点数
                    EffectHitPointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_2 += pointsValue;  // 返还指定点数
                    EffectHitPointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = EffectHitPointsNum;
                break;

            case StatType.EffectResistance:
                if (EffectResistancePointsNum == 0) { }
                else if (EffectResistancePointsNum < pointsValue)
                {
                    Owner.AttributePoints_2 += EffectResistancePointsNum;  // 返还剩余点数
                    EffectResistancePointsNum = 0;
                }
                else
                {
                    Owner.AttributePoints_2 += pointsValue;  // 返还指定点数
                    EffectResistancePointsNum -= pointsValue;
                }
                CompModiDict[statType.ToString()].modifierLevel = EffectResistancePointsNum;
                break;

            default:
                Debug.LogWarning($"未知的属性类型: {statType}");
                break;
        }
    }
    public void ClearPoints(StatType statType)
    {
        if (!GameDataManager.Instance.CharacterTeam.ContainsKey(OwnerChrID)) return;

        WorldCharacterData Owner = GameDataManager.Instance.CharacterTeam[OwnerChrID];

        //分类清空某个属性的属性点
        switch (statType)
        {
            case StatType.Health:
                Owner.AttributePoints_1 += HealthPointsNum;
                HealthPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = HealthPointsNum;
                break;

            case StatType.Attack:
                Owner.AttributePoints_1 += AttackPointsNum;
                AttackPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = AttackPointsNum;
                break;

            case StatType.Defense:
                Owner.AttributePoints_1 += DefensePointsNum;
                DefensePointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = DefensePointsNum;
                break;

            case StatType.MagicAttack:
                Owner.AttributePoints_1 += MAttackPointsNum;
                MAttackPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = MAttackPointsNum;
                break;

            case StatType.MagicDefense:
                Owner.AttributePoints_1 += MDefensePointsNum;
                MDefensePointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = MDefensePointsNum;
                break;

            case StatType.Speed:
                Owner.AttributePoints_1 += SpeedPointsNum;
                SpeedPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = SpeedPointsNum;
                break;

            case StatType.Accuracy:
                Owner.AttributePoints_2 += AccuracyPointsNum;
                AccuracyPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = AccuracyPointsNum;
                break;

            case StatType.Evasion:
                Owner.AttributePoints_2 += EvasionPointsNum;
                EvasionPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = EvasionPointsNum;
                break;

            case StatType.Parry:
                Owner.AttributePoints_2 += ParryPointsNum;
                ParryPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = ParryPointsNum;
                break;

            case StatType.Agility:
                Owner.AttributePoints_2 += AgilityPointsNum;
                AgilityPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = AgilityPointsNum;
                break;

            case StatType.EffectHit:
                Owner.AttributePoints_2 += EffectHitPointsNum;
                EffectHitPointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = EffectHitPointsNum;
                break;

            case StatType.EffectResistance:  // 修正：应该是EffectResistance，不是EffectHitRate
                Owner.AttributePoints_2 += EffectResistancePointsNum;
                EffectResistancePointsNum = 0;
                CompModiDict[statType.ToString()].modifierLevel = EffectResistancePointsNum;
                break;

            default:
                Debug.LogWarning($"未知的属性类型: {statType}");
                break;
        }
    }
}
