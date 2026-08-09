using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public bool frozen = false;
    public float iceVulnerabilityMultiplier = 1.5f;

    public NavMeshAgent agent;

    public void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damage, ElementType element)
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

    private void Die()
    {
        Destroy(gameObject);
    }
}