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
        button.onClick.AddListener(() => CleanListeners());
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
}
