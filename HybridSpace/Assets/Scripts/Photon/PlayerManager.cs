using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Diver"), new Vector3(0, 0, 0), Quaternion.identity);
        } else
        {
            GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TestPlayer"), new Vector3(50, 2, 50), Quaternion.identity);

        }
    }
}
