using Assets.Custom_Scripts.EnemyControllers.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MonsterController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public BehaviourState behaviourState;
    protected Element elementalType;

    public GameObject RewardPedestal;
    [SerializeField]
    protected List<GameObject> Rewards = new List<GameObject>();

    [SerializeField]
    protected GameObject Throphy;

    public GameObject StunVisual;

    // Update is called once per frame
    void Update()
    {
        behaviourState.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        behaviourState.OnCollisionEnter(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        behaviourState.OnCollisionExit(collision);
    }

    public virtual void OnHit(int damage, Element attackerElement = Element.Normal)
    {

        float effectiveness = ElementalEffectiveness.GetEffectiveness(attackerElement, elementalType);
        currentHealth -= (int)(damage * effectiveness);

        if (currentHealth <= 0)
        {
            Die();
        }

        var uiController = FindAnyObjectByType<HealthUIController>();
        if (uiController) uiController.UpdateHealth(currentHealth, maxHealth);
        
    }

    private void Die()
    {
        Destroy(gameObject);
        Vector3 rewardPos = transform.position;
        rewardPos.y = 0;
        var pedestal = Instantiate(RewardPedestal, rewardPos, Quaternion.identity);
        pedestal.GetComponent<RewardSpawner>().SpawnRewards(Rewards);
        Instantiate(Throphy, GameObject.Find("ThrophySpawner").transform.position, UnityEngine.Random.rotation);
    }

    public void Stun()
    {
        ChangeState(new StunState(gameObject, behaviourState));
    }

    public void ChangeState(BehaviourState newState)
    {
        behaviourState.End();
        behaviourState = newState;
        behaviourState.Start();
    }
}
