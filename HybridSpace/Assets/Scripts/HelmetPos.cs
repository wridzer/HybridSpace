using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetPos : MonoBehaviour
{
    [SerializeField] private GameObject cameraInstance;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private Vector3 offsetPos = new Vector3(0, -0.045f, 0);
    [SerializeField] private Vector3 offsetRot = new Vector3(0, 90, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotateSpeed = 5 * Time.deltaTime;
        Vector3 difference = rightHand.transform.position - leftHand.transform.position;
        transform.position = Camera.main.transform.position + offsetPos;
        Vector3 puntD = new Vector3(leftHand.transform.position.x + (difference.x * 0.5f), transform.position.y, leftHand.transform.position.z + (difference.z * 0.5f));
        Vector3 lookDir = Vector3.RotateTowards(transform.forward, transform.position - puntD, rotateSpeed, 0f);
        transform.rotation = Quaternion.LookRotation(lookDir);
    }
}