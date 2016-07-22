using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyMsg<TReturn> : IReplyFast<TReturn>
    {
        string ErrorMessage { get; }
        bool HasErrorMessage { get; }
    }
}
