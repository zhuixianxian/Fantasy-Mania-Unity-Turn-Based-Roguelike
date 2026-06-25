using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 战斗场景中敌人的数据承载
/// </summary>
public class BSEnemyData : BSBaseData
{
    public BSSkillComponent skiComp;//战斗场景中的技能组件

    public BSEnemyData()
    {

    }
    public BSEnemyData(WorldEnemyData worldEnemyData, BattleScenePosition enemyPos)
    {
        isActive = 1;
        hasCharacter = true;

        CharacterID = worldEnemyData.EnemyID;
        CharacterName = worldEnemyData.EnemyName;
        Level = worldEnemyData.Level;

        camp = Camp.Enemy;

        BSPosition = enemyPos;

        health = worldEnemyData.MaxHealth;
        MaxHealth = new AttributeValue(worldEnemyData.MaxHealth);

        energy = 0;
        MaxEnergy = worldEnemyData.MaxEnergy;

        skillPoints =0;
        MaxSkillPoints = worldEnemyData.MaxSkillPoints;

        Attack = new AttributeValue(worldEnemyData.Attack);
        Defense = new AttributeValue(worldEnemyData.Defense);
        MagicAttack = new AttributeValue(worldEnemyData.MagicAttack);
        MagicDefense = new AttributeValue(worldEnemyData.MagicDefense);
        Speed = new AttributeValue(worldEnemyData.Speed);

        Accuracy = new AttributeValue(worldEnemyData.Accuracy);
        Evasion = new AttributeValue(worldEnemyData.Evasion);
        Parry = new AttributeValue(worldEnemyData.Parry);
        Agility = new AttributeValue(worldEnemyData.Agility);
        EffectHit = new AttributeValue(worldEnemyData.EffectHit);
        EffectResistance = new AttributeValue(worldEnemyData.EffectResistance);

        DamageReduction = new AttributeValue(worldEnemyData.DamageReduction);
        LifeSteal = new AttributeValue(worldEnemyData.LifeSteal);
        ReflectedDamage = new AttributeValue(worldEnemyData.ReflectedDamage);
        ReflectionRate = new AttributeValue(worldEnemyData.ReflectionRate);
        HPRecoveryperTurn = new AttributeValue(worldEnemyData.HPRecoveryperTurn);
        HPRecoveryperAttack = new AttributeValue(worldEnemyData.HPRecoveryperAttack);
        CriticalRate = new AttributeValue(worldEnemyData.CriticalRate);
        CriticalDamage = new AttributeValue(worldEnemyData.CriticalDamage);
        DamageReflectionRatio = new AttributeValue(worldEnemyData.DamageReflectionRatio);
        CriticalResistance = new AttributeValue(worldEnemyData.CriticalResistance);
        EffectHitRate = new AttributeValue(worldEnemyData.EffectHitRate);
        EffectResistanceRate = new AttributeValue(worldEnemyData.EffectResistanceRate);
        Penetration = new AttributeValue(worldEnemyData.Penetration);

        skiComp = new BSSkillComponent(worldEnemyData.WSEnemySkillComp);

        buffComponent = new BuffComponent(this);
    }
}
