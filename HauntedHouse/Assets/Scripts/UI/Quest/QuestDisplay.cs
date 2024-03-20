using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestDisplay : UIPopup {

    public QuestItem[] questItems;
    public GameObject _objectSelector;

    private GameObject _lastSelectedGameObject;

    private void Start() {
        EventSystem.current.SetSelectedGameObject(questItems[0].gameObject);
        _lastSelectedGameObject = questItems[0].gameObject;
        _objectSelector.transform.SetParent(questItems[0].gameObject.transform);
        _objectSelector.transform.localPosition = Vector3.zero;
        
        List<Quest> activeQuests = QuestManager.Instance.activeQuests;
        for(int i = 0; i < activeQuests.Count; i++) {
            questItems[i].setup(activeQuests[i]);
            questItems[i].gameObject.Activate();
        }
    }

    public void Open() {
        List<Quest> activeQuests = QuestManager.Instance.activeQuests;
        for(int i = 0; i < activeQuests.Count; i++) {
            questItems[i].open(activeQuests[i]);
        }
        base.openPopup();
    }

    protected override void OnClickSubmitButton() {
        QuestItem item = _lastSelectedGameObject.GetComponent<QuestItem>();
        if (item != null) {
            QuestManager.Instance.claimItems(item);
        }
    }

    protected override void OnClickCloseButton() {
        base.closePopup();
    }

    private void Update() {
        // Get the currently selected GameObject
        GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;

        // If no GameObject is currently selected, set it to the last selected GameObject
        if (currentSelectedGameObject == null) {
            EventSystem.current.SetSelectedGameObject(_lastSelectedGameObject);
            return;
        }

        // If the currently selected GameObject has changed, update the last selected GameObject
        if (currentSelectedGameObject != _lastSelectedGameObject) {
            _lastSelectedGameObject = currentSelectedGameObject;
            _objectSelector.transform.SetParent(currentSelectedGameObject.transform);
            _objectSelector.transform.localPosition = Vector3.zero;
        }
        
        base.Update();
    }
}
