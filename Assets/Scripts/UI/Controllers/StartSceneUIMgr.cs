using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class StartSceneUIMgr : MonoBehaviour
{
    public Button StartButton;
    public Button LoadButton;
    public Button QuitGameButton;

    public GameObject promptPanel;
    public Button SettingButton;
    public GameObject SettingPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(() =>
        {
            SceneMgr.Instance.LoadSceneAsyn("TeamFormationScene");
        });
        SettingButton.onClick.AddListener(() =>
        {
            SettingPanel.SetActive(true);
        });

        LoadButton.onClick.AddListener(() =>
        {
            if (DataManager.Instance.SetGameDataMgr("HXJY_GameData"))
            {
                SceneMgr.Instance.LoadSceneAsyn("WorldScene");
            }
            else
            {
                promptPanel.SetActive(true);
            }
        });

        QuitGameButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void QuitGame()
    {
#if UNITY_EDITOR
        // 在Unity编辑器里运行时，这会停止Play Mode[reference:4]
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // 在打包好的游戏里，这会真正退出应用[reference:5]
            Application.Quit();
#endif
    }
}
