using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public bool frozen = false;
    public float iceVulnerabilityMultiplier = 1.5f;

    public NavMeshAgent agent;

    public void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage, ElementType element)
    {
        //take extra damage from ice attacks while already frozen
        if (element == ElementType.Ice && frozen)
        {
            damage = Mathf.RoundToInt(damage * iceVulnerabilityMultiplier);
        }
        health -= damage;
        if (health <= 0) 
        { 
            Die(); 
        }
    }

    //apply the frozen debuff, which slows the enemy
    public IEnumerator ApplyFreeze(float duration)
    {
        if (!frozen)
        {
            frozen = true;
            var tempSpeed = agent.speed;
            agent.speed /= 2f;
            yield return new WaitForSeconds(duration);
            frozen = false;
            agent.speed = tempSpeed;
        }
    }

    //apply a damage over time Debuff
    public IEnumerator ApplyBurn(float damagePerTick, float tickInterval, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            yield return new WaitForSeconds(tickInterval);
            TakeDamage(damagePerTick, ElementType.Fire);
            elapsed += tickInterval;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}