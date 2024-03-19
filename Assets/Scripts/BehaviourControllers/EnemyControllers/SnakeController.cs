using Assets.Custom_Scripts.EnemyControllers.Strategies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonsterController, IDashingMonster
{
    public GameObject NormalState;
    public GameObject DashState;
    public GameObject Colliders;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new PreDashState(gameObject));
    }

    public void startDashing(float rotationSpeed)
    {
        NormalState.SetActive(false);
        Colliders.SetActive(false);
        DashState.SetActive(true);
        ChangeState(new DashState(gameObject, rotationSpeed));
    }

    public void stopDashing()
    {
        NormalState.SetActive(true);
        Colliders.SetActive(true);
        DashState.SetActive(false);
        ChangeState(new StunState(gameObject, new PreDashState(gameObject), 1f));
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
