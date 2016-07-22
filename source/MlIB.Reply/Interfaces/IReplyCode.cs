using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyCode<TReturn> : IReplyFast<TReturn>, IReplyMsg<TReturn>
    {
        Enum ErrorCode { get; }
        bool HasErrorCode { get; }
    }
}
