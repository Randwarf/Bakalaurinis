using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    public Transform[] SpawnLocations;
    public GameObject attackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrab()
    {
        foreach (var spawnLocation in SpawnLocations)
        {
            var attack = Instantiate(attackPrefab, spawnLocation.position, spawnLocation.rotation);
            attack.transform.SetParent(spawnLocation);
        }
    }
}
