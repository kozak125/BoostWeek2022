using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "Scenario")]
public class ScenarioDefinition : ScriptableObject
{
    [SerializeField]
    private Sprite scenarioImage;
    [SerializeField]
    private string scenarioDescription;
    [SerializeField]
    private TMP_Text scenarioDescriptionFormat;
    [SerializeField]
    private List<Option> dialogueOptions;
    [SerializeField]
    private ScenarioVisitedCondition scenarioConditionToTrack;
    [SerializeField]
    private bool isEnding = false;

    public Sprite ScenarioImage => scenarioImage;
    public string ScenarioDescription => scenarioDescription;
    public List<Option> DialogueOptions => dialogueOptions;
    public bool IsEnding => isEnding;
    public TMP_Text ScenarioDescriptionFormat => scenarioDescriptionFormat;
    public ScenarioVisitedCondition ScenarioConditionToTrack => scenarioConditionToTrack;

    [Serializable]
    public class Option
    {
        [SerializeField]
        private string dialogueOptionText;
        [SerializeField]
        private TMP_Text dialogueOptionFormat;
        [SerializeField]
        private ScenarioDefinition defaulScenario;
        [SerializeField]
        private List<ConditionalBranching> conditionalBranches;

        public string DialogueOptionText => dialogueOptionText;
        public ScenarioDefinition DefaultScenario => defaulScenario;
        public List<ConditionalBranching> ConditionalBranches => conditionalBranches;
        public TMP_Text DialogueOptionFormat => dialogueOptionFormat;
    }

    [Serializable]
    public class ConditionalBranching
    {
        [SerializeField]
        private ScenarioDefinition branch;
        [SerializeField]
        private IntegerCondition conditionForBranch;
        [SerializeField]
        private int minimalViableValue;
        [SerializeField]
        private int maxViableValue;
        [SerializeField]
        private bool onlyCheckCondition;

        public ScenarioDefinition Branch => branch;
        public IntegerCondition ConditionForBranch => conditionForBranch;
        public int MinimalViableValue => minimalViableValue;
        public int MaxViableValue => maxViableValue;
        public bool OnlyCheckCondition => onlyCheckCondition;
    }
}
