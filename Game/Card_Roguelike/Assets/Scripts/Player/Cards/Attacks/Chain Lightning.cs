using System.Collections.Generic;
using UnityEngine;
using static CardLibrary;

//attack that bounces between enemies
public class ChainLightning : Card
{
    public List<int> hitEnemies = new List<int>();
    public ChainLightning() : base("Chain Lightning", RarityType.Rare, EffectType.Damage, ElementType.Lightning, 2.5f, false) { }

    public override void OnPlay()
    {
        //foreach (Collider hit in hits)
        //{
        //    if (hitEnemies.Count >= 3) break; // Limit to 3 enemies hit
        //    if (hit.CompareTag("Enemy"))
        //    {
        //        var target = hit.GetComponent<EnemyHealth>();
        //        if (!hitEnemies.Contains(target.GetInstanceID()))
        //        {
        //            float damage = 15f * playerController.lightningAttackMultiplier;
        //            playerController.lightningAttackMultiplier = playerController.baseLightningAttackMultiplier;
        //            target.TakeDamage(damage, Element);
        //            hitEnemies.Add(target.GetInstanceID());
        //            hits = Physics.OverlapSphere(target.transform.position, 5f);
        //        }
        //        else if (hitEnemies.Contains(target.GetInstanceID())) 
        //        {
        //            Debug.Log("Enemy already hit by Chain Lightning, skipping.");
        //            continue;
        //        }
        //    }
        //}
        Vector3 searchOrigin = playerController.transform.position;
        for (int i = 0; i < 3; i++)
        {
            Collider[] hits = Physics.OverlapSphere(searchOrigin, 5f);
            EnemyHealth nextTarget = null;

            foreach (Collider hit in hits)
            {
                if (!hit.CompareTag("Enemy")) continue;
                var candidate = hit.GetComponent<EnemyHealth>();
                if (candidate == null) continue;
                if (hitEnemies.Contains(candidate.GetInstanceID())) continue;

                nextTarget = candidate;
                break;   // first valid new target found; sort by distance instead if you want "nearest" specifically
            }

            if (nextTarget == null) break;   

            nextTarget.TakeDamage(20f * playerController.lightningAttackMultiplier, Element);
            hitEnemies.Add(nextTarget.GetInstanceID());
            searchOrigin = nextTarget.transform.position;
        }
        playerController.lightningAttackMultiplier = playerController.baseLightningAttackMultiplier;
        hitEnemies.Clear();
        base.OnPlay();
    }
}
