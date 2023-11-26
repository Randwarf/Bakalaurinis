using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Custom_Scripts.EnemyControllers.Strategies
{
    public class StunStrategy : IEnemyMovementStrategy
    {
        private MonsterController _monsterController;
        private IEnemyMovementStrategy _nextStrategy;

        private float _elapsedTime = 0f;
        private float _stunTime = 2f;

        public StunStrategy(MonsterController controller, IEnemyMovementStrategy nextStragegy) 
        {
            _monsterController= controller;
            _nextStrategy = nextStragegy;
            _monsterController.StunVisual.SetActive(true);
        }

        public bool DoneMoving()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime> _stunTime)
            {
                _monsterController.movementStrategy = _nextStrategy;
                _monsterController.StunVisual.SetActive(false);
            }
        }

        public void SetLooping(bool looping)
        {
            throw new NotImplementedException();
        }
    }
}
