using RestSharp;

namespace Proof.NET
{
    public class ApiResponse<T> : ApiResponse
    {
        public required T Data { get; set; }

        public static implicit operator T(ApiResponse<T> response) => response.Data;

        internal static ApiResponse<T> Create(RestResponse<T> restResponse)
        {
            return new ApiResponse<T>
            {
                StatusCode = (int)restResponse.StatusCode,
                Data = restResponse.Data!,
            };
        }
    }
}
