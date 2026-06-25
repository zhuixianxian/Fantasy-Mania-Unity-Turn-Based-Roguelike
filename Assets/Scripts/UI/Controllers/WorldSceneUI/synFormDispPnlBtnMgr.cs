using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class synFormDispPnlBtnMgr : MonoBehaviour
{
    //合成面板中，合成配方显示区的按钮身上挂载的管理器
    public string FormulaID;//配方的ID

    public Button FormDispBtn;//用于让配方悉数显现的按钮
    public TextMeshProUGUI FormName;//用于显示配方名字的区域

    // Start is called before the first frame update
    void Start()
    {
        FormDispBtn.onClick.AddListener(() =>
        {
            //待修改，待添加事件
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_DisplayFormula, FormulaID);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="FormID">配方ID</param>
    /// <param name="FormName">配方名称</param>
    public void SetID(string FormID,string _FormName)
    {
        FormulaID = FormID;
        FormName.text = _FormName;
    }
}
