using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class AIActionFadeAndTeleport : AIAction
{
    private GhostEnemy _ghostEnemy;
    
    private float currentFadeTime = 0f;
    public float fadeDuration = 1f;
    private bool _hasFaded = false;
    private List<Transform> _possibleTargets;
    public override void Initialization() {
        _ghostEnemy = transform.GetComponent<GhostEnemy>();
        _possibleTargets = this.gameObject.GetComponentInParent<HauntedHouseRoom>()?.moveableLocations;
    }

    public override void PerformAction() {
        if (_hasFaded) {
            return;
        }

        _hasFaded = true;
        StartCoroutine(startFadeAndTeleport());
    }

    private IEnumerator startFadeAndTeleport() {
        _ghostEnemy.setInvulnerablity(true);
        yield return fade(1.0f, 0.0f);
        teleport();
        yield return fade(0.0f, 1.0f);
        _ghostEnemy.setInvulnerablity(false);
    }
    
    private IEnumerator fade(float start, float end) {
        float elapsedTime = 0f;
        Color color = _ghostEnemy.getRendererColor();

        while (elapsedTime < fadeDuration) {
            float t = elapsedTime / fadeDuration;
            color.a = Mathf.Lerp(start, end, t);
            _ghostEnemy.setRendererColor(color);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = end;
        _ghostEnemy.setRendererColor(color);
    }
    
    private void teleport() {
        int rnd = Random.Range(0, _possibleTargets.Count);
        Transform teleportLocation = _possibleTargets[rnd];
        gameObject.transform.position = teleportLocation.position;
    }

    public override void OnEnterState() {
        _hasFaded = false;
    }
}
