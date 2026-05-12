using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class CardLibrary
{
    #region Cards

    #region Attacks
    public static Card CreateChainLightning()
        => new Card("Chain Lightning", RarityType.Rare, EffectType.Damage, EffectTime.OnPlay, false);

    public static Card CreateIceBolt()
        => new Card("IceBolt", RarityType.Common, EffectType.Damage, EffectTime.OnPlay, false);

    public static Card CreateLightningStrike()
        => new Card("Lightning Strike", RarityType.Common, EffectType.Damage, EffectTime.OnPlay, false);

    public static Card CreateLightningBolt()
        => new Card("Lightning Bolt", RarityType.Legendary, EffectType.Damage, EffectTime.OnPlay, false);
    #endregion

    #region buffs
    public static Card CreateCharge()
        => new Card("Charge", RarityType.Common, EffectType.Buff, EffectTime.OnDraw, true);
    #endregion

    #region Debuffs
    public static Card CreateFreeze()
        => new Card("Freeze", RarityType.Common, EffectType.Debuff, EffectTime.OnDraw, true);
    #endregion


    public static Card CreateBlank()
        => new Card("Blank", RarityType.Common, EffectType.Nothing, EffectTime.Never, false);
    #endregion

    
    [Serializable]
    public class LoudoutDecks
    {
        public string Name;
        public List<Card> Cards;

        public Deck(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }
    }
    public static Deck LightningDeck = new Deck(
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

    public static Deck IceDeck = new Deck(
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

    public static List<Deck> Starting_Decks = new List<LoudoutDecks>()
{
    LightningDeck,
    IceDeck
};
}


