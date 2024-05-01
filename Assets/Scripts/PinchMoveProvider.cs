using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Hands;

public class PinchMoveProvider : MonoBehaviour
{
    public Transform origin;
    public Transform direction;
    public float moveThreshold = 7f;
    public float moveSpeed = 1f;

    public void JointsUpdated(XRHandJointsUpdatedEventArgs args)
    {
        var hand = args.hand;
        if (isMoving(hand))
        {
            moveForward();
        }
    }

    private bool isMoving(XRHand hand)
    {
        var indexIntermediate = hand.GetJoint(XRHandJointID.IndexIntermediate);
        var middleIntermediate = hand.GetJoint(XRHandJointID.MiddleIntermediate);
        var palm = hand.GetJoint(XRHandJointID.Palm);

        indexIntermediate.TryGetAngularVelocity(out var angularVelocityIndex);
        middleIntermediate.TryGetAngularVelocity(out var angularVelocityMiddle);
        palm.TryGetAngularVelocity(out var angularVelocityPalm);

        angularVelocityIndex -= angularVelocityPalm;
        angularVelocityMiddle -= angularVelocityPalm;

        var swingSpeed = Math.Max(angularVelocityIndex.magnitude, angularVelocityMiddle.magnitude);
        var difference = angularVelocityMiddle - angularVelocityIndex;

        if (swingSpeed > moveThreshold)
        {
            return true;
        }
        return false;
    }

    private void moveForward()
    {
        origin.GetComponent<CharacterController>().Move(moveSpeed * Time.deltaTime * direction.forward);
    }
}
