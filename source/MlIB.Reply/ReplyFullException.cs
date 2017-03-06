using System;
using System.Collections.Generic;
using System.Text;

namespace MlIB
{
    public class ReplyFullException : Exception
    {

        internal ReplyFullException(string msgPrefix, string errorMsg, Exception innerEx = null)
            : base(
            string.Format(
                     "[{0}] {1}"
                     , string.IsNullOrEmpty(msgPrefix) ? "ERROR" : msgPrefix
                     , errorMsg
                        ), innerEx)
        { }

    }
}
