using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WSceneAntiqueUIMgr : MonoBehaviour
{
    public Button LeaveButton;
    public GameObject TeamPanel;

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
}
