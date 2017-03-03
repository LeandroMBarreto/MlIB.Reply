using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyCodeMsg<TReturn> : IReply<TReturn>, IReplyCode<TReturn>, IReplyMsg<TReturn>
    {
    }
}
