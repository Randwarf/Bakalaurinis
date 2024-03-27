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
        private float LIFESPAN_DURATION = 5f;
        private float lifespan = 0f;

        public FloatingOrbState(GameObject context, GameObject actionObjects) : base(context, actionObjects) { }

        public override void Update()
        {
            lifespan += Time.deltaTime;
            if (lifespan > LIFESPAN_DURATION)
            {
                UnityEngine.Object.Destroy(context);
            }
        }

        public override void OnRelease(SelectExitEventArgs args)
        {
            base.OnRelease(args);
            var rb = context.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }

        public override void End()
        {
            base.End();
            var rb = context.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
