using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;

public class ExplodingOrb : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    private SphereCollider collider;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var isHitable = collision.gameObject.TryGetComponent(out IHitableObject hitableObject);
        if (isHitable)
            Hit(hitableObject);
    }

    private void Hit(IHitableObject hitableObject)
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
