using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class CampStatUIMgr : MonoBehaviour
{
    public Button LeaveButton;//离开按钮
    public GameObject CampStatPanel;//脚本的挂载处

    public Button ChrButtonPrefab;//按下后显示各自属性的按钮的预制体

    public Transform ChrBtnPos;//角色的按钮生成的位置

    public Transform EnemyBtnPos;//敌人的按钮生成的位置

    public GameObject BuffTextPrefabs;//Buff的文本预制体

    public Transform BuffTextPos;//Buff的文本生成的地方

    #region 属性显示区
    public TextMeshProUGUI NameText;

    public TextMeshProUGUI LevelText;

    public TextMeshProUGUI HealthText;

    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefenseText;
    public TextMeshProUGUI MagicAttackText;
    public TextMeshProUGUI MagicDefenseText;
    public TextMeshProUGUI SpeedText;

    public TextMeshProUGUI AccuracyText;
    public TextMeshProUGUI EvasionText;
    public TextMeshProUGUI ParryText;
    public TextMeshProUGUI AgilityText;
    public TextMeshProUGUI EffectHitText;
    public TextMeshProUGUI EffectResistanceText;

    public TextMeshProUGUI DamageReductionText;
    public TextMeshProUGUI LifeStealText;
    public TextMeshProUGUI ReflectedDamageText;
    public TextMeshProUGUI ReflectionRateText;
    public TextMeshProUGUI HPRecoveryperTurnText;
    public TextMeshProUGUI HPRecoveryperAttackText;
    public TextMeshProUGUI CriticalRateText;
    public TextMeshProUGUI CriticalDamageText;
    public TextMeshProUGUI DamageReflectionRatioText;
    public TextMeshProUGUI CriticalResistanceText;
    public TextMeshProUGUI EffectHitRateText;
    public TextMeshProUGUI EffectResistanceRateText;
    public TextMeshProUGUI PenetrationText;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.onClick.AddListener(() =>
        {
            CampStatPanel.SetActive(false);
        });
        GenerateChrBtn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateChrBtn ()
    {
        foreach(var i in BattleSceneChrDataMgr.Instance.ChrTeam)
        {
            Button newButton = Instantiate(ChrButtonPrefab, ChrBtnPos);
            newButton.GetComponentInChildren<CampStatChrUIBtnMgr>().BtnChr = i.Key;
            newButton.GetComponentInChildren<CampStatChrUIBtnMgr>().SetText(i.Value.CharacterName);
        }

        foreach (var i in BattleSceneEnemyDataMgr.Instance.EnemyTeam)
        {
            Button newButton = Instantiate(ChrButtonPrefab, EnemyBtnPos);
            newButton.GetComponentInChildren<CampStatChrUIBtnMgr>().BtnChr = i.Key;
            newButton.GetComponentInChildren<CampStatChrUIBtnMgr>().SetText(i.Value.CharacterName);
        }
    }

    private void OnEnable()
    {

        EventCenter.Instance.AddEventListener<BattleSceneKeyBag>(E_EventType.E_RefreshBSStatView, RefreshAllText);

    }

    private void OnDisable()
    {
        EventCenter.Instance.Clear(E_EventType.E_RefreshBSStatView);
    }
    /// <summary>
    /// 用来刷新所有属性和刷新展示Buff文案的地方
    /// </summary>
    void RefreshAllText(BattleSceneKeyBag keyBag)
    {
        RefreshStatText(keyBag);
        RefreshBuffText(keyBag);
    }

    void RefreshStatText(BattleSceneKeyBag keyBag)
    {
        BSBaseData tempBSBaseData = new BSBaseData();
        if (keyBag.battleScenePosition <= BattleScenePosition.Cpos9)
        {
            if (BattleSceneChrDataMgr.Instance.ChrTeam.ContainsKey(keyBag))
            {
                tempBSBaseData = BattleSceneChrDataMgr.Instance.ChrTeam[keyBag];
            }
        }
        else
        {
            if (BattleSceneEnemyDataMgr.Instance.EnemyTeam.ContainsKey(keyBag))
            {
                tempBSBaseData = BattleSceneEnemyDataMgr.Instance.EnemyTeam[keyBag];
            }
        }

        NameText.text = tempBSBaseData.CharacterName.ToString();

        LevelText.text = tempBSBaseData.Level.ToString();

        HealthText.text = tempBSBaseData.health.ToString();

        AttackText.text = tempBSBaseData.Attack.currentValue.ToString();
        DefenseText.text = tempBSBaseData.Defense.currentValue.ToString();
        MagicAttackText.text = tempBSBaseData.MagicAttack.currentValue.ToString();
        MagicDefenseText.text = tempBSBaseData.MagicDefense.currentValue.ToString();
        SpeedText.text = tempBSBaseData.Speed.currentValue.ToString();

        AccuracyText.text = tempBSBaseData.Accuracy.currentValue.ToString();
        EvasionText.text = tempBSBaseData.Evasion.currentValue.ToString();
        ParryText.text = tempBSBaseData.Parry.currentValue.ToString();
        AgilityText.text = tempBSBaseData.Agility.currentValue.ToString();
        EffectHitText.text = tempBSBaseData.EffectHit.currentValue.ToString();
        EffectResistanceText.text = tempBSBaseData.EffectResistance.currentValue.ToString();

        DamageReductionText.text = tempBSBaseData.DamageReduction.currentValue.ToString();
        LifeStealText.text = tempBSBaseData.LifeSteal.currentValue.ToString();
        ReflectedDamageText.text = tempBSBaseData.ReflectedDamage.currentValue.ToString();
        ReflectionRateText.text = tempBSBaseData.ReflectionRate.currentValue.ToString();
        HPRecoveryperTurnText.text = tempBSBaseData.HPRecoveryperTurn.currentValue.ToString();
        HPRecoveryperAttackText.text = tempBSBaseData.HPRecoveryperAttack.currentValue.ToString();
        CriticalRateText.text = tempBSBaseData.CriticalRate.currentValue.ToString();
        CriticalDamageText.text = tempBSBaseData.CriticalDamage.currentValue.ToString();
        DamageReflectionRatioText.text = tempBSBaseData.DamageReflectionRatio.currentValue.ToString();
        CriticalResistanceText.text = tempBSBaseData.CriticalResistance.currentValue.ToString();
        EffectHitRateText.text = tempBSBaseData.EffectHitRate.currentValue.ToString();
        EffectResistanceRateText.text = tempBSBaseData.EffectResistanceRate.currentValue.ToString();
        PenetrationText.text = tempBSBaseData.Penetration.currentValue.ToString();
    }

    void RefreshBuffText(BattleSceneKeyBag keyBag)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in BuffTextPos)
        {
            children.Add(child.gameObject);
        }
        foreach (GameObject child in children)
        {
            Destroy(child);
        }
        
        BSBaseData tempBSBaseData = new BSBaseData();
        if (keyBag.battleScenePosition <= BattleScenePosition.Cpos9)
        {
            if (BattleSceneChrDataMgr.Instance.ChrTeam.ContainsKey(keyBag))
            {
                tempBSBaseData = BattleSceneChrDataMgr.Instance.ChrTeam[keyBag];
            }
        }
        else
        {
            if (BattleSceneEnemyDataMgr.Instance.EnemyTeam.ContainsKey(keyBag))
            {
                tempBSBaseData = BattleSceneEnemyDataMgr.Instance.EnemyTeam[keyBag];
            }
        }

        foreach(var i in tempBSBaseData.buffComponent.GetAllBuffDesc())
        {
            GameObject newTextCont = Instantiate(BuffTextPrefabs, BuffTextPos);
            // 设置不同的文本
            newTextCont.GetComponentInChildren<BuffTextContentMgr>().SetText(i.BuffDescription,i.BuffName,i.BuffDuration);

        }
    }
}
