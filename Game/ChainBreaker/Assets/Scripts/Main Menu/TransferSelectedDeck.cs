using System.Linq;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferSelectedDeck : MonoBehaviour
{
    
    
    public void TransferDeck(string SceneName) 
    {
        SceneManager.LoadScene(SceneName);
        string selectedName = gameObject.GetComponentInChildren<TMP_Text>().text;

        GameSession.SelectedDeck = CardLibrary.Starting_Decks
            .FirstOrDefault(deck => deck.Name == selectedName);
       
    }

    public static class GameSession
    {
        public static CardLibrary.LoudoutDeck SelectedDeck;
    }
}
