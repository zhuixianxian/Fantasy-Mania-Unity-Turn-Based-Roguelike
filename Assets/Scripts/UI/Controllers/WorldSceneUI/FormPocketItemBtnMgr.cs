using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 合成台中显示物品的地方，按钮的管理器
/// </summary>
public class FormPocketItemBtnMgr : MonoBehaviour
{
    public ItemType itemType;//该显示所代表的数据所存储的物品类型
    public int itemPos;//该显示所代表的数据所存储的物品在列表中的位置

    public TextMeshProUGUI nameText;//名称显示处
    public TextMeshProUGUI numText;//数量显示处

    public Button FormPocketItemBtn;

    public GameObject DespPanel;//物品描述显示面板
    public TextMeshProUGUI DespText;//物品描述显示区

    // Start is called before the first frame update
    void Start()
    {
        FormPocketItemBtn.onClick.AddListener(() =>
        {
            EventCenter.Instance.EventTrigger<AddItemToDicBag>(E_EventType.E_AddMaterToForm, new AddItemToDicBag(itemPos, itemType));
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(ItemType _itemType, int _itemPos)
    {
        itemType = _itemType;
        itemPos = _itemPos;

        switch (_itemType)
        {
            case ItemType.Normal:
                nameText.text = GameDataManager.Instance.pocket.worldNormalItemDatas[_itemPos].itemName;
                numText.text = GameDataManager.Instance.pocket.worldNormalItemDatas[_itemPos].StackNum.ToString();
                DespText.text = GameDataManager.Instance.pocket.worldNormalItemDatas[_itemPos].GetDescription();

                break;
            case ItemType.Equipment:
                nameText.text = GameDataManager.Instance.pocket.worldEquipmentDatas[_itemPos].itemName;
                numText.text = GameDataManager.Instance.pocket.worldEquipmentDatas[_itemPos].StackNum.ToString();
                DespText.text = GameDataManager.Instance.pocket.worldEquipmentDatas[_itemPos].GetDescription();
                break;
            default:
                break;
        }


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
