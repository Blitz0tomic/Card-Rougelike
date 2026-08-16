using System.Collections;
using UnityEngine;


public class ProjectileSpawner : MonoBehaviour
{
     public GameObject Projectile;
     public ProjectileData projectileData;
     private Rigidbody body = null;
    public void Spawn(float Damage, ElementType elementType, float speed)
    {
        //create projectile
        GameObject clone = Instantiate(Projectile);
        clone.SetActive(true);
        Debug.Log("Projectile Spawned");
        //make the clone the same position and rotation as the original projectile
        clone.transform.position = Projectile.transform.position;
        clone.transform.rotation = Projectile.transform.rotation;
        clone.transform.SetParent(Projectile.transform.parent);
        //assign the correct data to the projectile
        projectileData = clone.GetComponent<ProjectileData>();
        projectileData.Damage = Damage;
        projectileData.elementType = elementType;
        //move projectile
        body = clone.GetComponent<Rigidbody>();
        body.AddForce(clone.transform.up * speed, ForceMode.Impulse);
    }

    
}
