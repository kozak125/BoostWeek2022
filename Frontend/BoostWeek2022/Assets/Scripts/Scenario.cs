using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scenario")]
public class Scenario : ScriptableObject
{
    [SerializeField]
    private Sprite scenarioImage;
    [SerializeField]
    private string scenarioDescription;
    [SerializeField]
    private List<Option> dialogueOptions;

    public Sprite ScenarioImage => scenarioImage;
    public string ScenarioDescription => scenarioDescription;
    public List<Option> DialogueOptions => dialogueOptions;

    [Serializable]
    public class Option
    {
        [SerializeField]
        private string dialogueOptionText;
        [SerializeField]
        private Scenario branch;

        public string DialogueOptionText => dialogueOptionText;
        public Scenario Branch => branch;
    }

    [Serializable]
    private class ScenarioBranching
    {
        [SerializeField]
        private List<Scenario> branch;
    }
}
