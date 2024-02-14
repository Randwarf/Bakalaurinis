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
    public class MuskratController : MonsterController
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

        internal void DisableShields()
        {
            shield.SetActive(false);
            ChangeState(new StunState(gameObject, behaviourState, 5f));
            pillarManager.DisablePillars();
        }

        internal void EnableShields()
        {
            shield.SetActive(true);
            pillarManager.EnablePillars();
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
