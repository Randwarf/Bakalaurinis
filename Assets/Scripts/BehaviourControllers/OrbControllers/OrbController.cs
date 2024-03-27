using Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates;
using Assets.Scripts.BehaviourStates.OrbStates;
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
    public GameObject rewardPrefab;
    [NonSerialized]
    public Transform UISlot;
    [NonSerialized]
    public bool isHoveringDeck;
    [NonSerialized]
    public bool isGrabbed = false;

    [NonSerialized]
    public OrbBehaviourState UIState;
    [NonSerialized]
    public OrbBehaviourState ActionState;
    [NonSerialized]
    public OrbBehaviourState RewardState;

    private XRGrabInteractable interactable;

    /// <summary>
    /// Assign states that might be used in the life time of the orb
    /// ChangeState() is called by an object that instantiates the orb - some orbs might start in UIState, others in RewardState
    /// </summary>
    public virtual void Awake()
    {
        AddGrabInteractableListeners();

        UIState = new UIState(gameObject, uiObjects);
        RewardState = new PedestalOrbState(gameObject);
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
        isGrabbed = true;
        behaviourState.OnGrab(args);
    }

    public void OnSelectExit(SelectExitEventArgs args)
    {
        isGrabbed = false;
        behaviourState.OnRelease(args);
    }
}
