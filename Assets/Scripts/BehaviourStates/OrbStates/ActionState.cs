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

        public virtual void HitTarget(IHitableObject hitableObject)
        {
            PlayHitAudio();
        }

        public override void OnRelease(SelectExitEventArgs args)
        {
            if (controller.isHoveringDeck)
            {
                context.transform.LeanMoveLocal(Vector3.zero, 0.1f);
                controller.ChangeState(controller.UIState);
                return;
            }

            context.GetComponent<Rigidbody>().isKinematic = false;
            var spawner = UnityEngine.Object.FindAnyObjectByType<AttackSpawner>();
            spawner.Spawn(controller.UISlot);
            actionObjects.SetActive(true);
            context.transform.parent = null;
        }

        public override void Start()
        {
            context.GetComponent<Rigidbody>().isKinematic = false;
            context.GetComponent<Collider>().isTrigger = true;
            context.GetComponent<XRGrabInteractable>().throwVelocityScale = 5;
        }

        public override void End()
        {
            actionObjects.SetActive(false);
        }

        public override void OnTriggerEnter(Collider other)
        {
            var isHitable = other.gameObject.TryGetComponent(out IHitableObject hitableObject);
            if (isHitable)
                HitTarget(hitableObject);
        }

        public void PlayHitAudio()
        {
            var hasAudio = context.TryGetComponent(out AudioSource audio);
            if (hasAudio)
            {
                AudioSource.PlayClipAtPoint(audio.clip, context.transform.position);
            }
        }
    }
}
