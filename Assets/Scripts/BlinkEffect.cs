using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public Transform topEyelid;
    public Transform bottomEyelid;

    public bool startOpen = false;

    private Vector3 startingPosTopEyelid;
    private Vector3 startingPosBottomEyelid;

    bool isOpen;
    float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        startingPosTopEyelid = topEyelid.localPosition;
        startingPosBottomEyelid = bottomEyelid.localPosition;

        screenHeight = 250;

        if (startOpen)
        {
            SetEyeOpen();
        }
        else
        {
            AnimateEyeOpen();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateEyeOpen()
    {
        topEyelid.LeanMoveLocalY(screenHeight, 2).setEaseInBounce();
        bottomEyelid.LeanMoveLocalY(-screenHeight, 2).setEaseInBounce();
    }

    private void SetEyeOpen()
    {
        topEyelid.position = new Vector3(topEyelid.position.x, screenHeight, topEyelid.position.z);
        bottomEyelid.position = new Vector3(bottomEyelid.position.x, -screenHeight, bottomEyelid.position.z);
    }

    public void AnimateEyeClosed(Action action)
    {
        topEyelid.LeanMoveLocal(startingPosTopEyelid, 2);
        bottomEyelid.LeanMoveLocal(startingPosBottomEyelid, 2).setOnComplete(action);
    }

    private void SetEyeClosed()
    {
        topEyelid.localPosition = startingPosTopEyelid;
        bottomEyelid.localPosition = startingPosBottomEyelid;
    }
}
