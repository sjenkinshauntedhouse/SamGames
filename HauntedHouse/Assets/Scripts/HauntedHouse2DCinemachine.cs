using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class HauntedHouse2DCinemachine : MMCinemachineZone2D
{
    protected override void OnTriggerExit2D(Collider2D other) {
        if (gameObject.activeSelf && gameObject.activeInHierarchy) {
            base.OnTriggerExit2D(other);
        }
    }
}
