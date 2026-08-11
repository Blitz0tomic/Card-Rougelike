using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public int damage = 10;
    private bool hasHit = false;


    private void OnTriggerEnter(Collider other)
    { 
        if (!hasHit)
        {
            var target = other.gameObject;
            hasHit = true;


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
    private void OnEnable()
    {
        hasHit = false;
    }
}


