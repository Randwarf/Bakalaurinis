using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitableObject
{
    public void Hit(int damage, Element element, bool stun);
}
