using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MeleeKnockback : MonoBehaviour
{


    public float knockbackForce = 10f;
    public float disableDuration = 5f;
    void OnTriggerEnter(Collider enemy) 
    {
        if (enemy.CompareTag("Enemy"))
        {
            StartCoroutine(KnockbackRoutine(enemy));
        }

    }

    public IEnumerator KnockbackRoutine(Collider enemy)
    {
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        agent.enabled = false;
        rb.isKinematic = false;
        Vector3 direction = enemy.transform.position - transform.position;
        direction.y = 0f;
        rb.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);

        yield return new WaitForSeconds(disableDuration);

        rb.isKinematic = true;
        agent.Warp(enemy.transform.position);
        agent.enabled = true;
    }

}

