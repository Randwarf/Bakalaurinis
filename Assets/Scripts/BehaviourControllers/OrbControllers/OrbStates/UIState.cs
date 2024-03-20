using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIState : OrbBehaviourState
{
    private OrbController OrbController;

    public UIState(GameObject context, GameObject UIObjects)
    {
        this.context = context;
        OrbController = context.GetComponent<OrbController>();
    }

    public override void Start()
    {
        context.GetComponent<Rigidbody>().isKinematic = true;
        context.GetComponent<Collider>().isTrigger = false;
        OrbController.uiObjects.SetActive(true);
    }

    public override void End()
    {
        OrbController.uiObjects.SetActive(false);
    }

    public override void OnHoverEnter(HoverEnterEventArgs args)
    {
        OrbController.tooltip.SetActive(true);
    }

    public override void OnHoverExit(HoverExitEventArgs args)
    {
        OrbController.tooltip.SetActive(false);
    }

    public override void OnGrab(SelectEnterEventArgs args)
    {
        OrbController.ChangeState(OrbController.ActionState);
    }
}
