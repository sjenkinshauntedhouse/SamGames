using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : ScriptableObject {
    public string questName;
    public string description;
    public Sprite icon;
    public EQuestType type;
    public int rewardWeight;
    public int valueRequired;
}

[CreateAssetMenu(fileName = "Kill Quest", menuName = "HauntedHouse/Quest System/Kill Quest Data")]
public class KillQuestData : QuestData {
    public HauntedHouseEnemyTypes enemyType;
}

[CreateAssetMenu(fileName = "Spend Quest", menuName = "HauntedHouse/Quest System/Spend Quest Data")]
public class SpendQuestData : QuestData {
}

public enum EQuestType {
    Kills,
    Time,
    Upgrade,
    Spend
}
