using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BaseEnemyData
{
    //敌人的数据容器,用于从json中读取模板敌人
    // 核心身份信息
    public string EnemyID="ShuGuai";
    public string EnemyName="书怪";

    public long MaxHealth=80;

    public long MaxEnergy=80;
    public ushort MaxSkillPoints=3;

    public long Attack=10;
    public long Defense=10;
    public long MagicAttack=10;
    public long MagicDefense=10;
    public long Speed=3;

    public long Accuracy=5;
    public long Evasion=5;
    public long Parry=5;
    public long Agility=5;
    public long EffectHit=2;
    public long EffectResistance=2;

    public List<BaseEnemySkillData> enemySkillList;
}
