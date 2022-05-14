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

    public Action LifeLost;
}
