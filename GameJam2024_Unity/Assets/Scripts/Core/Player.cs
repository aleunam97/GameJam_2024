using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//shift + option + f = autoformat
public class Player : MonoBehaviour
{
    private float Move;
    public float speed = 5f;
    public Rigidbody2D playerRigidBody;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    [SerializeField] private Transform playerFeet;
    [SerializeField] private Transform rayCastOrigin;
    private RaycastHit2D Hit2D;

    public static int invisible = 0;

    public static bool freeze;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        freeze = false;
    }

    void Update()
    {
        if(!freeze)
        {
        Move = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(Move * speed, playerRigidBody.velocity.y);
        }
        //GroundCheckMethod();
    }

    private void GroundCheckMethod()
    {
        Hit2D = Physics2D.Raycast(rayCastOrigin.position, -Vector2.up, 100f, groundLayer);

        if(Hit2D != false)
        {
            Vector2 temp = playerFeet.position;
            temp.y = Hit2D.point.y;
            playerFeet.position = temp;
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
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

}



