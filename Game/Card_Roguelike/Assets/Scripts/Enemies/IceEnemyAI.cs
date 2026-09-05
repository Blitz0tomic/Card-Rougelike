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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
