using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUIController : MonoBehaviour
{
    private TextMeshPro _text;
    // Start is called before the first frame update
    void Start()
    {
        _text= GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int currerntHealth, int maxHealth)
    {
        currerntHealth = Math.Max(currerntHealth, 0);
        _text.text = currerntHealth.ToString() + "/" + maxHealth.ToString();
    }
}
