using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public int damage = 20;
    private Collider collider;
    public Element element = Element.Fire;

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
        var isHitable = other.gameObject.TryGetComponent(out IHitableObject hitableObject);
        if (isHitable)
        {
            Hit(hitableObject);
        }
    }

    private void Hit(IHitableObject hitableObject)
    {
        hitableObject.Hit(damage, element, false);
        collider.enabled = false;
    }
}
