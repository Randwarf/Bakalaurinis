using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BehaviourControllers.OrbControllers
{
    public class LightningOrbController : OrbController
    {
        public UIState UIState;

        public override void Start()
        {
            base.Start();
            UIState = new UIState();
        }
    }
}
