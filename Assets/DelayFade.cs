using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayFade : MonoBehaviour
{
    float fadeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadeTime -= Time.deltaTime;
        if (fadeTime <= 0)
        {
            gameObject.SetActive(false);
        }

    }

    public void FadeAfter(float time)
    {
        fadeTime = time;
    }
}
