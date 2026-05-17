using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static CardLibrary;
using static TransferSelectedDeck;

public class DeckController : MonoBehaviour
{
    #region Variable Declaration
    public List<Card> BaseDeck;
    public List<Card> Deck;
    public List<Card> Hand;
    public int HandSize = 2;
    public List<Card> DiscardPile;
    public LoudoutDeck SelectedDeck;
    
    #endregion
    
    void Start()
    {
        SelectedDeck = GameSession.SelectedDeck;
        BaseDeck = new List<Card>();
        foreach (Card c in SelectedDeck.Cards)
        {
            BaseDeck.Add(c);
        }
        Deck = BuildDeck();
        Debug.Log("Deck has " + Deck.Count + " Cards.");
        ShuffleDeck();
        Hand = new List<Card>();
        Draw(HandSize);
        foreach (Card c in Hand)
        {
            Debug.Log(c.Name);
        }
        DiscardPile = new List<Card>();
    }

    
    #region BaseDeck Manipulation
    public void AddCardToBaseDeck(Card Card)
    {
        BaseDeck.Add(Card);
    }

    public void RemoveCardFromBaseDeck(Card Card)
    {
        BaseDeck.Remove(Card);
    }
    #endregion
    #region During gameplay deck manipulation
    private List<Card> BuildDeck()
    {

        List<Card> Deck = new List<Card>(BaseDeck);

        return Deck;
    }
    public void AddCardToDeck(Card Card)
    {
        Deck.Add(Card);
    }

    public void RemoveCardFromDeck(Card Card)
    {
        Deck.Remove(Card);
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < Deck.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, Deck.Count);

            Card temp = Deck[i];
            Deck[i] = Deck[randomIndex];
            Deck[randomIndex] = temp;
        }
    }

    private void ReshuffleDiscardIntoDeck()
    {
        Deck.AddRange(DiscardPile);
        DiscardPile.Clear();
        ShuffleDeck();
    }
    #endregion
    #region Hand manipulation
    public void Draw(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (Deck.Count == 0)
            {
                ReshuffleDiscardIntoDeck();
            }

            Card drawn = Deck[0];
            Hand.Add(drawn);
            Deck.RemoveAt(0);
        }
    }
    public void Discard(int i)
    {
        DiscardPile.Add(Hand[i]);
        Hand.RemoveAt(i);
    }
    public void DiscardHand()
    {
        DiscardPile.AddRange(Hand);
        Hand.Clear();
    }


#endregion
}
[Serializable]
public class Card
{
    public string Name;
    public RarityType Rarity;
    public EffectType Type;
    public EffectTime Time;
    public bool Crystalizable;

    public Card(string name, RarityType rarity, EffectType type, EffectTime time, bool crystalizable)
    {
        Name = name;
        Rarity = rarity;
        Type = type;
        Time = time;
        Crystalizable = crystalizable;
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

public enum EffectTime
{
    OnPlay,
    OnDiscard,
    OnDraw,
    Never
}

