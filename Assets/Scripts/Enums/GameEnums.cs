using UnityEngine;
using System.Collections;
using System;

namespace FantasyMania.TurnBasedCombat
{
    public class GameEnums
    {
        public enum SkillTargetType
        {
            // 无目标（立即生效的技能）
            None = 0,

            // 敌人相关
            SingleEnemy = 1,         // 单个敌人
            MultipleEnemy = 2,       // 多个敌人
            AllEnemy = 3,           // 所有敌人
            RandomEnemy = 4,        // 随机敌人

            // 友方相关
            SingleAlly = 5,         // 单个友方
            MultipleAlly = 6,       // 多个友方
            AllAlly = 7,           // 所有友方
            Self = 8,              // 只能对自己使用

            // 特殊目标
            DeadAlly = 9,          // 死亡友方（复活技能）
            DeadEnemy = 10,        // 死亡敌人（鞭尸技能）
            EmptySlot = 11,        // 空位（召唤技能）
            Ground = 12,           // 地面（放置类技能）

            // 组合目标
            All = 14,              // 所有单位
            SpecialCombination = 15, // 每个技能单独设计目标位置数组

            // 条件目标
            ConditionalObjective = 16,// 依据属性数值判断
            Random = 17,          // 完全随机

        }

        public enum TargetRange
        {
            OurSide = 0,
            Front = 1,
            Side_1 = 2,
            Side_2 = 3,
        }

        /// <summary>
        /// 战斗系统状态的枚举值
        /// </summary>
        public enum CombatSystemType
        {
            /// <summary>
            /// 初始化系统状态
            /// </summary>
            InitSystem = 0,
            /// <summary>
            /// 一个回合开始之前的状态
            /// </summary>
            BeforeAction = 1,
            /// <summary>
            /// 一个回合正在进行的状态
            /// </summary>
            Actioning = 2,
            /// <summary>
            /// 一个回合结束时候的状态
            /// </summary>
            AfterAction = 3,
            /// <summary>
            /// 一场战斗结束的状态
            /// </summary>
            CombatEnd = 4,
            /// <summary>
            /// 退出战斗系统的时候的状态
            /// </summary>
            ExitSystem = 5
        }

        public enum UnitType
        {
            /// <summary>
            /// 单纯的数值
            /// </summary>
            Value = 0,
            /// <summary>
            /// 使用百分比的数值
            /// </summary>
            Percent = 1
        }

        public enum StatType
        {
            None,
            // 资源
            Health,

            CurrentHealth,
            MaxHealth,
            Energy,
            CurrentEnergy,
            MaxEnergy,
            SkillPoints,
            CurrentSkillPoints,
            MaxSkillPoints,
            CurrentExperience,
            MaxExperience,
            Level,

            // 战斗属性
            //加上血量就是第一类加点属性，使用第一类属性点进行加点
            Attack,
            Defense,
            MagicAttack,
            MagicDefense,
            Speed,
            //使用第二类属性点进行加点
            Accuracy,
            Evasion,
            Parry,
            Agility,
            EffectHit,
            EffectResistance,
            //仅能从装备中获取 
            DamageReduction,
            LifeSteal,
            ReflectedDamage,
            ReflectionRate,
            HPRecoveryperTurn,
            HPRecoveryperAttack,
            CriticalRate,
            CriticalDamage,
            DamageReflectionRatio,
            CriticalResistance,
            EffectHitRate,
            EffectResistanceRate,
            Penetration
        }

        public enum StatId
        {
            // 资源
            Health,
            CurrentHealth,
            MaxHealth,
            Energy,
            CurrentEnergy,
            MaxEnergy,
            SkillPoints,
            CurrentSkillPoints,
            MaxSkillPoints,
            CurrentExperience,
            MaxExperience,
            Level,

            // 战斗属性
            //加上血量就是第一类加点属性，使用第一类属性点进行加点
            Attack,
            Defense,
            MagicAttack,
            MagicDefense,
            Speed,
            //使用第二类属性点进行加点
            Accuracy,
            Evasion,
            Parry,
            Agility,
            EffectHit,
            EffectResistance,
            //仅能从装备中获取 
            DamageReduction,
            LifeSteal,
            ReflectedDamage,
            ReflectionRate,
            HPRecoveryperTurn,
            HPRecoveryperAttack,
            CriticalRate,
            CriticalDamage,
            DamageReflectionRatio,
            CriticalResistance,
            EffectHitRate,
            EffectResistanceRate,
            Penetration
        }

        public enum ModifierSource
        {
            BaseStat,      // 基础属性
            Equipment,     // 装备
            Skill,         // 技能
            Buff,          // Buff
            Talent,        // 天赋
            Aura           // 光环
        }

