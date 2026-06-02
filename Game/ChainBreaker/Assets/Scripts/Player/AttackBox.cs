using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public int damage = 10;
    List<string> damaged_Enemies = new List<string>();


    private void OnTriggerEnter(Collider other)
    { 
        if (!other.CompareTag(gameObject.tag))
        {
            var target = other.gameObject;
            
            if (target != null)
            {
                if (!damaged_Enemies.Contains(other.name))
                {
                    if (other.name == "Player")
                    {
                        var target1 = target.GetComponent<CharacterController>();
                        target1.TakeDamage(damage);
                        damaged_Enemies.Add(other.name);
                        Debug.Log($"Hit {other.name} for {damage} damage.");
                    }
                    else
                    {
                        var target1 = target.GetComponent<EnemyHealth>();
                        target1.TakeDamage(damage, ElementType.None);
                        damaged_Enemies.Add(other.name);
                        Debug.Log($"Hit {other.name} for {damage} damage.");
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
