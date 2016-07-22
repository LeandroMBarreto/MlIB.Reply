using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReply<TReturn>
    {
        TReturn Value { get; }
        bool HasError { get; }
    }
}
