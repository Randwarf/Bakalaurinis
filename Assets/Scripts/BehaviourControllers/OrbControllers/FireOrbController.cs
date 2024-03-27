using Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BehaviourControllers.OrbControllers
{
    public class FireOrbController : OrbController, IReplaceableOrb
    {
        public ExplosionController explosionPrefab;

        public override void Awake()
        {
            base.Awake();
            ActionState = new ExplodingOrbState(gameObject, actionObjects);

            damage = 20;
            element = Element.Fire;
        }

        public void Replace()
        {
            var explosion = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            explosion.damage = damage;
            explosion.element = element;

            Destroy(gameObject);
        }
    }
}
