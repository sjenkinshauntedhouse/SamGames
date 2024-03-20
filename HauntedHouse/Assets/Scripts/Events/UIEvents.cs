using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public enum MMUIEventType { Open, Close }

public struct MMUIEvent
{

    public MMUIEventType uiEventType;
    public string uiDialogName;
    
    static MMUIEvent e;
    
    public static void Trigger(MMUIEventType eventType, string name) {
        e.uiEventType = eventType;
        e.uiDialogName = name;
        MMEventManager.TriggerEvent(e);
    }
}
