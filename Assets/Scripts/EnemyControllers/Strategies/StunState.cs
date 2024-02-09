using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Custom_Scripts.EnemyControllers.Strategies
{
    public class StunState : BehaviourState
    {
        private BehaviourState _previousState;

        private float _elapsedTime = 0f;
        private float _stunTime = 2f;

        public StunState(GameObject controller, BehaviourState previousState) 
        {
            context = controller;
            _previousState = previousState;
            context.GetComponent<MonsterController>().StunVisual.SetActive(true);
        }

        public override void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _stunTime)
            {
                context.GetComponent<MonsterController>().behaviourState = _previousState;
                context.GetComponent<MonsterController>().StunVisual.SetActive(false);
            }
        }
    }
}
