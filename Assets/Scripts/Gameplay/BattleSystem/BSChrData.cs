using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 战斗场景中角色的数据承载
/// </summary>
public class BSChrData:BSBaseData
{
    public BSSkillComponent skiComp;//战斗场景中的技能组件
    public BSChrData(WorldCharacterData worldCharacterData,BattleScenePosition myBattleScenePosition)
    {
        isActive = 1;
        hasCharacter = true;
        CharacterID = worldCharacterData.CharacterID;
        CharacterName = worldCharacterData.CharacterName;
        Level = worldCharacterData.Level;

        camp = Camp.Character;

        BSPosition = myBattleScenePosition;

        health = worldCharacterData.MaxHealth.currentValue;
        MaxHealth = new AttributeValue(worldCharacterData.MaxHealth.currentValue);

        energy = worldCharacterData.energy;
        MaxEnergy = worldCharacterData.MaxEnergy;

        skillPoints = worldCharacterData.skillPoints;
        MaxSkillPoints = worldCharacterData.MaxSkillPoints;

        Attack = new AttributeValue(worldCharacterData.Attack.currentValue);
        Defense = new AttributeValue(worldCharacterData.Defense.currentValue);
        MagicAttack = new AttributeValue(worldCharacterData.MagicAttack.currentValue);
        MagicDefense = new AttributeValue(worldCharacterData.MagicDefense.currentValue);
        Speed = new AttributeValue(worldCharacterData.Speed.currentValue);

        Accuracy = new AttributeValue(worldCharacterData.Accuracy.currentValue);
        Evasion = new AttributeValue(worldCharacterData.Evasion.currentValue);
        Parry = new AttributeValue(worldCharacterData.Parry.currentValue);
        Agility = new AttributeValue(worldCharacterData.Agility.currentValue);
        EffectHit = new AttributeValue(worldCharacterData.EffectHit.currentValue);
        EffectResistance = new AttributeValue(worldCharacterData.EffectResistance.currentValue);

        DamageReduction = new AttributeValue(worldCharacterData.DamageReduction.currentValue);
        LifeSteal = new AttributeValue(worldCharacterData.LifeSteal.currentValue);
        ReflectedDamage = new AttributeValue(worldCharacterData.ReflectedDamage.currentValue);
        ReflectionRate = new AttributeValue(worldCharacterData.ReflectionRate.currentValue);
        HPRecoveryperTurn = new AttributeValue(worldCharacterData.HPRecoveryperTurn.currentValue);
        HPRecoveryperAttack = new AttributeValue(worldCharacterData.HPRecoveryperAttack.currentValue);
        CriticalRate = new AttributeValue(worldCharacterData.CriticalRate.currentValue);
        CriticalDamage = new AttributeValue(worldCharacterData.CriticalDamage.currentValue);
        DamageReflectionRatio = new AttributeValue(worldCharacterData.DamageReflectionRatio.currentValue);
        CriticalResistance = new AttributeValue(worldCharacterData.CriticalResistance.currentValue);
        EffectHitRate = new AttributeValue(worldCharacterData.EffectHitRate.currentValue);
        EffectResistanceRate = new AttributeValue(worldCharacterData.EffectResistanceRate.currentValue);
        Penetration = new AttributeValue(worldCharacterData.Penetration.currentValue);

        skiComp = new BSSkillComponent(worldCharacterData.skillComponent);
        buffComponent = new BuffComponent(this);
    }

}
