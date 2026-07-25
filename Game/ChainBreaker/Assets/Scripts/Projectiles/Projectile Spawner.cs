using System.Collections;
using UnityEngine;


public class ProjectileSpawner : MonoBehaviour
{
    public GameObject Projectile;
     
  private Rigidbody body = null;
    public void Spawn()
    {
        GameObject clone = Instantiate(Projectile);
        clone.SetActive(true);
        clone.transform.position = Projectile.transform.position;
        clone.transform.rotation = Projectile.transform.rotation;
        body = clone.GetComponent<Rigidbody>();
        
    }

    
}
