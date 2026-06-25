using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 在DataManager中保存合成配方json数据的基类
/// </summary>
public class BasesSnthesisItemData
{
    public string FormulaID;
    public string FormulaName;
    public Dictionary<string,int> materialNumTable;
    public string FormulaGoal;//合成目标

}
