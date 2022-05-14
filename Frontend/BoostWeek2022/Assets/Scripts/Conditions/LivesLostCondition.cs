using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/LivesLost")]
public class LivesLostCondition : IntegerCondition
{
    private void OnEnable()
    {
        MessageBroker.Instance.OnLifeLost += IncrementValue;
        StoreInitialValue();
    }

    private void OnDisable()
    {
        MessageBroker.Instance.OnLifeLost -= IncrementValue;
        ResetValue();
    }

    public override void Subscribe(ScenarioDefinition.Option option)
    {
        // we subscribe globally
    }

    public override void Unsubscribe(ScenarioDefinition.Option option)
    {
        // we unsubscribe globally
    }
}
