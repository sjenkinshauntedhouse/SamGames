using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class AIActionDiveBombPlayer : AIAction
{
    public bool delayAttack;
    private CharacterMovement _characterMovement;
    private bool _hasDelayed = false;
    private float _moveSpeed = 10.0f;

    public override void Initialization() {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    public override void PerformAction() {
        
        if (!_hasDelayed) {
            return;
        }

        StartCoroutine(move());
    }
    
    public IEnumerator move() {
        // Move the player towards the target position using Lerp
        transform.position = Vector2.MoveTowards(transform.position, _brain.Target.position, _moveSpeed * Time.deltaTime);
        yield return null;
    }
    
    private IEnumerator delayBeforeMoving() {
        float delay = UnityEngine.Random.Range(1.0f, 2.0f);
        yield return new WaitForSeconds(delay);
        _hasDelayed = true;
    }

    public override void OnEnterState() {;
        findNearestTarget();
        if (delayAttack) {
            StartCoroutine(delayBeforeMoving());    
        }
        else {
            _hasDelayed = true;
        }
        
    }

    public override void OnExitState() {
        _characterMovement.MovementSpeed = 3.0f;
        _hasDelayed = false;
        StopAllCoroutines();
    }

    private void findNearestTarget() {
        if (LevelManager.HasInstance && LevelManager.Instance.Players != null && LevelManager.Instance.Players.Count > 0) {
            int rnd = Random.Range(0, LevelManager.Instance.Players.Count);
            _brain.Target = LevelManager.Instance.Players[rnd].transform;
        }
    }
}
