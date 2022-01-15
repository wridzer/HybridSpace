using System.Collections;
using UnityEngine;

public class FollowDiver : MonoBehaviour
{
    public GameObject diver;
    [SerializeField] private Vector3 offset = new Vector3(0.5f, 1.5f, 0f);

    private void Update()
    {
        if(diver != null)
        {
            transform.position = diver.transform.position + offset;
            transform.rotation = diver.GetComponentInChildren<Camera>().transform.rotation;
        } else
        {
            diver = RoomManager.diver;
        }
    }
}