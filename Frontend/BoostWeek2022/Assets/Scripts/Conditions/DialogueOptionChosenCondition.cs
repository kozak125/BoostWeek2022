using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/DialogueOptionChosen")]
public class DialogueOptionChosenCondition : IntegerCondition
{
    private ScenarioDefinition.Option assignedDialogueOption;

    private void OnEnable()
    {
        StoreInitialValue();
    }

    private void OnDisable()
    {
        ResetValue();
    }

    public override void Subscribe(ScenarioDefinition.Option option)
    {
        assignedDialogueOption = option;
        MessageBroker.Instance.OnDialogueOptionClicked += TryInvoke;
    }

    public override void Unsubscribe(ScenarioDefinition.Option option)
    {
        MessageBroker.Instance.OnDialogueOptionClicked -= TryInvoke;
    }

    private void TryInvoke(ScenarioDefinition.Option option)
    {
        if (assignedDialogueOption == option)
        {
            IncrementValue();
        }
    }
}
