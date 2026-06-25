using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class synthesisLauncher : MonoBehaviour
{
    public int synthesisPosition;//调用的是节点中的哪个合成台

    public GameObject synthesisPanel;//合成台面板

    // 单例实例
    public static synthesisLauncher Instance { get; private set; }


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
    /// 合成台唤起的统一调用
    /// </summary>
    /// <param name="synPos">调用的是节点中的哪个合成台</param>
    public void LaunchToSynthesis(ushort synPos)
    {
        synthesisPanel.SetActive(true);
        synthesisPanel.GetComponentInChildren<SynPanelMgr>().DisplaySynForm(synPos);

    }
}
