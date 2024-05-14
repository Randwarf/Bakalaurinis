using Assets.Custom_Scripts.EnemyControllers.Strategies;
using Assets.Scripts.BehaviourControllers.EnemyControllers.States;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MonsterController : BehaviourController<MonsterBehaviourState>
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    
    protected Element elementalType;

    public GameObject RewardPedestal;
    [SerializeField]
    protected List<GameObject> Rewards = new List<GameObject>();

    [SerializeField]
    public GameObject Throphy;

    public GameObject StunVisual;

    public virtual void OnHit(int damage, Element attackerElement = Element.Normal)
    {
        behaviourState.GotHit();

        float effectiveness = ElementalEffectiveness.GetEffectiveness(attackerElement, elementalType);
        currentHealth -= (int)(damage * effectiveness);

        if (currentHealth <= 0)
        {
            Die();
        }

        var uiController = FindAnyObjectByType<HealthUIController>();
        if (uiController) uiController.UpdateHealth(currentHealth, maxHealth);
    }

    public void OnHit(float damage, Element attackerElement = Element.Normal)
    {
        OnHit((int)damage, attackerElement);
    }

    private void Die()
    {
        Destroy(gameObject);
        SpawnReward();
        Instantiate(Throphy, GameObject.Find("ThrophySpawner").transform.position, UnityEngine.Random.rotation);
        FindAnyObjectByType<Timer>().TurnOff();
        FindAnyObjectByType<StatManager>().UpdateWinStreak(Level.GetInstance().numberOfLoops + 1);
    }

    private void SpawnReward()
    {
        Vector3 rewardPos = transform.position;
        rewardPos.y = 0;
        var pedestal = Instantiate(RewardPedestal, rewardPos, Quaternion.identity);
        pedestal.GetComponent<RewardSpawner>().SpawnRewards(Rewards);
    }

    public void Stun(float time = 2f)
    {
        ChangeState(new StunState(gameObject, behaviourState, time));
    }

    public void Lose()
    {
        FindAnyObjectByType<BlinkEffect>().AnimateEyeClosed(Level.GetInstance().TeleportToSpawn);
    }
}
