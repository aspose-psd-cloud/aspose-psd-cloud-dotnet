// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiException.cs">
//   Copyright (c) 2018-2019 Aspose Pty Ltd. All rights reserved.
// </copyright>
// <summary>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Aspose.Psd.Cloud.Sdk.Model;

namespace Aspose.Psd.Cloud.Sdk.Client
{
    /// <summary>
    ///     Psd API Exception
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiException" /> class.
        /// </summary>
        public ApiException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiException" /> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The message.</param>
        /// <param name="error">The error.</param>
        public ApiException(int errorCode, string message, Error error = null) : base(message)
        {
            ErrorCode = errorCode;
            Error = error;
        }

        /// <summary>
        ///     Gets the error code.
        /// </summary>
        /// <value>
        ///     The error code.
        /// </value>
        public int ErrorCode { get; }

        /// <summary>
        ///     Gets the error.
        /// </summary>
        /// <value>
        ///     The error.
        /// </value>
        public Error Error { get; }
    }
}