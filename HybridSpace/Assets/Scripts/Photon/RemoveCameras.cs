using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCameras : MonoBehaviour
{
    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (!PV.IsMine)
        {
            try
            {
                Debug.Log("Diver Joined");
                Destroy(GetComponentInChildren<Camera>().gameObject);
            }
            catch 
            {
                Debug.Log("Boatcrew Joined");
                Destroy(this.transform.Find("VRCamera"));
                this.transform.Find("Diver").GetComponent<Valve.VR.InteractionSystem.Player>().enabled = false;
                this.transform.Find("Helmet").GetComponent<HelmetPos>().enabled = false;
            }
        }
    }
}