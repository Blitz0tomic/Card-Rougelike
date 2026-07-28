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
        if (element == ElementType.Ice && frozen)
            damage = Mathf.RoundToInt(damage * iceVulnerabilityMultiplier);
        health -= damage;
        if (health <= 0) Die();
    }

    public IEnumerator ApplyFreeze(float duration)
    {
        frozen = true;
        agent.speed /= 2f;
        yield return new WaitForSeconds(duration);
        frozen = false;
        agent.speed *= 2f;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}