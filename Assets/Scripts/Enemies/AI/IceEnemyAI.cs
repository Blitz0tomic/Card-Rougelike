using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class IceEnemyAI : MonoBehaviour
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
        
    }

    private IEnumerator Attack()
    {
        attackReady = false;


        StartCoroutine(AttackDelay());
        return null;
    }
    private IEnumerator AttackDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        attackReady = true;
    }
}
