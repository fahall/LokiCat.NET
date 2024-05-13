using System.Collections;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LokiCat.NET.Serialization;

// TODO: Write Tests to cover this class. 
/// <summary>
/// Supports <see cref="FallbackJsonProperty"/> for backwards compatible json property name changes  and ignores empty enumerables.
/// </summary>
[PublicAPI]
public class BackwardsCompatibleEmptyEnumerableIgnoringContractResolver : DefaultContractResolver
{
    /// <inheritdoc />
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        var typeMembers = GetSerializableMembers(type);
        var properties = new List<JsonProperty>();

        foreach (var member in typeMembers)
        {
            var property = CreateProperty(member, memberSerialization);
            properties.Add(property);

            var fallbackAttribute = member.GetCustomAttribute<FallbackJsonProperty>();

            if (fallbackAttribute is null)
            {
                continue;
            }

            property.PropertyName = fallbackAttribute.PreferredName;

            foreach (var alternateName in fallbackAttribute.FallbackReadNames)
            {
                var fallbackProperty = CreateProperty(member, memberSerialization);
                fallbackProperty.PropertyName = alternateName;
                fallbackProperty.ShouldSerialize = _ => false;
                properties.Add(fallbackProperty);
            }
        }

        return properties;
    }

    /// <inheritdoc />
    protected override JsonProperty CreateProperty(MemberInfo member,
        MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        if (property.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
        {
            property.ShouldSerialize = instance =>
            {
                // this value could be in a public field or public property

                if (member.MemberType switch
                    {
                        MemberTypes.Property => instance.GetType().GetProperty(member.Name)?.GetValue(instance, null),
                        MemberTypes.Field => instance.GetType().GetField(member.Name)?.GetValue(instance),
                        _ => null,
                    } is not IEnumerable enumerable)
                {
                    return true;
                }

                var enumerator = enumerable.GetEnumerator();
                var result = enumerator.MoveNext();
                (enumerator as IDisposable)?.Dispose();

                return result;

                // if the list is null, we defer the decision to NullValueHandling
            };
        }

        return property;
    }
}