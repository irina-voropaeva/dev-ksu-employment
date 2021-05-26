using System;

namespace KsuEmployment.Common.Errors
{
    [Serializable]
    public class ErrorResponse
    {
        public ErrorResponse() { }

        public ErrorResponse(string message)
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; set; } = string.Empty;
    }
}
