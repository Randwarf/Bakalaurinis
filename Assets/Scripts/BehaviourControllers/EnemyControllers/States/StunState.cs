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
        private float _stunTime;

        public StunState(GameObject controller, BehaviourState previousState, float stunTime = 2f) 
        {
            context = controller;
            _previousState = previousState;
            context.GetComponent<MonsterController>().StunVisual.SetActive(true);
            _stunTime = stunTime;
        }

        public override void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _stunTime)
            {
                Unstun();
            }
        }

        private void Unstun()
        {
            context.GetComponent<MonsterController>().ChangeState(_previousState);
        }

        public override void Hit()
        {
            Unstun();
        }

        public override void End()
        {
            context.GetComponent<MonsterController>().StunVisual.SetActive(false);
        }
    }
}
