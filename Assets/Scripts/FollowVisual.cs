using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FollowVisual : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis;

    private Vector3 startPos;

    private Vector3 offset;
    private Transform pokeAttachTransform;

    private XRBaseInteractable interactable;
    private bool isFollowing = false;
    private bool isFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = visualTarget.localPosition;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);
        interactable.selectExited.AddListener(Unfreeze);
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor poke = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;

            pokeAttachTransform = poke.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;
        }
    }

    public void Reset(BaseInteractionEventArgs exit)
    {
        if (exit.interactorObject is XRPokeInteractor)
            isFollowing = false;
    }

    public void Freeze(BaseInteractionEventArgs select)
    {
        if (select.interactorObject is XRPokeInteractor)
            isFrozen = true;
    }

    public void Unfreeze(BaseInteractionEventArgs unselect)
    {
        if (unselect.interactorObject is XRPokeInteractor)
            isFrozen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen)
            return;

        if(isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);

            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, startPos, Time.deltaTime * 2);
        }
    }
}
