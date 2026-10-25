using UnityEngine;
using TMPro;

public class StartGame : MonoBehaviour
{
    public GameObject QuitButton;
    public GameObject BlankButton;
    public Canvas canvas;

    public void StartNewGame()
    {
        QuitButton.SetActive(false);

        int i = 0;
        //create a button for each starting deck
        foreach (var deck in CardLibrary.Starting_Decks)
        {
            GameObject clone = Instantiate(BlankButton, canvas.transform, false);

            RectTransform rt = clone.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0, -50 * i);

            clone.GetComponentInChildren<TMP_Text>().text = deck.Name;

            clone.SetActive(true);

            i++;

            Debug.Log("Created button: " + deck.Name);
        }


        gameObject.SetActive(false);
    }
}