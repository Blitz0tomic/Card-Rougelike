using UnityEngine;
using static CardLibrary;

//attack that bounces between enemies
public class ChainLightning : Card
{
    public ChainLightning() : base("Chain Lightning", RarityType.Rare, EffectType.Damage, ElementType.Lightning, 2.5f, false) { }

    public override void OnPlay()
    {
        base.OnPlay();
        playerController.lightningAttackMultiplier = playerController.baseLightningAttackMultiplier;
    }
}
