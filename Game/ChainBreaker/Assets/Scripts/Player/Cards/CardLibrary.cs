using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CardLibrary
{

    #region base card class
    [Serializable]
    public class Card
    {
        public CardController cardController;
        public PlayerController playerController;
        public string Name;
        public RarityType Rarity;
        public EffectType Type;
        public bool Crystalizable;
        public bool Played = false;
        public bool autoPlayed = false;
        public float autoplayTimer = 3f;
        public ElementType Element;
        public Card(string name, RarityType rarity, EffectType type, ElementType element, bool crystalizable)
        {
            Name = name;
            Rarity = rarity;
            Type = type;
            Element = element;
            Crystalizable = crystalizable;
        }

        public virtual void findControllers()
        {
            cardController = GameObject.FindWithTag("Player").GetComponent<CardController>();
            playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        }

        public virtual void OnDraw()
        {
            // Default: no effect
        }

        public virtual void OnPlay()
        {
            Played = true;
            cardController.DiscardPile.Add(this);
            cardController.Hand.Remove(this);
            if (playerController.SelectedCard == cardController.Hand.Count)
            {
                playerController.SelectedCard = cardController.Hand.Count - 1;
            }
        }

        public virtual void OnDiscard()
        {

        }

        public IEnumerator AutoPlay()
        {
            yield return new WaitForSeconds(autoplayTimer);
            if (!Played)
            {
                autoPlayed = true;
                OnPlay();
            }
        }
    }

    #endregion

    #region Decks
    [Serializable]
    public class LoadoutDeck
    {
        public string Name;
        public List<string> Cards;

        public LoadoutDeck(string name, List<string> cards)
        {
            Name = name;
            Cards = cards;
        }
    }

    public static LoadoutDeck LightningDeck = new LoadoutDeck(
    "Lightning Deck",
    new List<string>()
    { 
        "charge",
        "charge",
        "charge",
        "lightningstrike",
        "lightningstrike",
        "lightningstrike",
     }
   );


public static LoadoutDeck IceDeck = new LoadoutDeck(
        "Ice Deck",
        new List<string>()
        {
            "freeze",
            "freeze",
            "freeze",
            "icebolt",
            "icebolt",
            "icebolt",
        }
    );

public static LoadoutDeck FireDeck = new LoadoutDeck(
    "Fire Deck",
    new List<string>()
    {

    });
public static List<LoadoutDeck> Starting_Decks = new List<LoadoutDeck>()
    {
    LightningDeck,
    IceDeck,
    FireDeck,
    };
    #endregion
}


