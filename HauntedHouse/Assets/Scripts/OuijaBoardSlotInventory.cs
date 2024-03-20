using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.UI;

public class OuijaBoardSlotInventory : InventorySlot { 
    public Text cost;
    public GameObject price;

    private HauntedHouseInventoryWeapon _item;

    protected override void Start() {
        this.onClick.AddListener(SlotClicked);
        _item = ParentInventoryDisplay.TargetInventory.Content[Index] as HauntedHouseInventoryWeapon;
        SetPrice();
    }

    public override void Equip()
    {
        if (canBuy()) {
            base.Equip();
        }
    }

    public void SetPrice() {
        if (_item != null) {
            cost.text = _item.costToBuy.ToString();
            price.gameObject.SetActive(true);
        }
    }

    private bool canBuy() {
        return CurrencyManager.Instance.spendSpiritCurrency(_item.costToBuy);
    }
}
