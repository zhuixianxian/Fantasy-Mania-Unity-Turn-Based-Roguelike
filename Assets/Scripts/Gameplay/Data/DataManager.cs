using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;

using FantasyMania.TurnBasedCombat;

using LitJson;

using Unity.VisualScripting;

using UnityEngine;

public class DataManager : SingletonMono<DataManager>
{
    public Dictionary<string, BaseCharacterData> singletonCharacterData;
    public Dictionary<string, BaseNodeData> singletonMapData;
    public Dictionary<string, BaseEnemyData> singletonEnemyData;
    public Dictionary<string, BaseItemData> singletonItemData;
    public Dictionary<string, BasesSnthesisItemData> singletonItemFormData;//保存配方数据

    // 加载状态
    private bool heroesLoaded = false;
    private bool mapsLoaded = false;
    private bool enemysLoaded = false;
    private bool itemsLoaded = false;
    private bool FormsLoaded = false;//配方是否加载完毕

    public bool IsLoading { get; private set; }

    //private void Start()
    //{
    //    string json = JsonMapper.ToJson(singletonEnemyData);
    //    string mapsConfigPath = Path.Combine(Application.dataPath, "Resources", "Configs", "Enemy");
    //    File.WriteAllText(mapsConfigPath + "/Enemy.json", json);
    //}
    private IEnumerator Start()
    {
        yield return LoadAllData();
    }

    private IEnumerator LoadAllData()
    {
        IsLoading = true;

        // 并行加载（也可以串行加载）
        StartCoroutine(LoadHeroesConfiguration());
        StartCoroutine(LoadMapsConfiguration());
        StartCoroutine(LoadEnemysConfiguration());
        StartCoroutine(LoadItemsConfiguration());
        StartCoroutine(LoadFormulasConfiguration());

        // 等待两个资源都加载完成
        yield return new WaitUntil(() => heroesLoaded && mapsLoaded && enemysLoaded && itemsLoaded && FormsLoaded);

        IsLoading = false;
        Debug.Log("所有数据加载完成！");
    }

    private IEnumerator LoadHeroesConfiguration()
    {
        // 异步加载Heros配置
        ResourceRequest request = Resources.LoadAsync<TextAsset>("Configs/Characters/Heros");
        yield return request;

        TextAsset jsonFile = request.asset as TextAsset;
        string data = jsonFile.text;

        singletonCharacterData = JsonMapper.ToObject<Dictionary<string, BaseCharacterData>>(data);
        heroesLoaded = true;
    }

    private IEnumerator LoadMapsConfiguration()
    {
        // 异步加载地图配置
        ResourceRequest request = Resources.LoadAsync<TextAsset>("Configs/Maps/Maps");
        yield return request;

        TextAsset jsonFile = request.asset as TextAsset;
        string data = jsonFile.text;

        singletonMapData = JsonMapper.ToObject<Dictionary<string, BaseNodeData>>(data);
        mapsLoaded = true;
    }

    private IEnumerator LoadEnemysConfiguration()
    {
        // 异步加载敌人配置
        ResourceRequest request = Resources.LoadAsync<TextAsset>("Configs/Enemy/Enemy");
        yield return request;

        TextAsset jsonFile = request.asset as TextAsset;
        string data = jsonFile.text;

        singletonEnemyData = JsonMapper.ToObject<Dictionary<string, BaseEnemyData>>(data);
        enemysLoaded = true;
    }

    private IEnumerator LoadFormulasConfiguration()
    {
        // 异步加载配方配置
        ResourceRequest request = Resources.LoadAsync<TextAsset>("Configs/Item/ItemFormula");
        yield return request;

        TextAsset jsonFile = request.asset as TextAsset;
        string data = jsonFile.text;

        singletonItemFormData = JsonMapper.ToObject<Dictionary<string, BasesSnthesisItemData>>(data);
        FormsLoaded = true;
    }

    private IEnumerator LoadItemsConfiguration()
    {
        // 异步加载普通物品配置
        ResourceRequest requestNor = Resources.LoadAsync<TextAsset>("Configs/Item/NormalItem");
        yield return requestNor;
        // 异步加载武器配置

        ResourceRequest requestEqui = Resources.LoadAsync<TextAsset>("Configs/Item/Equipment");
        yield return requestEqui;

        Dictionary<string, BaseNormalItemData> singletonNormData = new Dictionary<string, BaseNormalItemData>();

        TextAsset jsonNorFile = requestNor.asset as TextAsset;
        string dataNor = jsonNorFile.text;

        singletonNormData = JsonMapper.ToObject<Dictionary<string, BaseNormalItemData>>(dataNor);

        Dictionary<string, BaseEquipmentItemData> singletonEquiData = new Dictionary<string, BaseEquipmentItemData>();

        TextAsset jsonEquiFile = requestEqui.asset as TextAsset;
        string dataEqui = jsonEquiFile.text;

        singletonEquiData = JsonMapper.ToObject<Dictionary<string, BaseEquipmentItemData>>(dataEqui);

        singletonItemData = new Dictionary<string, BaseItemData>();
        foreach (var kv in singletonNormData) singletonItemData[kv.Key] = kv.Value;
        foreach (var kv in singletonEquiData) singletonItemData[kv.Key] = kv.Value;
        itemsLoaded = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveGameDataMgr(object GameData, string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";

        string jsonStr = "";

        jsonStr = JsonMapper.ToJson(GameData);

        File.WriteAllText(path, jsonStr);
    }

    public bool SetGameDataMgr(string fileName)
    {
        string path = Application.streamingAssetsPath + "/" + fileName + ".json";

        if (!File.Exists(path))
        {
            path = Application.persistentDataPath + "/" + fileName + ".json";
        }
        if (!File.Exists(path))
        {
            return false;//待修改
        }

        string jsonStr = File.ReadAllText(path);

        if (string.IsNullOrEmpty(jsonStr)) return false;

        GameDataManager.Instance.SetGameDataMgr(jsonStr);

        return true;
    }

    public void ClearGameData(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        File.WriteAllText(path, string.Empty);
    }
}
