using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Shared.Core.Utilities
{
    public class ResultMessage
    {
        public object Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public int ErrorCode { get; set; }
        public List<string> ValidationMessages { get; set; }
    }    
}
