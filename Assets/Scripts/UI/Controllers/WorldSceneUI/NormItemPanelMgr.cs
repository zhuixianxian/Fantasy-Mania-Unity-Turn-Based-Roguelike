using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class NormItemPanelMgr : MonoBehaviour
{
    public GameObject itemPanel;//在背包中生成来用于显示物品的基础信息的板块的预制体
    public Transform itemPos;//在背包中生成来用于显示物品的基础信息的板块的位置

    private List<GameObject> panelList = new List<GameObject>();


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

    private void RefreshUI()
    {
        ClearPanels();
        var items = GameDataManager.Instance.pocket.worldNormalItemDatas;
        for (int i = 0; i < items.Count; i++)
        {
            GameObject newPanel = Instantiate(itemPanel, itemPos);
            newPanel.GetComponentInChildren<PocketItemPanelMgr>().SetText(items[i].itemType, i);
            panelList.Add(newPanel);
        }
    }

    private void ClearPanels()
    {
        foreach (var panel in panelList)
            if (panel) Destroy(panel);
        panelList.Clear();
    }
}

