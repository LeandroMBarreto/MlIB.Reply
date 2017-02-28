
/* MlIB.Reply
 * https://github.com/LeandroMBarreto
 * http://www.codeproject.com/Members/LeandroMBarreto
 * 
 The MIT License (MIT)

Copyright (c) 2014-2016 Leandro M Barreto

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

namespace M
{
    // delegates missing in .net framework 2.0:
    public delegate void Action();
    public delegate TReturn Func<TReturn>();


    //VERSIONING SYSTEM: MAJOR.MINOR.PATCH
    // MAJOR - breakthrough change
    // MINOR - compatible change
    // PATCH - hotfix change
    // http://semver.org

    /// <summary>
    /// Factory for making a Reply v0.2.0
    /// Use this class to return valuable error information from methods instead of ambiguous null, false or default values.
    /// </summary>
    public static class Reply
    {

        public static IReplyFast<TReturn> NoError<TReturn>(TReturn value)
        {
            return new Reply<TReturn>(value);
        }

        public static IReplyFast<TReturn> Error<TReturn>(TReturn value = default(TReturn))
        {
            return new Reply<TReturn>(value, true);
        }

        public static IReplyMsg<TReturn> Error<TReturn>(string errorMessage, TReturn value = default(TReturn))
        {
            return new Reply<TReturn>(value, errorMessage);
        }

        public static IReplyExMsg<TReturn> Error<TReturn>(Exception ex, string errorMessage = null, TReturn value = default(TReturn))
        {
            return new Reply<TReturn>(value, ex, errorMessage);
        }

        public static IReplyCodeMsg<TReturn> Error<TReturn>(Enum errorCode, string errorMessage = null, TReturn value = default(TReturn))
        {
            return new Reply<TReturn>(value, errorCode, errorMessage);
        }

        public static IReplyFull<TReturn> Error<TReturn>(Enum errorCode, Exception ex, string errorMessage = null, TReturn value = default(TReturn))
        {
            return new Reply<TReturn>(value, errorCode, ex, errorMessage);
        }

        public static void Throw(Enum errorCode, string errorMessage = null)
        {
            new Reply<bool>(false, errorCode, errorMessage).ThrowWhenError();
        }

        /// <summary>
        /// Wraps the specified method in a try-catch block and executes it.
        /// If an exception is thrown, it's encapsulated and returned in a Reply object.
        /// </summary>
        /// <param name="method">The method to execute. ie: ()=>method(arg1, arg2, arg3, arg...)</param>
        /// <returns></returns>
        public static IReplyEx<Exception> From(Action method)
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
        /// Wraps the specified method in a try-catch block and executes it.
        /// If an exception is thrown, it's encapsulated and returned in a Reply object.
        /// </summary>
        /// <typeparam name="TReturn">The type of the data returned by method</typeparam>
        /// <param name="method">The method to execute. ie: ()=>method(arg1, arg2, arg3, arg...)</param>
        /// <returns></returns>
        public static IReplyEx<TReturn> From<TReturn>(Func<TReturn> method)
        {
            try
            {
                return new Reply<TReturn>(method());
            }
            catch (Exception ex)
            {
                return new Reply<TReturn>(default(TReturn), ex);
            }
        }

    }
}
