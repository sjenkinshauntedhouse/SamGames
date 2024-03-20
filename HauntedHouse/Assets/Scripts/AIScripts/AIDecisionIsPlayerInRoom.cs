using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class AIDecisionIsPlayerInRoom : AIDecision
{

    private HauntedHouseRoom _roomEnemyIsIn;
    public override void Initialization() {
        _roomEnemyIsIn = gameObject.GetComponentInParent<HauntedHouseRoom>();
    }

    public override bool Decide() {
        return _roomEnemyIsIn.isAnyPlayerInRoom();
    }
}
