using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class ChrPocketItemBtnMgr : MonoBehaviour
{
    // public ItemType itemType;//该显示所代表的数据所存储的物品类型
    public int itemPos;//该显示所代表的数据所存储的物品在列表中的位置

    public TextMeshProUGUI nameText;//名称显示处
    public TextMeshProUGUI numText;//数量显示处

    public Button ChrPocketItemBtn;

    public GameObject DespPanel;//物品描述显示面板
    public TextMeshProUGUI DespText;//物品描述显示区

    // Start is called before the first frame update
    void Start()
    {
        ChrPocketItemBtn.onClick.AddListener(() =>
        {
            EventCenter.Instance.EventTrigger<int>(E_EventType.E_EquipEquipment, itemPos);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(int _itemPos)
    {
        itemPos = _itemPos;

        nameText.text = GameDataManager.Instance.pocket.worldEquipmentDatas[_itemPos].itemName;
        numText.text = GameDataManager.Instance.pocket.worldEquipmentDatas[_itemPos].StackNum.ToString();
        DespText.text = GameDataManager.Instance.pocket.worldEquipmentDatas[_itemPos].GetDescription();

    }

    /// <summary>
    /// 通过悬浮鼠标的方式显示物品资料
    /// </summary>
    public void PocketItemDataDisp(BaseEventData eventData)
    {
        PointerEventData pEventData = eventData as PointerEventData;
        DespPanel.SetActive(true);
    }

    public void PocketItemDataHide(BaseEventData eventData)
    {
        DespPanel.SetActive(false);
    }
}
