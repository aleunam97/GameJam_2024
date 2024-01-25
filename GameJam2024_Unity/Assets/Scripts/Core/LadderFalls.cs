using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderFalls : MonoBehaviour
{
    public Animator ladderAnim;
    public Collider2D collider2DLadder;

    void Start()
    {
        collider2DLadder = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ladderAnim.SetTrigger("LadderTriggered");
        collider2DLadder.enabled = false; 
    }
}
