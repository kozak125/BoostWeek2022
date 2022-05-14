using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    [SerializeField]
    TMP_Text buttonText;
    public void Setup(ScenarioDefinition.Option dialgoueOption)
    {
        GetComponent<Button>().onClick.AddListener(() => InvokeDialogueCondition(dialgoueOption));
        buttonText.text = dialgoueOption.DialogueOptionText;
        foreach (var condition in dialgoueOption.ConditionalBranches)
        {
            if (!condition.OnlyCheckCondition)
            {
                condition.ConditionForBranch.Subscribe(dialgoueOption);
            }
        }
    }

    private void InvokeDialogueCondition(ScenarioDefinition.Option dialgoueOption)
    {
        MessageBroker.Instance.OnDialogueOptionClicked?.Invoke(dialgoueOption);
    }

    // Unsubscribe on destroy
}
