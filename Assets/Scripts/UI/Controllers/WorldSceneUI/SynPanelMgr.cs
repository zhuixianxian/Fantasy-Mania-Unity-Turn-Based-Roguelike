using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

/// <summary>
/// 合成面板管理器
/// </summary>
public class SynPanelMgr : MonoBehaviour
{
    public Button LeaveButton;//离开按钮
    public GameObject SynthesisPanel;//合成面板

    public Button synButton;//合成按钮，用于触发合成事件

    public Transform synFormulaDisplayPanel;//本合成台拥有的合成配方公示处
    public Button synFormDispBtnPref;//点击后显示具体合成配方这一事件的触发按钮
    private List<Button> FormBtnList = new List<Button>();//显示出的合成台具有的配方的按钮的列表


    public Transform formMaterDispPnl;//合成配方的具体材料的显示处
    public GameObject formMaterPnl;//用来显示配方具体材料的显示块

    public Transform MaterDispPnl;//合成配方的被玩家放置的材料的显示处
    public Button formMaterBtn;//用来显示被玩家放置的材料的按钮预制体

    public Button EPanelDisplayBtn;//合成台中展示背包时，显示武器背包的按钮
    public Button NPanelDisplayBtn;//合成台中展示背包时，显示普通背包的按钮

    public GameObject EquiItemPanel;//合成台中展示背包时，显示武器背包的面板
    public GameObject NormItemPanel;//合成台中展示背包时，显示普通背包的面板

    private string GoalItemID;//被合成的物品的ID的存储
    private Dictionary<string, int> materialNumTable = new Dictionary<string, int>();//用于存储材料和数量的对应字典

    private Dictionary<string, WorldBaseItemData> tempMaterNumTable = new Dictionary<string, WorldBaseItemData>();//用于存储现在已经放入的材料和数量的对应字典,使用引用，符合即减
    private Dictionary<string, Button> tempMaterNumTableBtn = new Dictionary<string, Button>();//用于存储现在已经放入的材料和按钮的对应字典,使用引用，去除方便


    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(() =>
        {
            SynthesisPanel.SetActive(false);
        });
        EPanelDisplayBtn.onClick.AddListener(() =>
        {
            EquiItemPanel.SetActive(true);
            NormItemPanel.SetActive(false);

        });
        NPanelDisplayBtn.onClick.AddListener(() =>
        {
            NormItemPanel.SetActive(true);
            EquiItemPanel.SetActive(false);
        });

        EventCenter.Instance.Clear(E_EventType.E_DisplayFormula);
        EventCenter.Instance.Clear(E_EventType.E_AddMaterToForm);
        EventCenter.Instance.Clear(E_EventType.E_RemoveMaterToForm);

        EventCenter.Instance.AddEventListener<string>(E_EventType.E_DisplayFormula, (GoalItemFormID) =>
        {
            SetTempFormulaData(GoalItemFormID);
        });

        EventCenter.Instance.AddEventListener<AddItemToDicBag>(E_EventType.E_AddMaterToForm, (itemBag) =>
        {
            AddMaterToDic(itemBag);
        });

        EventCenter.Instance.AddEventListener<string>(E_EventType.E_RemoveMaterToForm, (MaterItemID) =>
        {
            RemoveMaterItemFormDic(MaterItemID);
        });

