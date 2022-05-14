using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField]
    private ScenarioPicker scenarioPicker;
    [SerializeField]
    private Scenario startingScenario;
    [SerializeField]
    private Image scenarioImage;
    [SerializeField]
    private TMP_Text scenarioDescription;
    [SerializeField]
    private GameObject scenarioOptionButton;
    [SerializeField]
    private GameObject optionButtonsParent;

    private Scenario currentScenario;

    private void Awake()
    {
        ChangeScenario(startingScenario);
    }


    private void ChangeScenario(Scenario newScenario)
    {
        ClearPreviousScenario();
        currentScenario = newScenario;
        SetScenario(newScenario);
        if (currentScenario.IsEnding)
        {
            MessageBroker.Instance.LifeLost.Invoke();
        }
    }

    private void ClearPreviousScenario()
    {
        foreach (Transform child in optionButtonsParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void SetScenario(Scenario newScenario)
    {
        scenarioImage.sprite = newScenario.ScenarioImage;
        scenarioDescription.text = newScenario.ScenarioDescription;
        GameObject dialogueButton;
        foreach (var button in newScenario.DialogueOptions)
        {
            dialogueButton = Instantiate(scenarioOptionButton, optionButtonsParent.transform);
            dialogueButton.GetComponent<Button>().onClick.AddListener(() => PickNewScenario(button));
            dialogueButton.GetComponentInChildren<TMP_Text>().text = button.DialogueOptionText;
        }
    }

    private void PickNewScenario(Scenario.Option option)
    {
        var chosenScenario = scenarioPicker.PickScenario(option);
        ChangeScenario(chosenScenario);
    }
}
