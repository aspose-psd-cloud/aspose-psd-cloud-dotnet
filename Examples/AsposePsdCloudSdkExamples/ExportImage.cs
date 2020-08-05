// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ExportImage.cs">
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
using System.IO;
using Aspose.Psd.Cloud.Sdk.Api;
using Aspose.Psd.Cloud.Sdk.Model.Requests;

namespace AsposePsdCloudSdkExamples
{
    /// <summary>
    ///     Export image example.
    /// </summary>
    /// <seealso cref="ImagingBase" />
    internal class ExportImage : ImagingBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExportImage" /> class.
        /// </summary>
        /// <param name="psdApi">The imaging API.</param>
        public ExportImage(PsdApi psdApi) : base(psdApi)
        {
            PrintHeader("Export image example:");
        }

        /// <summary>
        ///     Gets the name of the example image file.
        /// </summary>
        protected override string SampleImageFileName => "SampleImage.psd";

        /// <summary>
        ///     Export an image to another format.
        /// </summary>
        public void SaveImageAsFromStorage()
        {
            Console.WriteLine("Export an image to another format");

            UploadSampleImageToCloud();

            // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Export(SaveAs) 
            // for possible output formats
            var format = "psd";
            var folder = CloudPath; // Input file is saved at the Examples folder in the storage
            string storage = null; // Cloud Storage name

            var request = new SaveImageAsRequest(SampleImageFileName, format, folder, storage);

            Console.WriteLine($"Call SaveImageAs with params: format:{format}");

            using (var updatedImage = PsdApi.SaveImageAs(request))
            {
                SaveUpdatedSampleImageToOutput(updatedImage, false, format);
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     Export an image to another format.
        /// </summary>
        public void SaveImageAsAndUploadToStorage()
        {
            Console.WriteLine("Export an image to another format and upload to cloud storage");

            UploadSampleImageToCloud();

            // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Export(SaveAs)
            // for possible output formats
            var format = "psd";
            var folder = CloudPath; // Input file is saved at the Examples folder in the storage
            string storage = null; // Cloud Storage name

            var request = new SaveImageAsRequest(SampleImageFileName, format, folder, storage);

            Console.WriteLine($"Call SaveImageAs with params: format:{format}");

            using (var updatedImage = PsdApi.SaveImageAs(request))
            {
                UploadImageToCloud(GetModifiedSampleImageFileName(false, format), updatedImage);
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     Export an image to another format. Image data is passed in a request stream.
        /// </summary>
        public void CreateSavedImageAsFromRequestBody()
        {
            Console.WriteLine("Export an image to another format. Image data is passed in a request body");

            using (var inputImageStream = File.OpenRead(Path.Combine(ExampleImagesFolder, SampleImageFileName)))
            {
                // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Export(SaveAs)
                // for possible output formats
                var format = "psd";
                string outPath = null; // Path to updated file (if this is empty, response contains streamed image)
                string storage = null; // Cloud Storage name

                var request = new CreateSavedImageAsRequest(inputImageStream, format, outPath, storage);

                Console.WriteLine($"Call CreateSavedImageAs with params: format:{format}");

                using (var updatedImage = PsdApi.CreateSavedImageAs(request))
                {
                    SaveUpdatedSampleImageToOutput(updatedImage, true, format);
                }

                Console.WriteLine();
            }
        }
    }
}