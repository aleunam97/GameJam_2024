using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODUI : MonoBehaviour
{
    public void SetWinParameter()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Win", 1);
    }

    public void PlayClockWindAnim()
    {
        FMODUnity.RuntimeManager.PlayOneShot("{8821c796-aa66-42a8-826f-2dd3cd32348d}");
    }
    
}
