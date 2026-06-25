using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WorldBaseItemData
{
    public string id;
    public string itemName;
    public string description;//物品描述
    public int StackNum = 1;//当前堆叠
    public bool canStack = true;//能否堆叠
    public ItemType itemType;//物品类型
    public uint price;//物品价值

    public WorldBaseItemData() { }
    public bool AddStackNum()
    {
        if (canStack)
        {
            StackNum++;
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="addNum">堆叠数需要增加多少</param>
    public bool AddStackNums(int addNum)
    {
        if (canStack)
        {
            StackNum += addNum;
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool ReduceStackNum()
    {
        if (StackNum > 0)
        {
            StackNum--;
            return true;
        }
        else 
        {
            return false;
        }
        
    }

    public bool ReduceStackNums(int reduceNum)
    {
        if(StackNum>= reduceNum)
        {
            StackNum -= reduceNum;
            return true;
        }
        else
        {
            return false;
        }
    }
}
