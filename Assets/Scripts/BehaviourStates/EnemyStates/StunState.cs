using Assets.Scripts.BehaviourControllers.EnemyControllers.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Custom_Scripts.EnemyControllers.Strategies
{
    public class StunState : MonsterBehaviourState
    {
        private MonsterBehaviourState _previousState;

        private float _elapsedTime = 0f;
        private float _stunTime;

        public StunState(GameObject controller, MonsterBehaviourState previousState, float stunTime = 2f) 
        {
            context = controller;
            _previousState = previousState;
            _stunTime = stunTime;
        }

        public override void Start()
        {
            base.Start();
            context.GetComponent<MonsterController>().StunVisual.SetActive(true);
            context.GetComponent<Rigidbody>().velocity = Vector3.zero;
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

        public override void GotHit()
        {
            Unstun();
        }

        public override void End()
        {
            context.GetComponent<MonsterController>().StunVisual.SetActive(false);
        }
    }
}
