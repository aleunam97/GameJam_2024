using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODMusic : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference musicRef;

    private FMOD.Studio.EventInstance musicInstance;
    private FMOD.Studio.PARAMETER_ID musicSubOffID;
    private void Start()
    {
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(musicRef);
        musicInstance.start();
        var musicDesc = FMODUnity.RuntimeManager.GetEventDescription(musicRef);
        musicDesc.getParameterDescriptionByName("ContinueMel", out FMOD.Studio.PARAMETER_DESCRIPTION parDesc);
        musicSubOffID = parDesc.id;
    }

    private void OnDestroy()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void MusicStartSync()
    {
        musicInstance.keyOff();
    }

    public void MusicMidSync()
    {
        musicInstance.keyOff();
        musicInstance.setParameterByID(musicSubOffID, 1);
    }
}
