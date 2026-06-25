using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSSkillComponent
{
    public List<BSSkillData> BSSkillList;

    public BSSkillComponent(SkillComponent skillComponent)
    {
        BSSkillList = new List<BSSkillData>();
        if(skillComponent.NormalAttack!=null)
        { 
            BSSkillList.Add(new BSSkillData(skillComponent.Skill[skillComponent.NormalAttack])); 
        }

        foreach (var i in skillComponent.SkillList)
        {
            if (i != null)
            {
                BSSkillList.Add(new BSSkillData(skillComponent.Skill[i]));
            }
        }

        foreach (var i in skillComponent.EnergySkillList)
        {
            if (i != null)
            {
                BSSkillList.Add(new BSSkillData(skillComponent.Skill[i]));
            }
        }

        foreach (var i in skillComponent.CDSkillList)
        {
            if (i != null)
            {
                BSSkillList.Add(new BSSkillData(skillComponent.Skill[i]));
            }
        }
    }

    public BSSkillComponent(WSEnemySkillComp WSceneEnemySkiComp)
    {
        BSSkillList = new List<BSSkillData>();
        foreach(var i in WSceneEnemySkiComp.worldEnemySkiDatas)
        {
            BSSkillList.Add(new BSSkillData(i));
        }

    }
}
