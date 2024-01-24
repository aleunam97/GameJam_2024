using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseObjectPlayerForce : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private float xDistance;
    private float force;

    private float playerWalkxDirection;
    private float prevPlayerxPos;

    private void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        prevPlayerxPos = playerRb.transform.position.x;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        var currPlayerXPos = playerRb.transform.position.x;
        playerWalkxDirection = currPlayerXPos - prevPlayerxPos;
        xDistance = (currPlayerXPos - transform.position.x );
        
        force = Math.Sign(xDistance) == Math.Sign(playerWalkxDirection) || playerWalkxDirection == 0 ?  1.0f / xDistance * 20f : 0;
        force = Mathf.Clamp(force, -100, 100);
        playerRb.AddForce(Vector2.right * force, ForceMode2D.Force);
        prevPlayerxPos = currPlayerXPos;
    }
}
