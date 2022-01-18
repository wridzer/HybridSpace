using System.Collections;
using UnityEngine;

public class BoatInputDelete : MonoBehaviour, IPlayable
{
    [SerializeField] private GameObject cam;

    public GameObject IsOtherPlayer()
    {
        Destroy(cam);

        return gameObject;
    }
}