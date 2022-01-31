using System.Collections.Generic;

namespace Api_Customer_Api.Extensions
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new ResponseResultMessageErrors();
        }
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseResultMessageErrors Errors { get; set; }
    }

    public class ResponseResultMessageErrors
    {
        public ResponseResultMessageErrors()
        {
            Messages = new List<string>();
        }
        public List<string> Messages { get; set; }
    }
}
