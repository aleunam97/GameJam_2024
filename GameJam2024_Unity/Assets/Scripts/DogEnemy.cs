using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogEnemy : MonoBehaviour
{
    private GameObject cachedPlayerObject;
    private PlayerNoise cachedPlayerNoise;

    private bool caught;
    public GameObject failedText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        cachedPlayerObject = other.gameObject;
        if (!cachedPlayerNoise)
            cachedPlayerNoise = other.gameObject.GetComponent<PlayerNoise>();
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        cachedPlayerObject = null;
        caught = false;
    }

    private void Update()
    {
        if (!cachedPlayerObject)
            return;

        if (cachedPlayerNoise.makesUnmaskedNoise && !caught)
        {
            Debug.Log("Dog eats you...");
            caught = true;
            failedText.SetActive(true);
            Player.freeze = true;
            Invoke("RestartGame", 3);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
