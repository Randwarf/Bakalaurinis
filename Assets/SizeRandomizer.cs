using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeRandomizer : MonoBehaviour
{
    public float minScale = 0.5f;
    public float maxScale = 2f;

    public bool randomizeRotation = false;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = RandomVector3();
        if (randomizeRotation)
        {
            this.transform.rotation = Random.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 RandomVector3()
    {
        float scale = Random.Range(minScale, maxScale);
        Vector3 v = new Vector3(scale, scale, scale);
        return v;
    }
}
