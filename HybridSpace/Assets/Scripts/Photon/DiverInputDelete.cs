using System.Collections;
using UnityEngine;

public class DiverInputDelete : MonoBehaviour, IPlayable
{
    [SerializeField] private GameObject cam, helmet, scriptObject;

    public GameObject IsOtherPlayer()
    {
        helmet.GetComponent<HelmetPos>().enabled = false;
        cam.GetComponent<Camera>().enabled = false;
        scriptObject.GetComponent<Valve.VR.InteractionSystem.Player>().enabled = false;

        return gameObject;
    }
}