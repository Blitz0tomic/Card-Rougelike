using System;
using System.Collections.Generic;
using UnityEngine;

public class GambleOriginal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Blackjack
{
    string betInput;
    int bet;
    private string[] deck;
    public string[] hand;

    public void Bet()
    {
        betInput = Console.ReadLine();
        if (betInput == "") { betInput = "5"; }
        bet = int.Parse(betInput);
    }

    public void Deal()
    {
        Bet();
        deck = BuildDeck();
        Console.WriteLine("you bet $" + bet);

        Console.WriteLine(" your hand is");

        System.Random random = new System.Random();
        int card1 = random.Next(0, deck.Length);

        Console.WriteLine(deck[card1]);

        int card2 = random.Next(0, deck.Length);

        Console.WriteLine(deck[card2]);
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






}

