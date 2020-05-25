// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="UpdateImageRequest.cs">
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
    ///     Request model for <see cref="Aspose.Psd.Cloud.Sdk.Api.PsdApi.UpdateImage" /> operation.
    /// </summary>
    public class UpdateImageRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UpdateImageRequest" /> class.
        /// </summary>
        public UpdateImageRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UpdateImageRequest" /> class.
        /// </summary>
        /// <param name="name">Filename of an image.</param>
        /// <param name="newWidth">New width of the scaled image.</param>
        /// <param name="newHeight">New height of the scaled image.</param>
        /// <param name="x">X position of start point for cropping rectangle.</param>
        /// <param name="y">Y position of start point for cropping rectangle.</param>
        /// <param name="rectWidth">Width of cropping rectangle.</param>
        /// <param name="rectHeight">Height of cropping rectangle.</param>
        /// <param name="rotateFlipMethod">
        ///     RotateFlip method (Rotate180FlipNone, Rotate180FlipX, Rotate180FlipXY, Rotate180FlipY,
        ///     Rotate270FlipNone, Rotate270FlipX, Rotate270FlipXY, Rotate270FlipY, Rotate90FlipNone, Rotate90FlipX,
        ///     Rotate90FlipXY, Rotate90FlipY, RotateNoneFlipNone, RotateNoneFlipX, RotateNoneFlipXY, RotateNoneFlipY). Default is
        ///     RotateNoneFlipNone.
        /// </param>
        /// <param name="format">
        ///     Resulting image format. Please, refer to
        ///     https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap
        ///     for possible use-cases.
        /// </param>
        /// <param name="folder">Folder with image to process.</param>
        /// <param name="storage">Your Aspose Cloud Storage name.</param>
        public UpdateImageRequest(string name, int? newWidth, int? newHeight, int? x, int? y, int? rectWidth,
            int? rectHeight, string rotateFlipMethod, string format = null, string folder = null, string storage = null)
        {
            Name = name;
            NewWidth = newWidth;
            NewHeight = newHeight;
            X = x;
            Y = y;
            RectWidth = rectWidth;
            RectHeight = rectHeight;
            RotateFlipMethod = rotateFlipMethod;
            Format = format;
            Folder = folder;
            Storage = storage;
        }

        /// <summary>
        ///     Filename of an image.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     New width of the scaled image.
        /// </summary>
        public int? NewWidth { get; set; }

        /// <summary>
        ///     New height of the scaled image.
        /// </summary>
        public int? NewHeight { get; set; }

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
        public int? RectWidth { get; set; }

        /// <summary>
        ///     Height of cropping rectangle.
        /// </summary>
        public int? RectHeight { get; set; }

        /// <summary>
        ///     RotateFlip method (Rotate180FlipNone, Rotate180FlipX, Rotate180FlipXY, Rotate180FlipY, Rotate270FlipNone,
        ///     Rotate270FlipX, Rotate270FlipXY, Rotate270FlipY, Rotate90FlipNone, Rotate90FlipX, Rotate90FlipXY, Rotate90FlipY,
        ///     RotateNoneFlipNone, RotateNoneFlipX, RotateNoneFlipXY, RotateNoneFlipY). Default is RotateNoneFlipNone.
        /// </summary>
        public string RotateFlipMethod { get; set; }

        /// <summary>
        ///     Resulting image format. Please, refer to
        ///     https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap
        ///     for possible use-cases.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        ///     Folder with image to process.
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        ///     Your Aspose Cloud Storage name.
        /// </summary>
        public string Storage { get; set; }
    }
}