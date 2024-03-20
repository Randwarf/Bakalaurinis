using UnityEngine;

namespace Assets.Scripts.BehaviourControllers.OrbControllers
{
    /// <summary>
    /// Requires IReplaceableOrb implementation
    /// </summary>
    public class ExplodingOrbState : ActionState
    {
        public ExplodingOrbState(GameObject context, GameObject actionObjects) : base(context, actionObjects) { }

        public override void HitTarget(IHitableObject hitableObject)
        {
            context.GetComponent<IReplaceableOrb>().Replace();
        }
    }
}