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

    private FMODMusic musicController;
    private int midCounter;

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

        musicController = GameObject.Find("MusicGlobal").GetComponent<FMODMusic>();
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

    public void MusicStartSync()
    {
        Debug.Log("Start");
        if (midCounter != 0)
            musicController.MusicStartSync();
    }
    
    public void MusicMidSync()
    {
        Debug.Log("Mid: Coutner: " + midCounter);
        //if(midCounter++ % 2 == 0)
        musicController.MusicMidSync();
    }
}
