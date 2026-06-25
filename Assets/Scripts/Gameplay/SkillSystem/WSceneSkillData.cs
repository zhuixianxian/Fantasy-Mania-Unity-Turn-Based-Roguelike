using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WSceneSkillData
{
    public string SkillID;//技能ID
    public string SkillName;//技能名
    public SkillType skillType;//技能类型（技能，大招技能或CD技能）
    public SkillCoinGrowthRate skillCoinGrowthRate;//技能升级金币增长速度类型
    public string SkillDescription;//技能描述
    public long SkillUnlockLevel;//技能解锁等级
    public bool skillUnlock;//判断技能是否已解锁

    public ushort SkillPoints;//技能所需的技能点数量
    public ushort SkillEnergy;//技能所需的能量
    public ushort SkillCD;//技能所需的冷却


    public ushort skillLevel;//技能等级
    public short maxSkillLevel;//技能等级

    public long LevelUpCoin;//技能升级所需的金币数量

    public void UnlockSkill(long CurrentLevel)
    {
        if(CurrentLevel>= SkillUnlockLevel)
        {
            skillUnlock = true;
        }
    }
    public WSceneSkillData() { }
    public WSceneSkillData(BaseSkillData baseSkillData)
    {
        SkillID = baseSkillData.SkillID;
        SkillName = baseSkillData.SkillName;
        skillType = baseSkillData.skillType;
        skillCoinGrowthRate = baseSkillData.skillCoinGrowthRate;
        SkillDescription = baseSkillData.SkillDescription;
        SkillUnlockLevel = baseSkillData.SkillUnlockLevel;
        maxSkillLevel = baseSkillData.MaxSkillLevel;
        skillUnlock = false;

        SkillPoints=baseSkillData.SkillPoints;
        SkillEnergy = baseSkillData.SkillEnergy;
        SkillCD = baseSkillData.SkillCD;


        skillLevel = 1;
        LevelUpCoin = 1000;
    }

    public bool AddSkillLevel()
    {
        if(GameDataManager.Instance.CoinNum>= LevelUpCoin&&skillLevel<maxSkillLevel)
        {
            skillLevel++;
            GameDataManager.Instance.CoinNum -= LevelUpCoin;
            switch (skillCoinGrowthRate)
            {
                case SkillCoinGrowthRate.verySlow:
                    LevelUpCoin = GameFunctions.Instance.LevelCoinFunction_1(LevelUpCoin);
                    break;
                case SkillCoinGrowthRate.slow:
                    LevelUpCoin = GameFunctions.Instance.LevelCoinFunction_2(LevelUpCoin);
                    break;
                case SkillCoinGrowthRate.normal:
                    LevelUpCoin = GameFunctions.Instance.LevelCoinFunction_3(LevelUpCoin);
                    break;
                case SkillCoinGrowthRate.quick:
                    LevelUpCoin = GameFunctions.Instance.LevelCoinFunction_4(LevelUpCoin);
                    break;
                case SkillCoinGrowthRate.veryQuick:
                    LevelUpCoin = GameFunctions.Instance.LevelCoinFunction_5(LevelUpCoin);
                    break;
            }
            
            return true;
        }
        else
        {
            return false;
        }
    }
}
