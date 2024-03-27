using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitablePillar : HitableRelay
{
    public TextMeshPro textMeshPro;
    public ParticleSystem particles;

    public void setData(int index, string text)
    {
        textMeshPro.text = text;
        this.RelayIndex = index;
    }
}
