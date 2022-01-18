using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private bool playSound = false;

    void Update()
    {
        if (playSound)
        {
            instance = FMODUnity.RuntimeManager.CreateInstance("event:/SymbolActive");
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            instance.start();
            instance.release();
        }
    }
}
