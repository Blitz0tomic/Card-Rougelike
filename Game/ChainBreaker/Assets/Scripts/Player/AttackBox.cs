using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public int damage = 10;
    List<int> damaged_Enemies = new List<int>();


    private void OnTriggerEnter(Collider other)
    { 
        if (!other.CompareTag(gameObject.tag))
        {
            var target = other.gameObject;
            
            if (target != null)
            {
                if (!damaged_Enemies.Contains(other.GetInstanceID()))
                {
                    if (other.tag == "Player")
                    {
                        var target1 = target.GetComponent<PlayerController>();
                        target1.TakeDamage(damage);
                        damaged_Enemies.Add(other.GetInstanceID());
                        Debug.Log($"Hit {other.name} for {damage} damage.");
                    }
                    else if (other.tag == "Enemy")
                    {
                        var target1 = target.GetComponent<EnemyHealth>();
                        target1.TakeDamage(damage, ElementType.None);
                        damaged_Enemies.Add(other.GetInstanceID());
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
    private void OnEnable()
    {
        damaged_Enemies.Clear();
    }
}
