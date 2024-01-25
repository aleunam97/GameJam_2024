using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Masquerade : MonoBehaviour
{
    public Player player;

    void Start()
    {
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.hasMask = 1;
            Debug.Log("Player has Mask!");
        }
    }
}
