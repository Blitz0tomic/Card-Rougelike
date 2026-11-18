using UnityEngine;
using static CardLibrary;
//applies the Burn debuff to an enemy, causing it to take damage over time
public class Burn: Card
{
    public Burn() : base("Burn", RarityType.Common, EffectType.Debuff, ElementType.Fire, 3.5f, true) { }
    public override void Crystalize()
    {
        base.Crystalize();
    }
}