using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 技能升级UI管理器
/// </summary>
public class WSceneSkillUIPanelMgr : MonoBehaviour
{
    public Button LeaveButton;
    public GameObject SkillPanel;
    public GameObject SkillLevelUpPanel;//技能升级面板的预制体
    public Transform SLUPPos;//技能升级面板预制体的生成位置

    public TextMeshProUGUI chrName;//被选中的角色的名字
    public TextMeshProUGUI SkillDescription;//被选中的技能点描述
    public TextMeshProUGUI SkillCoin;//被选中的技能升级花费的金币数量
    public TextMeshProUGUI SkillLevel;//用于在技能升级界面显示技能的等级

    public TextMeshProUGUI CoinNum;//用于在技能升级界面显示的金币的总数

    public GameObject configSkillPrompt;//在移出技能和技能列表满时提示的地方

    //private ushort skillNum;//技能数量

    //技能升级UI管理器
    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(() =>
        {
            SkillPanel.SetActive(false);
            GameDataManager.Instance.stateMachineStatus = StateMachineStatus.CoinFlash;
        });
    }

    void OnEnable()
    {
        CoinNum.text = GameDataManager.Instance.CoinNum.ToString();

        //skillNum = 0;
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

        chrName.text = characterData.CharacterName;

        foreach (var i in characterData.skillComponent.Skill)
        {
            
            GameObject newLevelUpPanel = Instantiate(SkillLevelUpPanel, SLUPPos);
            SkillLevelUpUI skillUI = newLevelUpPanel.GetComponentInChildren<SkillLevelUpUI>();
            skillUI.chrCarrySkillID = i.Key;
            skillUI.SetSkillNameText(i.Value.SkillName,i.Value.skillType);
        }
        EventCenter.Instance.Clear(E_EventType.E_SkillDescription);
        EventCenter.Instance.Clear(E_EventType.E_SkillLevelUp);
        EventCenter.Instance.Clear(E_EventType.E_SkillConfiguration);
        EventCenter.Instance.AddEventListener<string>(E_EventType.E_SkillDescription, (carrySkillID) =>
        {
            SkillDescription.text = characterData.skillComponent.Skill[carrySkillID].SkillDescription;
            SkillCoin.text = characterData.skillComponent.Skill[carrySkillID].LevelUpCoin.ToString();
            SkillLevel.text = characterData.skillComponent.Skill[carrySkillID].skillLevel.ToString();
        });
        EventCenter.Instance.AddEventListener<string>(E_EventType.E_SkillLevelUp, (carrySkillID) =>
        {
            characterData.skillComponent.Skill[carrySkillID].AddSkillLevel();
            SkillCoin.text = characterData.skillComponent.Skill[carrySkillID].LevelUpCoin.ToString();
            CoinNum.text = GameDataManager.Instance.CoinNum.ToString();
            SkillLevel.text = characterData.skillComponent.Skill[carrySkillID].skillLevel.ToString();
        });
        
        EventCenter.Instance.AddEventListener<string>(E_EventType.E_SkillConfiguration, (carrySkillID) =>
        {
            ConfigSkillType configType= characterData.skillComponent.SkillConfig(characterData.skillComponent.Skill[carrySkillID]);
            switch (configType)
            {
                case ConfigSkillType.Full:
                    configSkillPrompt.SetActive(true);
                    configSkillPrompt.GetComponentInChildren<ConfigSkiProMgr>().SetText("此种技能已满");
                    break;
                case ConfigSkillType.Remove:
                    configSkillPrompt.SetActive(true);
                    configSkillPrompt.GetComponentInChildren<ConfigSkiProMgr>().SetText("去除该技能成功");
                    break;
                default:
                    break;
            }
        });
    }

    private void OnDisable()
    {
        foreach (Transform child in SLUPPos)
        {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void UIUpdate()
    {

    }
}
