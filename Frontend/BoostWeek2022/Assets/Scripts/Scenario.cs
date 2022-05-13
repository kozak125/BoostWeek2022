using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scenario")]
public class Scenario : ScriptableObject
{
    [SerializeField]
    private Image scenarioImage;
    [SerializeField]
    private string scenarioDescription;
    [SerializeField]
    private List<Options> dialogueOptions;
    [SerializeField]
    private bool isBranching = true;

    public Image ScenarioImage => scenarioImage;
    public string ScenarioDescription => scenarioDescription;
    public bool IsBranching => isBranching;

    [Serializable]
    private class Options
    {
        [SerializeField]
        private string dialogueOption;
        [SerializeField]
        private Scenario branch;
    }

    [Serializable]
    private class ScenarioBranching
    {
        [SerializeField]
        private List<Scenario> branch;
    }
}
