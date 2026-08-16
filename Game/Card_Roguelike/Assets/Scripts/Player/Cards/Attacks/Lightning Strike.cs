using UnityEngine;
using static CardLibrary;

//ranged attack
public class LightningStrike : Card
{
    public LightningStrike() : base("Lightning Strike", RarityType.Common, EffectType.Damage, ElementType.Lightning, 2.5f, false) { }

    public override void OnPlay()
    {

        base.OnPlay();
        playerController.projectile.Spawn(15f * playerController.lightningAttackMultiplier, Element, 50f);
        playerController.lightningAttackMultiplier = playerController.baseLightningAttackMultiplier;

    }

}
