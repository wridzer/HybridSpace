using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecalibratePlayer : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 startRot;
    [SerializeField] private GameObject playerInstance;

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerInstance.transform.position = startPos;
            playerInstance.transform.eulerAngles = startRot;
        }
    }
}
