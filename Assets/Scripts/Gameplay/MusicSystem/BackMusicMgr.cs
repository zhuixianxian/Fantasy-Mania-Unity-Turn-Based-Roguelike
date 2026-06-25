using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.SceneManagement;

using static Unity.VisualScripting.Member;

public class BackMusicMgr : SingletonMono<BackMusicMgr>
{
    //背景音乐播放组件
    public AudioSource bkMusic;

    //背景音乐大小
    public float bkMusicValue = 0.1f;
    public bool bkMusicValue2 = true;

    //管理正在播放的音效
    private List<AudioSource> soundList = new List<AudioSource>();
    //音效音量大小
    private float soundValue = 0.1f;
    private float soundValue2 = 0.1f;
    //音效是否在播放
    private bool soundIsPlay = true;

    private const string BGM_PATH = "Audio/BGM/";   // Resources文件夹下的相对路径前缀
    /// <summary>
    /// 播放背景音乐（同步加载，适合小音频）
    /// </summary>
    /// <param name="fileName">文件名（不含后缀，放在Resources/Audio/BGM/下）</param>
    public void PlayBKMusic(string fileName)
    {
        if (bkMusic == null) return;

        string fullPath = BGM_PATH + fileName;
        AudioClip clip = Resources.Load<AudioClip>(fullPath);
        if (clip == null)
        {
            Debug.LogError($"背景音乐加载失败: {fullPath}");
            return;
        }

        //// 避免重复播放同一首
        //if (bkMusic.clip == clip && bkMusic.isPlaying) return;

        bkMusic.clip = clip;
        bkMusic.loop = true;
        bkMusic.volume = bkMusicValue;
        bkMusic.Play();
    }

    /// <summary>
    /// 异步加载并播放背景音乐（推荐用于大文件）
    /// </summary>
    public void PlayBKMusicAsync(string fileName, System.Action onStarted = null)
    {
        if (bkMusic == null) return;
        StartCoroutine(LoadAndPlayBGM(fileName, onStarted));
    }

    private IEnumerator LoadAndPlayBGM(string fileName, System.Action onStarted)
    {
        string fullPath = BGM_PATH + fileName;
        ResourceRequest request = Resources.LoadAsync<AudioClip>(fullPath);
        yield return request;

        AudioClip clip = request.asset as AudioClip;
        if (clip == null)
        {
            Debug.LogError($"异步加载背景音乐失败: {fullPath}");
            yield break;
        }

        bkMusic.clip = clip;
        bkMusic.loop = true;
        bkMusic.volume = bkMusicValue;
        bkMusic.Play();
        onStarted?.Invoke();
    }

    //停止背景音乐
    public void StopBKMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Stop();
    }

    //暂停背景音乐
    public void PauseBKMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Pause();
    }


    //设置背景音乐大小
    public void ChangeBKMusicValue(float v)
    {
        bkMusicValue = v;
        if (bkMusic == null)
            return;
        bkMusic.volume = bkMusicValue * (bkMusicValue2 ? 1 : 0);
    }

    public void ChangeBKMusicValue2(bool v)
    {
        bkMusicValue2 = v;
        if (bkMusic == null)
            return;
        bkMusic.volume = bkMusicValue * (bkMusicValue2 ? 1 : 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayBKMusicAsync("GIN");
    }

    private void Update()
    {
        //if (!soundIsPlay)
        //    return;

        //不停的遍历容器 检测有没有音效播放完毕 播放完了 就移除销毁它
        //为了避免边遍历边移除出问题 我们采用逆向遍历
        for (int i = soundList.Count - 1; i >= 0; --i)
        {
            if (!soundList[i].isPlaying)
            {
                //音效播放完毕了 不再使用了 我们将这个音效切片置空
                soundList[i].clip = null;
                PoolMgr.Instance.PushObj(soundList[i].gameObject);
                soundList.RemoveAt(i);
            }
        }
    }


    /// <summary>
    /// 继续播放或者暂停所有音效
    /// </summary>
    /// <param name="isPlay">是否是继续播放 true为播放 false为暂停</param>
    public void PlayOrPauseSound(bool isPlay)
    {
        if (isPlay)
        {
            soundIsPlay = true;
            for (int i = 0; i < soundList.Count; i++)
                soundList[i].Play();
        }
        else
        {
            soundIsPlay = false;
            for (int i = 0; i < soundList.Count; i++)
                soundList[i].Pause();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.name)
        {
            case "StartScene":
                PlayBKMusicAsync("GIN");
                break;
            case "TeamFormationScene":
                PlayBKMusicAsync("GIN");
                break;
            case "WorldScene":
                PlayBKMusicAsync("Circulation_loop");
                break;
            case "BattleScene":
                PlayBKMusicAsync("GuiHuaJianGe");
                break;
            default:
                break;
        }
    }
}
