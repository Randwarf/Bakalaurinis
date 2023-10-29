using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeckHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnGrab(SelectEnterEventArgs args)
    {
        Destroy(GetComponent<XRGrabInteractable>());
        Destroy(GetComponent<Rigidbody>());
        transform.SetParent(args.interactorObject.transform);
    }

}
