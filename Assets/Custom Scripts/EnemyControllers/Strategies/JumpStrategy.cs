using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Custom_Scripts.EnemyControllers.Strategies
{
    public class JumpStrategy : IEnemyMovementStrategy
    {
        private Rigidbody _rigidbody;
        private float _timeSinceLastJump;
        private float _jumpInterval = 3f;
        private float _jumpForce = 7f;

        private bool _isLooping = true;
        
        public JumpStrategy(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            _timeSinceLastJump = 0;
        }

        public bool DoneMoving()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            if (_isLooping == false) return;

            _timeSinceLastJump += Time.deltaTime;

            if (_timeSinceLastJump > _jumpInterval)
            {
                Jump();
                _timeSinceLastJump = 0;
            }
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        public void SetLooping(bool looping)
        {
            _isLooping = looping;
        }
    }
}
