using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public int damage = 10;


    private void OnTriggerEnter(Collider other)
    { 
        if (!other.CompareTag(gameObject.tag))
        {
            var target = other.gameObject;
            
            if (target != null)
            {
                    if (other.tag == "Player")
                    {
                        var target1 = target.GetComponent<PlayerController>();
                        target1.TakeDamage(damage);
                        Debug.Log($"Hit {other.name} for {damage} damage.");
                    }
                    else
                    {
                        Debug.Log($"Hit {other.name} but it is not a valid target.");
                    }
                
            }
        }
    }
    
}
