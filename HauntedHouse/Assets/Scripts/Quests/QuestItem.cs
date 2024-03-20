using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItem : Selectable
{
    public Image icon;
    public TextMeshProUGUI description;
    public GameObject progressPanel;
    public GameObject completePanel;
    public TextMeshProUGUI progress;
    public QuestRewardItem rewardItem;
    public Transform rewardPanel;

    private Quest _quest;

    public void setup(Quest quest) {
        _quest = quest;
        QuestData data = quest.getQuestData();
        icon.sprite = data.icon;
        description.text = data.description;
        progress.text = QuestManager.Instance.getProgressString(data);
        progressPanel.Activate();
        completePanel.Deactivate();
        
        Dictionary<HauntedHouseResourceItem, int> rewards = quest.getRewards();
        foreach (KeyValuePair<HauntedHouseResourceItem, int> kvp in rewards) {
            var item = Instantiate(rewardItem, rewardPanel);
            item.setUp(kvp.Value, kvp.Key.Icon);
        }
    }

    public void open(Quest quest) {
        if (quest.isCompleted()) {
            progressPanel.Deactivate();
            completePanel.Activate();
        }
    }

    public Quest getQuest() {
        return _quest;
    }
}
