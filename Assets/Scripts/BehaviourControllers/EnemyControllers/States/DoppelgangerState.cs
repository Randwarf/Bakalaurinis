using Assets.Scripts.BehaviourControllers.EnemyControllers.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EnemyControllers.States
{
    public class DoppelgangerState : MonsterBehaviourState
    {
        public DoppelgangerState(GameObject context) 
        {
            this.context = context;
        }
    }
}
