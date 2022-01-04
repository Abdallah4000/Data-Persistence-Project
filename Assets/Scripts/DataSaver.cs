using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance;

    public string PlayerName;
    public string PlayerName2;
    public int HighScore;
    public TextMeshProUGUI thetext;
    
    private void Awake() {
        
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerName();
    }



    [System.Serializable]
    class SaveData
    {
        public string PlayerName ;
        public int HighScore;
    }

    public void SavePlayerName()
    {
        SaveData TheData = new SaveData();

        TheData.PlayerName = PlayerName ;
        TheData.HighScore = HighScore ;

        string json = JsonUtility.ToJson(TheData);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json",json);

    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/SaveFile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData TheData = JsonUtility.FromJson<SaveData>(json);
            PlayerName = TheData.PlayerName;
            HighScore = TheData.HighScore;
            thetext.text = $"Best Player Was {PlayerName} : {HighScore}";
        }
    }

}
