using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CardLibrary
{
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
        "shield",
        "charge",
        "charge",
        "lightningshot",
        "lightningshot",
        "lightningshot",
     }
   );


public static LoadoutDeck IceDeck = new LoadoutDeck(
        "Ice Deck",
        new List<string>()
        {
            "shield",
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
        "shield",
        "burn",
        "burn",
        "firebolt",
        "firebolt",
        "firebolt",
    });
public static List<LoadoutDeck> Starting_Decks = new List<LoadoutDeck>()
    {
    LightningDeck,
    IceDeck,
    FireDeck,
    };
    #endregion
#region Drops
public static Dictionary<ElementType, List<string>> DropPools = new Dictionary<ElementType, List<string>>()
{
    { ElementType.Lightning, new List<string>() { "charge", "lightningshot", "chainlightning", "lightningbolt" } },
    { ElementType.Ice, new List<string>() { "freeze", "icebolt" } },
    { ElementType.Fire, new List<string>() { "burn", "firebolt" } },
    {ElementType.None, new List<string>() { "shield" } },
};
#endregion
}