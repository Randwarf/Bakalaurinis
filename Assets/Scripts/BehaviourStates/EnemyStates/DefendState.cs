using Assets.Custom_Scripts;
using Assets.Scripts.BehaviourControllers.EnemyControllers.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendState : MonsterBehaviourState
{
    IDefensiveMonster controller;
    bool enableShields = false;

    public DefendState (GameObject context)
    {
        this.context = context;
    }

    public override void Start()
    {
        UTILS.LookAtCamera(context);
        controller = context.GetComponent<IDefensiveMonster>();
        enableShields = true;
    }

    public override void End()
    {
        controller.DisableShields();
    }

    public override void Update()
    {
        //Delay shield enable by one frame
        if (enableShields)
        {
            controller.EnableShields();
            enableShields = false;
        }
    }
}
