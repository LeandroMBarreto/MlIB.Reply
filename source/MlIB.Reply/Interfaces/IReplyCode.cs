using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyCode<TReturn> : IReply<TReturn>, IReplyMsg<TReturn>
    {
        Enum ErrorCode { get; }
        bool HasErrorCode { get; }
    }
}
