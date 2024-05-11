using System.Collections;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LokiCat.NET.Serialization;

/// <summary>
/// Ignore empty enumerable properties when serializing.
/// </summary>
// TODO: Write Tests to cover this function. 
[PublicAPI]
public class IgnoreEmptyEnumerableResolver : DefaultContractResolver
{
    /// <inheritdoc />
    protected override JsonProperty CreateProperty(MemberInfo member,
        MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        if (property.PropertyType != typeof(string) &&
            typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
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
                    // if the list is null, we defer the decision to NullValueHandling
                    return true;
                }

                var enumerator = enumerable.GetEnumerator();
                var result = enumerator.MoveNext();
                (enumerator as IDisposable)?.Dispose();

                return result;
            };
        }

        return property;
    }
}