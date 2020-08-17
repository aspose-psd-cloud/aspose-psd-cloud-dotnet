// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiInvoker.cs">
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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Aspose.Psd.Cloud.Sdk.Client.Internal.RequestHandlers;

namespace Aspose.Psd.Cloud.Sdk.Client.Internal
{
    /// <summary>
    ///     API invoker class
    /// </summary>
    internal class ApiInvoker
    {
        /// <summary>
        ///     Aspose client header name
        /// </summary>
        private const string AsposeClientHeaderName = "x-aspose-client";

        /// <summary>
        ///     Aspose client version header name
        /// </summary>
        private const string AsposeClientVersionHeaderName = "x-aspose-client-version";

        /// <summary>
        ///     The timeout division increase coefficient - size in bytes is divided by its' value, getting milliseconds.
        ///     I.e., this is a number of bytes indicating timeout increase for 1 millisecond.
        /// </summary>
        private const long TimeoutDivisionIncreaseCoefficient = 40L;

        /// <summary>
        ///     The configuration
        /// </summary>
        private readonly Configuration _configuration;

        /// <summary>
        ///     The default header map
        /// </summary>
        private readonly Dictionary<string, string> _defaultHeaderMap = new Dictionary<string, string>();

        /// <summary>
        ///     The request handlers
        /// </summary>
        private readonly List<IRequestHandler> _requestHandlers;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiInvoker" /> class.
        /// </summary>
        /// <param name="requestHandlers">The request handlers.</param>
        /// <param name="configuration">The configuration.</param>
        public ApiInvoker(List<IRequestHandler> requestHandlers, Configuration configuration)
        {
            var sdkVersion = GetType().Assembly.GetName().Version;
            AddDefaultHeader(AsposeClientHeaderName, ".net sdk");
            AddDefaultHeader(AsposeClientVersionHeaderName, $"{sdkVersion.Major}.{sdkVersion.Minor}");
            _requestHandlers = requestHandlers;
            _configuration = configuration;
        }

        /// <summary>
        ///     Invokes the API.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="method">The method.</param>
        /// <param name="body">The body.</param>
        /// <param name="headerParams">The header parameters.</param>
        /// <param name="formParams">The form parameters.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>Resulting stream.</returns>
        public Stream InvokeApi(
            string path,
            string method,
            string body = null,
            Dictionary<string, string> headerParams = null,
            Dictionary<string, object> formParams = null,
            string contentType = "application/json")
        {
            return InvokeInternal(path, method, body, headerParams, formParams, contentType);
        }

        /// <summary>
        ///     Converts stream to the file information parameter.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>File information parameter.</returns>
        public FileInfo ToFileInfo(Stream stream, string paramName)
        {
            return new FileInfo
                {Name = paramName, MimeType = "application/octet-stream", File = StreamHelper.ReadAsBytes(stream)};
        }

        /// <summary>
        ///     Converts bytes to the file information parameter.
        /// </summary>
        /// <param name="data">The data bytes.</param>
        /// <returns>File information parameter.</returns>
        public FileInfo ToFileInfo(byte[] data)
        {
            return new FileInfo {Name = "file", MimeType = "application/octet-stream", File = data};
        }

        /// <summary>
        ///     Gets the multipart form data.
        /// </summary>
        /// <param name="postParameters">The post parameters.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>Multipart form data.</returns>
        private static Stream GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream contentStream = new MemoryStream();
            var needsClrf = false;

            foreach (var param in postParameters)
            {
                if (needsClrf)
                    contentStream.Write(Encoding.UTF8.GetBytes("\r\n"), 0, Encoding.UTF8.GetByteCount("\r\n"));

                needsClrf = true;

                if (param.Value is FileInfo)
                {
                    var fileInfo = (FileInfo)param.Value;
                    var postData =
                        string.Format(
                            "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n",
                            boundary,
                            param.Key,
                            fileInfo.MimeType);
                    contentStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));

