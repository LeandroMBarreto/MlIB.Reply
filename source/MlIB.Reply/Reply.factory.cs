
/* MlIB.Reply
 * https://github.com/LeandroMBarreto
 * http://www.codeproject.com/Members/LeandroMBarreto
 * 
 The MIT License (MIT)

Copyright (c) 2014-2016 LeandroMBarreto

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using System;
using System.Collections.Generic;
using MlIB;
using MlIB.ReplyDelegates;

namespace M
{
    /// <summary>
    /// Factory for making a Reply v0.1.0
    /// 0 - MAJOR - breakthrough change
    /// 1 - MINOR - compatible change
    /// 0 - PATCH - hotfix change
    /// </summary>
    public static class Reply
    {

        public static Reply<T> NoError<T>(T value)
        {
            return new Reply<T>(value);
        }

        public static Reply<T> Error<T>(Enum errorCode, T value)
        {
            return new Reply<T>(value, errorCode);
        }

        public static Reply<T> Error<T>(Enum errorCode, T value, string errorMessage = "")
        {
            return new Reply<T>(value, errorCode, errorMessage);
        }

        public static Reply<T> Error<T>(string errorMessage, T value)
        {
            return new Reply<T>(value, errorMessage);
        }

        public static Reply<T> Error<T>(Exception ex, T value = default(T))
        {
            return new Reply<T>(value, ex);
        }

        public static void Throw(Enum errorCode, string errorMessage = "")
        {
            var reply = new Reply<bool>(false, errorCode, errorMessage);
            throw new Exception(string.Format("ERROR {0}: {1}", errorCode, reply.ErrorMessage));
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
                return new Reply<Exception>(ex, ex);
            }
        }

        /// <summary>
        /// Executes specified method and encapsulates any fired exception in a Reply class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        public static Reply<T> From<T>(Func<T> method)
        {
            try
            {
                return new Reply<T>(method());
            }
            catch (Exception ex)
            {
                return new Reply<T>(default(T), ex);
            }
        }

    }
}
