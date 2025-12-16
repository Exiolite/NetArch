namespace Arch.Net.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public class RequireComponentAttribute(params Type[] componentTypes) : Attribute
{
    public Type[] ComponentTypes { get; } = componentTypes;
}
