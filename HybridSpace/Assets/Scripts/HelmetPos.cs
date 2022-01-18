using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetPos : MonoBehaviourPun
{
    [SerializeField] private GameObject cameraInstance;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private float rotateSpeed = 2.5f;
    [SerializeField] private Vector3 offsetPos = new Vector3(0, -0.045f, 0);
    [SerializeField] private Vector3 offsetRot = new Vector3(0, 90, 0);
    private PhotonTransformView PTV;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = rightHand.transform.position - leftHand.transform.position;
        transform.position = Camera.main.transform.position + offsetPos;
        Vector3 puntD = new Vector3(leftHand.transform.position.x + (difference.x * 0.5f), transform.position.y + cameraInstance.transform.forward.y, leftHand.transform.position.z + (difference.z * 0.5f));
        Vector3 lookDir = Vector3.RotateTowards(transform.forward, transform.position - puntD, rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(lookDir);
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
    }
}
