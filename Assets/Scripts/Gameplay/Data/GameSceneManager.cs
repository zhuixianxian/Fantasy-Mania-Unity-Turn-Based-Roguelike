using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class GameSceneManager : SingletonMono<GameSceneManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        // 核心：异步加载场景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        yield return asyncLoad;
    }
}
