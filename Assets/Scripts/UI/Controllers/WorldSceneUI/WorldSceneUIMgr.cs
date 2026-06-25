using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

//世界场景中的UI们的管理器，包括众多子版块的显隐和金币的刷新
public class WorldSceneUIMgr : MonoBehaviour
{
    public Button SettingButton;
    public TextMeshProUGUI CoinNum;
    public TextMeshProUGUI NodeName;
    public TextMeshProUGUI NodeNum;

    public GameObject SettingPanel;

    public Button PocketButton;
    public Button TeamButton;
    public Button CharacterButton;
    public Button AntiqueButton;

    public GameObject PocketUIPanel;
    public GameObject TeamUIPanel;
    public GameObject CharacterUIPanel;
    public GameObject AntiqueUIPanel;


    // Start is called before the first frame update
    void Start()
    {
        SettingButton.onClick.AddListener(() => SettingPanel.SetActive(true));
        PocketButton.onClick.AddListener(() => PocketUIPanel.SetActive(true));
        TeamButton.onClick.AddListener(() => TeamUIPanel.SetActive(true));
        CharacterButton.onClick.AddListener(() => CharacterUIPanel.SetActive(true));
        AntiqueButton.onClick.AddListener(() => AntiqueUIPanel.SetActive(true));
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameDataManager.Instance.stateMachineStatus == StateMachineStatus.Start)
        //{
        //    NodeName.text = GameDataManager.Instance.nodeData.NodeName;
        //    NodeNum.text = GameDataManager.Instance.NodeNum.ToString();
        //}
        if (GameDataManager.Instance.stateMachineStatus == StateMachineStatus.CoinFlash)
        {
            //Debug.Log(GameDataManager.Instance.nodeData.NodeName);
            //Debug.Log(GameDataManager.Instance.NodeNum);
            CoinNum.text = GameDataManager.Instance.CoinNum.ToString();
            NodeName.text = GameDataManager.Instance.nodeData.NodeName;
            NodeNum.text = GameDataManager.Instance.NodeNum.ToString();
            GameDataManager.Instance.stateMachineStatus = StateMachineStatus.In;
        }
    }
}
