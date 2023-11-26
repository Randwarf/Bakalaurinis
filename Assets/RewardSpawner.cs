using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> SpawnPositions = new List<Transform>();

    public void SpawnRewards(List<GameObject> Rewards)
    {
        foreach (var position in SpawnPositions)
        {
            var randomRewardIndex = Random.Range(0, Rewards.Count);
            Instantiate(Rewards[randomRewardIndex], position.position, Quaternion.identity);
        }
    }
}
