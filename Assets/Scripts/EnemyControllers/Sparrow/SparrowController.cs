using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Custom_Scripts.EnemyControllers.Strategies;
using Assets.Scripts.EnemyControllers.States;

public class SparrowController : MonsterController
{
    // Start is called before the first frame update
    void Start()
    {
        behaviourState = new DoppelgangerState(gameObject);
        elementalType = Element.Fire;
        UTILS.LookAtCamera(gameObject);
    }
}
