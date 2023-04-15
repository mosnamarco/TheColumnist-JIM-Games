using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserGeneratedTitleHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text currentArticleTitle, alteredTitleText; 
    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    void OnInputFieldValueChanged(string value) {
        alteredTitleText.text = value;
    }
}
