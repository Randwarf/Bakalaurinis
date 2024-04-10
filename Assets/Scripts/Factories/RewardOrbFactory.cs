using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardOrbFactory : AbstractOrbFactory
{
    protected override void SetUpOrbState(OrbController orb, GameObject prefab)
    {
        orb.rewardPrefab = prefab;
        orb.ChangeState(orb.RewardState);
    }
}
