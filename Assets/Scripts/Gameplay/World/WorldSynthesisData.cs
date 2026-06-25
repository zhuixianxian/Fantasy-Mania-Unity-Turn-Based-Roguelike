using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static UnityEngine.Rendering.DebugUI;

public class WorldSynthesisData
{
    /// <summary>
    /// 用来显示在UI中的文字
    /// </summary>
    public string displayText;
    /// <summary>
    /// 本结构可以用于合成的东西
    /// </summary>
    public List<string> canSynthesisItem;

    public WorldSynthesisData() { }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="MapID"></param>
    /// <param name="synthesisTableNum">要生成第几个合成台数据</param>
    public WorldSynthesisData(string MapID)
    {
        BaseNodeData baseNodeData = DataManager.Instance.singletonMapData[MapID];//获取为哪个地图生成合成台
        ushort synthesisTableNum = (ushort)Random.Range(0, baseNodeData.synthesisContentsData.Count);//随机选择一个位置
        displayText = baseNodeData.synthesisContentsData[synthesisTableNum].NodeContentName;//从json数据中获取要生成的合成台节点的名字
        canSynthesisItem = new List<string>(baseNodeData.synthesisContentsData[synthesisTableNum].canSynthesisItem);
    }
}
