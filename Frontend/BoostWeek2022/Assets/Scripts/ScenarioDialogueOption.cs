using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScenarioDialogueOption : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dialogueText;
    private Button optionButton;

    private void Awake()
    {
        optionButton = GetComponent<Button>();
    }

    //public TMP_Text DialogueText => dialogueText;

    public void Setup(Scenario.Option dialogueOption)
    {
        dialogueText.text = dialogueOption.DialogueOptionText;
    }
}
