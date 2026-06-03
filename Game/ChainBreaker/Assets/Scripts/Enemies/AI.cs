using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //public GameObject Waypoint;
    NavMeshAgent agent;
    //public List<Vector3> waypoints;
    //public int waypointNumber = 0;
    public bool chasing = true;
    public GameObject player;
    public float chaseDistance = 5f;
    public float attackDistance = 5f;
    public bool patrolling = false;

    public float DistanceToPlayer;
    public bool attackReady = true;
    public GameObject attackBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        //GetWaypoints();
        //SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            
                player = GameObject.FindWithTag("Player");
                return;
            
        }
        else
        {
            DistanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, player.transform.position);

            //if (DistanceToPlayer < chaseDistance)
            //{
            //    chasing = true;
            //}
            if (chasing)
            {
                Chase();
                //patrolling = false;
            }
            if (DistanceToPlayer < attackDistance && attackReady)
            {
                agent.isStopped = true;
                agent.gameObject.transform.LookAt(player.gameObject.transform);
                StartCoroutine(Attack());
            }
            if (DistanceToPlayer > attackDistance && !patrolling)
            {
                agent.isStopped = false;
            }
        }
    //    if (patrolling)
    //    {
    //        if (agent.remainingDistance <= agent.stoppingDistance)
    //        {
    //            UpdateWaypoint();
    //        }
    //    }
        
    //}

    //void GetWaypoints()
    //{
    //    waypoints = new List<Vector3>();
    //    waypoints.Add(Waypoint.transform.position);
    //    foreach(Transform child in Waypoint.transform) {waypoints.Add(child.position);}
    //} 

    //void SetDestination()
    //{
    //    agent.destination = waypoints[waypointNumber];
    //}

    //void UpdateWaypoint()
    //{
        
    //        waypointNumber++;
    //        if (waypointNumber >= waypoints.Count) { waypointNumber = 0; }
    //        SetDestination();
        
    }

    void Chase()
    {

        //Vector3 point;
        //point = waypoints[waypointNumber];
        agent.destination = player.transform.position;

        //if (Vector3.Distance(agent.gameObject.transform.position, player.transform.position) > chaseDistance)
        //{
        //    chasing = false;
        //    agent.destination = point;
        //    patrolling = true;
        //}
    }

    private IEnumerator Attack()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackBox.SetActive(false);
        attackReady = false;
        StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        attackReady = true;
    }

}
