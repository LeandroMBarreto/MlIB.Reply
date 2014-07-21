using System;
using System.Collections.Generic;

namespace mErrorWrapper
{
    /* mErrorWrapper
     * https://github.com/LeandroMBarreto
     * http://www.codeproject.com/Members/LeandroMBarreto
     * 
     The MIT License (MIT)

    Copyright (c) 2014 LeandroMBarreto

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

    /// <summary>
    /// Factory which provides easy shortcut to instantiate an Error object
    /// </summary>
    public static class Error
    {
        public static Version Version
        = new Version(1, //workflow version
                      0, //contract version
                      0, //feature version
                      0  //hotfix version
                      );

        public const string Name = "mErrorWrapper";
        public const string Author = "Leandro M Barreto";
        public const string Website = "https://github.com/LeandroMBarreto";


        public static Error<T> None<T>(T value)
        {
            return new Error<T>(value);
        }

        public static Error<T> With<T>(Enum error, T value)
        {
            return new Error<T>(error, value);
        }

        public static Error<T> With<T>(Enum error, string errorMessage, T value)
        {
            return new Error<T>(error, errorMessage, value);
        }
    }

    /// <summary>
    /// A simple class to encapsulate and deliver error messages besides the expected return value from methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Error<T>
    {
        public T Value { get; protected set; }
        public Enum ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }

        public bool HasError { get { return this.ErrorCode != null; } }

        public Error(T value, Enum error = null)
        {
            this.Value = value;
            this.ErrorCode = null;

            if (error == null)
                this.ErrorMessage = string.Empty;
            else this.ErrorMessage = Enum.GetName(error.GetType(), error);
        }

        public Error(Enum error, T value = default(T))
        {
            this.Value = value;
            this.ErrorCode = error;

            this.ErrorMessage = Enum.GetName(error.GetType(), error);
        }

        public Error(Enum error, string errorMessage, T value)
        {
            this.Value = value;
            this.ErrorCode = error;
            this.ErrorMessage = errorMessage;
        }
    }
}
