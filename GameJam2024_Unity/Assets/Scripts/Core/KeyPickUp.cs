using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public DoorLocked doorLocked;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DoorLocked.hasKey = 1;
            Debug.Log("Player has Key!");

            Destroy(gameObject);
        }
    }
}
