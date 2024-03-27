using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    public static List<GameObject> attackPrefabsGlobal;
    public static List<GameObject> attackPrefabsInDeck;
    public Transform[] SpawnLocations;
    public List<GameObject> attackPrefabs;

    [SerializeField]
    public GameObject RewardAura;

    // Start is called before the first frame update
    void Start()
    {
        if (attackPrefabsGlobal == null)
        {
            attackPrefabsGlobal = new List<GameObject>();
            attackPrefabsInDeck= new List<GameObject>();
            foreach(var attack in attackPrefabs)
            {
                attackPrefabsGlobal.Add(attack);
                attackPrefabsInDeck.Add(attack);
            }
        }
        else
        {
            attackPrefabs.Clear();
            foreach(var attack in attackPrefabsInDeck)
            {
                attackPrefabs.Add(attack);
            }
        }

        foreach (var spawnLocation in SpawnLocations)
        {
            Spawn(spawnLocation);
        }
    }

    public void Spawn(Transform parent)
    {
        var attackIndex = Random.Range(0, attackPrefabs.Count);
        var attack = Instantiate(attackPrefabs[attackIndex], parent.position, parent.rotation);
        var isOldVersion = attack.TryGetComponent<UiOrb>(out UiOrb uiOrb);
        if (isOldVersion)
        {
            uiOrb.parent = parent;
        }
        else
        {
            var orb = attack.GetComponent<OrbController>();
            orb.UISlot = parent;
            orb.ChangeState(orb.UIState);
        }
        attack.transform.SetParent(parent);
    }

    internal void AddNewAttack(GameObject gameObject)
    {
        attackPrefabs.Add(gameObject);
        attackPrefabsGlobal.Add(gameObject);
        attackPrefabsInDeck.Add(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        RewardOrb rewardOrb;
        var isOldVersion = other.gameObject.TryGetComponent<RewardOrb>(out rewardOrb);
        if (isOldVersion)
        {
            RewardAura.SetActive(true);
            rewardOrb.canBeAddedToDeck = true;
        }
        else
        {
            var isOrb = other.gameObject.TryGetComponent(out OrbController orbController);
            if (isOrb && orbController.isGrabbed)
            {
                RewardAura.SetActive(true);
                orbController.isHoveringDeck = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RewardOrb rewardOrb;
        var isOldVersion = other.gameObject.TryGetComponent<RewardOrb>(out rewardOrb);
        if (isOldVersion)
        {
            RewardAura.SetActive(false);
            rewardOrb.canBeAddedToDeck = false;
        }
        else
        {
            var isOrb = other.gameObject.TryGetComponent(out OrbController orbController);
            if (isOrb)
            {
                RewardAura.SetActive(false);
                orbController.isHoveringDeck = false;
            }
        }
    }
}