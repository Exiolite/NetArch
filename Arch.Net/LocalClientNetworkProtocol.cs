namespace Arch.Net;

public class ClientLocalNetworkProtocol : INetworkProtocol
{
    public Action<EntityDto> OnMessageSent;

    public Action<EntityDto> OnMessageReceived { get; set; }


    public void SendMessage(EntityDto message)
    {
        OnMessageSent?.Invoke(message);
    }


    public void Update()
    {
    }
}

public class ServerLocalNetworkProtocol : INetworkProtocol
{
    public Action<EntityDto> OnMessageSent;

    public Action<EntityDto> OnMessageReceived { get; set; }


    public void SendMessage(EntityDto message)
    {
        OnMessageSent?.Invoke(message);
    }


    public void Update()
    {
    }
}
