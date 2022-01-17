using System.Collections;
using UnityEngine;

public class FollowDiver : MonoBehaviour
{
    public GameObject diver, helmet;
    [SerializeField] private Vector3 offset = new Vector3(0.5f, 1.5f, 0f);

    private void Update()
    {
        if(diver != null)
        {
            if(helmet == null)
            {
                foreach (Transform child in diver.transform)
                {
                    if(child.GetComponentInChildren<HelmetPos>().gameObject != null)
                    {
                        helmet = child.GetComponentInChildren<HelmetPos>().gameObject;
                        transform.parent = helmet.transform;
                        gameObject.transform.position = offset;
                    }
                    if(helmet != null) { break; }
                }
            }
            gameObject.transform.localPosition = offset;
        } 
        else
        {
            diver = RoomManager.diver;
        }
    }
}