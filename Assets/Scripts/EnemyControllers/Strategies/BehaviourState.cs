using UnityEngine;

public class BehaviourState
{
    public GameObject context;

    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void OnCollisionEnter(Collision collision) { }
    public virtual void OnCollisionExit(Collision collision) { }
}