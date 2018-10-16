using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Utilities
{
    public class ResultMessage
    {
        public object Data { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public List<string> ValidationMessages { get; set; }
    }
    public enum ResultStatus
    {
        Error = 0,
        Success = 1,
        Warning = 2,
        Validation =3,
        InvalidData = 4

    }
}
