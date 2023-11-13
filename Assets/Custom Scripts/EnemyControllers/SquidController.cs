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
        public void Start()
        {
            movementStrategy = new JumpStrategy(GetComponent<Rigidbody>());
            elementalType = Element.Water;
        }
    }
}
