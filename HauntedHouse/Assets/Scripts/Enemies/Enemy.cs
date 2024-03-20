using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HauntedHouseEnemyTypes enemyType;
    [SerializeField] protected Health health;
    private void Awake() {
    }

    private void Start() {
        
        health.OnDeath += onDeath;
    }

    protected virtual void onDeath() {
        CurrencyManager.Instance.incrementSpiritCurrency(1);
        CurrencyManager.Instance.incrementEnemyCurrency(enemyType, 1);
        
        QuestManager.Instance.updateKillQuests(enemyType);
        
    }

    public virtual void layEgg() {
        
    }
}

public enum HauntedHouseEnemyTypes {
    SPIDER,
    BAT,
    GHOST,
    ANY
}
