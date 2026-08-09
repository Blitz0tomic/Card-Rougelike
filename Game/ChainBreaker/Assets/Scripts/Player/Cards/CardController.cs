using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static CardLibrary;
public class CardController : MonoBehaviour
{
    #region Variable Declaration
    public List<Card> BaseDeck;
    public List<Card> Deck;
    public List<Card> Hand;
    public int HandSize = 2;
    public List<Card> DiscardPile;
    public LoadoutDeck SelectedDeck;
    
    
    #endregion
    
    void Start()
    {
        //initialize collections and fall back to a default loadout if none selected
        SelectedDeck = GameSession.SelectedDeck;
        DiscardPile = new List<Card>();
        BaseDeck = new List<Card>();
        Hand = new List<Card>();
        if (SelectedDeck == null)
        {
            Debug.Log("SelectedDeck Null");
            SelectedDeck = Starting_Decks[0];
        }

        //build the base deck from the selected loadout's card names
        foreach (string c in SelectedDeck.Cards)
        {
            Card temp = CardFactory.Create(c);
            BaseDeck.Add(temp);
            temp.findControllers();
        }

        //build the runtime deck, shuffle it, and draw the starting hand
        Deck = BuildDeck();
        Debug.Log("Deck has " + Deck.Count + " Cards.");
        ShuffleDeck();
        Draw(HandSize);
        foreach (Card c in Hand)
        {
            Debug.Log(c.Name);
        }
        
    }

    void Update()
    {
        //keep the hand topped up automatically if it ever empties out
        if (Hand.Count == 0)
        {
            RefillHand();
        }
    }


    #region BaseDeck Manipulation
    public void AddCardToBaseDeck(string Card)
    {
        Card temp = CardFactory.Create(Card);
        temp.findControllers();
        BaseDeck.Add(temp);
    }

    public void RemoveCardFromBaseDeck(Card Card)
    {
        BaseDeck.Remove(Card);
    }
    #endregion
    #region During gameplay deck manipulation
    private List<Card> BuildDeck()
    {
        //copy the base deck so runtime changes don't affect the base loadout
        List<Card> Deck = new List<Card>(BaseDeck);

        return Deck;
    }
    public void AddCardToDeck(string Card)
    {
        Card temp = CardFactory.Create(Card);
        temp.findControllers();
        Deck.Add(temp);
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

    //recycle the discard pile back into the deck once the deck runs out
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

            //draw the top card into the hand and trigger its draw behavior
            Card card = Deck[0];
            Hand.Add(card);
            card.Played = false;
            card.OnDraw();
            StartCoroutine(card.AutoPlay());
            Deck.RemoveAt(0);
        }
    }

    //move a card from hand to discard pile and trigger its discard behavior
    public void Discard(Card card)
    {
        card.Played = true;

        DiscardPile.Add(card);
        card.OnDiscard();
        Hand.Remove(card);
    }

    //discard the entire hand, then draw back up to full
    public void DiscardHand()
    {
        
        foreach (Card c in new List<Card>(Hand))
        {
            Discard(c);
        }
        RefillHand();

    }

    public void RefillHand()
    {
        Draw(HandSize - Hand.Count);
    }


#endregion
}


