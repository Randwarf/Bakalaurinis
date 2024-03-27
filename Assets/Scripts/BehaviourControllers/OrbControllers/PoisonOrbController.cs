using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BehaviourControllers.OrbControllers
{
    public class PoisonOrbController : OrbController, IReplaceableOrb
    {
        public PuddleController puddlePrefab;

        public override void Awake()
        {
            base.Awake();
            ActionState = new ExplodingOrbState(gameObject, actionObjects);
            
            damage = 5;
            element = Element.Water;
        }

        public void Replace()
        {
            var puddle = Instantiate(puddlePrefab, this.transform.position, Quaternion.identity);
            puddle.transform.rotation = Quaternion.Euler(0, 0, 0);
            puddle.damage = damage;
            puddle.element = element;
            puddle.cooldown = 0.5f;
            puddle.durability = 5;

            Destroy(gameObject);
        }
    }
}
