using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NoElementAI : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public GameObject player;
    public float attackDistance = 5f;
    public float DistanceToPlayer;
    public bool attackReady = true;
    public GameObject attackBox;
      
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        agent.speed = 3.5f;
    }
    // Update is called once per frame
    void Update()
    {       //track distance to player and chase them   
            DistanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, player.transform.position);
            agent.destination = player.transform.position;

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
        //enable attackBox briefly to deal damage, then start cooldown
        attackReady = false;
        attackBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackBox.SetActive(false);
        StartCoroutine(AttackDelay());
    }
    private IEnumerator AttackDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        attackReady = true;
    }
}
