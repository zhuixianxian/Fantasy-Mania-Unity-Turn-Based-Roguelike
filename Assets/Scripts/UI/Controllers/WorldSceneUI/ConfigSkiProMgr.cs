using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class ConfigSkiProMgr : MonoBehaviour
{
    public Button LeaveButton;
    public GameObject ConfigSkiProPanel;//就是自己用于把自己失活的地方
    public TextMeshProUGUI promptText;//显示提示的地方
    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(()=>ConfigSkiProPanel.SetActive(false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string prompt)
    {
        promptText.text = prompt;
    }
}
