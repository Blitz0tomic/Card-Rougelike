using System;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public string[] deck;
    public string[] hand;
    public int HandSize = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deck = BuildDeck();
        ShuffleDeck();
        Debug.Log("Deck has " + deck.Length + " cards.");
        Deal(HandSize);  
    }

    
    public void Deal(int HandSize) { 
        
        hand = new string[HandSize];

        for (int i = 0; i < HandSize; i++)
        {
            hand[i] = deck[i];
        }

        Debug.Log("your hand is");

        
        foreach (string card in hand)
        {
            Debug.Log(card);
        }


    }

    private string[] BuildDeck()
    {
        string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        List<string> deck = new List<string>();

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                deck.Add($"{rank} {suit}");
            }
        }

        return deck.ToArray();
    }
    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, deck.Length);

            string temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
}


