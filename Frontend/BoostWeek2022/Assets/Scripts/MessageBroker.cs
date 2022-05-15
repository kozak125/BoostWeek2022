using System;

public class MessageBroker
{
    private static MessageBroker instance = null;
    public static MessageBroker Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MessageBroker();
            }

            return instance;
        }
    }

    public Action OnLifeLost;
    public Action OnScenarioVisited;
    public Action<ScenarioDefinition.Option> OnDialogueOptionClicked;
    public Action<UnityEngine.AudioClip> OnTryPlayDialogueSoundEffect;
}
