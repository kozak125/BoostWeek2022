using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField]
    private ScenarioPicker scenarioPicker;
    [SerializeField]
    private ScenarioDefinition startingScenario;
    [SerializeField]
    private Image scenarioImage;
    [SerializeField]
    private TMP_Text scenarioDescription;
    [SerializeField]
    private GameObject scenarioOptionButton;
    [SerializeField]
    private GameObject optionButtonsParent;

    private ScenarioDefinition currentScenario;

    private void Awake()
    {
        ChangeScenario(startingScenario);
    }


    private void ChangeScenario(ScenarioDefinition newScenario)
    {
        ClearPreviousScenario();
        currentScenario = newScenario;
        SetScenario(newScenario);
        MessageBroker.Instance.OnScenarioVisited?.Invoke();
        if (currentScenario.IsEnding)
        {
            MessageBroker.Instance.OnLifeLost?.Invoke();
        }
    }

    private void ClearPreviousScenario()
    {
        foreach (Transform child in optionButtonsParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void SetScenario(ScenarioDefinition newScenario)
    {
        scenarioImage.sprite = newScenario.ScenarioImage;
        scenarioDescription.text = newScenario.ScenarioDescription;
        GameObject dialogueButton;
        foreach (var button in newScenario.DialogueOptions)
        {
            dialogueButton = Instantiate(scenarioOptionButton, optionButtonsParent.transform);
            dialogueButton.GetComponent<DialogueButton>().Setup(button);
            dialogueButton.GetComponent<Button>().onClick.AddListener(() => PickNewScenario(button));
        }
    }

    private void PickNewScenario(ScenarioDefinition.Option option)
    {
        var chosenScenario = scenarioPicker.PickScenario(option);
        ChangeScenario(chosenScenario);
    }
}
