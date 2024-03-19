using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OrbBehaviourState : BehaviourState
{
    public virtual void OnHoverEnter(HoverEnterEventArgs args) { }
    public virtual void OnHoverExit(HoverExitEventArgs args) { }
    public virtual void OnGrab(SelectEnterEventArgs args) { }
    public virtual void OnRelease(SelectExitEventArgs args) { }
}
