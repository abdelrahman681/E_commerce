namespace E_commerce.API.Errors
{
    public class APIValidationErrorResponse : API_Response
    {
      

        public APIValidationErrorResponse() : base(400)
        {
            Errors = new List<string>();
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
