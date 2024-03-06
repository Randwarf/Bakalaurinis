using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Custom_Scripts.EnemyControllers.Strategies;
using Assets.Scripts.EnemyControllers.States;
using Assets.Custom_Scripts;

public class SparrowController : MonsterController, IDefensiveMonster
{
    public bool isImmune = true;
    public DoppelgangerManager doppelgangerManager;

    public void DisableShields()
    {
        doppelgangerManager.HideAllDoppelgangers();
        isImmune = false;
    }

    public void EnableShields()
    {
        doppelgangerManager.SpawnDoppelgangers();
        isImmune = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        behaviourState = new DefendState(gameObject);
        behaviourState.Start();
        elementalType = Element.Fire;
        UTILS.LookAtCamera(gameObject);
    }

    public override void OnHit(int damage, Element attackerElement = Element.Normal)
    {
        if (isImmune) return;
        base.OnHit(damage, attackerElement);
    }
}
