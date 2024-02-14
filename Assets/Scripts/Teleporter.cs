using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    Collider collider;
    public bool goToNextLevel = false;

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
        if (other is CharacterController)
        {
            if (!goToNextLevel)
            {
                var location = GameObject.Find("TeleportSpot");
                if (location)
                {
                    other.transform.position = location.transform.position;
                    return;
                }
            }

            Level.GetInstance().LoadNext();
        }
    }
}
