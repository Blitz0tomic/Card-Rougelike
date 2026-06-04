using System.Linq;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferSelectedDeck : MonoBehaviour
{
    
    
    public void TransferDeck(string SceneName) 
    {
        
        string selectedName = gameObject.GetComponentInChildren<TMP_Text>().text;

        GameSession.SelectedDeck = CardLibrary.Starting_Decks
            .FirstOrDefault(deck => deck.Name == selectedName);
        SceneManager.LoadScene(SceneName);

    }   
}
