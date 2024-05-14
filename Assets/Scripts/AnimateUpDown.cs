using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateUpDown : MonoBehaviour
{
    public float cycleLenght;
    public float moveValue;

    // Start is called before the first frame update
    void Start()
    {
        transform.LeanMoveLocalY(transform.localPosition.y - moveValue, cycleLenght).setLoopPingPong();
    }
}
