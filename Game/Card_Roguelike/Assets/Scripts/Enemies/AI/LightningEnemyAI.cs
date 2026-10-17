
using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class LightningEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player;
    public float attackDistance = 15f;
    public float DistanceToPlayer;
    public bool attackReady = true;

    public ProjectileSpawner projectile;
    public float bulletSpeed = 50f;
    public AIMode mode = AIMode.Attack;

    public int timesAttacked = 0;

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
        Vector3 standoffPoint = player.transform.position + directionFromPlayer * (attackDistance - 3);
        #region Attack Mode
        if (mode == AIMode.Attack)
        {
            
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
        #endregion
        #region Normal Mode

        if (mode == AIMode.Normal)
        {
            ChangeMode(AIMode.Attack);
        }
        #endregion
    }

    private IEnumerator Attack()
    {
        timesAttacked++;
        attackReady = false;
        projectile.Spawn(10, ElementType.Lightning, bulletSpeed);
        StartCoroutine(AttackDelay());
        if(timesAttacked == 3)
        { 
            ChangeMode(AIMode.Normal); 
        }
        yield break;
    }
    private IEnumerator AttackDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        attackReady = true;
    }

    void ChangeMode(AIMode targetMode)
    {
        if (targetMode == AIMode.Normal) 
        {
            agent.isStopped = false;
        }
        if (targetMode == AIMode.Attack) 
        { 
            timesAttacked = 0; 
        }
        mode = targetMode;
    }
}