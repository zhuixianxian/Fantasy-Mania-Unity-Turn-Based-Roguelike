using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 角色界面中用于显示武器背包的地方
/// </summary>
public class ChrEquiPockPnlMgr : MonoBehaviour
{
    public Button chrEquiPrefabs;//生成在面板中的按钮的预制体
    public Transform btnPos;//生成位置
    private List<Button> btnList = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        ClearPanels();
        var items = GameDataManager.Instance.pocket.worldEquipmentDatas;
        for (int i = 0; i < items.Count; i++)
        {
            Button newPanel = Instantiate(chrEquiPrefabs, btnPos);
            newPanel.GetComponentInChildren<ChrPocketItemBtnMgr>().SetText(i);
            btnList.Add(newPanel);
        }
    }

    private void ClearPanels()
    {
        foreach (var btn in btnList)
            if (btn) Destroy(btn.gameObject);
        btnList.Clear();
    }
}
