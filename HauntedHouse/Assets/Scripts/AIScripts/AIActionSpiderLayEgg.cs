using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class AIActionSpiderLayEgg : AIAction {
    private Enemy enemy;
    public override void Initialization() {
        enemy = gameObject.transform.GetComponent<Enemy>();
    }

    public override void PerformAction() {
        
    }

    public override void OnEnterState() {
        if (enemy != null) {
            enemy.layEgg();
        }
    }
}
