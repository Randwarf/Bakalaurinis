using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level
{
    private static Level instance;
    public static Level GetInstance()
    {
        if (instance == null) instance = new Level();
        return instance;
    }

    public static Guid GetSessionID()
    {
        return GetInstance().SessionID;
    }

    public int numberOfLoops = 0;
    public Guid SessionID;

    public Level()
    {
        SessionID = Guid.NewGuid();
    }

    internal void LoadNext()
    {
        numberOfLoops++;
        SceneManager.LoadScene("BattleScene");
    }

    public int TimeLimit()
    {
        if (numberOfLoops < 2) return -1;

        return 180 / numberOfLoops;
    }

    internal void TeleportToSpawn()
    {
        numberOfLoops = 0;
        SessionID = Guid.NewGuid();
        AttackSpawner.attackPrefabsGlobal = null;
        SceneManager.LoadScene("MainScene");
    }
}
