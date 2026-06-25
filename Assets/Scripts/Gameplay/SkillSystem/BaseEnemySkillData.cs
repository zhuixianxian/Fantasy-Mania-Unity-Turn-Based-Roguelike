using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BaseEnemySkillData
{
    //从json中读取角色基础数据时所使用的角色多少级解锁技能的数据类
    public string SkillID;//技能ID
    public string SkillName;//技能名
    public SkillType skillType;//技能类型（技能，大招技能或CD技能）

    public ushort SkillPoints;//技能所需的技能点数量
    public ushort SkillEnergy;//技能所需的能量
    public ushort SkillCD;//技能所需的冷却
}
