using Arch.Core;

namespace Arch.Net;

public static class ClientWorld
{
    private static World? _world;
    private static RequestsQueue? _requestsQueue;
    private static ResponseQueue? _responseQueue;


    public static void Initialize(INetworkProtocol networkProtocol)
    {
        _world = World.Create();
        _requestsQueue = new RequestsQueue(networkProtocol);
        _responseQueue = new ResponseQueue(networkProtocol, _world);
    }

    public static void Update()
    {
        _requestsQueue?.Update();
        _responseQueue?.Update();
    }

    public static void Create<T0>(in T0? t0Component = default)
    {
        _requestsQueue?.EnqueueCreate(t0Component);
    }
}