        public enum SceneName
        {
            StartScene,
            TeamFormationScene
        }

        public enum ModifierType
        {
            AddBase,        // 基础值加法（如等级提升）
            MultiplyBase,   // 基础值乘法（如等级提升）
            Add,            // 加法（如装备固定值）
            Multiply,       // 乘法（百分比加成）
            Override,       // 覆盖（如某些特殊效果）
            FinalAdd,       // 最终加法（所有计算结束后再加）
            FinalMultiply   // 最终乘法（独立乘区）
        }

        public enum GameState
        {
            None = 0, // 无
            MainMenu, // 主菜单
            TeamSetup, // 队伍配置
            WorldExploration, // 世界探索
            Battle, // 战斗
            Dialogue, // 对话
            Pause, // 暂停
            GameOver // 游戏结束
        }

        public enum E_EventType
        {
            /// <summary>
            /// 怪物死亡事件 —— 参数：Monster
            /// </summary>
            E_Monster_Dead,
            /// <summary>
            /// 玩家获取奖励 —— 参数：int
            /// </summary>
            E_Player_GetReward,
            /// <summary>
            /// 测试用事件 —— 参数：无
            /// </summary>
            E_Test,
            /// <summary>
            /// 场景切换时进度变化获取
            /// </summary>
            E_SceneLoadChange,

            /// <summary>
            /// 输入系统触发技能1 行为
            /// </summary>
            E_Input_Skill1,
            /// <summary>
            /// 输入系统触发技能2 行为
            /// </summary>
            E_Input_Skill2,
            /// <summary>
            /// 输入系统触发技能3 行为
            /// </summary>
            E_Input_Skill3,

            /// <summary>
            /// 水平热键 -1~1的事件监听
            /// </summary>
            E_Input_Horizontal,

            /// <summary>
            /// 竖直热键 -1~1的事件监听
            /// </summary>
            E_Input_Vertical,

            E_AddPointEvent,
            E_ReducePointEvent,
            E_Add10PointsEvent,
            E_Reduce10PointsEvent,
            E_ClearPointsEvent,

            E_SkillDescription,//展示技能描述
            E_SkillLevelUp,//技能升级 
            E_SkillConfiguration,//技能配置

            E_WorldNodeEvent_1,
            E_WorldNodeEvent_2,
            E_WorldNodeEvent_3,
            E_WorldNodeEvent_4,
            E_WorldNodeEvent_5,
            E_WorldNodeEvent_6,
            E_WorldNodeEvent_7,
            E_WorldNodeEvent_8,
            E_WorldNodeEvent_9,

            E_RefreshBSStatView,//刷新战斗场景中的属性界面的事件

            E_PromptPanelDisplay,//提示板显示的事件

            E_DisplayFormula,//用于显示出配方的事件

            E_AddMaterToForm,//添加材料到工作台中
            E_RemoveMaterToForm,//删除材料到工作台中

            E_UnEquipEquipment,//卸下装备
            E_EquipEquipment,//装备装备

            E_BuyShopGoods,//购买商店商品

            E_BattleEventPrint,//打印战斗事件
        }
        public enum TeamPosition
        {
            pos0,
            pos1,
            pos2,
            pos3,
            pos4,
            pos5,
            pos6,
            pos7,
            pos8,
            pos9
        }

        public enum StateMachineStatus
        {
            Menu,//在配队菜单中时
            Start,//从菜单加载场景时
            Before,//生成场景中的元素
            In,//场景中的元素生成完毕
            CoinFlash,//金币数量刷新
            After,//清除场景中的元素
            BattleToWorld,//从战斗场景到世界场景

            Load,//从存档加载场景时
        }

        public enum NodeContentType
        {
            Enemy,
            Shop,
            TreasureChest,
            NPC,
            NextNode
        }

        public enum WorldNodePosition
        {
            pos0,
            pos1,
            pos2,
            pos3,
            pos4,
            pos5,
            pos6,
            pos7,
            pos8,
            pos9
        }

        public enum BattleState_1
        {
            BeginBattle,
            BeginRound,
            SpeedSort,

            BeginSkill_EnterNextAction,//用于判断使用了哪个技能并增删改查事件监听，并挂载新的伤害事件，Buff伤害事件和Buff挂载事件
            BeginSkill_NotEnterNextAction,//用于判断使用了哪个技能并增删改查事件监听，并挂载新的伤害事件，Buff伤害事件和Buff挂载事件

