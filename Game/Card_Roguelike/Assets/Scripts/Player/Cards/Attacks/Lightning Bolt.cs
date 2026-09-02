using System.Collections.Generic;
using UnityEngine;
using static CardLibrary;

//big attack on everything in an area
public class LightningBolt : Card
{
    
    public LightningBolt() : base("Lightning Bolt", RarityType.Legendary, EffectType.Damage, ElementType.Lightning, 2.5f, false) { }

    public override void OnPlay()
    {
        
        float damage = 25f * playerController.lightningAttackMultiplier;
        
        Vector3 pointInFront = playerController.transform.position + playerController.transform.forward * 15f;
        Collider[] hits = Physics.OverlapSphere(pointInFront, 5f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                var target = hit.GetComponent<EnemyHealth>();
                target.TakeDamage(damage, Element);
            }
        }
        playerController.lightningAttackMultiplier = playerController.baseLightningAttackMultiplier;
        base.OnPlay();
        
    }
    
}
