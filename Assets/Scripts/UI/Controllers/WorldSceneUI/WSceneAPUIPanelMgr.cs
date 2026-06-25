using System.Collections;
using System.Collections.Generic;
using FantasyMania.TurnBasedCombat;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 加点UI管理器
/// </summary>
public class WSceneAPUIPanelMgr : MonoBehaviour
{
    public Button LeaveButton;
    public GameObject AddPointsPanel;

    #region 属性显示区
    public TextMeshProUGUI NameText;

    public TextMeshProUGUI AttriPoints_1Text;
    public TextMeshProUGUI AttriPoints_2Text;

    public TextMeshProUGUI HealthText;

    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefenseText;
    public TextMeshProUGUI MagicAttackText;
    public TextMeshProUGUI MagicDefenseText;
    public TextMeshProUGUI SpeedText;

    public TextMeshProUGUI AccuracyText;
    public TextMeshProUGUI EvasionText;
    public TextMeshProUGUI ParryText;
    public TextMeshProUGUI AgilityText;
    public TextMeshProUGUI EffectHitText;
    public TextMeshProUGUI EffectResistanceText;


    #endregion


    /// <summary>
    /// 被选择的角色身上的AddPointsComponent组件
    /// </summary>
    private AddPointsComponent chooseChrAPComp;

    //加点UI管理器
    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(() => AddPointsPanel.SetActive(false));
    }

    void OnEnable()
    {
        // 使用安全的链式访问
        var gameDataMgr = GameDataManager.Instance;
        if (gameDataMgr == null)
        {
            Debug.LogError("GameDataManager.Instance 为空");
            return;
        }

        var uiMgr = WSceneChrUIPanelMgr.Instance;
        if (uiMgr == null)
        {
            Debug.LogError("WSceneChrUIPanelMgr.Instance 为空");
            return;
        }

        string characterId = uiMgr.chooseCharacterID;
        if (string.IsNullOrEmpty(characterId))
        {
            Debug.LogError("选择的角色ID为空");
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_PromptPanelDisplay, "选择的角色ID为空");

            return;
        }

        if (gameDataMgr.CharacterTeam == null)
        {
            Debug.LogError("CharacterTeam 为空");
            return;
        }

        if (!gameDataMgr.CharacterTeam.TryGetValue(characterId, out var characterData))
        {
            Debug.LogError($"找不到角色ID: {characterId}");
            return;
        }

        if (characterData.addPointsComponent == null)
        {
            Debug.LogWarning($"角色 {characterId} 的 addPointsComponent 为空");
            // 可以选择创建新的
            characterData.addPointsComponent = new AddPointsComponent(characterData.CharacterID);
        }

        chooseChrAPComp = characterData.addPointsComponent;
        
        //NameText.text = chooseChrAPComp.Owner.CharacterName;
        NameText.text = GameDataManager.Instance.CharacterTeam[chooseChrAPComp.OwnerChrID].CharacterName;
        UIUpdate();
        EventCenter.Instance.Clear(E_EventType.E_AddPointEvent);
        EventCenter.Instance.Clear(E_EventType.E_ReducePointEvent);
        EventCenter.Instance.Clear(E_EventType.E_Add10PointsEvent);
        EventCenter.Instance.Clear(E_EventType.E_Reduce10PointsEvent);
        EventCenter.Instance.Clear(E_EventType.E_ClearPointsEvent);
        EventCenter.Instance.AddEventListener<StatType>(E_EventType.E_AddPointEvent, (statType) =>{ 
            chooseChrAPComp.AddPoints(1, statType);
            UIUpdate();
        });
        EventCenter.Instance.AddEventListener<StatType>(E_EventType.E_ReducePointEvent, (statType) => {
            chooseChrAPComp.ReducePoints(1, statType);
            UIUpdate();
            });
        EventCenter.Instance.AddEventListener<StatType>(E_EventType.E_Add10PointsEvent, (statType) => {
            chooseChrAPComp.AddPoints(10, statType);
            UIUpdate();
            });
        EventCenter.Instance.AddEventListener<StatType>(E_EventType.E_Reduce10PointsEvent, (statType) =>{   
            chooseChrAPComp.ReducePoints(10, statType); 
            UIUpdate();
        });
        EventCenter.Instance.AddEventListener<StatType>(E_EventType.E_ClearPointsEvent, (statType) => {
            chooseChrAPComp.ClearPoints(statType);
            UIUpdate();
            });
    }

    private void OnDisable()
    {
        print("OnDisable");
        if (chooseChrAPComp != null)
        {
            GameDataManager.Instance.CharacterTeam[chooseChrAPComp.OwnerChrID].AllocateModifier();
            WSceneChrUIPanelMgr.Instance.ShowCharacterDetails(GameDataManager.Instance.CharacterTeam[chooseChrAPComp.OwnerChrID]);

        }
    }

    // Update is called once per frame
    void UIUpdate()
    {
        AttriPoints_1Text.text = GameDataManager.Instance.CharacterTeam[chooseChrAPComp.OwnerChrID].AttributePoints_1.ToString();
        AttriPoints_2Text.text = GameDataManager.Instance.CharacterTeam[chooseChrAPComp.OwnerChrID].AttributePoints_2.ToString();

        HealthText.text = chooseChrAPComp.HealthPointsNum.ToString();
        // 主要属性
        AttackText.text = chooseChrAPComp.AttackPointsNum.ToString();
        DefenseText.text = chooseChrAPComp.DefensePointsNum.ToString();
        MagicAttackText.text = chooseChrAPComp.MAttackPointsNum.ToString();
        MagicDefenseText.text = chooseChrAPComp.MDefensePointsNum.ToString();
        SpeedText.text = chooseChrAPComp.SpeedPointsNum.ToString();

        // 次要属性
        AccuracyText.text = chooseChrAPComp.AccuracyPointsNum.ToString();
        EvasionText.text = chooseChrAPComp.EvasionPointsNum.ToString();
        ParryText.text = chooseChrAPComp.ParryPointsNum.ToString();
        AgilityText.text = chooseChrAPComp.AgilityPointsNum.ToString();
        EffectHitText.text = chooseChrAPComp.EffectHitPointsNum.ToString();
        EffectResistanceText.text = chooseChrAPComp.EffectResistancePointsNum.ToString();
    }
}
