using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Masquerade : MonoBehaviour
{
    public Player player;
    public GameObject masquerade;
    public SpriteRenderer spriteHat;
    public Animator hatOnPillar;

    void Start()
    {
        spriteHat = masquerade.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.hasMask = 1;
            spriteHat.enabled = true;
            hatOnPillar.SetTrigger("PickUpHat");

            Debug.Log("Player has Mask!");
        }
    }
}
