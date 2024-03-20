using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    private bool _onSubmitButtonClicked;
    private bool _onCloseButtonClicked;
   protected virtual void Update() {
        _onSubmitButtonClicked = Input.GetKeyDown(KeyCode.Space);
        _onCloseButtonClicked = Input.GetKeyDown(KeyCode.Escape);

        if (_onSubmitButtonClicked) {
            OnClickSubmitButton();
        }

        if (_onCloseButtonClicked) {
            OnClickCloseButton();
        }
    }

    protected virtual void OnClickSubmitButton() { }
    
    protected virtual void OnClickCloseButton() { }
}
