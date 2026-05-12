using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void StartNewGame()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene("TestScene");
    }
}
