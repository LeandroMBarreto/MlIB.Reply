using MlIB.ReplyDelegates;
using System;
using System.Collections.Generic;
using System.Text;

namespace MlIB
{
    public static partial class Reply
    {

        public static void ThrowingException(string message)
        {
            throw new Exception(string.Format(message));
        }

        public static Reply<T> NoException<T>(Exception ex, T value = default(T))
        {
            return new Reply<T>(value, ex.Message);
        }

        public static Reply<Exception> From(Action method)
        {
            try
            {
                method();
                return new Reply<Exception>(null);
            }
            catch (Exception ex)
            {
                return new Reply<Exception>(ex, ex.Message);
            }
        }

        public static Reply<T> From<T>(Func<T> method)
        {
            try
            {
                return new Reply<T>(method());
            }
            catch (Exception ex)
            {
                return new Reply<T>(default(T), ex.Message);
            }
        }

    }
}
