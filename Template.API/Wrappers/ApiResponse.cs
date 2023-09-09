namespace Template.API.Wrappers
{
    /// <summary>
    /// API Response Structrue 
    /// </summary>
    public class ApiResponse
    {
        public object Data { get; private set; }
        public string ErrorMessage { get; private set; }
        public int StatusCode { get; private set; }

        private ApiResponse() { } 

        public static ApiResponse Success(object data)
        {
            return new ApiResponse
            {
                Data = data,
                StatusCode = 200,
            };
        }

        public static ApiResponse Failure(int statusCode, string error)
        {
            return new ApiResponse
            {
                ErrorMessage = error,
                StatusCode = statusCode,
            };
        }

        public object ToResponse()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                return new { ErrorMessage, StatusCode };
            }
            return new { Data, StatusCode };
        }
    }

}
