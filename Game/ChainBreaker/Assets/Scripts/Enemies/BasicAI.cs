using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;

    public Transform waypointParent = null;
    public List<Transform> waypoints = new List<Transform>();
    public int curWaypointInList = 0;
    public float desiredRemainingDistance = 1f;
    public bool ChasingPlayer = false;
    public bool ableToChasePlayer = true;
    public float distanceToTarget;
    public float distanceToPlayer;
    public float chasingDistance = 5f;


    void Start()
    {
        waypoints.Clear();
        waypoints.AddRange(waypointParent.GetComponentsInChildren<Transform>());

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[curWaypointInList].position);

        StartCoroutine(AILogic());
    }
    private IEnumerator AILogic()
    {
        while (true)
        {
            yield return null;
            distanceToPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
            distanceToTarget = Vector3.Distance(waypoints[curWaypointInList % waypoints.Count].position, gameObject.transform.position);

            CheckDest();
        }
    }

    private void CheckDest()
    {
        if (!ChasingPlayer && distanceToPlayer <= chasingDistance && ableToChasePlayer)
            ChasingPlayer = true;

        else if (distanceToPlayer > chasingDistance)
        {
            if (ChasingPlayer)
            {
                StartCoroutine(ChaseWait());
            }
            ChasingPlayer = false;

        }

        if (ChasingPlayer && distanceToPlayer <= desiredRemainingDistance)
        {
            ChasingPlayer = false; StartCoroutine(ChaseWait());
        }

        if (ChasingPlayer)
        {
            agent.SetDestination(player.transform.position);
            return;
        }

        print("Not chasing player");
        if ((agent.remainingDistance <= desiredRemainingDistance  && !agent.pathPending) && !ChasingPlayer  )
        {
            curWaypointInList++;
            //curDestination = waypoints[curWaypointInList % waypoints.Count].position;
            agent.SetDestination(waypoints[curWaypointInList % waypoints.Count].position);
            return;
        }
        //print("Returning to waypoint loop");
        if (!agent.pathPending)
            agent.SetDestination(waypoints[curWaypointInList % waypoints.Count].position);
    }
    IEnumerator ChaseWait()
    {
        ableToChasePlayer = false;
        print("not able to chase");
        yield return new WaitForSeconds(2f);
        ableToChasePlayer = true;
        print("able to chase");


    }
}
