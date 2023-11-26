using Assets.Custom_Scripts.EnemyControllers.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Custom_Scripts
{
    public class SquidController : MonsterController
    {
        public InkApplier inkEffect;
        public float timeSinceLastInk = 0f;
        public float inkDelay = 10f;

        public void Start()
        {
            movementStrategy = new JumpStrategy(GetComponent<Rigidbody>());
            elementalType = Element.Water;
            inkEffect = GetComponent<InkApplier>();
        }

        public void Update()
        {
            movementStrategy.Move();
            timeSinceLastInk += Time.deltaTime;
            if (timeSinceLastInk > inkDelay )
            {
                inkEffect.ActivateInkEffect();
                timeSinceLastInk = 0f;
            }
        }
    }
}
