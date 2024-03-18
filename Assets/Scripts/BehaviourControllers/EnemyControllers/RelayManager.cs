using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RelayManager : MonoBehaviour
{
    public List<HitableRelay> Relays = new List<HitableRelay>();

    public abstract void Hit(int relayIndex, int damage, Element element, bool stun);
}
