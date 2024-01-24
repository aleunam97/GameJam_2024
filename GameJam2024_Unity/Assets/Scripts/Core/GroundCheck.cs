using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform rayCastOrigin;
    [SerializeField] private Transform playerFeet;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D Hit2D;

    void GroundCheckMethod()
    {
        Hit2D = Physics2D.Raycast(rayCastOrigin.position, -Vector2.up, 50f, layerMask);
        if (Hit2D != false)
        {
            Vector2 temp = playerFeet.position;
            temp.y = Hit2D.point.y;
            playerFeet.position = temp;
        }
    }
}
