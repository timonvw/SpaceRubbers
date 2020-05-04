using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject PreviousButton;
    public GameObject UIScreen;
    public GameObject ControlScreen;

    public void ToGame()
    {
        SceneManager.LoadScene("Timon");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToUIScreen()
    {
        //nextButton.SetActive(false);
        ControlScreen.SetActive(false);

        UIScreen.SetActive(true);
        //PreviousButton.SetActive(true);
    }

    public void GoToControlScreen()
    {
        //nextButton.SetActive(true);
        ControlScreen.SetActive(true);

        UIScreen.SetActive(false);
        //PreviousButton.SetActive(false);
    }
}