                    // Write the file data directly to the Stream, rather than serializing it to a string.
                    contentStream.Write(fileInfo.File, 0, fileInfo.File.Length);
                }
                else
                {
                    var stringData = param.Value as string ?? SerializationHelper.Serialize(param.Value);
                    var postData =
                        $"--{boundary}\r\nContent-Disposition: form-data; name=\"{param.Key}\"\r\n\r\n{stringData}";
                    contentStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));
                }
            }

            var footer = "\r\n--" + boundary + "--\r\n";
            contentStream.Write(Encoding.UTF8.GetBytes(footer), 0, Encoding.UTF8.GetByteCount(footer));
            contentStream.Position = 0;
            return contentStream;
        }

        /// <summary>
        ///     Adds the default header.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        private void AddDefaultHeader(string key, string value)
        {
            if (!_defaultHeaderMap.ContainsKey(key)) _defaultHeaderMap.Add(key, value);
        }

        /// <summary>
        ///     Invokes the internal API.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="method">The method.</param>
        /// <param name="body">The body.</param>
        /// <param name="headerParams">The header parameters.</param>
        /// <param name="formParams">The form parameters.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>Resulting stream.</returns>
        private Stream InvokeInternal(
            string path,
            string method,
            string body,
            Dictionary<string, string> headerParams,
            Dictionary<string, object> formParams,
            string contentType)
        {
            if (formParams == null) formParams = new Dictionary<string, object>();

            if (headerParams == null) headerParams = new Dictionary<string, string>();

            _requestHandlers.ForEach(p => path = p.ProcessUrl(path));

            WebRequest request;
            try
            {
                request = PrepareRequest(path, method, formParams, headerParams, body, contentType);
                return ReadResponse(request);
            }
            catch (NeedRepeatRequestException)
            {
                request = PrepareRequest(path, method, formParams, headerParams, body, contentType);
                return ReadResponse(request);
            }
        }

        /// <summary>
        ///     Prepares the request.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="method">The method.</param>
        /// <param name="formParams">The form parameters.</param>
        /// <param name="headerParams">The header parameters.</param>
        /// <param name="body">The body.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>Prepared request.</returns>
        /// <exception cref="Aspose.Psd.Cloud.Sdk.Client.ApiException">500 - unknown method type</exception>
        private WebRequest PrepareRequest(string path, string method, Dictionary<string, object> formParams,
            Dictionary<string, string> headerParams, string body, string contentType)
        {
            var client = WebRequest.Create(path.Replace(" ", "%20"));
            client.Method = method;
            Stream content = body == null ? null : new MemoryStream(Encoding.UTF8.GetBytes(body));

            try
            {
                if (formParams.Count > 0)
                {
                    content?.Dispose();

                    const string formDataBoundary = "Somthing";
                    client.ContentType = "multipart/form-data; boundary=" + formDataBoundary;
                    content = GetMultipartFormData(formParams, formDataBoundary);
                }
                else
                {
                    client.ContentType = contentType;
                }

                foreach (var headerParamsItem in headerParams)
                    client.Headers.Add(headerParamsItem.Key, headerParamsItem.Value);

                foreach (var defaultHeaderMapItem in _defaultHeaderMap)
                {
                    if (!headerParams.ContainsKey(defaultHeaderMapItem.Key))
                    {
                        client.Headers.Add(defaultHeaderMapItem.Key, defaultHeaderMapItem.Value);
                    }
                }

                _requestHandlers.ForEach(p => p.BeforeSend(client, content));

                if (content != null)
                {
                    client.ContentLength = content.Length;
                    client.Timeout += (int) (content.Length / TimeoutDivisionIncreaseCoefficient);
                    using (var requestStream = client.GetRequestStream())
                    {
                        StreamHelper.CopyTo(content, requestStream);
                    }
                }
                else
                {
                    // TODO: change the behavior according to IMAGINGCLOUD-52 resolution
                    client.ContentLength = 0;
                    client.Timeout += 600000;
                }
            }
            finally
            {
                content?.Dispose();
            }

            return client;
        }

        /// <summary>
        ///     Reads the response.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>Response stream.</returns>
        private Stream ReadResponse(WebRequest client)
        {
            var webResponse = (HttpWebResponse) GetResponse(client);
            var resultStream = new MemoryStream();

            StreamHelper.CopyTo(webResponse.GetResponseStream(), resultStream);
            try
            {
                _requestHandlers.ForEach(p => p.ProcessResponse(webResponse, resultStream));

                resultStream.Position = 0;
                return resultStream;
            }
            catch (Exception)
            {
                resultStream.Dispose();
                throw;
            }
        }

        /// <summary>
        ///     Gets the response.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response.</returns>
        private WebResponse GetResponse(WebRequest request)
        {
            try
            {
                return request.GetResponse();
            }
            catch (WebException wex)
            {
                if (wex.Response != null) return wex.Response;

                throw;
            }
        }
    }
}