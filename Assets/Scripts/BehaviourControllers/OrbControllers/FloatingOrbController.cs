using Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingOrbController : OrbController
{
    public override void Start()
    {
        base.Start();
        UIState = new UIState(gameObject, uiObjects);
        ActionState = new FloatingOrbState(gameObject, actionObjects);
        ChangeState(UIState);

        damage = 40;
    }
}
