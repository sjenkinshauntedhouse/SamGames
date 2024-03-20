using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class HauntedHouseRoom : MonoBehaviour {
    public List<Transform> moveableLocations;
    private HauntedHouse2DCinemachine _cinemachineZone2D;

    private int _playersInside = 0;
    private bool _isPlayerInside;

    public void Awake() {
        _cinemachineZone2D = GetComponent<HauntedHouse2DCinemachine>();
    }

    public void Start() {
        _cinemachineZone2D.OnEnterZoneEvent.AddListener(onEnterZone);
        _cinemachineZone2D.OnExitZoneEvent.AddListener(onExitZone);
    }

    public void onEnterZone() {
        _playersInside++;
        checkIfPlayerIsInRoom();
    }

    private void onExitZone() {
        _playersInside--;
        checkIfPlayerIsInRoom();
    }

    void checkIfPlayerIsInRoom() {
        if (_playersInside > 0) {
            _isPlayerInside = true;
        }
        else {
            _isPlayerInside = false;
        } 
    }

    public bool isAnyPlayerInRoom() {
        return _isPlayerInside;
    }

    public void OnDestroy() {
        _cinemachineZone2D.OnEnterZoneEvent.RemoveAllListeners();
        _cinemachineZone2D.OnExitZoneEvent.RemoveAllListeners();
    }
}
