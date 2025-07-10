using RestSharp;
using RestSharp.Serializers;
using RestSharp.Serializers.Json;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Proof.NET
{
    public class ProofClient
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = CreateJsonSerializerOptions();

        private readonly string _apiKey;
        private readonly RestClient _client;

        public ProofClient(string apiKey, string? endpoint = null)
        {
            _apiKey = apiKey;
            RestClientOptions restClientOptions = new(endpoint ?? "https://api.proof.com/v1/");
            _client = new(
                restClientOptions,
                configureSerialization: ConfigureRestClientSerialization);
        }

        public async Task<ApiResponse<Transaction>> CreateTransactionAsync(CreateTransactionRequest createTransactionRequest, DocumentUrlVersion documentUrlVersion = DocumentUrlVersion.v1, CancellationToken cancellationToken = default)
        {
            RestRequest restRequest = new("transactions", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(createTransactionRequest, ContentType.Json);

            return await ExecuteAsync<Transaction>(restRequest, documentUrlVersion, cancellationToken);
        }

        public async Task<ApiResponse<Transaction>> RetrieveTransactionAsync(string transactionId, DocumentUrlVersion documentUrlVersion = DocumentUrlVersion.v1, CancellationToken cancellationToken = default)
        {
            RestRequest restRequest = new($"transactions/{transactionId}", Method.Get);
            restRequest.AddHeader("Accept", "application/json");

            return await ExecuteAsync<Transaction>(restRequest, documentUrlVersion, cancellationToken);
        }

        public async Task<ApiResponse<Document>> AddDocumentAsync(string transactionId, AddDocumentRequest addDocumentRequest, DocumentUrlVersion documentUrlVersion = DocumentUrlVersion.v1, CancellationToken cancellationToken = default)
        {
            RestRequest restRequest = new($"transactions/{transactionId}/documents", Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(addDocumentRequest, ContentType.Json);

            return await ExecuteAsync<Document>(restRequest, documentUrlVersion, cancellationToken);
        }

        public async Task<ApiResponse<Transaction>> ActivateDraftTransactionAsync(string transactionId, DocumentUrlVersion documentUrlVersion = DocumentUrlVersion.v1, CancellationToken cancellationToken = default)
        {
            RestRequest restRequest = new($"transactions/{transactionId}/notarization_ready", Method.Post);
            restRequest.AddHeader("Accept", "application/json");

            return await ExecuteAsync<Transaction>(restRequest, documentUrlVersion, cancellationToken);
        }

        private void HandleResponse(RestResponse restResponse)
        {
            try
            {
                restResponse.ThrowIfError();
            }
            catch (HttpRequestException ex)
            {
                JsonElement? errorBody;
                try
                {
                    errorBody = JsonDocument.Parse(restResponse.Content ?? "{}")?.RootElement;
                }
                catch
                {
                    errorBody = null;
                }

                IEnumerable<string>? errors;
                if (errorBody.HasValue && errorBody.Value.TryGetProperty("errors", out JsonElement errorsElement))
                {
                    errors = errorsElement.EnumerateArray().Select(el => el.GetString()).OfType<string>();
                }
                else
                {
                    errors = null;
                }

                string message = errors?.Any() == true ? string.Join(Environment.NewLine, errors) : ex.Message;
                throw new RequestException(message, ex)
                {
                    Errors = errors,
                    HttpStatusCode = (int)restResponse.StatusCode,
                };
            }

            if (!restResponse.IsSuccessStatusCode)
            {
                throw new RequestException($"Request failed with status code: {restResponse.StatusCode}")
                {
                    HttpStatusCode = (int)restResponse.StatusCode,
                };
            }
        }

        private void PrepareRequest(RestRequest restRequest, DocumentUrlVersion documentUrlVersion)
        {
            restRequest.AddOrUpdateHeader("ApiKey", _apiKey);
            restRequest.AddQueryParameter("document_url_version", documentUrlVersion == DocumentUrlVersion.v2 ? "v2" : "v1", false);
        }

        private async Task<ApiResponse<TResponse>> ExecuteAsync<TResponse>(RestRequest restRequest, DocumentUrlVersion documentUrlVersion, CancellationToken cancellationToken = default)
        {
            PrepareRequest(restRequest, documentUrlVersion);
            RestResponse<TResponse> response = await _client.ExecuteAsync<TResponse>(restRequest, cancellationToken);
            HandleResponse(response);

            return ApiResponse<TResponse>.Create(response);
        }

        private static JsonSerializerOptions CreateJsonSerializerOptions()
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            return jsonSerializerOptions;
        }

        private static void ConfigureRestClientSerialization(SerializerConfig config)
        {
            config.UseSystemTextJson(_jsonSerializerOptions);
        }
    }
}
