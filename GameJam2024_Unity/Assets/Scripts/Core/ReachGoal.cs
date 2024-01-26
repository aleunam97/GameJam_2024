using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachGoal : MonoBehaviour
{
    public GameObject winScreen;
    public Player player;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene(2);
            winScreen.SetActive(true);
            Player.freeze = true;
            Player.invisible = 1;
        }
    }
}
