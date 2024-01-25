using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    private GameObject pendulum;
    private FMODPendulum pendulumScript;
    public bool makesUnmaskedNoise;
    public bool makesNoise;
    [SerializeField] private float noiseThreshold = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        pendulum = GameObject.Find("Pendulum");
        if (!pendulum)
        {
            Debug.LogError("Pendulum not found. Please add.");
            return;
        }
        
        pendulumScript = pendulum.GetComponent<FMODPendulum>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("NoiseObject"))
            return;
        makesNoise = true;
        var otherEmitter = other.GetComponent<StudioEventEmitter>();

        //otherEmitter.EventInstance.getParameterByName("isMasked", out float isMasked);
        //Debug.Log("Played noise with param: " + isMasked);
        otherEmitter.Play();
        otherEmitter.SetParameter("isMasked", pendulumScript.currentMaskingValue < noiseThreshold ? 0 : 1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("NoiseObject"))
            return;
        makesNoise = false;
    }

    private void FixedUpdate()
    {
        if (!pendulumScript)
            return;

        makesUnmaskedNoise = makesNoise && pendulumScript.currentMaskingValue < noiseThreshold;
    }

    public bool CheckUnmasked()
    {
        return makesNoise && pendulumScript.currentMaskingValue < noiseThreshold;
    }
}
