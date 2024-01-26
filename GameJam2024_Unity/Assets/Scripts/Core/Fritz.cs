using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fritz : MonoBehaviour
{
    public GameObject tutorialScreen;
    public GameObject creditsScreen;

    bool tutorialIsVisible = false;
    bool creditsIsVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (tutorialIsVisible)
            {
                HideTutorial();
            }

            if(creditsIsVisible)
            {
                HideCredits();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        Debug.Log("Tutorial active.");
        tutorialIsVisible = true;
        tutorialScreen.SetActive(true);
    }

    public void HideTutorial()
    {
        Debug.Log("Tutorial false.");
        tutorialIsVisible = false;
        tutorialScreen.SetActive(false);
    }
    public void ShowCredits()
    {
        Debug.Log("Credits active.");
        creditsIsVisible = true;
        creditsScreen.SetActive(true);
    }
    public void HideCredits()
    {
        Debug.Log("Credits false.");
        creditsIsVisible = false;
        creditsScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game quitting!");
    }
}
