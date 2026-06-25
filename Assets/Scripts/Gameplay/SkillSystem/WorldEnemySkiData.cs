using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WorldEnemySkiData
{
    //世界场景中敌人身上技能数据
    //从json中读取角色基础数据时所使用的角色多少级解锁技能的数据类
    public string SkillID;//技能ID
    public string SkillName;//技能名
    public SkillType skillType;//技能类型（技能，大招技能或CD技能）
    public ushort skiLevel;//技能等级

    public ushort SkillPoints;//技能所需的技能点数量
    public ushort SkillEnergy;//技能所需的能量
    public ushort SkillCD;//技能所需的冷却

    public WorldEnemySkiData() { }

    public WorldEnemySkiData(BaseEnemySkillData baseEnemySkillData, ushort skiLevelNum)
    {
        SkillID = baseEnemySkillData.SkillID;
        SkillName = baseEnemySkillData.SkillName;
        skillType = baseEnemySkillData.skillType;
        skiLevel = skiLevelNum;
        SkillPoints = baseEnemySkillData.SkillPoints;
        SkillEnergy = baseEnemySkillData.SkillEnergy;
        SkillCD = baseEnemySkillData.SkillCD;
    }
}

