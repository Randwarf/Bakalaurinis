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
        public GameObject ReplacementPrefab;

        public override void Awake()
        {
            base.Awake();
            ActionState = new ExplodingOrbState(gameObject, actionObjects);
            ChangeState(UIState);

            damage = 20;
        }

        public void Replace()
        {
            Instantiate(ReplacementPrefab, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
