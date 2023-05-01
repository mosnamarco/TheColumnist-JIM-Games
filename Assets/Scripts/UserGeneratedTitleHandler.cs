using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UserGeneratedTitleHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // do something with user input
            Debug.Log(inputField.text);
            inputField.text = "";
        }
    }

    public void OnButtonClick()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log("Button clicked: " + clickedButton.name);

        if (clickedButton.name == "Choice 1") {
            // Do something with choice 1
        }

        if (clickedButton.name == "Choice 2") {
            // Do something with choice 2
        }

        if (clickedButton.name == "Choice 3") {
            // Do something with choice 3
        }
    }
}
