using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
<<<<<<< Updated upstream
    NavMeshAgent agent;
    
=======

    NavMeshAgent agent;
    

>>>>>>> Stashed changes
    public bool chasing = true;
    public GameObject player;
    public float attackDistance = 5f;
<<<<<<< Updated upstream
    public bool patrolling = false;
=======

>>>>>>> Stashed changes

    public float DistanceToPlayer;
    public bool attackReady = true;
    public GameObject attackBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        
<<<<<<< Updated upstream
    }
=======
>>>>>>> Stashed changes

    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
<<<<<<< Updated upstream
        {          
                player = GameObject.FindWithTag("Player");
                return;   
        }
        else
        {
            DistanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, player.transform.position);           
            if (chasing)
            {
                Chase();
            }
=======

        {
            player = GameObject.FindWithTag("Player");
            return;
        }
        else
        {
            DistanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, player.transform.position);
            agent.destination = player.transform.position;

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
    }
    void Chase()
    {
        agent.destination = player.transform.position;
=======
>>>>>>> Stashed changes
    }

    private IEnumerator Attack()
    {
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
