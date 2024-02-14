using Assets.Custom_Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendState : BehaviourState
{
    MuskratController controller;

    public DefendState (GameObject context)
    {
        this.context = context;
    }

    public override void Start()
    {
        UTILS.LookAtCamera(context);
        controller = context.GetComponent<MuskratController>();
        controller.isImmune = true;
        controller.EnableShields();
    }

    public override void End()
    {
        controller.isImmune = false;
    }
}
