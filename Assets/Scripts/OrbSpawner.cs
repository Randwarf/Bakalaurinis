using Assets.Scripts.BehaviourStates.OrbStates;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    AttackSpawner attackSpawner;
    AudioSource spawnAudio;
    List<GameObject> orbs;
    List<GameObject> spawnedOrbs;

    private float SPAWN_COOLDOWN = 0.5f;
    private float spawnTimer = 0f;
    private int orbIndex = 0;
    private bool isSpawning = false;

    private LoadoutOrbFactory factory = new LoadoutOrbFactory();

    // Start is called before the first frame update
    void Start()
    {
        attackSpawner = FindAnyObjectByType<AttackSpawner>();
        spawnAudio = GetComponent<AudioSource>();
        spawnedOrbs= new List<GameObject>();
    }

    public void ResetDeck()
    {
        if(attackSpawner == null)
            attackSpawner = FindAnyObjectByType<AttackSpawner>();

        foreach (var deckSlot in attackSpawner.SpawnLocations)
        {
            deckSlot.DestroyAllChildren();
        }

        AttackSpawner.attackPrefabsInDeck.Clear();
        orbs = new List<GameObject>(AttackSpawner.attackPrefabsGlobal);
        isSpawning = true;
        orbIndex = 0;
        spawnTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Not activated
        if (!isSpawning)
            return;

        //On Cooldown
        spawnTimer += Time.deltaTime;
        if (spawnTimer < SPAWN_COOLDOWN)
            return;

        //Spawned everything
        if (orbIndex >= orbs.Count)
        {
            isSpawning = false;
            return;
        }

        SpawnOrb();
    }

    private void SpawnOrb()
    {
        spawnAudio.Play();
        var orb = factory.InstantiateOrb(orbs[orbIndex], transform.position, Quaternion.identity);
        spawnedOrbs.Add(orb);
        orbIndex++;
        spawnTimer = 0f;
    }

    public void MoveOrb(GameObject gameObject)
    {
        spawnAudio.Play();
        gameObject.transform.position = transform.position;
    }
}
