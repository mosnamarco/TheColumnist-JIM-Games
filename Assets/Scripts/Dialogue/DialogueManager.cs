using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkJSON;
    public TextMeshProUGUI dialogueText;
    public Button buttonPrefab;
    public GameObject choicePanel;

    private Story currentStory;

    private void Start()
    {
        currentStory = new Story(inkJSON.text);
        dialogueText.text = currentStory.Continue();
    }

    public void continueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        } 
        else if (currentStory.currentChoices.Count > 0)
        {
            foreach (Choice choice in currentStory.currentChoices)
            {
                Button choiceInstance = Instantiate(buttonPrefab, choicePanel.transform);
                choiceInstance.GetComponentInChildren<TMP_Text>().text = choice.text;

                choiceInstance.onClick.AddListener(delegate {
                    chooseChoiceIndex(choice);
                });
            }
        }
        else
        {
            Debug.LogWarning("Current Story Can't continue");
        }
    }

    private void chooseChoiceIndex(Choice choice)
    {
        currentStory.ChooseChoiceIndex(choice.index);
        continueStory();

        foreach (Transform child in choicePanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
