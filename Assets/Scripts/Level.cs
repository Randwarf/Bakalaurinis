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

    public int numberOfLoops = 0;

    internal void LoadNext()
    {
        numberOfLoops++;
        SceneManager.LoadScene("BattleScene");
    }
}
