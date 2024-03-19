using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BehaviourControllers.OrbControllers
{
    public class DirectHitState : ActionState
    {
        public DirectHitState(GameObject context, GameObject actionsObjects) : base(context, actionsObjects) { }

        public override void HitTarget(IHitableObject hitableObject)
        {
            hitableObject.Hit(controller.damage, controller.element, controller.canStun);
            controller.PlayHitAudio();
            UnityEngine.Object.Destroy(context);
        }
    }
}
