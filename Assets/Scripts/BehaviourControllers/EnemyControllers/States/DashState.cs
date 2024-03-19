using Assets.Scripts.BehaviourControllers.EnemyControllers.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : MonsterBehaviourState
{
    public float MOVE_SPEED = 200f;
    public float DASH_DURATION = 2f;

    private Rigidbody rb;
    private IDashingMonster dashing;
    private float dashTimer = 0f;
    private float rotationSpeed;

    public DashState(GameObject context, float rotationSpeed)
    {
        this.context = context;
        rb = context.GetComponent<Rigidbody>();
        dashing = context.GetComponent<IDashingMonster>();
        this.rotationSpeed = rotationSpeed;
    }

    public override void Update()
    {
        context.transform.Rotate(new Vector3(0, 30 * rotationSpeed * Time.deltaTime, 0));
        rb.velocity = context.transform.forward * Time.deltaTime * MOVE_SPEED;

        dashTimer += Time.deltaTime;
        if (dashTimer > DASH_DURATION)
        {
            dashing.stopDashing();
        }
    }
}
