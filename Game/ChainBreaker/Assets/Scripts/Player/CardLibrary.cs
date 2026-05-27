using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardLibrary
{
    
    #region Card creators

    #region Attacks
    public static Card CreateChainLightning()
        => new ChainLightning();

    public static Card CreateIceBolt()
        => new IceBolt();

    public static Card CreateLightningStrike()
        => new LightningStrike();

    public static Card CreateLightningBolt()
        => new LightningBolt();
    #endregion

    #region buffs
    public static Card CreateCharge()
        => new Charge();
    #endregion

    #region Debuffs
    public static Card CreateFreeze()
        => new Freeze();
    #endregion


    public static Card CreateBlank()
        => new Card("Blank", RarityType.Common, EffectType.Nothing, ElementType.None, false);
    #endregion

    #region Card Classes
    #region base card class
    [Serializable]
    public class Card
    {
        public CardController controller;
        public string Name;
        public RarityType Rarity;
        public EffectType Type;
        public bool Crystalizable;
        public bool Played = false;
        public float autoplayTimer = 3f;
        public Card(string name, RarityType rarity, EffectType type, ElementType element,bool crystalizable)
        {
            Name = name;
            Rarity = rarity;
            Type = type;
            Crystalizable = crystalizable;
        }

        public virtual void findController()
        {
            controller = GameObject.FindWithTag("Player").GetComponent<CardController>();
        }

        public virtual void OnDraw()
        {
            // Default: no effect
        }

        public virtual void OnPlay()
        {
            Played = true;
            controller.DiscardPile.Add(this);
            controller.Hand.Remove(this);
        }

        public virtual void OnDiscard()
        {
            // Default: no effect
        }

        public IEnumerator AutoPlay()
        {
            yield return new WaitForSeconds(3f);
            if (!Played)
            {
                OnPlay();
            }
        }
    }
    public enum RarityType
    {
        Common,
        Rare,
        Legendary
    }

    public enum EffectType
    {
        Damage,
        Heal,
        Buff,
        Debuff,
        Curse,
        Nothing
    }

    public enum ElementType
    {
        Lightning,
        Ice,
        Fire,
        None
    }
    #endregion

    #region Attacks
    //big attack on everything in an area
    public class LightningBolt : Card
    {
        public LightningBolt() : base("Lightning Bolt", RarityType.Legendary, EffectType.Damage, ElementType.None ,false)
        {

        }

        public override void OnPlay()
        {
            base.OnPlay();
        }
    }
//attack that bounces between enemies
    public class ChainLightning : Card
    {
        public ChainLightning() : base("Chain Lightning", RarityType.Rare, EffectType.Damage, ElementType.Lightning, false) { }

        public override void OnPlay() 
        {
            base.OnPlay(); ;
        }
    }
//attack that deals more damage to frozen enemies
    public class IceBolt : Card
    {
        public IceBolt() : base("IceBolt", RarityType.Common, EffectType.Damage, ElementType.Ice, false) { }

        public override void OnPlay() {
            base.OnPlay();
        }
    }
//ranged attack
    public class LightningStrike : Card
    {
        public LightningStrike() : base("Lightning Strike", RarityType.Common, EffectType.Damage, ElementType.Ice, false) { }

        public override void OnPlay() 
        {

            base.OnPlay();


        }
        
    }
    #endregion

    #region Buffs
//buff that causes the next lightning attack to be stronger
    public class Charge : Card
    {
            public Charge(): base("Charge", RarityType.Common,
                       EffectType.Buff, ElementType.None, true)
            {
            }

            public override void OnDraw()
            {
                Debug.Log("Charge triggered!");
            }
    }
    #endregion

    #region Debuffs
//applies the frozen debuff to an enemy, causing it to move slower
    public class Freeze : Card
    {
        public Freeze() : base("Freeze", RarityType.Common, EffectType.Debuff, ElementType.None, true) { }
              
    }
    #endregion
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
    });

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
    });

    public static LoudoutDeck FireDeck = new LoudoutDeck(
        "Fire Deck",
        new List<Card>()
        {
        
        });
    public static List<LoudoutDeck> Starting_Decks = new List<LoudoutDeck>()
    {
    LightningDeck,
    IceDeck,
    FireDeck,
    };
}


