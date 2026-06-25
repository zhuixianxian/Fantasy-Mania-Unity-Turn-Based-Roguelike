using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;


public class EnergySkill : ISkill
{
    public string SkillName { get; set; }//技能的名字
    public BSBaseData skillSource { get; set; }//技能的源
    public BSBaseData skillMainGoal { get; set; }//技能的目标
    public bool NeedSwitchAction { get; set; }//技能执行后是否需要切换行动者

    public List<BSBaseData> skillDeputyGoal { get; set; }//技能的溅射目标
    public SputteringType sputteringType { get; set; }//技能的溅射方式
    public void CalculateDeputyGoal() { }//计算溅射目标（是否该在此处处理持怀疑态度)
    public List<SkillEventBag> skillEventBags;

    public ushort skillLevel { get; set; }//技能等级
    //public Action SkillEvent { get; private set; }//技能的执行函数
    public event EventHandler<MyEventArgs> SkillEvent;//技能的执行函数

    public ushort SkillNeedEnergy { get; set; }//技能所需的技能点

    public bool TryUseSkill(ushort ChrHasPoints) //尝试使用技能
    {
        if (ChrHasPoints < SkillNeedEnergy)
        {
            return false;
        }

        return true;

    }

    public EnergySkill
        (
        string _SkillName,
        SputteringType _sputteringType,
        ushort _SkillNeedEnergy,
        ushort _skillLevel,
        bool _NeedSwitchAction
        )
    {
        SkillName = _SkillName;
        sputteringType = _sputteringType;
        SkillNeedEnergy = _SkillNeedEnergy;
        skillLevel = _skillLevel;
        NeedSwitchAction = _NeedSwitchAction;
        skillEventBags = new List<SkillEventBag>();
    }
    /// <summary>
    /// 复制构造函数
    /// </summary>
    /// <param name="otherSkill"></param>
    public EnergySkill
        (
        EnergySkill otherSkill
        )
    {
        SkillName = otherSkill.SkillName;
        sputteringType = otherSkill.sputteringType;
        SkillNeedEnergy = otherSkill.SkillNeedEnergy;
        skillLevel = otherSkill.skillLevel;
        skillEventBags = new List<SkillEventBag>();
        foreach (var i in otherSkill.skillEventBags)
        {
            skillEventBags.Add(new SkillEventBag(i));
        }
    }

    #region 根据技能事件包列表的类型加技能事件
    /// <summary>
    /// 减技能点
    /// </summary>
    /// <param name="_skillSource"></param>
    private void ReduceEnergy(BSBaseData _skillSource)
    {
        if (_skillSource != null)
        {
            _skillSource.energy -= SkillNeedEnergy;
        }
    }

    private void ReplyHealthMainGoal(BSBaseData _skillSource, BSBaseData _skillMainGoal, SkillEventBag skillEventBag)
    {
        if (_skillSource != null && _skillMainGoal != null)
        {
            _skillMainGoal.ReplyHealth((long)(_skillSource.GetStatByType(skillEventBag.statType) * skillEventBag.GetSkillEventValue(skillLevel)));
        }
        EventCenter.Instance.EventTrigger<string>(E_EventType.E_BattleEventPrint,
            GetReplyHPText(
                _skillSource.CharacterName, SkillName, _skillMainGoal.CharacterName,
                (long)(
                _skillSource.GetStatByType(skillEventBag.statType) *
                skillEventBag.GetSkillEventValue(skillLevel)
                )
                )
            );
    }

    private void ReplyPointsMainGoal(BSBaseData _skillSource, BSBaseData _skillMainGoal, SkillEventBag skillEventBag)
    {
        if (_skillSource != null && _skillMainGoal != null)
        {
            _skillMainGoal.ReplyPoints((ushort)skillEventBag.GetSkillEventValue(skillLevel));
        }
    }

