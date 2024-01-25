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

    private bool catchable;
    private bool caught;
    public GameObject failedText;

    public FMODUnity.StudioEventEmitter snoreEmitter;
    public FMODUnity.EventReference barkRef;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        if (!cachedPlayerNoise)
            cachedPlayerNoise = other.gameObject.GetComponent<PlayerNoise>();
        catchable = true;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        cachedPlayerObject = null;
        caught = false;
        catchable = false;
    }

    private void Update()
    {
        if (!catchable)
            return;
        
        if (cachedPlayerNoise.makesUnmaskedNoise && !caught)
        {
            Debug.Log("Dog eats you...");
            caught = true;
            failedText.SetActive(true);
            Player.freeze = true;
            FMODUnity.RuntimeManager.PlayOneShot(barkRef, transform.position);
            snoreEmitter.Stop();
            Invoke("RestartGame", 3);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
