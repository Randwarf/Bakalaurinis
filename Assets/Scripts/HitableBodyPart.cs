using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class HitableBodyPart : MonoBehaviour, IHitableObject
    {
        public float DamageMultiplier = 1f;
        public MonsterController Controller;

        public void Start()
        {
            Controller = GetComponentInParent<MonsterController>();
        }

        public void Hit(int damage, Element element, bool stun)
        {
            Controller.OnHit(damage * DamageMultiplier, element);
            if (stun)
            {
                Controller.Stun();
            }
        }
    }
}
