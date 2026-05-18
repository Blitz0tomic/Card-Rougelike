using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class CardLibrary
{
    #region Cards

    #region Attacks
    public static Card CreateChainLightning()
        => new Card("Chain Lightning", RarityType.Rare, EffectType.Damage, EffectTime.OnPlay, false, false, true, false);

    public static Card CreateIceBolt()
        => new Card("IceBolt", RarityType.Common, EffectType.Damage, EffectTime.OnPlay, false, false, true, false);

    public static Card CreateLightningStrike()
        => new Card("Lightning Strike", RarityType.Common, EffectType.Damage, EffectTime.OnPlay, false, false, true, false);

    public static Card CreateLightningBolt()
        => new Card("Lightning Bolt", RarityType.Legendary, EffectType.Damage, EffectTime.OnPlay, false, false, true, false);
    #endregion

    #region buffs
    public static Card CreateCharge()
        => new Card("Charge", RarityType.Common, EffectType.Buff, EffectTime.OnDraw, true, true, false, false);
    #endregion

    #region Debuffs
    public static Card CreateFreeze()
        => new Card("Freeze", RarityType.Common, EffectType.Debuff, EffectTime.OnDraw, true, true, false, false);
    #endregion


    public static Card CreateBlank()
        => new Card("Blank", RarityType.Common, EffectType.Nothing, EffectTime.Never, false, false,false,false);
    #endregion

    
    [Serializable]
    public class LoudoutDeck
    {
        public string Name;
        public List<Card> Cards;

        public LoudoutDeck(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }
    }
    public static LoudoutDeck LightningDeck = new LoudoutDeck(
    "Lightning Deck",
    new List<Card>()
    {
        CreateCharge(),
        CreateCharge(),
        CreateCharge(),
        CreateLightningStrike(),
        CreateLightningStrike(),
        CreateLightningStrike(),
    }
);

    public static LoudoutDeck IceDeck = new LoudoutDeck(
        "Ice Deck",
        new List<Card>()
        {
        CreateFreeze(),
        CreateFreeze(),
        CreateFreeze(),
        CreateIceBolt(),
        CreateIceBolt(),
        CreateIceBolt(),
        }
    );

    

    public static List<LoudoutDeck> Starting_Decks = new List<LoudoutDeck>()
    {
    LightningDeck,
    IceDeck,
    
    };
}


