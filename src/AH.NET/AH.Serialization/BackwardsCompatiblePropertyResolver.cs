using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AH.Serialization
{
    /// <summary>
    /// Supports <see cref="FallbackJsonProperty"/> for backwards compatible json property name changes
    /// </summary>
    /// <remarks>
    /// Use DefaultValueHandling = DefaultValueHandling.Ignore with this resolver, or else null values stored at alternate names may overwrite the value you want.
    /// </remarks>
    public class BackwardsCompatiblePropertyResolver : DefaultContractResolver
    {
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
                    fallbackProperty.ShouldSerialize = (x) => false;
                    properties.Add(fallbackProperty);
                }
            }

            return properties;
        }

    }
}