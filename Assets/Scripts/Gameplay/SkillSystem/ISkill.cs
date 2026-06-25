using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public interface ISkill
{
    string SkillName { get;  }//技能的名字
    BSBaseData skillSource { get; }//技能的源
    BSBaseData skillMainGoal { get; }//技能的目标
    ushort skillLevel { get; }//技能的等级
    bool NeedSwitchAction { get; }//技能是否需要切换行动者

    List<BSBaseData> skillDeputyGoal { get; }//技能的溅射目标
    SputteringType sputteringType { get; }//技能的溅射方式
    bool TryUseSkill(ushort ChrHasPoints) { return false; }//尝试使用技能
    void CalculateDeputyGoal() { }//计算溅射目标
    public event EventHandler<MyEventArgs> SkillEvent;//技能的执行函数


    void SetSkillLevel(ushort _skillLevel)
    {
        
    }

     void SetSkillSource(BSBaseData _skillSource)
    {
        
    }

    void SetSkillMainGoal(BattleScenePosition _skillMainGoalPos)
    {
        
    }

    void AddEventFromBag() { }

    bool UseSkillEvent() { return true; }
}
