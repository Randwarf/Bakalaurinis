using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates
{
    public abstract class RewardOrbState : OrbBehaviourState
    {
        protected OrbController orbController;

        public RewardOrbState(GameObject context)
        {
            this.context = context;
            orbController = context.GetComponent<OrbController>();
        }

        public override void Start()
        {
            context.GetComponent<Rigidbody>().isKinematic = true;
            context.GetComponent<Collider>().isTrigger = false;
            orbController.uiObjects.SetActive(true);
            orbController.tooltip.SetActive(true);
        }

        public override void OnRelease(SelectExitEventArgs args)
        {
            if(orbController.isHoveringDeck)
            {
                AddAttack();
                var attackSpawner = UnityEngine.Object.FindAnyObjectByType<AttackSpawner>();
                attackSpawner.RewardAura.SetActive(false);
                context.SetActive(false);
            }
        }

        public abstract void AddAttack();
    }
}
