using System.Collections;
using System.Collections.Generic;
using FantasyMania.TurnBasedCombat;
using TMPro;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 角色属性显示UI管理器
/// </summary>
public class WSceneChrUIPanelMgr : MonoBehaviour
{
    private static WSceneChrUIPanelMgr instance;
    public static WSceneChrUIPanelMgr Instance
    {
        get
        {
            return instance;
        }
    }


    public string chooseCharacterID;
    /// <summary>
    /// 角色列表中生成按钮时所用到的预制体
    /// </summary>
    public Button chooseCharacterBtn;

    public Button LeaveButton;
    public Button AddPointsButton;
    public Button EquipmentButton;
    public Button RingButton;
    public Button TalentButton;
    public Button SkillButton;

    public GameObject CharacterPanel;
    public GameObject AddPointsContent;
    public GameObject EquipmentContent;
    public GameObject RingContent;
    public GameObject TalentContent;
    public GameObject SkillContent;

    public Transform contentParent;

    #region 属性显示区
    public TextMeshProUGUI NameText;

    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI CurrentExpText;
    public TextMeshProUGUI MaxExpText;

    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;

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

    private void Awake()
    {
        // 确保只有一个实例
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);  // 销毁重复的实例
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameDataManager.Instance != null &&
    GameDataManager.Instance.CharacterTeam != null)
        {
            
            foreach (var data  in GameDataManager.Instance.CharacterTeam)
            {
                //print("GameDataManager");
                // 每循环一次，就复印一个新的按钮
                Button newButton = Instantiate(chooseCharacterBtn, contentParent);
                newButton.name = $"Btn_{data.Value.CharacterID}";
                // 设置不同的文本
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = data.Value.CharacterName;
                BindButtonClickEvent(newButton, data.Value);
            }

            LeaveButton.onClick.AddListener(() => CharacterPanel.SetActive(false));
            AddPointsButton.onClick.AddListener(() => AddPointsContent.SetActive(true));
            EquipmentButton.onClick.AddListener(() => EquipmentContent.SetActive(true));
            RingButton.onClick.AddListener(() => RingContent.SetActive(true));
            TalentButton.onClick.AddListener(() => TalentContent.SetActive(true));
            SkillButton.onClick.AddListener(() => SkillContent.SetActive(true));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BindButtonClickEvent(Button button, WorldCharacterData data)
    {
        // 先移除所有旧的监听器（防止重复绑定）
        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(() =>
        {
            OnCharacterButtonClicked(data);
        });
    }

    void OnCharacterButtonClicked(WorldCharacterData data)
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
    public void ShowCharacterDetails(WorldCharacterData data)
    {
        print(data.CharacterName);
        chooseCharacterID = data.CharacterID;
        NameText.text = data.CharacterName;
        LevelText.text = data.Level.ToString();
        CurrentExpText.text = data.CurrentExperience.ToString();
        MaxExpText.text = data.MaxExperience.ToString();

        HealthText.text = data.MaxHealth.currentValue.ToString();
        ManaText.text = data.MaxEnergy.ToString();

        AttackText.text = data.Attack.currentValue.ToString();
        DefenseText.text = data.Defense.currentValue.ToString();
        MagicAttackText.text = data.MagicAttack.currentValue.ToString();
        MagicDefenseText.text = data.MagicDefense.currentValue.ToString();
        SpeedText.text = data.Speed.currentValue.ToString();

        // 次要属性
        AccuracyText.text = data.Accuracy.currentValue.ToString();
        EvasionText.text = data.Evasion.currentValue.ToString();
        ParryText.text = data.Parry.currentValue.ToString();
        AgilityText.text = data.Agility.currentValue.ToString();
        EffectHitText.text = data.EffectHit.currentValue.ToString();
        EffectResistanceText.text = data.EffectResistance.currentValue.ToString();

    }
}
