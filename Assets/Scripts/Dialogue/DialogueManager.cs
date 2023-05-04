using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private TextMeshProUGUI currentSpeaker;
    [SerializeField] private Image portrait;
    [SerializeField] private Image BG;

    private Story currentStory;
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string BACKGROUND_TAG = "background";

    private void Start()
    {
        currentStory = new Story(inkJSON.text);
        continueStory();
    }

    public void continueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            handleTags();
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

    private void handleTags()
    {
        string[] pair;
        string key, value;

        foreach (string tag in currentStory.currentTags)
        {
            pair = tag.Split(':');
            key = pair[0].Trim();
            value = pair[1].Trim();
            // Debug.Log("Key: " + key + "Value: " + value);
            switch (key)
            {
                case SPEAKER_TAG:
                    currentSpeaker.text = value; break;
                case PORTRAIT_TAG:
                    handlePortrait(value);
                    break;
                case BACKGROUND_TAG:
                    handleBackground(value);
                    break;
            }
        }
    }

    private void handleBackground(string backgroundImage)
    {
        BG.GetComponent<Animator>().Play(backgroundImage);
    }
    private void handlePortrait(string portraitImage)
    {
        portrait.GetComponent<Animator>().Play(portraitImage);
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
