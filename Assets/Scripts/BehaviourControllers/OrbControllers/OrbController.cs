using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public abstract class OrbController : BehaviourController<OrbBehaviourState>
{
    public int damage;
    public bool canStun;
    public Element element;
    public GameObject tooltip;
    public GameObject uiObjects;
    public GameObject actionObjects;

    [NonSerialized]
    public Transform UISlot;
    [NonSerialized]
    public OrbBehaviourState UIState;
    [NonSerialized]
    public OrbBehaviourState ActionState;
    private XRGrabInteractable interactable;

    public virtual void Start()
    {
        AddGrabInteractableListeners();
        AnimatePopUp();
    }

    private void AnimatePopUp()
    {
        var originalScale = transform.localScale;
        gameObject.transform.localScale = Vector3.zero;
        gameObject.transform.LeanScale(originalScale, 1).setEaseOutSine();
    }

    private void AddGrabInteractableListeners()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnSelectEnter);
        interactable.selectExited.AddListener(OnSelectExit);
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        behaviourState.OnHoverEnter(args);
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        behaviourState.OnHoverExit(args);
    }

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        behaviourState.OnGrab(args);
    }

    public void OnSelectExit(SelectExitEventArgs args)
    {
        behaviourState.OnRelease(args);
    }

    public void PlayHitAudio()
    {
        var hasAudio = TryGetComponent(out AudioSource audio);
        if (hasAudio)
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        }
    }

}
