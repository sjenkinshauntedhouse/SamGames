using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class AIActionFlyBackToPerch : AIAction
{
    
    protected CharacterMovement _characterMovement;
    private List<Transform> _possibleTargets;

    private float _moveSpeed = 5.0f;

    public override void Initialization() {
        _characterMovement = this.gameObject.GetComponentInParent<Character>()?.FindAbility<CharacterMovement>();
        _possibleTargets = this.gameObject.GetComponentInParent<HauntedHouseRoom>()?.moveableLocations;
    }

    public override void PerformAction() {
       StartCoroutine(move());
    }

    public IEnumerator move() {
        // Move the player towards the target position using Lerp
        transform.position = Vector2.MoveTowards(transform.position, _brain.Target.position, _moveSpeed * Time.deltaTime);
        yield return null;
    }

    public override void OnEnterState() {
        setTarget();
    }

    private void setTarget() {
        int rand = UnityEngine.Random.Range(0, _possibleTargets.Count);
        _brain.Target = _possibleTargets[rand];

    }
}
