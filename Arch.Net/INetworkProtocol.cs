namespace Arch.Net;

public interface INetworkProtocol
{
    public Action<EntityDto> OnMessageReceived { get; set; }
    public void SendMessage(EntityDto message);
    public void Update();
}
