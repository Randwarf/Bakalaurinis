using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System;

public class StatManager : MonoBehaviour
{
    public TextMeshPro LastMatch;
    public TextMeshPro BestMatch;
    public TextMeshPro HighScore;

    private PlayerStats stats;
    private string filePath;


    // Start is called before the first frame update
    void Start()
    {
        SetupPath();
        LoadStats();
        VisualizeStats();
    }

    private void SetupPath()
    {
        filePath = Application.persistentDataPath + "/Bakalaurinis";///PlayerStats.json";
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        filePath += "/PlayerStats.json";
    }

    // Update is called once per frame
    void Update()
    {
        VisualizeStats();
    }

    private void VisualizeStats()
    {
        LastMatch.text = stats.RecentMatchTime.ToString("0.00");
        BestMatch.text = stats.BestMatchTime.ToString("0.00");
        HighScore.text = stats.MaxConsecutiveWins.ToString();
    }

    private void LoadStats()
    {
        if (File.Exists(filePath))
        {
            var fileContent = File.ReadAllText(filePath);
            stats = JsonUtility.FromJson<PlayerStats>(fileContent);
        }
        else
        {
            stats = new PlayerStats();
            SaveStats();
        }
    }

    public void SaveStats()
    {
        var jsonString = JsonUtility.ToJson(stats);
        File.WriteAllText(filePath, jsonString);
    }

    public void UpdateMatchTime(float RecentTime)
    {
        stats.RecentMatchTime = RecentTime;
        if (RecentTime < stats.BestMatchTime)
        {
            stats.BestMatchTime = RecentTime;
        }

        SaveStats();
    }

    public void UpdateWinStreak(int winCount)
    {
        if (winCount > stats.MaxConsecutiveWins)
        {
            stats.MaxConsecutiveWins = winCount;
            SaveStats();
        }
    }
}
