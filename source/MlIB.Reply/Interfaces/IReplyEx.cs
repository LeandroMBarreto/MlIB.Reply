using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyEx<TReturn>
    {
        bool HasException { get; }
    }
}
