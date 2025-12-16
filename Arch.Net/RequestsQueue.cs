using Arch.Core;

namespace Arch.Net;

public class RequestsQueue(INetworkProtocol networkProtocol)
{
    public void Update()
    {
        while (_createQueue.TryDequeue(out object? componentTypes))
        {
            networkProtocol.SendMessage(new EntityDto());
        }
    }


    private readonly Queue<object> _createQueue = new Queue<object>();
    private readonly Queue<ComponentType[]> _destroyQueue = new Queue<ComponentType[]>();
    private readonly Queue<ComponentType[]> _addQueue = new Queue<ComponentType[]>();
    private readonly Queue<ComponentType[]> _setQueue = new Queue<ComponentType[]>();
    private readonly Queue<ComponentType[]> _removeQueue = new Queue<ComponentType[]>();


    public void EnqueueCreate(object componentTypes)
    {
        _createQueue.Enqueue(componentTypes);
    }
}
