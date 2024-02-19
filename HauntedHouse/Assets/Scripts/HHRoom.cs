using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class HHRoom : MonoBehaviour
{
    public Door3D door;
    public GameObject fog;

    private void Awake() {
        door.OnPushDoor += doorPushedEvent;
    }

    public void doorPushedEvent() {
        fog.gameObject.SetActive(false);
    }
}
