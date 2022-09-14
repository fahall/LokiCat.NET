using System;
using JetBrains.Annotations;

namespace AH.Serialization
{
    // TODO: Write Tests to cover this class.
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Property)]
    public class FallbackJsonProperty : Attribute
    {
        public string PreferredName { get; }
        public string[] FallbackReadNames { get; }

        public FallbackJsonProperty(string preferredName, params string[] fallbackReadNames)
        {
            PreferredName = preferredName;
            FallbackReadNames = fallbackReadNames;
        }
    }
}