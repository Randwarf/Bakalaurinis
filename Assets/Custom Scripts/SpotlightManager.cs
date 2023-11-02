using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpotlightManager : MonoBehaviour
{
    public GameObject Target;
    public AudioClip TurnOffSound;
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
            return;
        transform.LookAt(Target.transform.position);
    }

    public void TurnOff(int delayInMiliseconds)
    {
        Invoke("TurnOff", delayInMiliseconds / 1000);
    }

    private void TurnOff()
    {
        if (TurnOffSound != null)   
            AudioSource.PlayClipAtPoint(TurnOffSound, this.transform.position);
        light.enabled = false;
    }
}
