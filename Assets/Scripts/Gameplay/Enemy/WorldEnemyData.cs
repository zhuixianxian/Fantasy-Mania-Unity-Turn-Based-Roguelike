using System.Collections;
using System.Collections.Generic;
using System.Linq;

using FantasyMania.TurnBasedCombat;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WorldEnemyData
{
    //世界场景中敌人的数据容器
    // 核心身份信息
    public string EnemyID;
    public string EnemyName;
    public long Level;
    /// <summary>
    /// 敌人生成在敌方的哪个位置
    /// </summary>
    public int teamPosition;

    public long MaxHealth;

    public long MaxEnergy;
    public ushort MaxSkillPoints;

    public long Attack;
    public long Defense;
    public long MagicAttack;
    public long MagicDefense;
    public long Speed;
    public long Accuracy;
    public long Evasion;
    public long Parry;
    public long Agility;
    public long EffectHit;
    public long EffectResistance;

    public long DamageReduction;
    public long LifeSteal;
    public long ReflectedDamage;
    public long ReflectionRate;
    public long HPRecoveryperTurn;
    public long HPRecoveryperAttack;
    public long CriticalRate;
    public long CriticalDamage;
    public long DamageReflectionRatio;
    public long CriticalResistance;
    public long EffectHitRate;
    public long EffectResistanceRate;
    public long Penetration;

    public WSEnemySkillComp WSEnemySkillComp;//世界场景中的敌人的技能管理器

    int PointsNum1;
    int PointsNum2;

    List<int> sharePosition1;
    List<int> sharePosition2;
    List<int> sharePositionNum1;
    List<int> sharePositionNum2;

    public WorldEnemyData() { }

    public WorldEnemyData(string EnemyID,int NodeNum,int EnemyDeviationValue,int enemyPos)
    {
        //Random.InitState(GameDataManager.Instance.GameSeed+NodeNum+ EnemyDeviationValue);
        this.EnemyID = EnemyID;
        EnemyName = DataManager.Instance.singletonEnemyData[EnemyID].EnemyName;

        Level = NodeNum+1;
        teamPosition = enemyPos;
        //Debug.Log(EnemyID);
        //属性点总数
        PointsNum1 = NodeNum * 4;
        PointsNum2 = NodeNum * 4;
        BaseEnemyData(EnemyID,NodeNum);
        //属性点分配的份数
        int sharesAllocation = Random.Range(1, 7);
        //要分配给哪些属性,用数字代表要分配给哪个属性，1代表分给血量，2代表分给攻击，3代表分给防御，4代表分给特攻，以此类推
        //然后根据一个被分成sharesAllocation份的PointsNum的列表正式给他们一个一个加上数值，为了生成的敌人五花八门，因此需要
        //属性点的分配方式情况较多
        sharePosition1 = new List<int>();
        sharePosition2 = new List<int>();
        sharePositionNum1 = new List<int>();
        sharePositionNum2 = new List<int>();
        //应该分配给哪些属性点
        for(int i=0;i< sharesAllocation; i++)
        {
            sharePosition1.Add(Random.Range(1, 7));
            sharePosition2.Add(Random.Range(1, 7));
        }
        //根据属性点总数和应分配份数得到每份属性点有多少
        sharePositionNum1 = RandomSplitUniformOptimized(PointsNum1, sharesAllocation);
        sharePositionNum2 = RandomSplitUniformOptimized(PointsNum2, sharesAllocation);
        AllocatePoints();
    }

    public void BaseEnemyData(string EnemyID,int NodeNum)
    {
        BaseEnemyData baseEnemyData=DataManager.Instance.singletonEnemyData[EnemyID];
        MaxHealth = baseEnemyData.MaxHealth;

        MaxEnergy = baseEnemyData.MaxEnergy;
        MaxSkillPoints = baseEnemyData.MaxSkillPoints;

        Attack = baseEnemyData.Attack;
        Defense = baseEnemyData.Defense;
        MagicAttack = baseEnemyData.MagicAttack;
        MagicDefense = baseEnemyData.MagicDefense;
        Speed = baseEnemyData.Speed;

        Accuracy = baseEnemyData.Accuracy;
        Evasion = baseEnemyData.Evasion;
        Parry = baseEnemyData.Parry;
        Agility = baseEnemyData.Agility;
        EffectHit = baseEnemyData.EffectHit;
        EffectResistance = baseEnemyData.EffectResistance;
        if (baseEnemyData.enemySkillList == null)
        {
            Debug.Log(EnemyID + "null");
        }
        WSEnemySkillComp = new WSEnemySkillComp(baseEnemyData.enemySkillList, NodeNum);
    }

    /// <summary>
    /// 随机拆分算法
    /// </summary>
    private List<int> RandomSplitUniformOptimized(int total, int n)
    {
        if (n <= 0) return new List<int>();

        if (total == 0)
        {
            return Enumerable.Repeat(0, n).ToList();
        }

        if (n == 1) return new List<int> { total };

        // 新增：当 total < n 时，分配方案：前 total 个位置得1，其余得0
        if (total < n)
        {
            var result = new List<int>(n);
            for (int i = 0; i < n; i++)
                result.Add(i < total ? 1 : 0);
            return result;
        }

        List<int> parts = new List<int>(n); 
        List<int> cutPoints = new List<int>(n - 1);
        if (n - 1 <= total * 0.5f)
        {
            HashSet<int> usedPoints = new HashSet<int>();
            while (cutPoints.Count < n - 1)
            {
                int point = Random.Range(1, total);
                if (usedPoints.Add(point))
                {
                    cutPoints.Add(point);
                }
            }
        }
        else
        {
            List<int> allPoints = new List<int>(total - 1);
            for (int i = 1; i < total; i++)
            {
                allPoints.Add(i);
            }

            for (int i = 0; i < allPoints.Count; i++)
            {
                int j = Random.Range(i, allPoints.Count);
                int temp = allPoints[i];
                allPoints[i] = allPoints[j];
                allPoints[j] = temp;
            }
            cutPoints = allPoints.GetRange(0, n - 1);
        }

        cutPoints.Sort();

        parts.Add(cutPoints[0]);  
        for (int i = 1; i < n - 1; i++)
        {
            parts.Add(cutPoints[i] - cutPoints[i - 1]);  
        }
        parts.Add(total - cutPoints[n - 2]);  

        return parts;
    }

    /// <summary>
    /// 权重版本 - 可以根据不同属性设置不同的分配权重
    /// </summary>
    private int[] RandomSplitWeighted(int total, int n, List<int> weights = null)
    {
        if (weights == null || weights.Count != n)
        {
            // 如果没有提供权重，使用均匀权重
            weights = new List<int>();
            for (int i = 0; i < n; i++) weights.Add(1);
        }

        int[] parts = new int[n];
        int remaining = total;
        int totalWeight = 0;

        foreach (int w in weights) totalWeight += w;

        for (int i = 0; i < n - 1; i++)
        {
            // 根据权重计算最大分配值
            int max = remaining - (n - i - 1); // 确保至少有1留给后面的
            if (max < 0) max = 0;

            // 权重影响分配范围
            int weightedMax = Mathf.FloorToInt(max * (weights[i] / (float)totalWeight));
            if (weightedMax < 0) weightedMax = 0;

            // 随机分配
            parts[i] = Random.Range(0, weightedMax + 1);
            remaining -= parts[i];
            totalWeight -= weights[i];
        }

        parts[n - 1] = remaining; // 最后一部分

        // 随机交换，增加随机性
        for (int i = 0; i < n; i++)
        {
            int j = Random.Range(i, n);
            int temp = parts[i];
            parts[i] = parts[j];
            parts[j] = temp;
        }

        return parts;
    }
    /// <summary>
    /// 用于分配属性
    /// </summary>
    private void AllocatePoints()
    {
        int tempPos1 = 0;
        int tempPos2 = 0;
        //……一个用于生成属性点分配数列表的函数
        foreach (int i in sharePosition1)
        {

            //通过switch按照sharePosition为每个被选中的属性添加分配数列表中的数据
            //Debug.Log(sharePositionNum[tempPos]);
            switch (i)
            {
                case 1:
                    MaxHealth += sharePositionNum1[tempPos1]*4;
                    break;
                case 2:
                    Attack += sharePositionNum1[tempPos1];
                    break;
                case 3:
                    Defense += sharePositionNum1[tempPos1];
                    break;
                case 4:
                    MagicAttack += sharePositionNum1[tempPos1];
                    break;
                case 5:
                    MagicDefense += sharePositionNum1[tempPos1];
                    break;
                case 6:
                    Speed += sharePositionNum1[tempPos1];
                    break;
                default:
                    // 处理未知的 case 值
                    Debug.LogWarning($"未知的属性类型: {i}");
                    break;
            }
            tempPos1++;
        }

        foreach (int i in sharePosition2)
        {

            //通过switch按照sharePosition为每个被选中的属性添加分配数列表中的数据
            //Debug.Log(sharePositionNum[tempPos]);
            switch (i)
            {
                case 1:
                    Accuracy += sharePositionNum2[tempPos2];
                    break;
                case 2:
                    Evasion += sharePositionNum2[tempPos2];
                    break;
                case 3:
                    Parry += sharePositionNum2[tempPos2];
                    break;
                case 4:
                    Agility += sharePositionNum2[tempPos2];
                    break;
                case 5:
                    EffectHit += sharePositionNum2[tempPos2];
                    break;
                case 6:
                    EffectResistance += sharePositionNum2[tempPos2];
                    break;
                default:
                    // 处理未知的 case 值
                    Debug.LogWarning($"未知的属性类型: {i}");
                    break;
            }
            tempPos2++;
        }
    }
}
