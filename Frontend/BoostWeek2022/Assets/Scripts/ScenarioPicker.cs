using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioPicker : MonoBehaviour
{
    public Scenario PickScenario(Scenario.Option optionsForScenario)
    {
        return optionsForScenario.Branch;
    }
}
