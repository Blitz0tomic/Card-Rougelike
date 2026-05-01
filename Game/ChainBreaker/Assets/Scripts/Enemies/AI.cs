using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject Waypoint;
    NavMeshAgent agent;
    public List<Vector3> waypoints;
    public int waypointNumber = 0;
    public float desiredDistance = .5f;
    public bool chasing = false;
    public GameObject player;
    public float chaseDistance = 5f;
    public bool patroling;

    public float DistanceToPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetWaypoints();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        agent.stoppingDistance = desiredDistance;

       DistanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, player.transform.position);

        if ((DistanceToPlayer) < chaseDistance)
        {
            chasing = true;
        }
        if (chasing)
        {
            Chase();
        }
        if (patroling)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                UpdateWaypoint();
            }
        }
        
    }

    void GetWaypoints()
    {
        waypoints = new List<Vector3>();
        waypoints.Add(Waypoint.transform.position);
        foreach(Transform child in Waypoint.transform) {waypoints.Add(child.position);}
    } 

    void SetDestination()
    {
        agent.destination = waypoints[waypointNumber];
    }

    void UpdateWaypoint()
    {
        
            waypointNumber++;
            if (waypointNumber > waypoints.Count) { waypointNumber = 0; }
            SetDestination();
        
    }

    void Chase()
    {

        Vector3 point;
        point = waypoints[waypointNumber];
        agent.destination = player.transform.position;

        if (Vector3.Distance(agent.gameObject.transform.position, player.transform.position) > chaseDistance)
        {
            chasing = false;
            agent.destination = point;
        }
    }


}
