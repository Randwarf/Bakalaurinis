using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattleSceneTests
{
    [UnityTest]
    public IEnumerator BattleSceneLoadsEnemy()
    {
        Level.GetInstance().LoadNext();
        yield return null;

        var enemy = GameObject.FindAnyObjectByType<MonsterController>();

        Assert.IsNotNull(enemy, "battle scene should load an enemy when first started");
    }

    [UnityTest]
    public IEnumerator BattleSceneLoadsEnemyAfterAFullLoop()
    {
        var levelSingleton = Level.GetInstance();
        levelSingleton.LoadNext();
        yield return null;
        var enemySpawner = GameObject.FindAnyObjectByType<EnemySpawner>();
        var numberOfEnemies = enemySpawner.EnemyPrefabs.Count;
        
        for(int i = 0; i < numberOfEnemies;i++)
        {
            levelSingleton.LoadNext();
            yield return null;
        }

        var enemy = GameObject.FindAnyObjectByType<MonsterController>();
        Assert.IsNotNull(enemy, "battle scene should load an enemy after all enemies have been defeated");
    }
}
