using System;
using Unity.VisualScripting;
using UnityEngine;

internal class WanderState : BehaviourState
{
    Vector3 _target;
    GameObject _unit;
    Rigidbody _rb;
    float _speed = 3f;

    public WanderState(GameObject unit)
    {
        _unit = unit;
        _rb = _unit.GetComponent<Rigidbody>();
        PickNewTarget();
    }

    public override void Update()
    {
        _unit.transform.LookAt(_target);

        _rb.velocity = Direction() * _speed;

        if ((_target - _unit.transform.position).magnitude < 1f) PickNewTarget();
    }

    private Vector3 Direction()
    {
        return (_target - _unit.transform.position).normalized;
    }

    private void PickNewTarget()
    {
        //Always try to stay around the center
        _target = new Vector3(0, 0, 0);

        //Shift it around a bit
        var randomDirection = UnityEngine.Random.insideUnitSphere;
        randomDirection.y = 0f;
        var randomMagnitude = UnityEngine.Random.Range(5f, 10f);

        
        _target += randomDirection * randomMagnitude;
    }
}