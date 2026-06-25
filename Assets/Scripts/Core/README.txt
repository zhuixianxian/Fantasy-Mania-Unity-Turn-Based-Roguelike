          Core/                     # 核心系统（独立于游戏）
    │   ├── Singletons/           # 单例管理器
    │   │   ├── EventManager.cs
    │   │   ├── AudioManager.cs
    │   │   └── SaveManager.cs
    │   ├── Events/              # 事件系统
    │   │   ├── EventSystem.cs
    │   │   ├── GameEvents.cs
    │   │   └── EventArgs/
    │   ├── Utilities/           # 工具类
    │   │   ├── Extensions/
    │   │   ├── MathUtils.cs
    │   │   └── DebugTools.cs
    │   ├── Patterns/            # 设计模式
    │   │   ├── StateMachine/
    │   │   ├── ObjectPool/
    │   │   └── ServiceLocator/
    │   └── Editor/              # 编辑器工具
    │       └── Tools/