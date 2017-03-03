using System;
using System.Collections.Generic;
using System.Text;

namespace MlIB
{
    public class ReplyFullException : Exception
    {

        internal ReplyFullException(string messagePrefix, string errorMessage, Exception innerException = null)
            : base(
            string.Format(
                     "[{0}] {1}"
                     , string.IsNullOrEmpty(messagePrefix) ? "ERROR" : messagePrefix
                     , errorMessage
                        ), innerException)
        { }

    }
}
