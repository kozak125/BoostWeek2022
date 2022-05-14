using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private ScenarioManager scenarioManager;
    [SerializeField]
    private ScenarioDefinition scenarioDefinition;

    public void StartGame()
    {
        scenarioManager.LoadFirstScenario(scenarioDefinition);
        gameObject.SetActive(false);
    }
}
