using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetPos : MonoBehaviour
{
    [SerializeField] private GameObject cameraInstance;
    [SerializeField] private Vector3 offset = new Vector3(0, -0.045f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position + offset;
    }
}
