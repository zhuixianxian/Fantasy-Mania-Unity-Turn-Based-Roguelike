using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class WSPromptPanelMgr : MonoBehaviour
{
    public Button LeaveButton;
    public GameObject promptPanel;

    public TextMeshProUGUI promptText;
    // Start is called before the first frame update

    private void Awake()
    {
        //promptPanel.SetActive(false);
        EventCenter.Instance.Clear(E_EventType.E_PromptPanelDisplay);
        EventCenter.Instance.AddEventListener<string>(E_EventType.E_PromptPanelDisplay, SetText);
    }
    void Start()
    {
        LeaveButton.onClick.AddListener(() =>
        {
            promptPanel.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string _promptText)
    {
        promptPanel.SetActive(true);
        promptText.text = _promptText;
    }
}
