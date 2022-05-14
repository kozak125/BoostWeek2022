using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IntegerCondition : ScriptableObject
{
    [SerializeField]
    protected int value;
    protected int initialValue;

    public int Value => value;

    protected void IncrementValue() => value++;
    protected void StoreInitialValue() => initialValue = value;
    protected void ResetValue() => value = initialValue;

    public abstract void Subscribe(ScenarioDefinition.Option option);
    public abstract void Unsubscribe(ScenarioDefinition.Option option);
}
