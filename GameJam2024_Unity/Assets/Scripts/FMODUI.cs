using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODUI : MonoBehaviour
{
    public void SetWinParameter()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Win", 1);
    }
}
