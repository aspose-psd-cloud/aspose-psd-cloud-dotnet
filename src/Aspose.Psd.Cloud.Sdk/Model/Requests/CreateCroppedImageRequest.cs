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

namespace Aspose.Psd.Cloud.Sdk.Model.Requests 
{
  using Aspose.Psd.Cloud.Sdk.Model; 

  /// <summary>
  /// Request model for <see cref="Aspose.Psd.Cloud.Sdk.Api.PsdApi.CreateCroppedImage" /> operation.
  /// </summary>  
  public class CreateCroppedImageRequest  
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCroppedImageRequest"/> class.
        /// </summary>        
        public CreateCroppedImageRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCroppedImageRequest"/> class.
        /// </summary>
        /// <param name="imageData">Input image</param>
        /// <param name="x">X position of start point for cropping rectangle.</param>
        /// <param name="y">Y position of start point for cropping rectangle.</param>
        /// <param name="width">Width of cropping rectangle.</param>
        /// <param name="height">Height of cropping rectangle.</param>
        /// <param name="format">Resulting image format. Please, refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases.</param>
        /// <param name="outPath">Path to updated file (if this is empty, response contains streamed image).</param>
        /// <param name="storage">Your Aspose Cloud Storage name.</param>
        public CreateCroppedImageRequest(System.IO.Stream imageData, int? x, int? y, int? width, int? height, string format = null, string outPath = null, string storage = null)             
        {
            this.imageData = imageData;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.format = format;
            this.outPath = outPath;
            this.storage = storage;
        }
        
        /// <summary>
        /// Input image
        /// </summary>  
        public System.IO.Stream imageData { get; set; }

        /// <summary>
        /// X position of start point for cropping rectangle.
        /// </summary>  
        public int? x { get; set; }

        /// <summary>
        /// Y position of start point for cropping rectangle.
        /// </summary>  
        public int? y { get; set; }

        /// <summary>
        /// Width of cropping rectangle.
        /// </summary>  
        public int? width { get; set; }

        /// <summary>
        /// Height of cropping rectangle.
        /// </summary>  
        public int? height { get; set; }

        /// <summary>
        /// Resulting image format. Please, refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases.
        /// </summary>  
        public string format { get; set; }

        /// <summary>
        /// Path to updated file (if this is empty, response contains streamed image).
        /// </summary>  
        public string outPath { get; set; }

        /// <summary>
        /// Your Aspose Cloud Storage name.
        /// </summary>  
        public string storage { get; set; }
  }
}
