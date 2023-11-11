using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterController : MonoBehaviour
{
    protected IEnemyMovementStrategy movementStrategy;

    // Update is called once per frame
    void Update()
    {
        movementStrategy.Move();
    }
}
