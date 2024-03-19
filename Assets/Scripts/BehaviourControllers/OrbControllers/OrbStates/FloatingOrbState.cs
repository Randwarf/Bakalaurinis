using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates
{
    public class FloatingOrbState : DirectHitState
    {
        public FloatingOrbState(GameObject context, GameObject actionObjects) : base(context, actionObjects) { }

        public override void OnRelease(SelectExitEventArgs args)
        {
            base.OnRelease(args);
            var rb = context.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
