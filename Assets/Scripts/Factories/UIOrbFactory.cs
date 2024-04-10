using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrbFactory : AbstractOrbFactory
{
    protected override void SetUpOrbState(OrbController orb, GameObject prefab)
    {
        orb.ChangeState(orb.UIState);
    }
}
