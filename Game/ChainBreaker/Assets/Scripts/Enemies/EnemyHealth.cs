using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public AI ai;
    
    public int health = 100;
    public bool frozen = false;
    public float iceVulnerabilityMultiplier = 1.5f;

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
        GetComponent<NavMeshAgent>().speed /= 2f;
        yield return new WaitForSeconds(duration);
        frozen = false;
        GetComponent<NavMeshAgent>().speed *= 2f;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}