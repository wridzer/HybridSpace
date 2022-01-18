using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Vector2 input;
    [SerializeField] private float movementSpeed = 1;
    private CharacterController characterController;
    [SerializeField] private GameObject helmet;

    private FMOD.Studio.EventInstance instance;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.axis.magnitude > 0.1f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            characterController.Move(Vector3.ProjectOnPlane(direction, Vector3.up) * movementSpeed * Time.deltaTime - new Vector3(0, 9.81f, 0)*Time.deltaTime);
            FootstepSound();
        }
    }

    void FootstepSound()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        instance.start();
        instance.release();
    }
}
