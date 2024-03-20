using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class CurrencyManager : MMSingleton<CurrencyManager> {
    private int _spiritCurrencyCount;
    private Dictionary<HauntedHouseEnemyTypes, int> _enemyCurrencyCount = new Dictionary<HauntedHouseEnemyTypes, int>();

    public event Action<string, int> onCurrencyChanged;

    #region Spirit Currency Methods

    public void incrementSpiritCurrency(int amount) {
        _spiritCurrencyCount += amount;
        onCurrencyChanged?.Invoke("spirit", _spiritCurrencyCount);
    }

    public int getSpiritCurrencyAmount() {
        return _spiritCurrencyCount;
    }

    public bool spendSpiritCurrency(int amountToSpend) {
        if (amountToSpend > _spiritCurrencyCount) {
            return false;
        }

        _spiritCurrencyCount -= amountToSpend;
        onCurrencyChanged?.Invoke("spirit", _spiritCurrencyCount);
        QuestManager.Instance.updateSpendQuest(amountToSpend);
        return true;
    }

    #endregion

    #region Enemy Currency Methods

    public int getEnemyCurrencyAmountOfType(HauntedHouseEnemyTypes type) {
        int value = 0;
        _enemyCurrencyCount.TryGetValue(type, out value);
        return value;
    }

    public void incrementEnemyCurrency(HauntedHouseEnemyTypes type, int amount) {
        int value = 0;
        _enemyCurrencyCount.TryGetValue(type, out value);
        _enemyCurrencyCount[type] = value + amount;
        onCurrencyChanged?.Invoke(type.ToString(),_enemyCurrencyCount[type] );
    }

    #endregion
}
