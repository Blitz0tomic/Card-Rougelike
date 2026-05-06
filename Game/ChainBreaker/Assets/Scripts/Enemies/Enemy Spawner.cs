using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    waypoints = new List<Vector3>();
    bool spawnable = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy.transform.position = new Vector3(0.65f,2.01f,12.39f);
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
clone GetComponent<AI>.waypoints = GameObject.FindGameObjectsWithTag("WaypointParent");
        yield return new WaitForSecondsRealtime(1.5f);
        spawnable = true;
    }
}
