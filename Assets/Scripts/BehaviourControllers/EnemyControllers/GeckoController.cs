using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeckoController : MonsterController
{
    // Start is called before the first frame update
    void Start()
    {
        behaviourState = new WanderState(gameObject);
        elementalType = Element.Normal;
    }

    public override void OnHit(int damage, Element attackerElement = Element.Normal)
    {
        base.OnHit(damage, attackerElement);
    }

}
