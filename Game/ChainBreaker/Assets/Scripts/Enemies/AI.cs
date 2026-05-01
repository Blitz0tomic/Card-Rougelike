using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject Waypoint;
    NavMeshAgent agent;
    public List<Vector3> waypoints;
    public int waypointNumber = 0;
    public float desiredDistance = .5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        agent.stoppingDistance = desiredDistance;
        if (agent.remainingDistance <= agent.stoppingDistance) 
        { 
            waypointNumber++; 
            if (waypointNumber > waypoints.Count) { waypointNumber = 0; }
            SetDestination(); 
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
}
