using System;
using JetBrains.Annotations;

namespace LokiCat.NET.Serialization
{
    /// <summary>
    /// Json Property with a preferred name and fallback read names for backwards compatibility.
    /// </summary>

    // TODO: Write Tests to cover this class.
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Property)]
    public class FallbackJsonProperty : Attribute
    {
        /// <summary>
        /// Json Property with a preferred name and fallback read names for backwards compatibility.
        /// </summary>
        /// <param name="preferredName">The preferred name of the property.</param>
        /// <param name="fallbackReadNames">The names to check if the preferred name is not found.</param>
        public FallbackJsonProperty(string preferredName, params string[] fallbackReadNames)
        {
            PreferredName = preferredName;
            FallbackReadNames = fallbackReadNames;
        }

        /// <summary>
        /// The preferred name of the property.
        /// </summary>
        public string PreferredName { get; }

        /// <summary>
        /// The names to check if the preferred name is not found. These are read-only and used for backwards compatibility.
        /// </summary>
        public string[] FallbackReadNames { get; }
    }
}