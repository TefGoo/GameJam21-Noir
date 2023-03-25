using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNoir : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("City");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }

}

