using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using TMPro;

//using UnityEditor.U2D.Animation;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WSceneEquUIMgr : MonoBehaviour
{
    //装备界面的管理器
    public Button LeaveButton;
    public GameObject TeamPanel;


    public GameObject EquiPocketPanel;//装备武器的地方的装备背包


    public TextMeshProUGUI HelmetText;
    public TextMeshProUGUI ChestplateText;
    public TextMeshProUGUI WeaponText;
    public TextMeshProUGUI LeggingsText;
    public TextMeshProUGUI BracersText;
    public TextMeshProUGUI BootsText;

    private WorldCharacterData currentCharacterData;   // 保存当前查看的角色数据

    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(() => {
            TeamPanel.SetActive(false);
        });
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
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

        currentCharacterData = characterData;
        RefreshEquipmentName();
        EventCenter.Instance.Clear(E_EventType.E_UnEquipEquipment);
        EventCenter.Instance.AddEventListener<EquipmentType>(E_EventType.E_UnEquipEquipment ,(equipmentType) =>
        {
            currentCharacterData.equipmentComponent.UnEquipEquipment(equipmentType);

            RefreshEquipmentName();

            EquiPocketPanel.GetComponentInChildren<ChrEquiPockPnlMgr>().RefreshUI();
        });
        EventCenter.Instance.Clear(E_EventType.E_EquipEquipment);
        EventCenter.Instance.AddEventListener<int>(E_EventType.E_EquipEquipment, (equipmentPos) =>
        {
            currentCharacterData.equipmentComponent.EquipEquipment(GameDataManager.Instance.pocket.worldEquipmentDatas[equipmentPos]);

            RefreshEquipmentName();
            EquiPocketPanel.GetComponentInChildren<ChrEquiPockPnlMgr>().RefreshUI();

        });

    }

    private void OnDisable()
    {
        if (currentCharacterData != null)
        {
            currentCharacterData.AllocateModifier();
            WSceneChrUIPanelMgr.Instance.ShowCharacterDetails(currentCharacterData);

        }
    }

    private void RefreshEquipmentName()
    {
        if (currentCharacterData == null || currentCharacterData.equipmentComponent == null)
        {
            // 如果角色数据或装备组件不存在，将所有文本设为默认值
            HelmetText.text = ChestplateText.text = WeaponText.text =
            LeggingsText.text = BracersText.text = BootsText.text = "未装备";
            return;
        }

        var comp = currentCharacterData.equipmentComponent;
        HelmetText.text = comp.Helmet?.itemName ?? "";
        ChestplateText.text = comp.Chestplate?.itemName ?? "";
        WeaponText.text = comp.Weapon?.itemName ?? "";
        LeggingsText.text = comp.Leggings?.itemName ?? "";
        BracersText.text = comp.Bracers?.itemName ?? "";
        BootsText.text = comp.Boots?.itemName ?? "";
    }

}
