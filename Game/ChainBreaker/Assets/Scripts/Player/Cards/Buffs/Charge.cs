using UnityEngine;
using static CardLibrary;

//buff that causes the next lightning attack to be stronger
public class Charge : Card
{
    public Charge() : base("Charge", RarityType.Common, EffectType.Buff, ElementType.None, true) { }

    public override void OnDraw()
    {
        Debug.Log("Charge triggered!");
    }
}
