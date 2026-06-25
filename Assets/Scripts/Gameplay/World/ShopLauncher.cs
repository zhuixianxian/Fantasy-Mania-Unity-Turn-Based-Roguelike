using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLauncher : MonoBehaviour
{
    public int shopPosition;//调用的是节点中的哪个合成台

    public GameObject shopPanel;//合成台面板

    // 单例实例
    public static ShopLauncher Instance { get; private set; }


    private void Awake()
    {
        // 实现单例逻辑
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 商店唤起的统一调用
    /// </summary>
    /// <param name="shopPos">调用的是节点中的哪个商店</param>
    public void LaunchToShop(ushort shopPos)
    {
        shopPanel.SetActive(true);
        shopPanel.GetComponentInChildren<ShopPanelMgr>().DispShopGoods(shopPos);

    }
}