        synButton.onClick.AddListener(() =>
        {
            SynthesisGoal();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        ClearTempFormulaData();
        ClearSynFormPanels();
    }
    private void OnDisable()
    {
        ClearSynFormPanels();
    }

    /// <summary>
    /// 显示该合成台的配方
    /// </summary>
    /// <param name="FormulaPos">该合成台所显示的配方被存储的位置</param>
    public void DisplaySynForm(ushort FormulaPos)
    {
        //ClearSynFormPanels();
        List<string> tempFormulaIDList = GameDataManager.Instance.nodeData.worldSynthesisDatas[FormulaPos].canSynthesisItem;
        foreach (var i in tempFormulaIDList)
        {
            Button newButton = Instantiate(synFormDispBtnPref, synFormulaDisplayPanel);
            newButton.GetComponentInChildren<synFormDispPnlBtnMgr>().SetID(i, DataManager.Instance.singletonItemFormData[i].FormulaName);
            FormBtnList.Add(newButton);
        }
    }

    /// <summary>
    /// 设置临时的配方数据用于显示在面板中
    /// </summary>
    void SetTempFormulaData(string GoalItemFormID)
    {
        BasesSnthesisItemData tempFormData = DataManager.Instance.singletonItemFormData[GoalItemFormID];
        GoalItemID = tempFormData.FormulaGoal;
        materialNumTable = tempFormData.materialNumTable;
        //待确实显示，待修改
        ClearTempFormulaData();

        foreach (var i in tempFormData.materialNumTable)
        {
            GameObject newMaterPnl = Instantiate(formMaterPnl, formMaterDispPnl);
            newMaterPnl.GetComponentInChildren<formMaterItemPnlMgr>().SetText(DataManager.Instance.singletonItemData[i.Key].itemName, i.Value);
        }
    }

    void ClearTempFormulaData()
    {
        // 确保父物体有效
        if (formMaterDispPnl == null || !formMaterDispPnl.gameObject)
            return;

        // 倒序遍历并销毁
        for (int i = formMaterDispPnl.childCount - 1; i >= 0; i--)
        {
            Transform child = formMaterDispPnl.GetChild(i);
            // Unity 对已销毁对象的判空会返回 true（假空），所以需要用 gameObject 判断
            if (child != null && child.gameObject != null)
            {
                Destroy(child.gameObject);
            }
        }
    }

    /// <summary>
    /// 清除配方显示区的按钮生成
    /// </summary>
    private void ClearSynFormPanels()
    {
        for (int i = synFormulaDisplayPanel.childCount - 1; i >= 0; i--)
        {
            Transform child = synFormulaDisplayPanel.GetChild(i);
            if (child != null && child.gameObject != null)
                Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// 将被点击的物品放入两个字典
    /// </summary>
    public void AddMaterToDic(AddItemToDicBag itemBag)
    {
        if (!tempMaterNumTable.ContainsKey(GameDataManager.Instance.pocket.worldNormalItemDatas[itemBag.itemPos].id))
        {
            WorldBaseItemData tempItemData = new WorldBaseItemData();
            switch (itemBag.itemType)
            {
                case ItemType.Normal:
                    tempItemData = GameDataManager.Instance.pocket.worldNormalItemDatas[itemBag.itemPos];
                    tempMaterNumTable.Add(
                        tempItemData.id,
                        tempItemData
                        );

                    tempMaterNumTableBtn.Add(
                        tempItemData.id,
                        Instantiate(formMaterBtn, MaterDispPnl)
                        );
                    tempMaterNumTableBtn[tempItemData.id].GetComponentInChildren<MaterDispBtnMgr>()
                        .SetItemID(tempItemData.id, tempItemData.itemName, tempItemData.StackNum);
                    break;
                case ItemType.Equipment:
                    tempItemData = GameDataManager.Instance.pocket.worldEquipmentDatas[itemBag.itemPos];
                    tempMaterNumTable.Add(
                        tempItemData.id,
                        tempItemData
                        );

                    tempMaterNumTableBtn.Add(
                        tempItemData.id,
                        Instantiate(formMaterBtn, MaterDispPnl)
                        );
                    tempMaterNumTableBtn[tempItemData.id].GetComponentInChildren<MaterDispBtnMgr>()
                        .SetItemID(tempItemData.id, tempItemData.itemName, tempItemData.StackNum);
                    break;
            }

        }
    }

    /// <summary>
    /// 从已放入工作台中的字典中删除材料
    /// </summary>
    /// <param name="MaterItemID">材料ID</param>
    public void RemoveMaterItemFormDic(string MaterItemID)
    {
        tempMaterNumTable.Remove(MaterItemID);
        Destroy(tempMaterNumTableBtn[MaterItemID].gameObject);
        tempMaterNumTableBtn.Remove(MaterItemID);
    }

    /// <summary>
    /// 将材料合成成目标
    /// </summary>
    public void SynthesisGoal()
    {
        //判断能否合成
        if (canSyn())
        {
            foreach (var i in materialNumTable)
            {
                tempMaterNumTable[i.Key].ReduceStackNums(i.Value);
            }

            GameDataManager.Instance.pocket.AddItem(GoalItemID);
            GameDataManager.Instance.pocket.RemoveStack0();//删除背包中堆叠数为0的物品们

            //待修改
            EquiItemPanel.GetComponentInChildren<FormEPocketMgr>().RefreshUI();
            NormItemPanel.GetComponentInChildren<FormNPocketMgr>().RefreshUI();//刷新背包的UI

            tempMaterNumTable.Clear();//清空数据

            foreach(var i in tempMaterNumTableBtn)
            {
                Destroy(i.Value.gameObject);
            }

            tempMaterNumTableBtn.Clear();//清空按钮
        }

    }
    /// <summary>
    /// 判断能否合成
    /// </summary>
    /// <returns></returns>
    private bool canSyn()
    {
        if (materialNumTable.Count == 0) return false;
        if (tempMaterNumTable.Count == 0) return false;
        if (GoalItemID==null) return false;

        foreach (var i in materialNumTable)
        {
            if (!tempMaterNumTable.ContainsKey(i.Key))
            {
                return false;
            }
            else if (tempMaterNumTable[i.Key].StackNum < i.Value)
            {
                return false;
            }
        }
        return true;
    }
}
