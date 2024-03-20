using Assets.Scripts.BehaviourControllers.EnemyControllers.States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Tweenables.Primitives;

public class PreDashState : MonsterBehaviourState
{
    public float MOVE_SPEED = 100f;
    public float DASH_COOLDOWN = 3f;
    public float PERLIN_SCALE = 5f;
    public float PERLIN_MULTIPLIER = 10f;
    public float TURN_AROUND_RADIUS = 10f;

    private Rigidbody rb;
    private IDashingMonster dashing;
    private float dashTimer = 0f;

    public PreDashState(GameObject context)
    {
        this.context = context;
        rb = context.GetComponent<Rigidbody>();
        dashing = context.GetComponent<IDashingMonster>();
    }

    public override void Update()
    {
        if (NeedsToTurnAround())
        {
            UTILS.LookAtCamera(context);
        }
        float rotationSpeed = (Mathf.PerlinNoise1D(Time.timeSinceLevelLoad/PERLIN_SCALE) - 0.5f) * PERLIN_MULTIPLIER;
        context.transform.Rotate(new Vector3(0,30*rotationSpeed*Time.deltaTime,0));
        rb.velocity = context.transform.forward * Time.deltaTime * MOVE_SPEED;

        dashTimer += Time.deltaTime;
        if (dashTimer> DASH_COOLDOWN)
        {
            dashing.startDashing(rotationSpeed);
        }
    }

    private bool NeedsToTurnAround()
    {
        var position = context.transform.position;
        
        if (position.x > 10 || position.x < -10) return true;
        if (position.z > 10 || position.z < -10) return true;
        return false;
    }
}