            //CN：CanNext,可以跳转下一行动的技能的种种阶段
            CN_BuffMount,//减防，减攻，减免伤等buff的挂载阶段
            CN_SkillDamage,//技能伤害执行阶段
            CN_SkillBloodSucking,//攻击吸血事件的执行阶段
            CN_SkillReply,//攻击回复事件的执行阶段
            CN_BuffDamage,//Dot伤害类Buff伤害结算阶段
            CN_BuffRelieve,//减防，减攻，减免伤等buff的解除阶段
            CN_ReduceActionCD,//依靠行动来判断冷却的技能们的冷却数减少阶段
            EndSkill_EnterNextAction,//该阶段至少一个功能是用来判断双方有没有一方全部死亡

            //NN:NotNext，不会跳转到下一行动的技能的种种阶段
            NN_BuffMount,//减防，减攻，减免伤等buff的挂载阶段
            NN_SkillDamage,//技能伤害执行阶段
            NN_SkillBloodSucking,//攻击吸血事件的执行阶段
            NN_SkillReply,//攻击回复事件的执行阶段
            EndSkill_NotEnterNextAction,

            ActionVerification,//验证该回合中是否仍有人未执行行动的阶段

            RoundBuffRelieve,//用回合数作为留存依据的Buff的能否存续的验证阶段
            ReduceRoundCD,//用回合数作为冷却的技能的冷却数的减少阶段

            EndRound,//回合结束阶段

            EndBattle,//战斗结束阶段

            Settlement,//胜负结算阶段，胜利给予经验，金币和产物，武器等，并将该队敌人置死，失败判断队伍角色是否全部死亡，否回到世界场景，是则结算游戏

            EndGame//结束游戏阶段，用于回到初始场景

        }

        public enum BattleState
        {
            None,
            BeginBattle,
            BeginRound,//开始回合
            BeginAction,//开始行动

            BuffProcess,//Buff的处理阶段
            //SpeedSort,//速度排序
            DetermineCurrentActor,//确定当前行动者

            RefreshUI,//刷新UI的阶段
            RefreshUIDone,//刷新UI的阶段

            BeginActionOperation,//行动操作开始的阶段
            ActionOperation,//行动运行中的阶段

            BeginSkill,//开始使用技能

            EndRound,//结束回合


            VictorySettlement,//胜利结算
            VictorySwitch,//胜利结算
            FailedSettlement,//失败结算
        }
        /// <summary>
        /// 一次行动中的逐个阶段
        /// </summary>
        public enum ActionState
        {
            None,
            CampJudgment,//判断当前的行动者的阵营
            ChrAction,//角色行动

            ChrSkillExecute_1,//角色技能执行的阶段1,主要负责选取技能
            ChrSkillExecute_2,//角色技能执行的阶段2，主要负责选取目标
            ChrSkillExecute_3,//角色技能执行的阶段3，主要选择技能原型进入队列
            ChrSkillExecute_4,//角色技能执行的阶段4，主要设置技能的源，目标，等级
            ChrSkillExecute_5,//角色技能执行的阶段5，主要将技能的包转化为事件

            UseSkillEvent,//逐步推进技能事件

            RefreshUI,//刷新UI，主要是刷新血量和点数，能量之类的
            RefreshUIDone,//刷新UI，主要是刷新血量和点数，能量之类的


            EnemyAction,//敌人行动

            EnemySkillExecute_1,//敌人技能执行的阶段1,主要负责选取技能
            EnemySkillExecute_2,//敌人技能执行的阶段2，主要负责选取目标
            EnemyThink,//敌人的思考时间，用于显示行动者时更加清晰
            EnemyThinking,//敌人的思考时间，用于显示行动者时更加清晰
            EnemySkillExecute_3,//敌人技能执行的阶段3，主要选择技能原型进入队列
            EnemySkillExecute_4,//敌人技能执行的阶段4，主要设置技能的源，目标，等级
            EnemySkillExecute_5,//敌人技能执行的阶段5，主要将技能的包转化为事件


            EndAction,//结束行动
        }

        public enum SkillType
        {
            NormalAttack,//普通攻击
            Skill,//技能
            EnergySkill,//消耗能量的大招 
            CDSkill,//有CD的技能
            WholeTeamSkill,//消耗全队技能点的技能
            ComboSkill,//连击
            CounterSkill,//反击
            FollowupSkill,//追击
            VariantSkill,//变招
        }

        public enum ConfigSkillType
        {
            Join,//加入成功
            Remove,//已有，去除
            Full,//满了，没法加进来
            None//作为默认返回值
        }

        public enum SkillCoinGrowthRate
        {
            verySlow,
            slow,
            normal,
            quick,
            veryQuick
        }

        [Flags]
        public enum ActionTag
        {
            None = 0,
            Original = 1 << 0,     // 原始行动
            Derived = 1 << 1,      // 衍生行动

            // 行动类型
            Counter = 1 << 2,      // 反击
            FollowUp = 1 << 3,     // 追击
            Combo = 1 << 4,        // 连击
            Extra = 1 << 5,        // 额外行动
            Passive = 1 << 6,      // 被动触发

