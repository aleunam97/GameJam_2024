using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
public float moveSpeed = 5f;

public Rigidbody2D playerRigidBody;
Vector2 movement;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

void FixedUpdate()
{
    playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
}

    void Move()
    {
movement.x = Input.GetAxisRaw("Horizontal");
movement.y = Input.GetAxisRaw("Vertical");
    }
}
