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

        var originalScale = context.transform.localScale;
        context.transform.localScale = Vector3.zero;
        context.transform.LeanScale(originalScale, 0.5f).setEaseOutSine();
    }

    private void ActivateUIObjects()
    {
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
