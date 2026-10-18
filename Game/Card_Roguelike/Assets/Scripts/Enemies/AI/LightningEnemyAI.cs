
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class LightningEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float attackDistance = 15f;
    public float distanceToPlayer;
    public float randomLocationRadius;
    public bool attackReady = true;
    public ProjectileSpawner projectile;
    public float bulletSpeed = 50f;
    public AIMode mode = AIMode.Attack;
    public int timesAttacked = 0;
    public Vector3 randomLocation;
    private float normalModeStartTime;
    public float normalTime = 5f;
    public bool graceOver = false;

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
        distanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, player.transform.position);
        randomLocationRadius = distanceToPlayer;
        Vector3 directionFromPlayer = (agent.transform.position - player.transform.position).normalized;
        Vector3 standoffPoint = player.transform.position + directionFromPlayer * (attackDistance - 3);
        #region Attack Mode
        if (mode == AIMode.Attack)
        {
            agent.destination = standoffPoint;
        //stop and attack if within range and not on cooldown
        if (distanceToPlayer < attackDistance && attackReady)
            {
                agent.isStopped = true;
                agent.gameObject.transform.LookAt(player.gameObject.transform);
                StartCoroutine(Attack());
            }
            if (distanceToPlayer > attackDistance)
            {
                agent.isStopped = false;
            }
        }
        #endregion
        #region Normal Mode
        if (mode == AIMode.Normal)
        {
            graceOver = Time.time - normalModeStartTime >= normalTime;
            if (agent.remainingDistance <= 1f && !agent.pathPending)
            {
                GenerateRandomLocation();
            }
            if (distanceToPlayer <= attackDistance + 10 && graceOver) 
            {
                ChangeMode(AIMode.Attack); 
            }
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
            graceOver = false;
            GenerateRandomLocation();
            normalModeStartTime = Time.time;
}
        if (targetMode == AIMode.Attack) 
        { 
            timesAttacked = 0; 
        }
        mode = targetMode;
    }
    void GenerateRandomLocation()
    {
        randomLocation.x = transform.position.x + Random.Range(-randomLocationRadius, randomLocationRadius);
        randomLocation.y = transform.position.y;
        randomLocation.z = transform.position.z + Random.Range(-randomLocationRadius, randomLocationRadius);
        if (NavMesh.SamplePosition(randomLocation, out NavMeshHit hit, 2f, NavMesh.AllAreas))
        {
            agent.destination = hit.position;
        }   
    }
    
}