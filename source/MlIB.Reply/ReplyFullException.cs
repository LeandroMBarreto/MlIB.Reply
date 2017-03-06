using System;
using System.Collections.Generic;
using System.Text;

namespace MlIB
{
    public class ReplyFullException : Exception
    {

        internal ReplyFullException(string errorMsg, Exception innerEx, string msgPrefix = "ERROR")
            : base(
                string.Format("[{0}] {1}", msgPrefix, errorMsg)
            , innerEx)
        { }

    }
}
