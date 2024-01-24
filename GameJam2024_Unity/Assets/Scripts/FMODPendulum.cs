using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;

public class FMODPendulum : MonoBehaviour
{
    [SerializeField]
    private EventReference pendulumEvtRef;
    
    [SerializeField]
    private EventReference clockRingEvtRef;

    private EventInstance clockRing;

    private PARAMETER_ID maskingID;
    private PARAMETER_ID clockRingID;

    private int pendulumCounter = 11;
    private int chimesCount = 0;
    
    

    public float currentMaskingValue;

    private void Start()
    {
        RuntimeManager.StudioSystem.getParameterDescriptionByName("SoundMasker",
            out PARAMETER_DESCRIPTION maskDescr);
        clockRing = RuntimeManager.CreateInstance(clockRingEvtRef);
        EventDescription ringDescr = RuntimeManager.GetEventDescription(clockRingEvtRef);
        ringDescr.getParameterDescriptionByName("ClockStartRing", out PARAMETER_DESCRIPTION startDescr);
        clockRingID = startDescr.id;
        clockRing.start();
        RuntimeManager.AttachInstanceToGameObject(clockRing, transform);
        maskingID = maskDescr.id;

    }

    private void OnDestroy()
    {
        clockRing.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void PlayPendulum()
    {
        RuntimeManager.PlayOneShotAttached(pendulumEvtRef, gameObject);
       
        if(pendulumCounter++ % 15 == 0)
            PlayClockChimes(++chimesCount % 13);
    }

    private void PlayClockChimes(int amount)
    {
        clockRing.setParameterByID(clockRingID, amount);
    }

    private void Update()
    {
        RuntimeManager.StudioSystem.getParameterByID(maskingID, out _, out currentMaskingValue);
    }
}
