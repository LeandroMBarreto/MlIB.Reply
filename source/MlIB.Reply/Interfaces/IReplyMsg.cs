using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyMsg<TReturn> : IReply<TReturn>
    {
        string ErrorMessage { get; }
        bool HasErrorMessage { get; }
    }
}
