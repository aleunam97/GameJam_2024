using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocked : MonoBehaviour
{
    public Animator openDoorAnim;
    public Collider2D collider2DDoor;

    public static int hasKey = 0;

    void Start()
    {
        collider2DDoor = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player close to Door.");

        if(other.tag == "Player" && hasKey == 1)
        {
            Debug.Log("Player opens Door.");
            openDoorAnim.SetTrigger("DoorOpened");
            collider2DDoor.enabled = false;
        }
    }
}
