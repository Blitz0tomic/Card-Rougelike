using UnityEngine;
using static CardLibrary;

public class IceBolt : Card
{
    public IceBolt() : base("IceBolt", RarityType.Common, EffectType.Damage, ElementType.Ice, 3.5f, false) { }

    public override void OnPlay()
    {
        playerController.projectile.Spawn(15f, Element, 50f);
        
        base.OnPlay();
    }
}