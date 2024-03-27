using Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BehaviourStates.OrbStates
{
    public class PedestalOrbState : RewardOrbState
    {
        public PedestalOrbState(GameObject context) : base(context) { }

        public override void AddAttack()
        {
            var deck = GameObject.FindAnyObjectByType<AttackSpawner>();
            deck.AddNewAttack(orbController.rewardPrefab);
        }
    }
}
