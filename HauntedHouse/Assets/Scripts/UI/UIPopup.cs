using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class UIPopup : UIInputManager
{
    public CanvasGroup canvasGroup;

    public bool freezeCharacters;

    protected virtual void openPopup() {
        MMUIEvent.Trigger(MMUIEventType.Open, gameObject.name);
        canvasGroup.alpha = 1.0f;
        
        if (freezeCharacters) {
            setCharacterFreezeState(true);
        }
    }

    protected virtual void closePopup() {
        MMUIEvent.Trigger(MMUIEventType.Close, gameObject.name);
        canvasGroup.alpha = 0.0f;

        if (freezeCharacters) {
            setCharacterFreezeState(false);
        }
    }

    private void setCharacterFreezeState(bool freeze) {
        List<Character> activeCharacters = LevelManager.Instance.Players;
        foreach (Character character in activeCharacters) {
            if (freeze) {
                character.Freeze();
                character.MovementState.ChangeState(CharacterStates.MovementStates.Idle);
            }
            else {
                character.UnFreeze();
            }
        }

    }
}
