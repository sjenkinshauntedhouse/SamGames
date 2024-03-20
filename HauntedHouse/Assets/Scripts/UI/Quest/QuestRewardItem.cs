using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestRewardItem : MonoBehaviour
{
    public TextMeshProUGUI amount;
    public Image icon;

    public void setUp(int amount, Sprite sprite) {
        this.amount.text = $"{amount}x";
        icon.sprite = sprite;
    }
}
