using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates
{
    public class RewardState : OrbBehaviourState
    {
        OrbController OrbController;

        public RewardState(GameObject context)
        {
            this.context = context;
            OrbController = context.GetComponent<OrbController>();
        }

        public override void Start()
        {
            context.GetComponent<Rigidbody>().isKinematic = true;
            context.GetComponent<Collider>().isTrigger = false;
            OrbController.uiObjects.SetActive(true);
            OrbController.tooltip.SetActive(true);
        }

        public override void OnRelease(SelectExitEventArgs args)
        {
            if(OrbController.isHoveringDeck)
            {
                var attackSpawner = UnityEngine.Object.FindAnyObjectByType<AttackSpawner>();
                attackSpawner.AddNewAttack(OrbController.rewardPrefab);
                attackSpawner.RewardAura.SetActive(false);
                context.SetActive(false);
            }
        }
    }
}
