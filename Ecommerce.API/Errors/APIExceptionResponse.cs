namespace E_commerce.API.Errors
{
    public class APIExceptionResponse :API_Response
    {
        public APIExceptionResponse(int statusCode, string? errorMessage = null, string? details = null) : base(statusCode, errorMessage)
        {
            Details = details;
        }

        public string? Details { get; set; }
    }
}
