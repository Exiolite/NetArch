namespace Arch.Net;

public enum EntityActionType
{
    Create,
    Destroy,
    Add,
    Set,
    Remove
}

public class EntityDto
{
    public Guid NetworkId { get; set; }
    public EntityActionType EntityActionType { get; set; }
    public object[]? Components { get; set; }
}
