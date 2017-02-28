using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyFast<TReturn>
    {
        TReturn Value { get; }
        bool HasError { get; }

        void ThrowWhenError(string msgPrefix = null);
    }
}
