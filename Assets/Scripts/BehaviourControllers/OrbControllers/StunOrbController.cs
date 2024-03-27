using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BehaviourControllers.OrbControllers
{
    public class StunOrbController : OrbController
    {
        public override void Awake()
        {
            base.Awake();

            canStun = true;
            damage = 10;
            element = Element.Normal;

            ActionState = new DirectHitState(gameObject, actionObjects);
        }
    }
}
