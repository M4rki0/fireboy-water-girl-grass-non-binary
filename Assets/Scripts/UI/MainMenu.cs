using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject optionsCanvas;
    public GameObject creditsCanvas;

    public void StartGame()
    {
        SceneManager.LoadScene("Testing_Game");
    }

    public void Options()
    {
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void Back()
    {
        if (optionsCanvas)
        {
            optionsCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
        else if (creditsCanvas)
        {
            creditsCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
    }
}
