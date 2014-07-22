using System;
using System.Collections.Generic;

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
    public static class mError
    {
        public static readonly Version Version
        = new Version(1, //workflow version
                      2, //contract version
                      0, //feature version
                      0  //hotfix version
                      );

        public static mError<T> None<T>(T value)
        {
            return new mError<T>(value);
        }

        public static mError<T> With<T>(Enum error, T value)
        {
            return new mError<T>(value, error);
        }

        public static mError<T> With<T>(Enum error, T value, string errorMessage = "")
        {
            return new mError<T>(value, error, errorMessage);
        }

        public static mError<T> With<T>(string errorMessage, T value)
        {
            return new mError<T>(value, errorMessage);
        }
    }

    /// <summary>
    /// A simple class to encapsulate and deliver error messages besides the expected return value from methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class mError<T>
    {
        public T Value { get; protected set; }
        public Enum ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }

        public bool HasErrorCode { get { return this.ErrorCode != null; } }
        public bool HasErrorMessage { get { return !string.IsNullOrEmpty(this.ErrorMessage); } }
        public bool HasError
        {
            get
            {
                return HasErrorCode || HasErrorMessage;
            }
        }

        public mError(T value, string errorMessage = "")
        {
            this.Value = value;
            this.ErrorCode = null;
            this.ErrorMessage = errorMessage;
        }

        public mError(T value, Enum error, string errorMessage)
        {
            this.Value = value;
            this.ErrorCode = error;
            this.ErrorMessage = errorMessage;
        }

        public mError(T value, Enum error, bool useEnumFlagAsErrorMessage = true)
        {
            this.Value = value;
            this.ErrorCode = error;

            if (useEnumFlagAsErrorMessage && HasError)
                this.ErrorMessage = Enum.GetName(error.GetType(), error);
            else this.ErrorMessage = string.Empty;
        }
    }

