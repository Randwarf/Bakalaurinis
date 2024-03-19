using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets.Scripts.BehaviourControllers.OrbControllers
{
    public abstract class ActionState : OrbBehaviourState
    {
        public OrbController controller;
        public GameObject actionObjects;

        public ActionState(GameObject context, GameObject actionObjects)
        {
            this.context = context;
            this.actionObjects = actionObjects;
            controller = context.GetComponent<OrbController>();
        }

        public abstract void HitTarget(IHitableObject hitableObject);

        public override void OnRelease(SelectExitEventArgs args)
        {
            //return to deck; else
            context.GetComponent<Rigidbody>().isKinematic = false;
            var spawner = UnityEngine.Object.FindAnyObjectByType<AttackSpawner>();
            spawner.Spawn(controller.UISlot);
            actionObjects.SetActive(true);
            context.transform.parent = null;
        }

        public override void Start()
        {
            context.GetComponent<Rigidbody>().isKinematic = false;
        }

        public override void End()
        {
            actionObjects.SetActive(false);
        }

        public override void OnCollisionEnter(Collision collision)
        {
            var isHitable = collision.gameObject.TryGetComponent(out IHitableObject hitableObject);
            if (isHitable)
                HitTarget(hitableObject);
        }
    }
}
