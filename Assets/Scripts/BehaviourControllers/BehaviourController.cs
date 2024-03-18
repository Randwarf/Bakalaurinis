using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourController : MonoBehaviour
{
    public BehaviourState behaviourState;

    // Update is called once per frame
    void Update()
    {
        behaviourState.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        behaviourState.OnCollisionEnter(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        behaviourState.OnCollisionExit(collision);
    }

    public void ChangeState(BehaviourState newState)
    {
        behaviourState.End();
        behaviourState = newState;
        behaviourState.Start();
    }
}
