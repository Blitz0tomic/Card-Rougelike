using System.Collections.Generic;
using UnityEngine;

public static class CardLibrary
{
    #region Cards

    #region Attacks
    public static Card CreateChainLightning()
        => new Card("Chain Lightning", RarityType.Rare, EffectType.Damage, EffectTime.OnPlay, false);

    public static Card CreateLightningStrike()
        => new Card("Lightning Strike", RarityType.Common, EffectType.Damage, EffectTime.OnPlay, false);

    public static Card CreateLightningBolt()
        => new Card("Lightning Bolt", RarityType.Legendary, EffectType.Damage, EffectTime.OnPlay, false);
    #endregion

    #region buffs
    public static Card CreateCharge()
        => new Card("Charge", RarityType.Common, EffectType.Buff, EffectTime.OnDraw, true);
    #endregion

    
    public static Card CreateBlank()
        => new Card("Blank", RarityType.Common, EffectType.Nothing, EffectTime.Never, false);
    #endregion

    public static List<Card> LightningWielder = new List<Card>()
    {
        CreateCharge(),
        CreateCharge(),
        CreateCharge(),
        CreateLightningStrike(),
        CreateLightningStrike(),
        CreateLightningStrike(),
    };
}


