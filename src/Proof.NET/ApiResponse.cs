using RestSharp;

namespace Proof.NET
{
    public class ApiResponse
    {
        public required int StatusCode { get; set; }

        internal static ApiResponse Create(RestResponse restResponse)
        {
            return new ApiResponse
            {
                StatusCode = (int)restResponse.StatusCode,
            };
        }
    }
}
