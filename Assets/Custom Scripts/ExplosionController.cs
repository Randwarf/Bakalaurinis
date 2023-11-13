using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public int damage = 20;
    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MonsterController monster;
        var isMonster = other.gameObject.TryGetComponent<MonsterController>(out monster);
        if (isMonster)
        {
            monster.OnHit(damage, Element.Fire);
            collider.enabled = false;
        }
    }
}
