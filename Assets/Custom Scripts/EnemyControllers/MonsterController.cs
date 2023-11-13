using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    protected IEnemyMovementStrategy movementStrategy;
    protected Element elementalType;

    // Update is called once per frame
    void Update()
    {
        movementStrategy.Move();
    }

    public void OnHit(int damage, Element attackerElement = Element.Normal)
    {
        float effectiveness = ElementalEffectiveness.GetEffectiveness(attackerElement, elementalType);
        currentHealth -= (int)(damage * effectiveness);
        FindAnyObjectByType<HealthUIController>().UpdateHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
