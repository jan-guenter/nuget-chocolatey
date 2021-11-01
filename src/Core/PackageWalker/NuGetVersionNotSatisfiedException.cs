using System;

namespace NuGet
{
    [Serializable]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2229:Implement serialization constructors", Justification = "We don't need the constructor which accepts streaming context.")]
    public class NuGetVersionNotSatisfiedException : Exception
    {
        public NuGetVersionNotSatisfiedException()
        {
        }

        public NuGetVersionNotSatisfiedException(string message)
            : base(message)
        {
        }

        public NuGetVersionNotSatisfiedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}