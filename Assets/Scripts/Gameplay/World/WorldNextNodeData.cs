using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldNextNodeData
{
    /// <summary>
    /// 用来显示在UI中的文字
    /// </summary>
    public string displayText;

    public string nextNodeMapID;//下一个节点的MapID

    public WorldNextNodeData() { }

    public WorldNextNodeData(string _nextNodeMapID)
    {
        nextNodeMapID = _nextNodeMapID;
        displayText = DataManager.Instance.singletonMapData[nextNodeMapID].NodeName;
    }
}
