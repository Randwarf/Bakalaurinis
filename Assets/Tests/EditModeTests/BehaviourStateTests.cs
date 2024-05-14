using System.Collections;
using System.Collections.Generic;
using Assets.Custom_Scripts;
using Assets.Custom_Scripts.EnemyControllers.Strategies;
using Assets.Scripts.BehaviourControllers.OrbControllers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.TestTools;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class BehaviourStateTests<TBehaviourState> where TBehaviourState : BehaviourState
{
    public abstract TBehaviourState CreateState(GameObject context);
    public abstract GameObject CreateContext();
    public Vector3 GetStartingPosition() { return Vector3.zero; }
    public abstract Vector3 ExpectedPositionAfterUpdate();
    protected abstract bool ObjectStartedAsIntended();
    protected abstract bool ObjectEndedAsIntended();

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator ObjectIsInExpectedPositionAfterUpdate()
    {
        var context = CreateContext();
        var state = CreateState(context);

        yield return null;
        state.Update();
        yield return null;

        Assert.AreEqual(ExpectedPositionAfterUpdate(), context.transform.position);
    }

    [UnityTest]
    public IEnumerator ObjectStartsAsIntended()
    {
        var context = CreateContext();
        yield return null;
        var state = CreateState(context);

        yield return null;
        state.Start();
        yield return null;

        Assert.IsTrue(ObjectStartedAsIntended());
    }

    [UnityTest]
    public IEnumerator ObjectEndsAsIntended()
    {
        var context = CreateContext();
        yield return null;
        var state = CreateState(context);

        yield return null;
        state.Start();
        yield return null;
        state.End();
        yield return null;

        Assert.IsTrue(ObjectEndedAsIntended());
    }

}

public class DefendStateTests : BehaviourStateTests<DefendState>
{
    DefensiveMock defensive;

    public override GameObject CreateContext()
    {
        var gameObject = new GameObject();
        defensive = gameObject.AddComponent<DefensiveMock>();
        gameObject.transform.position = GetStartingPosition();
        return gameObject;
    }

    public override DefendState CreateState(GameObject context)
    {
        return new DefendState(context);
    }

    public override Vector3 ExpectedPositionAfterUpdate()
    {
        return GetStartingPosition();
    }

    protected override bool ObjectStartedAsIntended()
    {
        return defensive.shieldEnabled == true;
    }

    protected override bool ObjectEndedAsIntended()
    {
        return defensive.shieldEnabled == false;
    }
}

public class StunStateTests : BehaviourStateTests<StunState>
{
    MockMonsterController controller;
    Rigidbody rb;

    public override GameObject CreateContext()
    {
        var gameObject = new GameObject("Monster");
        controller = gameObject.AddComponent<MockMonsterController>();
        controller.Start();
        rb = gameObject.AddComponent<Rigidbody>();

        gameObject.transform.position = GetStartingPosition();
        return gameObject;
    }

    public override StunState CreateState(GameObject context)
    {
        return new StunState(context, new DefendState(context), 5f);
    }

    public override Vector3 ExpectedPositionAfterUpdate()
    {
        return GetStartingPosition();
    }

    protected override bool ObjectEndedAsIntended()
    {
        return controller.StunVisual.activeSelf == false;
    }

    protected override bool ObjectStartedAsIntended()
    {
        return rb.velocity == Vector3.zero &&
            controller.StunVisual.activeSelf == true;
    }
}

public class DirectHitStateTests : BehaviourStateTests<DirectHitState>
{
    MockOrbController controller;
    public Rigidbody rb;
    public Collider col;
    public XRGrabInteractable inter;

    public override GameObject CreateContext()
    {
        var gameObject = new GameObject("DirectHitTest");
        rb = gameObject.AddComponent<Rigidbody>();
        col = gameObject.AddComponent<BoxCollider>();
        inter = gameObject.AddComponent<XRGrabInteractable>();
        controller = gameObject.AddComponent<MockOrbController>();
        controller.Start();

        gameObject.transform.position = GetStartingPosition();
        return gameObject;
    }

    public override DirectHitState CreateState(GameObject context)
    {
        return new DirectHitState(context, controller.actionObjects);
    }

    public override Vector3 ExpectedPositionAfterUpdate()
    {
        return GetStartingPosition();
    }

    protected override bool ObjectEndedAsIntended()
    {
        return controller.actionObjects.activeSelf == false;
    }

    protected override bool ObjectStartedAsIntended()
    {
        return rb.isKinematic == false &&
            col.isTrigger == true &&
            inter.throwVelocityScale == 5;
    }
}

public class DefensiveMock : MonoBehaviour, IDefensiveMonster
{
    public bool shieldEnabled = false;

    public void DisableShields()
    {
        shieldEnabled = false;
    }

    public void EnableShields()
    {
        shieldEnabled = true;
    }
}

public class MockOrbController : OrbController
{
    public void Start()
    {
        actionObjects = new GameObject();
        actionObjects.SetActive(true);
    }
}

public class MockMonsterController : MonsterController
{
    public void Start()
    {
        StunVisual = new GameObject();
    }
}
