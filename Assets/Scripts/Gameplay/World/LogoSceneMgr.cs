using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class LogoSceneMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneWait());
        SceneMgr.Instance.LoadScene("StartScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SceneWait()
    {
        yield return new WaitForSecondsRealtime(4f);

    }
}
