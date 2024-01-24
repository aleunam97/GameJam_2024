using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class FMODPendulumSwoosh : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference swooshEvtRef;
    private FMOD.Studio.EventInstance _swooshInstance;

    private Vector3 prevPos;
    private float _speed;

    private FMOD.Studio.PARAMETER_ID speedID;

    private void Start()
    {
        _swooshInstance = FMODUnity.RuntimeManager.CreateInstance(swooshEvtRef);
        _swooshInstance.start();
        prevPos = transform.position;

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(_swooshInstance, gameObject.transform);
        
        _swooshInstance.getDescription(out FMOD.Studio.EventDescription descr);
        descr.getParameterDescriptionByName("speed", out PARAMETER_DESCRIPTION parDescr);
        speedID = parDescr.id;
    }

    private void FixedUpdate()
    {
        var curPos = transform.position;
        _speed = (prevPos - curPos).magnitude / Time.fixedDeltaTime / 10.0f;
        prevPos = curPos;
    }

    private void Update()
    {
        _swooshInstance.setParameterByID(speedID, _speed);
    }

    private void OnDestroy()
    {
        _swooshInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
