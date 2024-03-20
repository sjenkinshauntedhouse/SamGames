using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplay : MonoBehaviour
{
    public Text spiritCounter;
    // Start is called before the first frame update
    void Start() {
        CurrencyManager.Instance.onCurrencyChanged += updateCurrency;
    }

    public void updateCurrency(string type, int newAmount) {
        if (type.Equals("spirit")) {
            spiritCounter.text = $"Spirits: {newAmount.ToString()}";    
        }
    }
}
