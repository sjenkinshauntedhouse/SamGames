using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static GameObject Activate(this GameObject gameObject) {
        if (gameObject != null) {
            gameObject.SetActive(true);
        }

        return gameObject;
    }
    
    public static GameObject Deactivate(this GameObject gameObject) {
        if (gameObject != null) {
            gameObject.SetActive(false);
        }

        return gameObject;
    }
}
