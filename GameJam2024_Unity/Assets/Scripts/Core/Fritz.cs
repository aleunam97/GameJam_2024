using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fritz : MonoBehaviour
{
    public GameObject tutorialScreen;

    bool tutorialIsVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (tutorialIsVisible)
            {
                ShowTutorial();
            }
            else
            {
                HideTutorial();
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
        tutorialScreen.SetActive(true);
    }

    public void HideTutorial()
    {
        Debug.Log("Tutorial false.");
        tutorialScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game quitting!");
    }
}
