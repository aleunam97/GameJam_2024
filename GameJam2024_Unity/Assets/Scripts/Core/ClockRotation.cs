using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    public Vector3 rotationDirection;
    public float durationTime;
    private float smooth;

    void Update()
    {
        //Rotate um X Achse
        smooth = Time.deltaTime * durationTime;
        transform.Rotate(rotationDirection * smooth);
    }
}
