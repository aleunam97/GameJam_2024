using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class FMODPendulum : MonoBehaviour
{
    [SerializeField]
    private EventReference pendulumEvtRef;

    private PARAMETER_ID masking_ID;

    public float currentMaskingValue;

    private void Start()
    {
        RuntimeManager.StudioSystem.getParameterDescriptionByName("SoundMasker",
            out PARAMETER_DESCRIPTION maskDescr);
        masking_ID = maskDescr.id;
        
    }

    public void PlayPendulum()
    {
        RuntimeManager.PlayOneShotAttached(pendulumEvtRef, gameObject);
    }

    private void Update()
    {
        RuntimeManager.StudioSystem.getParameterByID(masking_ID, out _, out currentMaskingValue);
    }
}
