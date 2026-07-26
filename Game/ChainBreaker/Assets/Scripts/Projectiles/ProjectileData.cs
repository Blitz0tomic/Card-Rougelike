using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ProjectileData : MonoBehaviour
{
    public int Damage;
    public ElementType elementType;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var target = collision.gameObject;
            if (target != null)
            {                
                var target1 = target.GetComponent<EnemyHealth>();
                target1.TakeDamage(Damage, elementType);
                Debug.Log($"Hit {collision.gameObject.name} for {Damage} damage.");
                Destroy(gameObject);
            }
        }
        else 
        { 
            Debug.Log($"Hit {collision.gameObject.name}");
            Destroy(gameObject);
        }
    }
}
