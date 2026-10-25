using UnityEngine;
using static CardLibrary;

//applies the frozen debuff to an enemy, causing it to move slower
public class Freeze : Card
{
    public Freeze() : base("Freeze", RarityType.Common, EffectType.Debuff, ElementType.Ice, 3.5f, true) { }

    public override void Crystalize()
    {
        base.Crystalize();
    }
}
