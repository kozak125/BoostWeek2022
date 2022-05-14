using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/LivesLostCondition")]
public class LivesLostCondition : IntegerCondition
{
    private void OnEnable()
    {
        MessageBroker.Instance.LifeLost += IncrementValue;
        StoreInitialValue();
    }

    private void OnDisable()
    {
        MessageBroker.Instance.LifeLost -= IncrementValue;
        ResetValue();
    }
}
