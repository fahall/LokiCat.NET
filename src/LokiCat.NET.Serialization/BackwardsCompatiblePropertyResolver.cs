using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LokiCat.NET.Serialization
{
    /// <summary>
    /// Supports <see cref="FallbackJsonProperty"/> for backwards compatible json property name changes
    /// </summary>
    /// <remarks>
    /// Use DefaultValueHandling = DefaultValueHandling.Ignore with this resolver, or else null values stored at alternate names may overwrite the value you want.
    /// </remarks>

// TODO: Write Tests to cover this class.
    [PublicAPI]
    public class BackwardsCompatiblePropertyResolver : DefaultContractResolver
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

                if (fallbackAttribute == null)
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
    }
}