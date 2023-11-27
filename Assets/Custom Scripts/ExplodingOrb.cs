using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (collision.gameObject.CompareTag("OrbTarget"))
        {
            Debug.Log("Hit something");
            Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
