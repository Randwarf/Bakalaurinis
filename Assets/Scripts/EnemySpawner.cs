using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        if (EnemyPrefabs == null) return;

        var enemyID = Level.GetInstance().numberOfLoops % EnemyPrefabs.Count;

        Instantiate(EnemyPrefabs[enemyID], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
