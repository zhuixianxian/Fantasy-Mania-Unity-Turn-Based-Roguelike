using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public interface IBaseBuff
{
    string BuffID { get; }
    string BuffName { get; }
    bool isBufforDebuff { get; }//是Buff还是Debuff,true为正向的Buff，false则为Debuff
    string BuffDescription { get; }//Buff的描述
    short BuffDuration { get; }//Buff持续的回合数，-1时为永续
    short currentBuffDuration { get; }//Buff剩余持续的回合数，-1时为永续
    BuffType buffType { get; }//Buff的种类划分
    BuffOverlayType buffOverlayType { get; }//Buff的叠加方式划分
    BuffReduceType BuffReduceType { get; }//BuffCD为0时的处理方式
    //float BuffValue { get; }//Buff的具体数值
    ushort BuffLevel { get; }//Buff的等级
    ushort BuffMaxLevel { get; }//Buff的最大等级
    IBaseBuff ModifyBuffValue(List<float> modValueList);

    string GetDescription() { return ""; }
}
