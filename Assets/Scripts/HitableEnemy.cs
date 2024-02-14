using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterController))]

public class HitableEnemy : MonoBehaviour, IHitableObject
{
    MonsterController controller;

    void Start()
    {
        controller = GetComponent<MonsterController>();
    }

    public void Hit(int damage, Element element, bool stun)
    {
        controller.OnHit(damage, element);
        if (stun)
        {
            controller.Stun();
        }
    }
}
