using System;
using System.Collections.Generic;
using System.Text;

namespace MlIB
{
    public class ReplyException : Exception
    {
        public ReplyException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
