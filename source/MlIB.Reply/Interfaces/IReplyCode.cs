using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyCode<TReturn> : IReply<TReturn>
    {
        bool HasErrorCode { get; }
        Enum ErrorCode { get; }
        string ErrorCodeID { get; }
        string ErrorCodeLabel { get; }
    }
}
