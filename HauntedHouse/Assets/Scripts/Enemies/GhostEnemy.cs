using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class GhostEnemy : Enemy {
    public SpriteRenderer _ghostColor;

    void Awake() {
        health = transform.GetComponent<Health>();
    }

    public Color getRendererColor() {
        return _ghostColor.color;
    }

    public void setRendererColor(Color color) {
        _ghostColor.color = color;
    }

    public void setInvulnerablity(bool invulnerable) {
        health.Invulnerable = invulnerable;
    }
}
