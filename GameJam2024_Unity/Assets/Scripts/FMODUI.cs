using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODUI : MonoBehaviour
{
    public void SetWinParameter(float val)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Win", val);
    }

    public void PlayClockWindAnim()
    {
        FMODUnity.RuntimeManager.PlayOneShot("{8821c796-aa66-42a8-826f-2dd3cd32348d}");
    }
    
}
