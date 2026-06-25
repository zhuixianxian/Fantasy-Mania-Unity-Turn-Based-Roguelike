├── Gameplay/                # 游戏逻辑
    │   ├── BattleSystem/        # 战斗系统
    │   │   ├── Controllers/
    │   │   │   ├── BattleController.cs
    │   │   │   └── SkillController.cs
    │   │   ├── States/          # 状态机
    │   │   │   ├── IBattleState.cs
    │   │   │   ├── InitState.cs
    │   │   │   └── BeforeActionState.cs
    │   │   ├── Systems/         # 战斗子系统
    │   │   │   ├── DamageSystem.cs
    │   │   │   ├── TargetSystem.cs
    │   │   │   └── TurnSystem.cs
    │   │   └── Components/      # 战斗组件
    │   │       ├── BattleStage.cs
    │   │       └── ...
    │   │
    │   ├── CharacterSystem/     # 角色系统
    │   │   ├── Data/           # 数据类
    │   │   │   ├── HeroData.cs
    │   │   │   ├── HeroProperty.cs
    │   │   │   └── ValueUnit.cs
    │   │   ├── Entities/       # 实体类
    │   │   │   ├── HeroMono.cs
    │   │   │   ├── HeroTeamMono.cs
    │   │   │   └── ...
    │   │   ├── Components/     # 组件
    │   │   │   ├── HealthComponent.cs
    │   │   │   ├── SkillComponent.cs
    │   │   │   └── BuffComponent.cs
    │   │   └── Factories/      # 工厂
    │   │       ├── HeroFactory.cs
    │   │       └── ...
    │   │
    │   ├── SkillSystem/        # 技能系统
    │   │   ├── Base/
    │   │   │   ├── BaseSkill.cs
    │   │   │   └── SkillData.cs
    │   │   ├── Effects/        # 技能效果
    │   │   │   ├── DamageEffect.cs
    │   │   │   ├── HealEffect.cs
    │   │   │   └── BuffEffect.cs
    │   │   └── Controllers/
    │   │
    │   ├── BuffSystem/         # Buff系统
    │   │   ├── Base/
    │   │   │   ├── Buff.cs
    │   │   │   └── BuffData.cs
    │   │   ├── Effects/        # Buff效果
    │   │   │   ├── StatBuff.cs
    │   │   │   ├── ControlBuff.cs
    │   │   │   └── ShieldBuff.cs
    │   │   ├── Managers/       # Buff管理器
    │   │   │   └── BuffManager.cs
    │   │   └── Controllers/
    │   │
    │   ├── Data/               # 游戏数据
    │   │   ├── Config/         # 配置
    │   │   │   ├── HeroTable.cs
    │   │   │   ├── SkillTable.cs
    │   │   │   └── BuffTable.cs
    │   │   ├── Save/           # 存档
    │   │   │   ├── SaveData.cs
    │   │   │   └── SaveSystem.cs
    │   │   └── Runtime/        # 运行时数据
    │   │       └── GameState.cs
    │   │
    │   └── World/              # 非战斗系统
    │       ├── Map/
    │       ├── NPC/
    │       └── Quest/