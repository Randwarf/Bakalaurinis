using Assets.Scripts.BehaviourStates.OrbStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutOrbFactory : AbstractOrbFactory
{
    protected override void SetUpOrbState(OrbController orb, GameObject prefab)
    {
        orb.rewardPrefab = prefab;
        orb.ChangeState(new EquipableOrbState(orb.gameObject));
    }
}
