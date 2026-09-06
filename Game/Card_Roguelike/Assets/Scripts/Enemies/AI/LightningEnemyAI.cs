using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LightningEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player;
    public float attackDistance = 100f;
    public float DistanceToPlayer;
    public bool attackReady = true;

    public ProjectileSpawner projectile;
    public float bulletSpeed = 50f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        projectile = GetComponent<ProjectileSpawner>();
        agent.speed = 7;
        agent.autoBraking = true;
    }
   
    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, player.transform.position);
        Vector3 directionFromPlayer = (agent.transform.position - player.transform.position).normalized;
        Vector3 standoffPoint = player.transform.position + directionFromPlayer * attackDistance;
        agent.destination = standoffPoint;

        //stop and attack if within range and not on cooldown
        if (DistanceToPlayer < attackDistance && attackReady)
        {
            agent.isStopped = true;
            agent.gameObject.transform.LookAt(player.gameObject.transform);
            StartCoroutine(Attack());
        }
        if (DistanceToPlayer > attackDistance)
        {
            agent.isStopped = false;
        }

    }

    private IEnumerator Attack()
    {
        attackReady = false;
        projectile.Spawn(10, ElementType.Lightning, bulletSpeed);

        StartCoroutine(AttackDelay());
        yield break;
    }
    private IEnumerator AttackDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        attackReady = true;
    }
}
