using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChoiceHandler : MonoBehaviour
{
    public void handleChoice()
    {
        GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log("The object that was clicked is: " + clickedObject.name);
    }
}
