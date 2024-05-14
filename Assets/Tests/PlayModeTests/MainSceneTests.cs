using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MainSceneTests
{
    [UnityTest]
    public IEnumerator MainSceneShouldSpawnDeck()
    {
        var levelSingleton = Level.GetInstance();
        levelSingleton.TeleportToSpawn();
        yield return null;

        var deck = GameObject.FindAnyObjectByType<DeckHandler>();
        
        Assert.IsNotNull(deck);
    }
}
