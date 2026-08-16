using UnityEngine;
using static CardLibrary;

public class Shield : Card
{
    public Shield() : base("Shield", RarityType.Common, EffectType.Buff, ElementType.None, 2f, false) { }

    public override void OnPlay()
    {
        playerController.armor += 10;
        base.OnPlay();
    }
}
