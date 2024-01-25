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

    public void PlayLadderDrop()
    {
        FMODUnity.RuntimeManager.PlayOneShot("{fe0e429b-a0da-401a-b0c7-8a809227fcbc}", transform.GetChild(0).transform.position);
    }
    
    public void PlayLadderImpact()
    {
        FMODUnity.RuntimeManager.PlayOneShot("{c0fc5391-e9ee-4d70-9a0a-44cbd8cc79ed}", transform.GetChild(0).transform.position);
    }
}
