using System.Collections;
using System.Linq;
using UnityEngine;
using Photon.Pun;

public class PlayerControllerTest : MonoBehaviour
{
    PhotonView PV;

    void Start()
    {
        GameObject[] controllers = (GameObject[])GameObject.FindObjectsOfType<PhotonView>().OfType<GameObject>();
        foreach (GameObject controller in controllers)
        {
            PV = controller.transform.GetComponent<PhotonView>();
            if (!PV.IsMine)
            {
                //controller.enabled = false;
                Destroy(GetComponentInChildren<Camera>()?.gameObject);
            }
        }
    }
}