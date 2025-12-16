using Arch.Core;

namespace Arch.Net;

public class ResponseQueue(INetworkProtocol networkProtocol, World world)
{
    internal void Update()
    {
        UpdateNetwork();
        UpdateCreate();
    }


    private readonly Queue<EntityDto> _createQueue = new Queue<EntityDto>();
    private readonly Queue<EntityDto> _destroyQueue = new Queue<EntityDto>();
    private readonly Queue<EntityDto> _addQueue = new Queue<EntityDto>();
    private readonly Queue<EntityDto> _setQueue = new Queue<EntityDto>();
    private readonly Queue<EntityDto> _removeQueue = new Queue<EntityDto>();


    private void UpdateNetwork()
    {
        networkProtocol.OnMessageReceived += (dto =>
        {
            switch (dto.EntityActionType)
            {
                case EntityActionType.Create:
                    _createQueue.Enqueue(dto);
                    break;
                case EntityActionType.Destroy:
                    _destroyQueue.Enqueue(dto);
                    break;
                case EntityActionType.Add:
                    _addQueue.Enqueue(dto);
                    break;
                case EntityActionType.Set:
                    _setQueue.Enqueue(dto);
                    break;
                case EntityActionType.Remove:
                    _removeQueue.Enqueue(dto);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });
    }


    private void UpdateCreate()
    {
        while (_createQueue.TryDequeue(out EntityDto? entityDto))
        {
            world.Create(entityDto.Components[0]);
        }
    }
}
