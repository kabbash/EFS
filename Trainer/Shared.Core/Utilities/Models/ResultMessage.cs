using System;
using System.Collections.Generic;
using System.Net;

namespace Shared.Core.Utilities.Models
{
    public class ResultMessage
    {
        public object Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public int ErrorCode { get; set; }
        public Exception exception { get; set; }
        public List<string> ValidationMessages { get; set; }
    }    
}
