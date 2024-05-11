using JetBrains.Annotations;

namespace LokiCat.NET.Serialization;

// TODO: Write Tests to cover this class.
[PublicAPI]
[AttributeUsage(AttributeTargets.Property)]
public class FallbackJsonProperty(string preferredName, params string[] fallbackReadNames) : Attribute
{
    public string PreferredName { get; } = preferredName;
    public string[] FallbackReadNames { get; } = fallbackReadNames;
}