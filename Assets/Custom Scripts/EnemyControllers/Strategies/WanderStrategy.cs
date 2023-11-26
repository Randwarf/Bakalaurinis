using System;
using Unity.VisualScripting;
using UnityEngine;

internal class WanderStrategy : IEnemyMovementStrategy
{
    Vector3 _target;
    GameObject _unit;
    Rigidbody _rb;
    float _speed = 4f;

    public WanderStrategy(GameObject unit)
    {
        _unit = unit;
        _rb = _unit.GetComponent<Rigidbody>();
        PickNewTarget();
    }

    public bool DoneMoving()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        _rb.velocity = (_unit.transform.position - _target).normalized*_speed;

        if ((_unit.transform.position - _target).magnitude < 0.5f) PickNewTarget();
    }

    private void PickNewTarget()
    {
        var randomDirection = UnityEngine.Random.insideUnitSphere;
        randomDirection.y = 0f;
        var randomMagnitude = UnityEngine.Random.Range(0.5f, 2f);
        _target = _unit.transform.position + randomDirection * randomMagnitude;
    }

    public void SetLooping(bool looping)
    {
        throw new System.NotImplementedException();
    }
}