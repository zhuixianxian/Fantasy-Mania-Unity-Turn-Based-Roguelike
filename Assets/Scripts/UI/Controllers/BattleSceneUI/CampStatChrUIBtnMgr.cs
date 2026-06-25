using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class CampStatChrUIBtnMgr : MonoBehaviour
{
    public BattleSceneKeyBag BtnChr;//该按钮被点击会显示谁的数据

    public Button hasButton;//哪个按钮挂载着本脚本

    public TextMeshProUGUI ChrName;//数据来源的名字显示处
    // Start is called before the first frame update
    void Start()
    {
        hasButton.onClick.AddListener(() =>
        {
            EventCenter.Instance.EventTrigger<BattleSceneKeyBag>(E_EventType.E_RefreshBSStatView, BtnChr);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }

    public void SetText(string _ChrName)
    {
        ChrName.text = _ChrName;
    }
}
