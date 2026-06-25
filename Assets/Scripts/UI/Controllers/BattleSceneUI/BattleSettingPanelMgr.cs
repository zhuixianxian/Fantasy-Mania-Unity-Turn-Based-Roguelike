using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BattleSettingPanelMgr : MonoBehaviour
{
    public Button LeaveButton;
    public Button LeaveWorldButton;
    public GameObject SettingPanel;

    [Tooltip("音量滑动条")]
    public Scrollbar bgmVolumeScrollbar;
    [Tooltip("静音单选框")]
    public Toggle bgmMuteToggle;



    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(() => SettingPanel.SetActive(false));

        bgmVolumeScrollbar.onValueChanged.AddListener((value) =>
        {
            BackMusicMgr.Instance.ChangeBKMusicValue(value);
        });

        bgmMuteToggle.onValueChanged.AddListener((value) =>
        {
            BackMusicMgr.Instance.ChangeBKMusicValue2(value);
        });

        LeaveWorldButton.onClick.AddListener(() =>
        {
            SceneMgr.Instance.LoadScene("StartScene");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        bgmVolumeScrollbar.value = BackMusicMgr.Instance.bkMusicValue;
        bgmMuteToggle.isOn = BackMusicMgr.Instance.bkMusicValue2;
    }

    
}
