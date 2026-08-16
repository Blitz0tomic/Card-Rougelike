using UnityEngine;
using static CardLibrary;

//buff that causes the next lightning attack to be stronger
public class Charge : Card
{
    public Charge() : base("Charge", RarityType.Common, EffectType.Buff, ElementType.None, 0.5f,true) { }

    public override void OnDraw()
    {
        base.OnDraw();
        Debug.Log("Charge triggered!");
        playerController.lightningAttackMultiplier *= 1.5f;
    }

    public override void Crystalize()
    {
        playerController.baseLightningAttackMultiplier *= 1.5f;
        playerController.lightningAttackMultiplier = playerController.baseLightningAttackMultiplier;
        base.Crystalize();
    }

   
}
