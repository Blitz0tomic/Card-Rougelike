using System.Collections;
using UnityEngine;


public class ProjectileSpawner : MonoBehaviour
{
     public GameObject Projectile;
     public ProjectileData projectileData;
     private Rigidbody body = null;
    public void Spawn(int Damage, ElementType elementType)
    {
        GameObject clone = Instantiate(Projectile);
        clone.SetActive(true);
        Debug.Log("Projectile Spawned");
        clone.transform.position = Projectile.transform.position;
        clone.transform.rotation = Projectile.transform.rotation;
        clone.transform.SetParent(Projectile.transform.parent);
        projectileData = clone.GetComponent<ProjectileData>();
        projectileData.Damage = Damage;
        projectileData.elementType = elementType;
        body = clone.GetComponent<Rigidbody>();
        body.AddForce(clone.transform.up * 10f, ForceMode.Impulse);
    }

    
}
