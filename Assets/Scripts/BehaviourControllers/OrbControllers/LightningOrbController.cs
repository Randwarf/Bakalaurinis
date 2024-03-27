using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BehaviourControllers.OrbControllers
{
    public class LightningOrbController : OrbController
    {
        
        public override void Awake()
        {
            base.Awake();
            ActionState = new DirectHitState(gameObject, actionObjects);
        }
    }
}
