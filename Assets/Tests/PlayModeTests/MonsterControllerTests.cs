using System.Collections;
using System.Collections.Generic;
using Assets.Custom_Scripts.EnemyControllers.Strategies;
using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MonsterControllerTests
{

    [UnityTest]
    public IEnumerator MonsterShouldTakeDamage()
    {
        int damage = 10;
        var levelSingleton = Level.GetInstance();
        levelSingleton.TeleportToSpawn();
        yield return null;

        levelSingleton.LoadNext(); //Loading an enemy that does not have invincibility
        yield return null;

        var enemy = GameObject.FindAnyObjectByType<MonsterController>();
        enemy.OnHit(damage, Element.Normal);
        yield return null;

        Assert.AreEqual(enemy.maxHealth-damage, enemy.currentHealth);
    }

    [UnityTest]
    public IEnumerator MonsterShouldRoundDamageCorrectly()
    {
        float damage = 10.5f;
        var levelSingleton = Level.GetInstance();
        levelSingleton.TeleportToSpawn();
        yield return null;

        levelSingleton.LoadNext(); //Loading an enemy that does not have invincibility
        yield return null;

        var enemy = GameObject.FindAnyObjectByType<MonsterController>();
        enemy.OnHit(damage, Element.Normal);
        yield return null;

        Assert.AreEqual(enemy.maxHealth - (int)damage, enemy.currentHealth);
    }

    [UnityTest]
    public IEnumerator MonsterShouldBeStunned()
    {
        var levelSingleton = Level.GetInstance();
        levelSingleton.TeleportToSpawn();
        yield return null;

        levelSingleton.LoadNext(); //Loading an enemy that does not have invincibility
        yield return null;

        var enemy = GameObject.FindAnyObjectByType<MonsterController>();
        enemy.Stun(1f);
        yield return null;
        Assert.IsInstanceOf(typeof(StunState), enemy.behaviourState);
    }

    [UnityTest]
    public IEnumerator MonsterShouldBeUnstunnedAfterBeingHit()
    {
        var levelSingleton = Level.GetInstance();
        levelSingleton.TeleportToSpawn();
        yield return null;

        levelSingleton.LoadNext(); //Loading an enemy that does not have invincibility
        yield return null;

        var enemy = GameObject.FindAnyObjectByType<MonsterController>();
        enemy.Stun(1f);
        yield return null;

        enemy.OnHit(1);
        yield return null;
        Assert.IsNotInstanceOf(typeof(StunState), enemy.behaviourState);
    }
}