            // 攻击类型
            NormalAttack = 1 << 7, // 普通攻击
            Skill = 1 << 8,        // 技能
            Ultimate = 1 << 9,     // 必杀技

            // 属性类型
            Physical = 1 << 10,    // 物理
            Magic = 1 << 11,       // 魔法
            Fire = 1 << 12,        // 火属性
            Ice = 1 << 13,         // 冰属性
            Thunder = 1 << 14,     // 雷属性

            // 攻击方式
            Melee = 1 << 15,       // 近战
            Ranged = 1 << 16,      // 远程
            Area = 1 << 17,        // 范围攻击
            Single = 1 << 18,      // 单体攻击
        }

        //战斗场景中的角色和敌人位置的枚举
        public enum BattleScenePosition
        {
            Cpos1,
            Cpos2,
            Cpos3,
            Cpos4,
            Cpos5,
            Cpos6,
            Cpos7,
            Cpos8,
            Cpos9,

            Epos1,
            Epos2,
            Epos3,
            Epos4,
            Epos5,
            Epos6,
            Epos7,
            Epos8,
            Epos9
        }
        /// <summary>
        /// 有哪几种Buff，例如减益类，回合作用类，攻击时作用类，受击时作用类
        /// </summary>
        public enum BuffType
        {
            StatBuff,//属性改变
            TagBuff,//Tag类Buff
            TurnTriggerBuff,//回合触发
            OnAttackTriggerBuff,//攻击触发
            OnHitTriggerBuff//受击触发
        }
        /// <summary>
        /// //Buff的叠加方式区分
        /// </summary>
        public enum BuffOverlayType
        {
            OverWrite,//新的覆盖旧的
            Independent,//各个Buff独自留下
            LevelUp//等级提升
        }
        /// <summary>
        /// //Buff衰减的类型
        /// </summary>
        public enum BuffReduceType
        {
            Clear,//清除该Buff
            LevelDown//等级降低
        }

        public enum SputteringType//技能溅射的类型
        {
            One,//只攻击一个，不做溅射
            Short1,//短1，即攻击主目标以及主目标身后一个
            long1,//攻击攻击主目标以及主目标身后2个
            Horizontal,//攻击一行
            ShortT,//短T，一行及中间目标的后一个
            LongT,//一行及中间目标的后2个
            TwoHorizontal,//两行
            ThreeHorizontal,//三行
        }

        public enum SkillEventType//技能事件的类型
        {
            ConsumeResources,//消耗资源（如技能点，能量等）
            ReplyHealthMainGoal,//对主目标回复血量
            ReplyHealthDeputyGoal,//回复血量
            ReplyHealthSource,//回复血量
            ReplyPointsMainGoal,//对主目标回复技能点
            ReplyPointsDeputyGoal,//回复技能点
            ReplyPointsSource,//回复技能点
            ReplyEnergyMainGoal,//对主目标回复能量
            ReplyEnergyDeputyGoal,//回复能量
            ReplyEnergySource,//回复能量
            DamageMainGoal,//对主目标造成伤害
            DamageDeputyGoal,//对副目标造成伤害
            BuffDeputyGoal,//对副目标上Buff
            BuffMainGoal,//对主目标上Buff

            BuffSource,//对源上Buff
            BuffLvlChangeMove,//Buff等级对是否变招的判断
            RandomChangeMove,//依据传入的数字和属性值进行概率判断并判断是否进行变招

            BuffLevelDown,//对指定的Buff的等级进行削减

            StrengthenRelease,//解除所有的强化Buff
            WeakenedRelease,//解除所有的弱化Buff
        }

        public enum Camp//阵营的枚举
        {
            Character,//角色
            Enemy,//敌人
        }
        /// <summary>
        /// 判断敌我双方是否有一个全部死亡
        /// </summary>
        public enum BattleVictoryJudgment
        {
            Victory,
            None,
            Failure
        }
        /// <summary>
        /// 弹射按钮会调用哪种弹射事件
        /// </summary>
        public enum LaunchType
        {
            Enemy,//弹射到战斗场景
            synthesis,//弹射出合成面板
            shop,//弹射到商店面板
            nextNode,//去往下一节点
        }
        /// <summary>
        /// 游戏物品的种类
        /// </summary>
        public enum ItemType
        {
            Normal,//最普通的物品，没有特殊效用
            Medicine_Food,//药品和食物
            Equipment,//装备
        }


        /// <summary>
        /// 装备部位类型
        /// </summary>
        public enum EquipmentType
        {
            Helmet,     // 帽子
            Chestplate, // 胸甲
            Weapon,     // 武器
            Leggings,   // 裤子
            Bracers,    // 护腕
            Boots       // 鞋子
        }
    }
}