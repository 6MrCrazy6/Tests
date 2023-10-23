using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartTest()
    {
        SceneManager.LoadScene("Tests");
    }

    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("Application close!");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
