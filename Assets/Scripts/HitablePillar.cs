using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitablePillar : MonoBehaviour, IHitableObject
{
    public TextMeshPro textMeshPro;
    PillarManager manager;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.GetComponentInParent<PillarManager>();
    }

    public void Hit(int damage, Element element, bool stun)
    {
        manager.OnHit(index);
    }

    public void setData(int index, string text)
    {
        textMeshPro.text = text;
        this.index = index;
    }
}
