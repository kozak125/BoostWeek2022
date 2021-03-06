using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField]
    private ScenarioPicker scenarioPicker;
    [SerializeField]
    private ScenarioMusicManager scenarioMusicManager;
    [SerializeField]
    private Image scenarioImage;
    [SerializeField]
    private TMP_Text scenarioDescription;
    [SerializeField]
    private GameObject scenarioOptionButton;
    [SerializeField]
    private GameObject optionButtonsParent;
    [SerializeField]
    private FadeInController fadeInController;

    private ScenarioDefinition currentScenario;

    public void LoadFirstScenario(ScenarioDefinition startingScenario)
    {
        currentScenario = startingScenario;
        ChangeScenario(startingScenario);
    }


    private void ChangeScenario(ScenarioDefinition newScenario)
    {
        if (currentScenario.IsEnding)
        {
            MessageBroker.Instance.OnLifeLost?.Invoke();
            fadeInController.FadeToWhite();
        }

        if (currentScenario.ScenarioConditionToTrack != null)
        {
            currentScenario.ScenarioConditionToTrack.Unsubscribe(null);
        }

        ClearPreviousScenario();
        currentScenario = newScenario;
        if (currentScenario.ScenarioConditionToTrack != null)
        {
            currentScenario.ScenarioConditionToTrack.Subscribe(null);
        }

        SetScenario(newScenario);
        scenarioMusicManager.TryPlayNewAudio(newScenario.ScenarioMusicGroup, newScenario.ScenarioMusic);
        MessageBroker.Instance.OnScenarioVisited?.Invoke();
    }

    private void ClearPreviousScenario()
    {
        foreach (Transform child in optionButtonsParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetScenario(ScenarioDefinition newScenario)
    {
        scenarioImage.sprite = newScenario.ScenarioImage;
        if (newScenario.ScenarioDescriptionFormat != null)
        {
            CreateDescriptionStyle(newScenario.ScenarioDescriptionFormat);
        }

        scenarioDescription.text = newScenario.ScenarioDescription.Replace("\\n", "\n");
        GameObject dialogueButton;
        foreach (var button in newScenario.DialogueOptions)
        {
            dialogueButton = Instantiate(scenarioOptionButton, optionButtonsParent.transform);
            dialogueButton.GetComponent<DialogueButton>().Setup(button);
            dialogueButton.GetComponent<Button>().onClick.AddListener(() => PickNewScenario(button));
        }
    }

    private void CreateDescriptionStyle(TMP_Text style)
    {
        scenarioDescription.fontStyle = style.fontStyle;
        scenarioDescription.textStyle = style.textStyle;
    }

    private void PickNewScenario(ScenarioDefinition.Option option)
    {
        var chosenScenario = scenarioPicker.PickScenario(option);
        ChangeScenario(chosenScenario);
    }
}