    private void ReplyEnergyMainGoal(BSBaseData _skillSource, BSBaseData _skillMainGoal, SkillEventBag skillEventBag)
    {
        if (_skillSource != null && _skillMainGoal != null)
        {
            _skillMainGoal.ReplyEnergy((uint)skillEventBag.GetSkillEventValue(skillLevel));
        }
    }
    private void ReplyHealthSource(BSBaseData _skillSource, SkillEventBag skillEventBag)
    {
        if (_skillSource != null)
        {
            _skillSource.ReplyHealth((long)(_skillSource.GetStatByType(skillEventBag.statType) * skillEventBag.GetSkillEventValue(skillLevel)));
            Debug.Log(_skillSource.CharacterName + "通过" + SkillName + "恢复了" +
                (long)(_skillSource.GetStatByType(skillEventBag.statType) * skillEventBag.GetSkillEventValue(skillLevel)) + "血量");
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_BattleEventPrint,
            GetReplyHPText(
                _skillSource.CharacterName, SkillName, _skillSource.CharacterName,
                (long)(
                _skillSource.GetStatByType(skillEventBag.statType) *
                skillEventBag.GetSkillEventValue(skillLevel)
                )
                )
            );
        }
    }

    private void ReplyPointsSource(BSBaseData _skillSource, SkillEventBag skillEventBag)
    {
        if (_skillSource != null)
        {
            _skillSource.ReplyPoints((ushort)skillEventBag.GetSkillEventValue(skillLevel));
        }
    }

    private void ReplyEnergySource(BSBaseData _skillSource, SkillEventBag skillEventBag)
    {
        if (_skillSource != null)
        {
            _skillSource.ReplyEnergy((uint)skillEventBag.GetSkillEventValue(skillLevel));
        }
    }
    private void ReplyHealthDeputyGoal(BSBaseData _skillSource, List<BSBaseData> _skillDeputyGoal, SkillEventBag skillEventBag)
    {
        if (_skillSource != null && _skillDeputyGoal != null)
        {
            foreach (var i in _skillDeputyGoal)
            {
                i.ReplyHealth((long)(_skillSource.GetStatByType(skillEventBag.statType) * skillEventBag.GetSkillEventValue(skillLevel)));
                EventCenter.Instance.EventTrigger<string>(E_EventType.E_BattleEventPrint,
            GetReplyHPText(
                _skillSource.CharacterName, SkillName, i.CharacterName,
                (long)(
                _skillSource.GetStatByType(skillEventBag.statType) *
                skillEventBag.GetSkillEventValue(skillLevel)
                )
                )
            );
            }
        }
    }

    private void ReplyPointsDeputyGoal(BSBaseData _skillSource, List<BSBaseData> _skillDeputyGoal, SkillEventBag skillEventBag)
    {
        if (_skillSource != null && _skillDeputyGoal != null)
        {
            foreach (var i in _skillDeputyGoal)
            {
                i.ReplyPoints((ushort)skillEventBag.GetSkillEventValue(skillLevel));
            }
        }
    }

    private void ReplyEnergyDeputyGoal(BSBaseData _skillSource, List<BSBaseData> _skillDeputyGoal, SkillEventBag skillEventBag)
    {
        if (_skillSource != null && _skillDeputyGoal != null)
        {
            foreach (var i in _skillDeputyGoal)
            {
                i.ReplyEnergy((uint)skillEventBag.GetSkillEventValue(skillLevel));
            }
        }
    }

    /// <summary>
    /// 降低角色身上的某个Buff的等级
    /// </summary>
    /// <param name="_skillSource"></param>
    /// <param name="skillEventBag"></param>
    private void BuffLevelDown(BSBaseData _skillSource, SkillEventBag skillEventBag)
    {

    }

    private void DamageMainGoal(BSBaseData _skillSource, BSBaseData _skillMainGoal, SkillEventBag skillEventBag)
    {
        //待修改，暴击率，暴击伤害，命中，闪避，反震，反震率，反伤比例尚未使用
        if (_skillSource != null && _skillMainGoal != null)
        {
            long Damage = 0;//能造成多少伤害（无免伤时）
            long GoalDefense = 0;//目标的防御
            switch (skillEventBag.statType)
            {
                case StatType.Attack:
                    GoalDefense = _skillMainGoal.GetStatByType(StatType.Defense);
                    break;
                case StatType.MagicAttack:
                    GoalDefense = _skillMainGoal.GetStatByType(StatType.MagicDefense);
                    break;
                default:
                    GoalDefense = (_skillMainGoal.GetStatByType(StatType.Defense) +
                        _skillMainGoal.GetStatByType(StatType.MagicDefense)) / 2;
                    break;
            }
            //Damage = (long)(_skillSource.GetStatByType(skillEventBag.statType) * skillEventBag.GetSkillEventValue(skillLevel) * _skillSource.Level*4 / (GoalDefense + 1));
            Damage = GetDamage(_skillSource.GetStatByType(skillEventBag.statType),
                skillEventBag.GetSkillEventValue(skillLevel),
                _skillSource.Level,
                (GoalDefense + 1));

            long returnDamage = 0;//造成了多少伤害
            returnDamage = _skillMainGoal.DamageReceiver(Damage);
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_BattleEventPrint,
            GetDamageText(
                _skillSource.CharacterName, SkillName, _skillMainGoal.CharacterName, returnDamage)
            );
            _skillSource.ReplyHealth(returnDamage * _skillSource.LifeSteal.currentValue / 100);
        }
    }
    private void DamageDeputyGoal(BSBaseData _skillSource, List<BSBaseData> _skillDeputyGoal, SkillEventBag skillEventBag)
    {
        if (_skillSource != null && _skillDeputyGoal != null)
        {
            long returnDamage = 0;//造成了多少伤害
            foreach (var i in _skillDeputyGoal)
            {
                long Damage = 0;//能造成多少伤害（无免伤时）
                long GoalDefense = 0;//目标的防御
                switch (skillEventBag.statType)
                {
                    case StatType.Attack:
                        GoalDefense = i.GetStatByType(StatType.Defense);
                        break;
                    case StatType.MagicAttack:
                        GoalDefense = i.GetStatByType(StatType.MagicDefense);
                        break;
                    default:
                        GoalDefense = (i.GetStatByType(StatType.Defense) +
                            i.GetStatByType(StatType.MagicDefense)) / 2;
                        break;
                }
                //Damage = (long)(_skillSource.GetStatByType(skillEventBag.statType) * skillEventBag.GetSkillEventValue(skillLevel) * _skillSource.Level / (GoalDefense + 1));
                Damage = GetDamage(_skillSource.GetStatByType(skillEventBag.statType),
                skillEventBag.GetSkillEventValue(skillLevel),
                _skillSource.Level,
                (GoalDefense + 1));
                returnDamage += i.DamageReceiver(Damage);
                EventCenter.Instance.EventTrigger<string>(E_EventType.E_BattleEventPrint,
                GetDamageText(
                _skillSource.CharacterName, SkillName, i.CharacterName, i.DamageReceiver(Damage))
                );
            }
            _skillSource.ReplyHealth(returnDamage * _skillSource.LifeSteal.currentValue);
        }
    }

    private void BuffMainGoal(BSBaseData _skillSource, BSBaseData _skillMainGoal, SkillEventBag skillEventBag)
    {
        //效果命中，效果抵抗尚未使用
        if (_skillSource != null && _skillMainGoal != null
            && BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID] != null)
        {
            _skillMainGoal.buffComponent.AddBuff(BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID].ModifyBuffValue(skillEventBag.GetEventModifyBuffValue(skillLevel)));
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_BattleEventPrint,
                GetBuffText(
                _skillSource.CharacterName, SkillName, _skillMainGoal.CharacterName, BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID].BuffName)
                );
        }
    }

    private void BuffSource(BSBaseData _skillSource, SkillEventBag skillEventBag)
    {
        //效果命中，效果抵抗尚未使用
        if (_skillSource != null
            && BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID] != null)
        {
            _skillSource.buffComponent.AddBuff(BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID].ModifyBuffValue(skillEventBag.GetEventModifyBuffValue(skillLevel)));
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_BattleEventPrint,
                GetBuffText(
                _skillSource.CharacterName, SkillName, _skillSource.CharacterName, BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID].BuffName)
                );
        }
    }

    private void BuffDeputyGoal(BSBaseData _skillSource, List<BSBaseData> _skillDeputyGoal, SkillEventBag skillEventBag)
    {
        if (_skillSource != null && _skillDeputyGoal != null
            && BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID] != null)
        {
            foreach (var i in _skillDeputyGoal)
            {
                i.buffComponent.AddBuff(BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID].ModifyBuffValue(skillEventBag.GetEventModifyBuffValue(skillLevel)));

                EventCenter.Instance.EventTrigger<string>(E_EventType.E_BattleEventPrint,
                GetBuffText(
                _skillSource.CharacterName, SkillName, i.CharacterName, BuffLibrary.Instance.buffLibrary[skillEventBag.BuffID].BuffName)
                );
            }
        }
    }
    #endregion

    public void AddEventFromBag()
    {
        foreach (var i in skillEventBags)
        {
            var eventBag = i;
            switch (i.skillEventType)
            {
                case SkillEventType.ConsumeResources://消耗资源的事件的添加
                    SkillEvent += (sender, e) => ReduceEnergy(skillSource);
                    break;
                case SkillEventType.ReplyHealthSource:
                    SkillEvent += (sender, e) => ReplyHealthSource(skillSource, eventBag);
                    break;
                case SkillEventType.ReplyPointsSource:
                    SkillEvent += (sender, e) => ReplyPointsSource(skillSource, eventBag);
                    break;
                case SkillEventType.ReplyEnergySource:
                    SkillEvent += (sender, e) => ReplyEnergySource(skillSource, eventBag);
                    break;
                case SkillEventType.ReplyHealthMainGoal:
                    SkillEvent += (sender, e) => ReplyHealthMainGoal(skillSource, skillMainGoal, eventBag);
                    break;
                case SkillEventType.ReplyPointsMainGoal:
                    SkillEvent += (sender, e) => ReplyPointsMainGoal(skillSource, skillMainGoal, eventBag);
                    break;
                case SkillEventType.ReplyEnergyMainGoal:
                    SkillEvent += (sender, e) => ReplyEnergyMainGoal(skillSource, skillMainGoal, eventBag);
                    break;
                case SkillEventType.ReplyHealthDeputyGoal:
                    SkillEvent += (sender, e) => ReplyHealthDeputyGoal(skillSource, skillDeputyGoal, eventBag);
                    break;
                case SkillEventType.ReplyPointsDeputyGoal:
                    SkillEvent += (sender, e) => ReplyPointsDeputyGoal(skillSource, skillDeputyGoal, eventBag);
                    break;
                case SkillEventType.ReplyEnergyDeputyGoal:
                    SkillEvent += (sender, e) => ReplyEnergyDeputyGoal(skillSource, skillDeputyGoal, eventBag);
                    break;
                case SkillEventType.DamageMainGoal:
                    SkillEvent += (sender, e) => DamageMainGoal(skillSource, skillMainGoal, eventBag);
                    break;
                case SkillEventType.DamageDeputyGoal:
                    SkillEvent += (sender, e) => DamageDeputyGoal(skillSource, skillDeputyGoal, eventBag);
                    break;
                case SkillEventType.BuffMainGoal:
                    SkillEvent += (sender, e) => BuffMainGoal(skillSource, skillMainGoal, eventBag);
                    break;
                case SkillEventType.BuffSource:
                    SkillEvent += (sender, e) => BuffSource(skillSource, eventBag);
                    break;
                case SkillEventType.BuffDeputyGoal:
                    SkillEvent += (sender, e) => BuffDeputyGoal(skillSource, skillDeputyGoal, eventBag);
                    break;

            }
        }
    }

    #region 向事件包列表中添加新的事件包的所有事件
    public EnergySkill AddEventBagToList(
        SkillEventType skillEventType,
        StatType statType,
        List<float> EventModifyBuffValue,
        float EventBaseValue = 0,
        Func<uint, float> EventBaseValueFunc = null,
        string BuffID = "none"

        )
    {
        skillEventBags.Add(new SkillEventBag(skillEventType, statType, EventModifyBuffValue, EventBaseValue, EventBaseValueFunc, BuffID));
        return this;
    }

    public EnergySkill AddEventBagToList(
            SkillEventType skillEventType,
    List<float> EventModifyBuffValue,
Func<uint, float> EventBaseValueFunc = null,
    string BuffID = "none"

        )
    {
        skillEventBags.Add(new SkillEventBag(skillEventType, EventModifyBuffValue, EventBaseValueFunc, BuffID));
        return this;
    }

    public EnergySkill AddEventBagToList(
                SkillEventType skillEventType,
    StatType statType,
float EventBaseValue,
Func<uint, float> EventBaseValueFunc

        )
    {
        skillEventBags.Add(new SkillEventBag(skillEventType, statType, EventBaseValue, EventBaseValueFunc));
        return this;
    }
    #endregion

    /// <summary>
    /// 使用技能的事件
    /// </summary>
    //public void UseSkillEvent()
    //{
    //    SkillEvent.Invoke();
    //}

    public bool UseSkillEvent()
    {
        var args = new MyEventArgs();
        var handlers = SkillEvent?.GetInvocationList();
        if (handlers == null) return false;
        foreach (EventHandler<MyEventArgs> handler in handlers)
        {
            handler(this, args);
            if (args.Cancel) break;
        }
        return NeedSwitchAction;
    }

    public void SetSkillLevel(ushort _skillLevel)
    {
        skillLevel = _skillLevel;
    }

    public void SetSkillSource(BSBaseData _skillSource)
    {
        skillSource = _skillSource;
    }

    //public void SetSkillMainGoal(BSBaseData _skillMainGoal)
    //{
    //    skillMainGoal = _skillMainGoal;
    //}
    public void SetSkillMainGoal(BattleScenePosition _skillMainGoalPos)
    {
        if (_skillMainGoalPos <= BattleScenePosition.Cpos9)
        {
            if (BattleSceneChrDataMgr.Instance.ChrTeamPosDic.ContainsKey(_skillMainGoalPos))
            {
                skillMainGoal = BattleSceneChrDataMgr.Instance.ChrTeam[new BattleSceneKeyBag(BattleSceneChrDataMgr.Instance.ChrTeamPosDic[_skillMainGoalPos], _skillMainGoalPos)];
            }
            else
            {
                skillMainGoal = null;
            }
        }
        else
        {
            if (BattleSceneEnemyDataMgr.Instance.EnemyTeamPosDic.ContainsKey(_skillMainGoalPos))
            {
                skillMainGoal = BattleSceneEnemyDataMgr.Instance.EnemyTeam[new BattleSceneKeyBag(BattleSceneEnemyDataMgr.Instance.EnemyTeamPosDic[_skillMainGoalPos], _skillMainGoalPos)];
            }
            else
            {
                skillMainGoal = null;
            }
        }
    }
    /// <summary>
    /// 计算伤害
    /// </summary>
    /// <param name="StatNum">参与本次计算的属性的值，例如生命值，攻击力等</param>
    /// <param name="skillLvlInfluence">技能等级的影响</param>
    /// <param name="sourceLvl">源的等级</param>
    /// <param name="GoalDefense">目标的等级</param>
    long GetDamage(long StatNum, float skillLvlInfluence, long sourceLvl, long GoalDefense)
    {
        return (long)((long)StatNum * skillLvlInfluence * sourceLvl / (GoalDefense <= 1 ? GoalDefense : 1));
    }

    string GetReplyHPText(string sourceName, string skillName, string sourceGoalName, long ReplyNum)
    {
        return sourceName + "通过" + skillName + "恢复了" + sourceGoalName +
                ReplyNum + "血量";
    }

    string GetDamageText(string sourceName, string skillName, string sourceGoalName, long ReplyNum)
    {
        return sourceName + "通过" + skillName + "对" + sourceGoalName + "造成了" +
                ReplyNum + "伤害";
    }

    string GetBuffText(string sourceName, string skillName, string sourceGoalName, string BuffName)
    {
        return sourceName + "通过" + skillName + "给予了" + sourceGoalName +
                BuffName;
    }
}
