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
    [SerializeField] private float offsetRot;
    [SerializeField] private float rotationThreshold = 1;
    private float currentRot;
    private PhotonTransformView PTV;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 difference = rightHand.transform.position - leftHand.transform.position;
        transform.position = Camera.main.transform.position + offsetPos;

        float verticalLook = transform.position.y + cameraInstance.transform.forward.y + offsetRot;
        if (verticalLook - currentRot > rotationThreshold || verticalLook - currentRot < -rotationThreshold)
        {
            Vector3 verticalRot = new Vector3(0, verticalLook, 0);
            currentRot = verticalLook;
        }

        Vector3 puntD = new Vector3(leftHand.transform.position.x + (difference.x * 0.5f), transform.position.y, leftHand.transform.position.z + (difference.z * 0.5f));
        Vector3 lookDir = Vector3.RotateTowards(transform.forward, transform.position - puntD, rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(lookDir);
    }
}
