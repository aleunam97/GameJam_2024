using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotBreakStairs : MonoBehaviour
{
    public Collider2D colliderStairs; 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        colliderStairs.enabled = false;
    }
}
