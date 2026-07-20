using UnityEngine;
using static CardLibrary;

//applies the frozen debuff to an enemy, causing it to move slower
public class Freeze : Card
{
    public Freeze() : base("Freeze", RarityType.Common, EffectType.Debuff, ElementType.None, 3.5f, true) { }

}
