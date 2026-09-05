using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LightningEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player;
    public float attackDistance = 5f;
    public float DistanceToPlayer;
    public bool attackReady = true;
    


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }
   
    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(agent.gameObject.transform.position, player.transform.position);
        
    }

    private IEnumerator Attack()
    {
        attackReady = false;


        StartCoroutine(AttackDelay());
        return null;
    }
    private IEnumerator AttackDelay()
    {
        new WaitForSecondsRealtime(1.5f);
        attackReady = true;
        return null;
    }
}
