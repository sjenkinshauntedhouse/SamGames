using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class SpiderEnemy : Enemy {

    public GameObject spiderSprite;
    public GameObject eggSprite;

    public GameObject spiderInstance;

    private AIBrain _aiBrain;

    private bool isDead = false;

    private void Awake() {
        _aiBrain = transform.GetComponent<AIBrain>();
    }

    protected override void onDeath() {
        base.onDeath();
        isDead = true;
    }

    public override void layEgg() {
        var obj = Instantiate(spiderInstance, gameObject.transform.parent, true).GetComponent<SpiderEnemy>();
        obj.setEggState();
    }

    public void setEggState() {
        _aiBrain.ResetBrainOnStart = false;
        _aiBrain.BrainActive = false;
        eggSprite.Activate();
        spiderSprite.Deactivate();
        health.InitialHealth = 20.0f;
        StartCoroutine(waitForEggToHatch());
    }

    private IEnumerator waitForEggToHatch() {
        yield return new WaitForSeconds(3.0f);
        if (!isDead) {
            eggSprite.Deactivate();
            spiderSprite.Activate();
        }

        _aiBrain.ResetBrain();
        _aiBrain.BrainActive = true;
        health.InitialHealth = health.MaximumHealth;
    }
}
