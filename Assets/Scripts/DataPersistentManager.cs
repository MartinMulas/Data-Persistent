using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistentManager : MonoBehaviour
{
    public static  DataPersistentManager Instance;
    public string playerName;
    public int playerScore;

    //public SaveData bestScore = new SaveData();

    public string bestPlayer;
    public int bestScore;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savescore.json", json);
    }

    public void LoadBestScore()
    {
        string json;
        SaveData data = new SaveData();
        if (!File.Exists(Application.persistentDataPath + "/savescore.json"))
        {
            data.playerName = "PlaceHolder";
            data.playerScore = 5;

            json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savescore.json", json);
            json = string.Empty;
        }

        json = File.ReadAllText(Application.persistentDataPath + "/savescore.json");
        data = JsonUtility.FromJson<SaveData>(json);
        bestPlayer = data.playerName;
        bestScore = data.playerScore;
    }
}
