using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
   
    bool spawnReady = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy.transform.position = gameObject.transform.position;
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spawnReady)
        {
            //spawn an enemy if spawnReady is true
            Spawn();
        }
    }

    private void Spawn()
    {
        //spawn an enemy and set spawnReady to false, then wait
        spawnReady = false;
        GameObject clone = Instantiate(enemy);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        //wait for 10 seconds before allowing an enemy to spawn
        yield return new WaitForSecondsRealtime(10f);
        spawnReady = true;
    }
}
