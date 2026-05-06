using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    bool spawnable = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        yield return new WaitForSecondsRealtime(1.5f);
        spawnable = true;
    }
}
