using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float Move;
    public float speed = 5f;
    public Rigidbody2D playerRigidBody;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    void Start()
    {
    playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(Move * speed, playerRigidBody.velocity.y);

        if(!isGrounded())
        {
            playerRigidBody.velocity = new Vector2(Move * -speed, playerRigidBody.velocity.x);
        }
    }

    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance,boxSize);
    }

}



