using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> SpawnPositions = new List<Transform>();

    private RewardOrbFactory factory = new RewardOrbFactory();

    public void SpawnRewards(List<GameObject> Rewards)
    {
        foreach (var position in SpawnPositions)
        {
            var randomRewardIndex = Random.Range(0, Rewards.Count);
            var reward = Rewards[randomRewardIndex];
            factory.InstantiateOrb(reward, position.position, Quaternion.identity);
        }
    }
}
