using UnityEngine;
using static CardLibrary;

//attack that deals more damage to frozen enemies
public class IceBolt : Card
{
    public IceBolt() : base("IceBolt", RarityType.Common, EffectType.Damage, ElementType.Ice, false) { }

    public override void OnPlay()
    {
        base.OnPlay();
    }
}