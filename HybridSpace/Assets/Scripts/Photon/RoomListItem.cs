using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public RoomInfo info;

    public void Setup(RoomInfo _info)
    {
        info = _info;
        text.text = info.Name;
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }
}
