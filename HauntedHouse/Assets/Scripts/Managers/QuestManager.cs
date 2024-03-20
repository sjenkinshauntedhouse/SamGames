using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using MoreMountains.Tools;
using UnityEngine;

public class QuestManager : MMSingleton<QuestManager> {
    public QuestData[] questData;
    public HauntedHouseResourceItem[] lootTable;
    public Inventory chestInventory;

    public List<Quest> activeQuests = new();

    private void Awake() {
        setActiveQuests();
    }

    private void setActiveQuests() {
        foreach (QuestData data in questData) {
            Quest quest = new Quest(data);
            quest.createRewards(lootTable);
            activeQuests.Add(quest);
        }
    }

    public void updateKillQuests(HauntedHouseEnemyTypes enemy) {
        foreach (Quest quest in activeQuests) {
            QuestData data = quest.getQuestData();
            if (data.type == EQuestType.Kills) {
                KillQuestData killData = (KillQuestData)data;
                if (killData.enemyType == enemy || killData.enemyType == HauntedHouseEnemyTypes.ANY) {
                    quest.incrementTracker(1);
                    Debug.Log($"Kill Quest {enemy}: {quest.getTrackerValue()}/{killData.valueRequired}");
                }
            }
        }
    }

    public void updateSpendQuest(int amountSpent) {
        foreach (Quest quest in activeQuests) {
            QuestData data = quest.getQuestData();
            if (data.type == EQuestType.Kills) {
                SpendQuestData spendData = (SpendQuestData)data;
                quest.incrementTracker(amountSpent);
                Debug.Log($"Kill Quest: {quest.getTrackerValue()}/{spendData.valueRequired}");
            }
        }
    }

    public string getProgressString(QuestData questData) {
        foreach (Quest quest in activeQuests) {
            if (quest.getQuestData() == questData) {
                return $"{quest.getTrackerValue()}/{quest.getQuestData().valueRequired}";
            }
        }
        return null;
    }

    public void claimItems(QuestItem finishedQuest) {
        Quest quest = finishedQuest.getQuest();
        if (!quest.isCompleted() || quest.hasQuestBeenClaimed()) {
            return;
        }
        
        foreach (KeyValuePair<HauntedHouseResourceItem, int> kvp in quest.getRewards()) {
            chestInventory.AddItem(kvp.Key, kvp.Value);
        }
        
        quest.setClaimed();
    }
}
