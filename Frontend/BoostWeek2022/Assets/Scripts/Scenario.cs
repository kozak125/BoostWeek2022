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
    [SerializeField]
    private bool isEnding = false;

    public Sprite ScenarioImage => scenarioImage;
    public string ScenarioDescription => scenarioDescription;
    public List<Option> DialogueOptions => dialogueOptions;
    public bool IsEnding => isEnding;

    [Serializable]
    public class Option
    {
        [SerializeField]
        private string dialogueOptionText;
        [SerializeField]
        private Scenario defaulScenario;
        [SerializeField]
        private List<ConditionalBranching> conditionalBranches;

        public string DialogueOptionText => dialogueOptionText;
        public Scenario DefaultScenario => defaulScenario;
        public List<ConditionalBranching> ConditionalBranches => conditionalBranches;
    }

    [Serializable]
    public class ConditionalBranching
    {
        [SerializeField]
        private Scenario branch;
        [SerializeField]
        private IntegerCondition conditionForBranch;
        [SerializeField]
        private int minimalViableValue;
        [SerializeField]
        private int maxViableValue;

        public Scenario Branch => branch;
        public IntegerCondition ConditionForBranch => conditionForBranch;
        public int MinimalViableValue => minimalViableValue;
        public int MaxViableValue => maxViableValue;
    }
}
