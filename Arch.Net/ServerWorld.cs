using Arch.Core;

namespace Arch.Net;

public static class ServerWorld
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


    public static int Count()
    {
        return _world!.CountEntities(new QueryDescription());
    }

    public static void Create(params ComponentType[] types)
    {
        _requestsQueue?.EnqueueCreate(types);
    }
}
