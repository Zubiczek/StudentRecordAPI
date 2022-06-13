using System;

namespace StudentRecordAPI.Models.Others
{
    [Serializable]
    public class HttpResponseException : Exception
    {
        public int StatusCode { get; set; }
        public HttpResponseException()
        {
            this.StatusCode = 500;
        }
        public HttpResponseException(string message) : base(message)
        {
            this.StatusCode = 500;
        }
        public HttpResponseException(string message, int statuscode): base(message)
        {
            this.StatusCode = statuscode;
        }
    }
}
