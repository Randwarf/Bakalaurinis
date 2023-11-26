using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeckoController : MonsterController
{
    // Start is called before the first frame update
    void Start()
    {
        movementStrategy = new WanderStrategy(gameObject);
    }

}
