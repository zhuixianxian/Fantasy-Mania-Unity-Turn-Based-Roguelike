using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

/// <summary>
/// 用于在合成面板中显示具体的合成材料需求时的管理器
/// </summary>
public class formMaterItemPnlMgr : MonoBehaviour
{
    public TextMeshProUGUI nameText;//名称显示处
    public TextMeshProUGUI numText;//数量显示处

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matName">材料的名称</param>
    /// <param name="matNum">材料的消耗数量</param>
    public void SetText(string matName,int matNum)
    {
        nameText.text = matName;
        numText.text = matNum.ToString();
    }
}
