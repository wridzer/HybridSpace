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
            //geef iedere player een soort selfdestruct-script met een interface zodat je deze hier kan aanroepen
            GameObject otherPlayer = GetComponent<IPlayable>().IsOtherPlayer();
            if(gameObject.tag == "Player")
            {
                RoomManager.diver = otherPlayer;
            }
        }
    }
}