using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 世界场景中敌人身上
/// </summary>
public class WSEnemySkillComp
{
    public List<WorldEnemySkiData> worldEnemySkiDatas;

    public WSEnemySkillComp() { }

    public WSEnemySkillComp(List<BaseEnemySkillData> baseEnemySkillDatas,int NodeNum)
    {
        worldEnemySkiDatas = new List<WorldEnemySkiData>();
        if (baseEnemySkillDatas != null)
        {
            foreach (var i in baseEnemySkillDatas)
            {
                worldEnemySkiDatas.Add(new WorldEnemySkiData(i, (ushort)(NodeNum / 100 + 1)));
            }

        }
    }
}
