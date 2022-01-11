using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    private PhotonView PV;
    private GameObject host;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            player.transform.parent = RoomManager.GetHost().transform;
        }
    }
}
