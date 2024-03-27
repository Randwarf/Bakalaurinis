using Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingOrbController : OrbController
{
    public override void Awake()
    {
        base.Awake();
        ActionState = new FloatingOrbState(gameObject, actionObjects);

        damage = 40;
        element = Element.Normal;
    }
}
