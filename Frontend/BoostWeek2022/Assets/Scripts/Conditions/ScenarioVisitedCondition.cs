using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/ScenarioVisited")]
public class ScenarioVisitedCondition : IntegerCondition
{
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
        MessageBroker.Instance.OnScenarioVisited += IncrementValue;
    }

    public override void Unsubscribe(ScenarioDefinition.Option option)
    {
        MessageBroker.Instance.OnScenarioVisited -= IncrementValue;
    }
}
