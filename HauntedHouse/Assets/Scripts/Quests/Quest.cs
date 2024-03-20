using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {
    private QuestData questData;
    private int trackerValue;
    private bool completed;
    private bool hasClaimed;
    private Dictionary<HauntedHouseResourceItem, int> rewards;

    public Quest(QuestData data) {
        questData = data;
        rewards = new();
    }

    public void incrementTracker(int value) {
        if (trackerValue >= questData.valueRequired) {
            return;
        }

        trackerValue += value;
        checkForCompletion();
    }

    private void checkForCompletion() {
        completed = trackerValue >= questData.valueRequired;
    }

    public void createRewards(HauntedHouseResourceItem[] loot) {
        int totalWeight = 0;
        while (totalWeight < questData.rewardWeight) {
            int rand = Random.Range(0, loot.Length);
            HauntedHouseResourceItem potentialItem = loot[rand];
            if (totalWeight + potentialItem.weightRarity <= questData.rewardWeight) {
                totalWeight += potentialItem.weightRarity;
                if (rewards.ContainsKey(potentialItem)) {
                    rewards[potentialItem]++;
                }
                else {
                    rewards.Add(potentialItem, 1);
                }
            }
        }
    }

    public Dictionary<HauntedHouseResourceItem, int> getRewards() {
        return rewards;
    } 

    public QuestData getQuestData() {
        return questData;
    }

    public bool isCompleted() {
        return completed;
    }

    public void setClaimed() {
        hasClaimed = true;
    }

    public bool hasQuestBeenClaimed() {
        return hasClaimed;
    }

    public int getTrackerValue() {
        return trackerValue;
    }
}
