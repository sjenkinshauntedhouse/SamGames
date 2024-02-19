using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Rigidbody rig;
    public float moveSpeed;
    void Update() {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);
        
        Vector3 vel = rig.velocity;
        vel.y = 0;

        if (vel.x != 0 || vel.z != 0) {
            transform.forward = vel;    
        }
    }

    private void OnCo(Collider other) {
        if (other.CompareTag("Door")) {
            var go = other.GetComponent<GameObject>();
            go.SetActive(false);
        }
    }
}
