// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="SaveImageAsRequest.cs">
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
  /// Request model for <see cref="Aspose.Psd.Cloud.Sdk.Api.PsdApi.SaveImageAs" /> operation.
  /// </summary>  
  public class SaveImageAsRequest  
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveImageAsRequest"/> class.
        /// </summary>        
        public SaveImageAsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveImageAsRequest"/> class.
        /// </summary>
        /// <param name="name">Filename of image.</param>
        /// <param name="format">Resulting image format. Please, refer to https://docs.aspose.cloud/display/psdcloud/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases.</param>
        /// <param name="folder">Folder with image to process.</param>
        /// <param name="storage">Your Aspose Cloud Storage name.</param>
        public SaveImageAsRequest(string name, string format, string folder = null, string storage = null)             
        {
            this.name = name;
            this.format = format;
            this.folder = folder;
            this.storage = storage;
        }
        
        /// <summary>
        /// Filename of image.
        /// </summary>  
        public string name { get; set; }

        /// <summary>
        /// Resulting image format. Please, refer to https://docs.aspose.cloud/display/psdcloud/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases.
        /// </summary>  
        public string format { get; set; }

        /// <summary>
        /// Folder with image to process.
        /// </summary>  
        public string folder { get; set; }

        /// <summary>
        /// Your Aspose Cloud Storage name.
        /// </summary>  
        public string storage { get; set; }
  }
}
