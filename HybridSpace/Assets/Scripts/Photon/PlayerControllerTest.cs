using System.Collections;
using UnityEngine;
using Photon.Pun;

public class PlayerControllerTest : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
        UnityTemplateProjects.SimpleCameraController[] controllers = GetComponents<UnityTemplateProjects.SimpleCameraController>();
        foreach (UnityTemplateProjects.SimpleCameraController controller in controllers)
        {
            controller.enabled = false;
        }
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
        if (PV.IsMine)
        {
            PV.transform.GetComponent<UnityTemplateProjects.SimpleCameraController>().enabled = true;
        }
    }
}