using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourController<TBehaviourState> : MonoBehaviour where TBehaviourState : BehaviourState
{
    public TBehaviourState behaviourState { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (behaviourState != null)
        {
            behaviourState.Update();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (behaviourState != null) 
        {
            behaviourState.OnCollisionEnter(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (behaviourState != null)
        {
            behaviourState.OnCollisionExit(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (behaviourState != null)
        {
            behaviourState.OnTriggerEnter(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (behaviourState != null)
        {
            behaviourState.OnTriggerExit(other);
        }
    }

    public void ChangeState(TBehaviourState newState)
    {
        if (behaviourState != null)
        { 
            behaviourState.End(); 
        }
        behaviourState = newState;
        behaviourState.Start();
    }
}
