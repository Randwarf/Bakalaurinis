using Assets.Custom_Scripts.EnemyControllers.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Custom_Scripts
{
    public class MuskratController : MonsterController, IDefensiveMonster
    {
        public PillarManager pillarManager;
        public TextMeshPro text;
        public GameObject shield;

        public bool isImmune = true;

        public void Start()
        {
            elementalType = Element.Normal;

            behaviourState = new DefendState(gameObject);
            behaviourState.Start();
        }

        public void DisableShields()
        {
            shield.SetActive(false);
            pillarManager.DisablePillars();
            isImmune = false;
        }

        public void EnableShields()
        {
            shield.SetActive(true);
            pillarManager.EnablePillars();
            isImmune = true;
        }

        internal void setSymbol(char v)
        {
            text.text = v.ToString();
        }

        public override void OnHit(int damage, Element attackerElement = Element.Normal)
        {
            if (isImmune) return;
            base.OnHit(damage, attackerElement);
        }


    }
}
