using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioPicker : MonoBehaviour
{
    public ScenarioDefinition PickScenario(ScenarioDefinition.Option optionsForScenario)
    {
        if (optionsForScenario.ConditionalBranches.Count == 0)
        {
            return optionsForScenario.DefaultScenario;
        }

        return StartConditionalScenarioOrDefault(optionsForScenario);
    }

    private ScenarioDefinition StartConditionalScenarioOrDefault(ScenarioDefinition.Option options)
    {
        ScenarioDefinition scenario;
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

    private ScenarioDefinition TryStartConditionalScenario(ScenarioDefinition.ConditionalBranching conditionalBranch)
    {
        if (conditionalBranch.ConditionForBranch.Value >= conditionalBranch.MinimalViableValue && conditionalBranch.ConditionForBranch.Value < conditionalBranch.MaxViableValue)
        {
            return conditionalBranch.Branch;
        }

        return null;
    }
}
