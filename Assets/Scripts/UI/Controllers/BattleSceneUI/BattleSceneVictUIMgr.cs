using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BattleSceneVictUIMgr : MonoBehaviour
{
    public TextMeshProUGUI getItemText;//显示本次战斗所得的地方
    public Button leaveButton;
    // Start is called before the first frame update
    void Start()
    {
        leaveButton.onClick.AddListener(() =>
        {
            BattleManager.Instance.battleState = BattleState.VictorySwitch;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(List<string> ItemStr)
    {
        getItemText.text = string.Join(" ", ItemStr);
    }
}
