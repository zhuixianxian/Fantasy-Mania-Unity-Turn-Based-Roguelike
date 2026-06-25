using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 合成台中武器背包管理器
/// </summary>
public class FormEPocketMgr : MonoBehaviour
{
    public Button itemBtn;//在合成台背包中生成来用于显示物品的基础信息的板块的预制体
    public Transform itemPos;//在背包中生成来用于显示物品的基础信息的板块的位置
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
            Button newPanel = Instantiate(itemBtn, itemPos);
            newPanel.GetComponentInChildren<FormPocketItemBtnMgr>().SetText(items[i].itemType, i);
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
