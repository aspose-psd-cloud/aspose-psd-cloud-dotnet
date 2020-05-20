﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IRequestHandler.cs">
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

using System.IO;
using System.Net;

namespace Aspose.Psd.Cloud.Sdk.Client.Internal.RequestHandlers
{
    /// <summary>
    ///     Request handler interface.
    /// </summary>
    internal interface IRequestHandler
    {
        /// <summary>
        ///     Processes the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Processed URL.</returns>
        string ProcessUrl(string url);

        /// <summary>
        ///     Processes parameters before sending.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="streamToSend">The stream to send.</param>
        void BeforeSend(WebRequest request, Stream streamToSend);

        /// <summary>
        ///     Processes the response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="resultStream">The result stream.</param>
        void ProcessResponse(HttpWebResponse response, Stream resultStream);
    }
}