using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [SerializeField] PlayerStatsHolder _stats;
    [SerializeField] string _datalocation;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this);

        _datalocation = Application.persistentDataPath + "/datosJuego.json";

        if (File.Exists(_datalocation))
        {
            LoadData();
        }
        else
            SaveData();


        EventManager.shop.OnBuyAnItem += LOL;
        EventManager.player.OnDead += SaveData;
        EventManager.shop.OnShopOpen += LOL2;
        EventManager.enemy.OnDead += SaveData;
        
    }

    //Borrar despues
    public void LOL(int LOL)
    {
        SaveData();
    }

    public void LOL2(int Lol2)
    {
        LoadData();
    }

    public void LoadData()
    {

        if (File.Exists(_datalocation))
        {
            string contenido = File.ReadAllText(_datalocation);
            PlayerStatsData data = JsonUtility.FromJson<PlayerStatsData>(contenido);

            if (data != null)
            {
                _stats.speedStats = data.speedStats;
                _stats.stats = data.stats;
                Debug.Log("Partida Cargada");
            }
        }
    }

    public void SaveData()
    {
        PlayerStatsData data = new PlayerStatsData
        {
            speedStats = _stats.speedStats,
            stats = _stats.stats
        };

        string cadenaJSON = JsonUtility.ToJson(data);
        File.WriteAllText(_datalocation, cadenaJSON);
        Debug.Log("Datos guardados.");
    }
}

[System.Serializable]
public class PlayerStatsData
{
    [Header("Speed stats")]
    public EntityStats speedStats;
    [Header("Base stats")]
    public PlayerStats stats;

    public MonoBehaviour[] hablilidades;
}
