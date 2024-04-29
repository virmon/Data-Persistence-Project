using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string CurrentPlayer;
    public string BestPlayer;
    public int BestScore;

    public TextMeshProUGUI BestScoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
        BestScoreText.text = $"Best Score : {Instance.BestPlayer} : {Instance.BestScore}";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class SaveData
    {
        public string BestPlayer;
        public int BestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.BestPlayer = BestPlayer;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/persistenceDataFile.json", json);

        Debug.Log("Save bestPlayer " + BestPlayer);
        Debug.Log("Save score " + BestScore);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/persistenceDataFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.BestPlayer;
            BestScore = data.BestScore;

            Debug.Log("Load playerName " + BestPlayer);
            Debug.Log("Load score " + BestScore);
            Debug.Log(Application.persistentDataPath);
        }
    }
}
