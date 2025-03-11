namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    internal sealed class CompilerFeatureRequiredAttribute : Attribute
    {
        public CompilerFeatureRequiredAttribute(string featureName)
        {
            FeatureName = featureName;
        }

        public string FeatureName { get; }
    }
}
