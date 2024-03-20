using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "HauntedHouseInventoryWeapon", menuName = "MoreMountains/TopDownEngine/HauntedHouseInventoryWeapon", order = 1)]
[Serializable]
public class HauntedHouseInventoryWeapon : InventoryWeapon {
    public int costToBuy;
}
