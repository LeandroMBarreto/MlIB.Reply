using System;
using System.Collections.Generic;
using System.Text;

namespace MlIB
{
    public class ReplyException : Exception
    {
        public ReplyException(string msgPrefix, Enum ErrorCode, string ErrorMessage, Exception exception)
            :base(
                string.Format(
                    "[{0}-{1}-{2}]", msgPrefix, ErrorCode, ErrorMessage
                ), exception)
        {
            
        }
    }
}
