using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider= GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something stepped on me");
        if (other is CharacterController)
        {
            Debug.Log("playerStepped on me");
            Level.GetInstance().LoadNext();
        }
    }
}
