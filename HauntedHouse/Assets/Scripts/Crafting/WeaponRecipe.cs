using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponRecipe", menuName = "HauntedHouse/Resources/WeaponRecipe", order = 0)]
[Serializable]
public class WeaponRecipe : ScriptableObject {
    public string id;
    public string name;
    public List<ResourceEntry> requiredResources;

    public Sprite sprite;

    public MeleeWeapon prefab;

    public WeaponRecipe requiredWeapon;
}

[Serializable]
public class ResourceEntry
{
    public EResources resourceName;
    public int resourceAmount;
}
