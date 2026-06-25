using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WScenePocketUIMgr : MonoBehaviour
{
    public Button LeaveButton;
    public Button EPanelDisplayBtn;
    public Button NPanelDisplayBtn;
    public GameObject pocketPanel;//背包面板
    public GameObject EquiItemPanel;
    public GameObject NormItemPanel;

    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(() => {
            pocketPanel.SetActive(false);
        });

        EPanelDisplayBtn.onClick.AddListener(() => {
            EquiItemPanel.SetActive(true);
            NormItemPanel.SetActive(false);

        });
        NPanelDisplayBtn.onClick.AddListener(() => {
            NormItemPanel.SetActive(true);
            EquiItemPanel.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
