using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour
{
public GameObject pointA;
public GameObject pointB;
private Rigidbody2D enemyRigidbody;
private Transform currentPoint;
public float speed;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    void Update()
    {
        Patrol();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GetCaught();
    }

    void GetCaught()
    {
        Debug.Log("See you!");
    }

    void Patrol()
    {
        Vector2 point = currentPoint.position - transform.position;

        if(currentPoint == pointB.transform)
        {
            enemyRigidbody.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(-speed, 0);
        }

        //Umdrehen bei pointB
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
        }

         //Umdrehen bei pointA
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform. localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        //Visualisiere Patrol-Route
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
