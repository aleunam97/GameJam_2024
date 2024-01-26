using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocked : MonoBehaviour
{
    public Animator openDoorAnim;
    public Collider2D collider2DDoor;

    public static int hasKey = 0;
    public GameObject keyIcon;

    void Start()
    {
        collider2DDoor = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && hasKey == 1)
        {
            Debug.Log("Player opens Door.");
            openDoorAnim.SetTrigger("DoorOpened");
            FMODUnity.RuntimeManager.PlayOneShot("{165ba1b1-35e7-4680-b45d-045d468f8621}", transform.position);
            collider2DDoor.enabled = false;
            keyIcon.SetActive(false);
            hasKey = 0;
        }
    }
}
