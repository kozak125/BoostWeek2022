using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioPicker : MonoBehaviour
{
    public Scenario PickScenario(Scenario.Option optionsForScenario)
    {
        if (optionsForScenario.ConditionalBranches.Count == 0)
        {
            return optionsForScenario.DefaultScenario;
        }

        return StartConditionalScenarioOrDefault(optionsForScenario);
    }

    private Scenario StartConditionalScenarioOrDefault(Scenario.Option options)
    {
        Scenario scenario;
        foreach (var branch in options.ConditionalBranches)
        {
            scenario = TryStartConditionalScenario(branch);
            if (scenario != null)
            {
                return scenario;
            }
        }

        return options.DefaultScenario;
    }

    private Scenario TryStartConditionalScenario(Scenario.ConditionalBranching conditionalBranch)
    {
        if (conditionalBranch.ConditionForBranch.Value >= conditionalBranch.MinimalViableValue && conditionalBranch.ConditionForBranch.Value < conditionalBranch.MaxViableValue)
        {
            return conditionalBranch.Branch;
        }

        return null;
    }
}
