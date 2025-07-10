using Microsoft.Extensions.DependencyInjection;
using System;

namespace Proof.NET
{
    public static class ProofClientServiceCollectionExtensions
    {
        public const string HttpClientName = nameof(ProofClient);

        public static IHttpClientBuilder AddProofClient(
            this IServiceCollection services,
            Action<ProofClientOptions> configureOptions,
            Action<IHttpClientBuilder>? configureBuilder = null)
        {
            services.Configure(configureOptions);

            var builder = services.AddHttpClient<ProofClient>(HttpClientName);

            configureBuilder?.Invoke(builder);

            return builder;
        }
    }
}
