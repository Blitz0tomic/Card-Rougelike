using UnityEngine;
using static CardLibrary;

//ranged attack
public class LightningStrike : Card
{
    public LightningStrike() : base("Lightning Strike", RarityType.Common, EffectType.Damage, ElementType.Lightning, false) { }

    public override void OnPlay()
    {

        base.OnPlay();


    }

}
