using System;

namespace Lucy.Core
{
    public class CustomException : Exception
    {
        public int ErrorCode { get; set; }
        public string ErrorDetails { get; set;}
    }
}
