using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject waypoints;
    bool spawnable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy.transform.position = new Vector3(0.65f,2.01f,12.39f);
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spawnable)
        {
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        spawnable = false;
        GameObject clone = Instantiate(enemy);
        waypoints = GameObject.FindGameObjectWithTag("WaypointParent");
        clone.GetComponent<AI>().Waypoint = waypoints;
        yield return new WaitForSecondsRealtime(10f);
        spawnable = true;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(10f);
        spawnable = true;
    }
}
