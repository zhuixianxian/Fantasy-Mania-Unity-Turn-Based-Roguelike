using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BSSkillData 
{
    //战斗场景中的技能的数据，技能实际会做什么不在此处存储，而是位于SkillLibrary
    public string SkillID;//技能ID
    public string SkillName;//技能名
    public SkillType skillType;//技能类型（技能，大招技能或CD技能）
    public ushort skillLevel;//技能等级

    public ushort SkillPoints;//技能所需的技能点数量
    public ushort SkillEnergy;//技能所需的能量
    public ushort CurrentSkillCD;//技能当前的冷却
    public ushort SkillCD;//技能的冷却




    public BSSkillData()
    {

    }
    public BSSkillData(WSceneSkillData wSceneSkillData)
    {
        SkillID = wSceneSkillData.SkillID;
        SkillName = wSceneSkillData.SkillName;
        skillType = wSceneSkillData.skillType;
        skillLevel = wSceneSkillData.skillLevel;

        SkillPoints = wSceneSkillData.SkillPoints;
        SkillEnergy = wSceneSkillData.SkillEnergy;
        SkillCD = wSceneSkillData.SkillCD;

        CurrentSkillCD = 0;
    }

    public BSSkillData(WorldEnemySkiData enemySkiData)
    {
        SkillID = enemySkiData.SkillID;
        SkillName = enemySkiData.SkillName;
        skillType = enemySkiData.skillType;
        skillLevel = enemySkiData.skiLevel;

        SkillPoints = enemySkiData.SkillPoints;
        SkillEnergy = enemySkiData.SkillEnergy;
        SkillCD = enemySkiData.SkillCD;

        CurrentSkillCD = 0;
    }

    public void SetSkillCD()
    {
        CurrentSkillCD = SkillCD;
    }
}
