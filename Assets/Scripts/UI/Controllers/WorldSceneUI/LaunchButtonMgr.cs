using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using TMPro;

//using Unity.Android.Types;

using UnityEngine;
using UnityEngine.UI;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class LaunchButtonMgr : MonoBehaviour
{
    public Button LaunchButton;//该脚本挂载在哪个按钮上
    public TextMeshProUGUI LaunchName;//被弹射到的组件的显示区
    public TextMeshProUGUI LaunchTypeText;//被弹射到的组件的类型的显示区

    public LaunchType launchType;//该脚本会用来弹射什么

    public ushort LaunchNum;//该脚本会用来弹射数据列表中的哪个
    // Start is called before the first frame update
    void Start()
    {
        LaunchButton.onClick.AddListener(() =>
        {
            switch (launchType)
            {
                case LaunchType.Enemy:
                    BattleLauncher.Instance.LaunchToBattle(LaunchNum);
                    break;
                case LaunchType.synthesis:
                    synthesisLauncher.Instance.LaunchToSynthesis(LaunchNum);
                    break;
                case LaunchType.shop:
                    ShopLauncher.Instance.LaunchToShop(LaunchNum);
                    break;
                case LaunchType.nextNode:
                    NextNodeLauncher.Instance.LaunchToNextNode(LaunchNum);
                    break;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTextAndType(string _LaunchName, ushort _LaunchNum, LaunchType _launchType)
    {
        LaunchName.text = _LaunchName;
        LaunchNum = _LaunchNum;
        launchType = _launchType;
        LaunchTypeText.text = GetLaunchTypeText(launchType);
    }

    string GetLaunchTypeText(LaunchType _launchType)
    {
        switch (launchType)
        {
            case LaunchType.Enemy:
                return "敌人";
            case LaunchType.synthesis:
                return "合成台";
            case LaunchType.shop:
                return "商店";
            case LaunchType.nextNode:
                return "下一个场景";
            default:
                return "";
        }
    }
}
