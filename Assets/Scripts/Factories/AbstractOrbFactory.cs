using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class AbstractOrbFactory
{
    public GameObject InstantiateOrb(GameObject prefab, Vector3 position, Quaternion quaternion)
    {
        var orbGameObject = UnityEngine.GameObject.Instantiate(prefab, position, quaternion);
        var orb = orbGameObject.GetComponent<OrbController>();

        SetUpOrbState(orb, prefab);
        return orb.gameObject;
    }

    public GameObject InstantiateOrb(GameObject prefab, Transform parent)
    {
        var orbGameObject = UnityEngine.GameObject.Instantiate(prefab, parent);
        var orb = orbGameObject.GetComponent<OrbController>();

        orb.transform.SetParent(parent);
        orb.UISlot = parent;

        SetUpOrbState(orb, prefab);
        return orb.gameObject;
    }

    protected abstract void SetUpOrbState(OrbController orb, GameObject prefab);
}
