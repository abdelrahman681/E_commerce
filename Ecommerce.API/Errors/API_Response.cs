
namespace E_commerce.API.Errors
{
    public class API_Response
    {
        public API_Response(int statusCode, string? errorMessage=null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage?? GetErrorMessageForStatusCode(StatusCode);
        }

        private string? GetErrorMessageForStatusCode(int statusCode)
        => statusCode switch
        {
            500=>"Internal Server Error",
            404=>"Not Found Error",
            401=>"UnAuthorized Error",
            400=>"BadRequest",
            _=>"   "
        };

        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
