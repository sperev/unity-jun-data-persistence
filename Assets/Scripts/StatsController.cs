using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatsController
{
    public static StatsController Instance = new StatsController();
    public PlayerData topPlayer;
    public string currentPlayerName;

    StatsController()
    {
        string path = Application.persistentDataPath + "/savefile.json";


        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            topPlayer = JsonUtility.FromJson<PlayerData>(json);
        }
    }

    public void AddScore(string name, int score)
    {
        if (topPlayer == null || score > topPlayer.score)
        {
            topPlayer = new PlayerData();
            topPlayer.name = name;
            topPlayer.score = score;
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(topPlayer);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
