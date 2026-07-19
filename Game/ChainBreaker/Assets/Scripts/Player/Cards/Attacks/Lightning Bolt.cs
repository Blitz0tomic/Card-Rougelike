using UnityEngine;
using static CardLibrary;

//big attack on everything in an area
public class LightningBolt : Card
{
    public LightningBolt() : base("Lightning Bolt", RarityType.Legendary, EffectType.Damage, ElementType.None, false) { }

    public override void OnPlay()
    {
        base.OnPlay();
    }
}
