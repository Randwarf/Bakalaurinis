using Assets.Scripts.BehaviourControllers.OrbControllers.OrbStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BehaviourStates.OrbStates
{
    public class EquipableOrbState : RewardOrbState
    {
        public EquipableOrbState(GameObject context) : base(context) { }

        public override void Start()
        {
            base.Start();
            
            context.GetComponent<Rigidbody>().isKinematic = false;
            context.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.insideUnitSphere);
        }

        public override void AddAttack()
        {
            var deck = GameObject.FindAnyObjectByType<AttackSpawner>();
            AttackSpawner.attackPrefabsInDeck.Add(orbController.rewardPrefab);
            if (AttackSpawner.Teleporter != null)
            {
                AttackSpawner.Teleporter.SetActive(true);
            }
        }
    }
}
