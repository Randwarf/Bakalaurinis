using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardOrb : MonoBehaviour
{
    public GameObject UIOrb;
    public bool canBeAddedToDeck = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOrbRelease()
    {
        if(canBeAddedToDeck)
        {
            var attackSpawner = FindAnyObjectByType<AttackSpawner>();
            attackSpawner.AddNewAttack(UIOrb);
            attackSpawner.RewardAura.SetActive(false);
            Destroy(gameObject);
        }
    }
}
