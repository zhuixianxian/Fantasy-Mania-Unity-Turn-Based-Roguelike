using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;
public class BaseSkillData 
{
    //从json中读取角色基础数据时所使用的角色多少级解锁技能的数据类
    public string SkillID;//技能ID
    public string SkillName;//技能名
    public SkillType skillType;//技能类型（技能，大招技能或CD技能）

    public ushort SkillPoints;//技能所需的技能点数量
    public ushort SkillEnergy;//技能所需的能量
    public ushort SkillCD;//技能所需的冷却

    public SkillCoinGrowthRate skillCoinGrowthRate;//技能升级金币增长速度类型
    public short MaxSkillLevel=15;//技能的最大等级
    public string SkillDescription;//技能描述
    public long SkillUnlockLevel;//技能解锁等级
}
