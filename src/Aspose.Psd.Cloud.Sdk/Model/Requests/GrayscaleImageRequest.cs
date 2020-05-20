// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="GrayscaleImageRequest.cs">
//   Copyright (c) 2018-2020 Aspose Pty Ltd. All rights reserved.
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

namespace Aspose.Psd.Cloud.Sdk.Model.Requests
{
    /// <summary>
    ///     Request model for <see cref="Aspose.Psd.Cloud.Sdk.Api.PsdApi.GrayscaleImage" /> operation.
    /// </summary>
    public class GrayscaleImageRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GrayscaleImageRequest" /> class.
        /// </summary>
        public GrayscaleImageRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GrayscaleImageRequest" /> class.
        /// </summary>
        /// <param name="name">Image file name.</param>
        /// <param name="folder">Folder</param>
        /// <param name="storage">Storage</param>
        public GrayscaleImageRequest(string name, string folder = null, string storage = null)
        {
            Name = name;
            Folder = folder;
            Storage = storage;
        }

        /// <summary>
        ///     Image file name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Folder
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        ///     Storage
        /// </summary>
        public string Storage { get; set; }
    }
}