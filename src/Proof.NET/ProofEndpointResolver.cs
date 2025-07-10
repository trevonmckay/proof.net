using System;

namespace Proof.NET
{
    internal static class ProofEndpointResolver
    {
        public static Uri ResolveBaseAddress(ProofEnvironment environment, string? endpointOverride = null)
        {
            if (endpointOverride is not null)
            {
                Uri.TryCreate(endpointOverride, UriKind.Absolute, out Uri? baseUri);
                return baseUri ?? throw new ArgumentException($"The Proof API endpoint '{endpointOverride}' is not valid.");
            }

            switch (environment)
            {
                case ProofEnvironment.Production:
                    return new Uri("https://api.proof.com/v1/");
                case ProofEnvironment.Sandbox:
                    return new Uri("https://api.fairfax.proof.com/v1/");
                default:
                    throw new ArgumentOutOfRangeException(nameof(environment), environment, "Invalid Proof environment specified.");
            }
        }
    }
}
