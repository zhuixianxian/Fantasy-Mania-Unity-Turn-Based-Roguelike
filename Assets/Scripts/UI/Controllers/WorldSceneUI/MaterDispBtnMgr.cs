using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class MaterDispBtnMgr : MonoBehaviour
{
    public ItemType itemType;//该显示所代表的数据所存储的物品类型
    public int itemNum;//该显示所代表的数据所存储的物品的堆叠数
    public string MaterItemID;//被放入到合成台中的物品的ID

    public TextMeshProUGUI nameText;//名称显示处
    public TextMeshProUGUI numText;//数量显示处

    public Button MaterDispBtn;

    // Start is called before the first frame update
    void Start()
    {
        MaterDispBtn.onClick.AddListener(() =>
        {
            EventCenter.Instance.EventTrigger<string>(E_EventType.E_RemoveMaterToForm, MaterItemID);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetItemID(string _MaterItemID, string _MaterItemName, int _itemNum)
    {
        MaterItemID = _MaterItemID;
        nameText.text = _MaterItemName;
        numText.text = _itemNum.ToString();
    }
}
