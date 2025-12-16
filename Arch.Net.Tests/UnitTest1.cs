using Arch.Core;

namespace Arch.Net.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        ClientLocalNetworkProtocol clientLocalNetworkProtocol = new();
        ServerLocalNetworkProtocol serverLocalNetworkProtocol = new();
        clientLocalNetworkProtocol.OnMessageSent += serverLocalNetworkProtocol.OnMessageReceived;
        serverLocalNetworkProtocol.OnMessageSent += clientLocalNetworkProtocol.OnMessageReceived;
        ClientWorld.Initialize(clientLocalNetworkProtocol);
        ServerWorld.Initialize(serverLocalNetworkProtocol);
    }


    [Test]
    public void Test1()
    {
        ClientWorld.Create(new TestComponent());
        ClientWorld.Update();
        ServerWorld.Update();
        Assert.AreEqual(1, ServerWorld.Count());
    }
}
