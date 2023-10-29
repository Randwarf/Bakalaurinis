using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    public Transform[] SpawnLocations;
    public List<GameObject> attackPrefabs;

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
            Spawn(spawnLocation);
        }
    }

    public void Spawn(Transform parent)
    {
        var attackIndex = Random.Range(0, attackPrefabs.Count);
        var attack = Instantiate(attackPrefabs[attackIndex], parent.position, parent.rotation);
        attack.GetComponent<UiOrb>().parent = parent;
        attack.transform.SetParent(parent);
    }
}