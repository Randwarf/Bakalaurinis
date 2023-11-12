using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSource : MonoBehaviour
{
    public int damage = 40;
    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
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
            monster.OnHit(damage);
        }
        if (other.tag.Equals("OrbTarget"))
        {
            Destroy(gameObject);
        }
    }
}
