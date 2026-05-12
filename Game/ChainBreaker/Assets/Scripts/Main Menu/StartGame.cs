using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    public GameObject QuitButton;
    public GameObject BlankButton;
    
    public void StartNewGame()
    {
       QuitButton.SetActive(false);
       gameObject.SetActive(false);
        
        foreach (var deck in CardLibrary.Starting_Decks)
        {
            TMP_Text textbox;
            GameObject clone = Instantiate(BlankButton);
            clone.SetActive(true);
            
            textbox = clone.GetComponentInChildren<TMP_Text>();
            textbox.text = deck.Name;
        }
    }
}
