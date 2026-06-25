using System;
using System.Collections;
using System.Collections.Generic;
//using System.Xml;

using FantasyMania.TurnBasedCombat;

using TMPro;

//using Unity.VisualScripting;

//using UnityEditor.U2D.Animation;

using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

//using static UnityEditor.Rendering.FilterWindow;

/// <summary>
/// 角色配队场景UI的脚本
/// </summary>
public class TFSceneUIMgr : MonoBehaviour
{
    public Button chooseCharacterBtn;
    public Button goToWorldButton;
    public TextMeshProUGUI textTeamList;
    public Transform contentParent;
    public Transform MTeamList;
    //public Transform STeamList;

    public TextMeshProUGUI NameText;

    public TextMeshProUGUI BaseHealthText;
    public TextMeshProUGUI BaseManaText;

    public TextMeshProUGUI BaseAttackText;
    public TextMeshProUGUI BaseDefenseText;
    public TextMeshProUGUI BaseMagicAttackText;
    public TextMeshProUGUI BaseMagicDefenseText;
    public TextMeshProUGUI BaseSpeedText;

    public TextMeshProUGUI BaseAccuracyText;
    public TextMeshProUGUI BaseEvasionText;
    public TextMeshProUGUI BaseParryText;
    public TextMeshProUGUI BaseAgilityText;
    public TextMeshProUGUI BaseEffectHitText;
    public TextMeshProUGUI BaseEffectResistanceText;



    public TextMeshProUGUI Description;

    //private int ButtonNum = 0;
    private List<Button> ButtonList=new List<Button>();
    /// <summary>
    /// 选中的角色的ID
    /// </summary>
    public string ChooseCharacterID;
    public List<string> TeamCharacterIDs;
    //public List<string> BackgroundTeamCharacterIDs;
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null &&
    DataManager.Instance.singletonCharacterData != null)
        {
            foreach (KeyValuePair<string, BaseCharacterData> kvp in DataManager.Instance.singletonCharacterData)
            {
                // 每循环一次，就复印一个新的按钮
                Button newButton = Instantiate(chooseCharacterBtn, contentParent);
                newButton.name = $"Btn_{kvp.Key}";
                // 设置不同的文本
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = DataManager.Instance.singletonCharacterData[kvp.Key].Name;
                BindButtonClickEvent(newButton, DataManager.Instance.singletonCharacterData[kvp.Key]);
                ButtonList.Add(newButton);
            }
        }
        goToWorldButton.onClick.AddListener(() => 
        {
            if (TeamCharacterIDs != null)
            {
                SceneMgr.Instance.LoadSceneAsyn("WorldScene");
                GameDataManager.Instance.MenuToWorld(TeamCharacterIDs);

            }
        });                                             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BindButtonClickEvent(Button button, BaseCharacterData data)
    {
        // 先移除所有旧的监听器（防止重复绑定）
        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(() =>
        {
            OnCharacterButtonClicked(data);
        });
    }

    void OnCharacterButtonClicked(BaseCharacterData data)
    {
        // 这里可以执行任何你想要的操作：
        // 1. 显示角色详情
        ShowCharacterDetails(data);

        //// 3. 高亮选中的按钮
        //HighlightSelectedButton(characterID);

        //// 4. 播放音效
        //PlayButtonClickSound();

        //// 5. 任何其他逻辑...
    }

    /// <summary>
    /// 显示角色详情
    /// </summary>
    void ShowCharacterDetails(BaseCharacterData data)
    {
        ChooseCharacterID = data.ID;
        NameText.text = data.Name;

        BaseHealthText.text = data.BaseHealth.ToString();
        BaseManaText.text = data.BaseEnergy.ToString();

        BaseAttackText.text = data.BaseAttack.ToString();
        BaseDefenseText.text=data.BaseDefense.ToString();
        BaseMagicAttackText.text=data.BaseMagicAttack.ToString();
        BaseMagicDefenseText.text=data.BaseMagicDefense.ToString();
        BaseSpeedText.text=data.BaseSpeed.ToString();

        BaseAccuracyText.text=data.BaseAccuracy.ToString();
        BaseEvasionText.text=data.BaseEvasion.ToString();
        BaseParryText.text=data.BaseParry.ToString();
        BaseAgilityText.text=data.BaseAgility.ToString();
        BaseEffectHitText.text=data.BaseEffectHit.ToString();
        BaseEffectResistanceText.text=data.BaseEffectResistance.ToString();

        Description.text = data.Description.ToString();
    }
    /// <summary>
    /// 添加当前选中的角色的ID进入主队ID列表
    /// </summary>
    public void AddCharacterToMTeamIDs()
    {
        if(ChooseCharacterID != "")
        {
            //if (!BackgroundTeamCharacterIDs.Contains(ChooseCharacterID))
            //{
                if (TeamCharacterIDs.Contains(ChooseCharacterID))
                {
                    TeamCharacterIDs.Remove(ChooseCharacterID);
                }
                else
                {
                    if (TeamCharacterIDs.Count < 13)
                    {
                        TeamCharacterIDs.Add(ChooseCharacterID);
                    }
                }
            //}
                
        }
        RefreshMTeamList();

    }
    /// <summary>
    /// 添加当前选中的角色的ID进入副队ID列表
    /// </summary>
    //public void AddCharacterToSTeamIDs()
    //{
    //    if (ChooseCharacterID != "")
    //    {
    //        if (!TeamCharacterIDs.Contains(ChooseCharacterID))
    //        {
    //            if (BackgroundTeamCharacterIDs.Contains(ChooseCharacterID))
    //            {
    //                BackgroundTeamCharacterIDs.Remove(ChooseCharacterID);
    //            }
    //            else
    //            {
    //                if (BackgroundTeamCharacterIDs.Count < 8)
    //                {
    //                    BackgroundTeamCharacterIDs.Add(ChooseCharacterID);
    //                }
    //            }
    //        }
    //    }
    //    RefreshSTeamList();

    //}

    public void RefreshMTeamList()
    {
        for (int i = MTeamList.childCount - 1; i >= 0; i--)
        {
            // 删除子物体
            Destroy(MTeamList.GetChild(i).gameObject);
        }
        if(TeamCharacterIDs!=null)
        {
            foreach (string id in TeamCharacterIDs)
            {
                TextMeshProUGUI newText = Instantiate(textTeamList, MTeamList);
                newText.name = $"MTeamList_{id}";
                newText.text = DataManager.Instance.singletonCharacterData[id].Name;
            }
        }
    }

    //public void RefreshSTeamList()
    //{
    //    for (int i = STeamList.childCount - 1; i >= 0; i--)
    //    {
    //        // 删除子物体
    //        Destroy(STeamList.GetChild(i).gameObject);
    //    }
    //    if(BackgroundTeamCharacterIDs!=null)
    //    {
    //        foreach (string id in BackgroundTeamCharacterIDs)
    //        {
    //            TextMeshProUGUI newText = Instantiate(textTeamList, STeamList);
    //            newText.name = $"STeamList_{id}";
    //            newText.text = DataManager.Instance.singletonCharacterData[id].Name;
    //        }
    //    }
    //}
}
