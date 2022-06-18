using System.Text.Json;

namespace StudentRecordAPI.Models.Others
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ErrorDetails(int StatusCode, string Message)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
