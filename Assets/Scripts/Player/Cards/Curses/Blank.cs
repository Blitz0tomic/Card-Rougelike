using UnityEngine;
using static CardLibrary;

public class Blank : Card
{
    public Blank() : base("Blank", RarityType.Common, EffectType.Nothing, ElementType.None, 2, false) { }
}
