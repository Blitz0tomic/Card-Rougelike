using UnityEngine;
using static CardLibrary;


public class LightningRush : Card
{
    public LightningRush() : base("Lightning Rush", RarityType.Rare, EffectType.Buff, ElementType.Lightning, 1f, true) { }

    public override void OnPlay()
    {
        
        Debug.Log("Lightning Rush triggered!");
        //temporarily increase move speed
        base.OnPlay();
    }

    public override void Crystalize()
    {
        //permanantly increase move speed
    }

   
}
