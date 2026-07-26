using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public int damage = 10;
    public ElementType elementType;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var target = collision.gameObject;
            if (target != null)
            {                
                var target1 = target.GetComponent<EnemyHealth>();
                target1.TakeDamage(damage, elementType);
                Debug.Log($"Hit {collision.gameObject.name} for {damage} damage.");   
            }
        }
    }
}
