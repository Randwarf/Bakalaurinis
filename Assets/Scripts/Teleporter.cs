using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Teleporter : MonoBehaviour
{
    Collider collider;
    public bool goToNextLevel = false;

    private GameObject location;
    private Collider other;

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
        this.other = other;
        if (this.other is CharacterController)
        {
            if (!goToNextLevel)
            {
                location = GameObject.Find("TeleportSpot");
                if (location)
                {
                    FindAnyObjectByType<BlinkEffect>().AnimateEyeClosed(Teleport);
                    return;
                }
            }

            FindAnyObjectByType<BlinkEffect>().AnimateEyeClosed(Level.GetInstance().LoadNext);
        }
    }

    private void Teleport()
    {
        other.transform.position = location.transform.position;
        FindAnyObjectByType<BlinkEffect>().AnimateEyeOpen();
    }
}
