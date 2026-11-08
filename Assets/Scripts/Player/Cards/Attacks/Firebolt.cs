using UnityEngine;
using static CardLibrary;

//ranged attack
public class FireBolt : Card
{
    public FireBolt() : base("Fire Bolt", RarityType.Common, EffectType.Damage, ElementType.Fire, 3f, false) { }

    public override void OnPlay()
    {
        playerController.projectile.Spawn(15f * playerController.lightningAttackMultiplier, Element, 50f);
        playerController.lightningAttackMultiplier = playerController.baseLightningAttackMultiplier;
        base.OnPlay();

    }

}
