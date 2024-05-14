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
        public float timeSinceLastInk = 0f;
        public float inkDelay = 10f;

        public void Start()
        {
            ChangeState(new JumpState(gameObject));
            elementalType = Element.Water;
            transform.localPosition += new Vector3(0, 1, 0);
        }
    }
}
