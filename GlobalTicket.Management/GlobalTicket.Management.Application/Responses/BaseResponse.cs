namespace GlobalTicket.Management.Application.Responses
{
    using System.Collections.Generic;

    public class BaseResponse
    {
        public BaseResponse() => this.Success = true;
        public BaseResponse(string message = null)
        {
            this.Success = true;
            this.Message = message;
        }
        public BaseResponse(string message, bool success)
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
