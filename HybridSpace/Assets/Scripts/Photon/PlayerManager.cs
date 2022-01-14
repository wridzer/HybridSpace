using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    private PhotonView PV;
    private GameObject host;

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
            host = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Diver"), new Vector3(50, 2, 50), Quaternion.identity);
            RoomManager.SetHost(host);
        } else
        {
            GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TestPlayer"), new Vector3(50, 2, 50), Quaternion.identity);
            player.transform.parent = this.transform.Find("Diver").GetComponent<Transform>();
            player.transform.localPosition = new Vector3(0.5f, 1.5f, 0f);
        }
    }
}
