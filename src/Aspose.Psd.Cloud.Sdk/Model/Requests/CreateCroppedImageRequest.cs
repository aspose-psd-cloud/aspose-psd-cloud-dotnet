// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="CreateCroppedImageRequest.cs">
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

using System.IO;

namespace Aspose.Psd.Cloud.Sdk.Model.Requests
{
    /// <summary>
    ///     Request model for <see cref="Aspose.Psd.Cloud.Sdk.Api.PsdApi.CreateCroppedImage" /> operation.
    /// </summary>
    public class CreateCroppedImageRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateCroppedImageRequest" /> class.
        /// </summary>
        public CreateCroppedImageRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateCroppedImageRequest" /> class.
        /// </summary>
        /// <param name="imageData">Input image</param>
        /// <param name="x">X position of start point for cropping rectangle.</param>
        /// <param name="y">Y position of start point for cropping rectangle.</param>
        /// <param name="width">Width of cropping rectangle.</param>
        /// <param name="height">Height of cropping rectangle.</param>
        /// <param name="format">
        ///     Resulting image format. Please, refer to
        ///     https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap
        ///     for possible use-cases.
        /// </param>
        /// <param name="outPath">Path to updated file (if this is empty, response contains streamed image).</param>
        /// <param name="storage">Your Aspose Cloud Storage name.</param>
        public CreateCroppedImageRequest(Stream imageData, int? x, int? y, int? width, int? height,
            string format = null, string outPath = null, string storage = null)
        {
            ImageData = imageData;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Format = format;
            OutPath = outPath;
            Storage = storage;
        }

        /// <summary>
        ///     Input image
        /// </summary>
        public Stream ImageData { get; set; }

        /// <summary>
        ///     X position of start point for cropping rectangle.
        /// </summary>
        public int? X { get; set; }

        /// <summary>
        ///     Y position of start point for cropping rectangle.
        /// </summary>
        public int? Y { get; set; }

        /// <summary>
        ///     Width of cropping rectangle.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        ///     Height of cropping rectangle.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        ///     Resulting image format. Please, refer to
        ///     https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap
        ///     for possible use-cases.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        ///     Path to updated file (if this is empty, response contains streamed image).
        /// </summary>
        public string OutPath { get; set; }

        /// <summary>
        ///     Your Aspose Cloud Storage name.
        /// </summary>
        public string Storage { get; set; }
    }
}