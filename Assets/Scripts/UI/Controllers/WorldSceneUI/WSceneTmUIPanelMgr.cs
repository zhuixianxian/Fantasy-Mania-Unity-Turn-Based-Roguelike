using System.Collections;
using System.Collections.Generic;

using FantasyMania.TurnBasedCombat;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WSceneTmUIPanelMgr : MonoBehaviour
{
    /// <summary>
    /// 角色列表中生成按钮时所用到的预制体
    /// </summary>
    public Button chooseCharacterBtn;
    /// <summary>
    /// 被选中的角色的ID
    /// </summary>
    public string chooseCharacterID;
    /// <summary>
    /// 角色列表位置
    /// </summary>
    public Transform contentParent;
    public Button LeaveButton;
    public GameObject TeamPanel;

    public Button pos1Button;
    public Button pos2Button;
    public Button pos3Button;
    public Button pos4Button;
    public Button pos5Button;
    public Button pos6Button;
    public Button pos7Button;
    public Button pos8Button;
    public Button pos9Button;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("WSceneTmUIPanelMgrStart");
        if (GameDataManager.Instance != null &&
    GameDataManager.Instance.CharacterTeam != null)
        {

            foreach (var data in GameDataManager.Instance.CharacterTeam)
            {
                //print("GameDataManager");
                // 每循环一次，就复印一个新的按钮
                Button newButton = Instantiate(chooseCharacterBtn, contentParent);
                newButton.name = $"Btn_{data.Value.CharacterID}";
                // 设置不同的文本
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = data.Value.CharacterName;
                BindButtonClickEvent(newButton, data.Value);
            }
        }
        LeaveButton.onClick.AddListener(() => {
            TeamPanel.SetActive(false);
            foreach(var i in GameDataManager.Instance.BattleCharacterTeam)
            {
                print(i.ToString());
            }
            });

        if (GameDataManager.Instance != null &&
GameDataManager.Instance.BattleCharacterTeam != null)
        {
            foreach (var i in GameDataManager.Instance.BattleCharacterTeam)
            {
                switch (i.Key)
                {
                    case TeamPosition.pos1:
                        pos1Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    case TeamPosition.pos2:
                        pos2Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    case TeamPosition.pos3:
                        pos3Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    case TeamPosition.pos4:
                        pos4Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    case TeamPosition.pos5:
                        pos5Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    case TeamPosition.pos6:
                        pos6Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    case TeamPosition.pos7:
                        pos7Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    case TeamPosition.pos8:
                        pos8Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    case TeamPosition.pos9:
                        pos9Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[i.Value].CharacterName;
                        break;
                    default:
                        break;
                }
            }
        }

        pos1Button.onClick.AddListener(() =>
        {
            if (pos1Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID) && chooseCharacterID != "")
                {
                    AddChrToTeam(TeamPosition.pos1, chooseCharacterID);
                    pos1Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos1);
                pos1Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });
        // 为按钮2添加监听
        pos2Button.onClick.AddListener(() =>
        {
            if (pos2Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID) && chooseCharacterID != "")
                {
                    AddChrToTeam(TeamPosition.pos2, chooseCharacterID);
                    pos2Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos2);
                pos2Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });

        // 为按钮3添加监听
        pos3Button.onClick.AddListener(() =>
        {
            if (pos3Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID) && chooseCharacterID != "")
                {
                    AddChrToTeam(TeamPosition.pos3, chooseCharacterID);
                    pos3Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos3);
                pos3Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });

        // 为按钮4添加监听
        pos4Button.onClick.AddListener(() =>
        {
            if (pos4Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID) && chooseCharacterID != "")
                {
                    AddChrToTeam(TeamPosition.pos4, chooseCharacterID);
                    pos4Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos4);
                pos4Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });

        // 为按钮5添加监听
        pos5Button.onClick.AddListener(() =>
        {
            if (pos5Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID) && chooseCharacterID != "")
                {
                    AddChrToTeam(TeamPosition.pos5, chooseCharacterID);
                    pos5Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos5);
                pos5Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });

        // 为按钮6添加监听
        pos6Button.onClick.AddListener(() =>
        {
            if (pos6Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID) && chooseCharacterID != "")
                {
                    AddChrToTeam(TeamPosition.pos6, chooseCharacterID);
                    pos6Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos6);
                pos6Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });

        // 为按钮7添加监听
        pos7Button.onClick.AddListener(() =>
        {
            if (pos7Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID) && chooseCharacterID != "")
                {
                    AddChrToTeam(TeamPosition.pos7, chooseCharacterID);
                    pos7Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos7);
                pos7Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });

        // 为按钮8添加监听
        pos8Button.onClick.AddListener(() =>
        {
            if (pos8Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID)&&chooseCharacterID != "")
                {
                    AddChrToTeam(TeamPosition.pos8, chooseCharacterID);
                    pos8Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos8);
                pos8Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });

        // 为按钮9添加监听
        pos9Button.onClick.AddListener(() =>
        {
            if (pos9Button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                if (!GameDataManager.Instance.BattleCharacterTeam.ContainsValue(chooseCharacterID)&& chooseCharacterID!="")
                {
                    AddChrToTeam(TeamPosition.pos9, chooseCharacterID);
                    pos9Button.GetComponentInChildren<TextMeshProUGUI>().text = GameDataManager.Instance.CharacterTeam[chooseCharacterID].CharacterName;
                }
            }
            else
            {
                RemoveChrInTeam(TeamPosition.pos9);
                pos9Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        });
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
        chooseCharacterID = data.CharacterID;
    }
    void AddChrToTeam(TeamPosition teamPosition, string id)
    {
        //if (id != null)
        //{
        //    GameDataManager.Instance.AddCharacterToBattleTeam(teamPosition, id);
        //}
        //else
        //{
        //    //待提示
        //    Debug.Log("未选中要添加对象");
        //}

        if (string.IsNullOrEmpty(id))
        {
            Debug.LogWarning("未选中任何角色，无法添加到队伍");
            // 可选：显示提示面板
            return;
        }
        if (!GameDataManager.Instance.CharacterTeam.ContainsKey(id))
        {
            Debug.LogError($"角色ID {id} 不存在于角色字典中");
            return;
        }
        GameDataManager.Instance.AddCharacterToBattleTeam(teamPosition, id);
    }
    void RemoveChrInTeam(TeamPosition teamPosition)
    {
        GameDataManager.Instance.RemoveCharacterToBattleTeam(teamPosition);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
