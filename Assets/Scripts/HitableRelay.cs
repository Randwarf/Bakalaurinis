using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableRelay : MonoBehaviour, IHitableObject
{
    public RelayManager manager;
    public int RelayIndex;

    public void Hit(int damage, Element element, bool stun)
    {
        manager.Hit(RelayIndex, damage, element, stun);
    }


    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.GetComponentInParent<RelayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
