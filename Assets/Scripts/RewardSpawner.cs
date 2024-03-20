using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> SpawnPositions = new List<Transform>();

    private void Start()
    {
        //var target = FindAnyObjectByType<Camera>().transform;
        //Vector3 targetPostition = new Vector3(target.position.x,
        //                               this.transform.position.y,
        //                               target.position.z);
        //this.transform.LookAt(targetPostition);
    }

    public void SpawnRewards(List<GameObject> Rewards)
    {
        foreach (var position in SpawnPositions)
        {
            var randomRewardIndex = Random.Range(0, Rewards.Count);
            var orb = Instantiate(Rewards[randomRewardIndex], position.position, Quaternion.identity);
            var isOrbController = orb.TryGetComponent(out OrbController controller);
            if (isOrbController)
            {
                controller.ChangeState(controller.RewardState);
            }
        }
    }
}
