using Assets.Scripts.BehaviourControllers.EnemyControllers.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Custom_Scripts.EnemyControllers.Strategies
{
    public class JumpState : MonsterBehaviourState
    {
        private Rigidbody _rigidbody;
        private AudioSource _splatEffect;
        private float _timeSinceLastJump;
        private const float JUMP_INTERVAL = 3f;
        private const float JUMP_FORCE = 7f;

        
        public JumpState(GameObject gameObject)
        {
            context = gameObject;
            _rigidbody = context.GetComponent<Rigidbody>();
            _splatEffect = context.GetComponent<AudioSource>();
            _timeSinceLastJump = 0;
        }

        public override void Update()
        {
            _timeSinceLastJump += Time.deltaTime;

            if (_timeSinceLastJump > JUMP_INTERVAL)
            {
                Jump();
                _timeSinceLastJump = 0;
            }
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector3.up * JUMP_FORCE, ForceMode.Impulse);
            if (_splatEffect)
            {
                _splatEffect.Play();
            }
        }
    }
}
