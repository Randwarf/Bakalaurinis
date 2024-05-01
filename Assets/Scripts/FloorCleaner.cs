using Assets.Scripts.BehaviourStates.OrbStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCleaner : MonoBehaviour
{
    Collider collider;
    public Transform ThrophySpawner;
    public OrbSpawner OrbSpawner;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var throphy =other.GetComponentInParent<PersistantObject>();
        if (throphy != null)
        {
            throphy.gameObject.transform.position = ThrophySpawner.transform.position;
        }
        else if (other.TryGetComponent<OrbController>(out var orbController))
        {
            if (orbController.behaviourState is EquipableOrbState)
            {
                OrbSpawner.MoveOrb(orbController.gameObject);
            }
        }
    }
}
