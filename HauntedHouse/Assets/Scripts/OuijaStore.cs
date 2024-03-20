using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class OuijaStore : ButtonActivated, MMEventListener<MMCharacterEvent>
{
    public Inventory ouijaInventory;
    //public InventoryInputManager inventoryManager;
    public QuestDisplay questDisplay;
    public InventoryItem[] inventoryItems;
    
    private bool _isInventoryOpen;

    private bool _isInStoreRange = false;

    private void Awake() {
        foreach (InventoryItem item in inventoryItems) {
            ouijaInventory.AddItem(item, 1);
        }
    }

    protected override void OnEnable() {
        base.OnEnable ();
        this.MMEventStartListening<MMCharacterEvent>();
    }

    public void interact() {
        _isInventoryOpen = !_isInventoryOpen;
        questDisplay.Open();
    }

    public void OnMMEvent(MMCharacterEvent characterEvent) {
        if (characterEvent.TargetCharacter.CharacterType == Character.CharacterTypes.Player) {
            if (characterEvent.TargetCharacter.GetComponent<CharacterButtonActivation>()?.ButtonActivatedZone == this) {
                interact();
            }
        }
    }
}
