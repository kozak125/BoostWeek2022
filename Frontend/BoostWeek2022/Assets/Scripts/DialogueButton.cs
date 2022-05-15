using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text buttonText;
    private ScenarioDefinition.Option thisDialogueOption;

    public void Setup(ScenarioDefinition.Option dialgoueOption)
    {
        thisDialogueOption = dialgoueOption;
        var button = GetComponent<Button>();
        button.onClick.AddListener(() => InvokeDialogueCondition(thisDialogueOption));
        button.onClick.AddListener(() => TryPlaySoundEffect(dialgoueOption.SoundEffect));
        button.onClick.AddListener(() => CleanListeners());
        if (dialgoueOption.DialogueOptionFormat != null)
        {
            CreateDescriptionStyle(dialgoueOption.DialogueOptionFormat);
        }

        buttonText.text = thisDialogueOption.DialogueOptionText;
        foreach (var condition in thisDialogueOption.ConditionalBranches)
        {
            if (!condition.OnlyCheckCondition)
            {
                condition.ConditionForBranch.Subscribe(thisDialogueOption);
            }
        }
    }

    private void InvokeDialogueCondition(ScenarioDefinition.Option dialgoueOption)
    {
        MessageBroker.Instance.OnDialogueOptionClicked?.Invoke(dialgoueOption);
    }

    private void TryPlaySoundEffect(AudioClip soundEffect)
    {
        MessageBroker.Instance.OnTryPlayDialogueSoundEffect.Invoke(soundEffect);
    }

    private void CleanListeners()
    {
        foreach (var condition in thisDialogueOption.ConditionalBranches)
        {
            if (!condition.OnlyCheckCondition)
            {
                condition.ConditionForBranch.Unsubscribe(thisDialogueOption);
            }
        }
    }

    private void CreateDescriptionStyle(TMP_Text style)
    {
        buttonText.fontStyle = style.fontStyle;
        buttonText.textStyle = style.textStyle;
    }
}
