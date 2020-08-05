﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="CropImage.cs">
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
    ///     Crop image example.
    /// </summary>
    /// <seealso cref="ImagingBase" />
    internal class CropImage : ImagingBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CropImage" /> class.
        /// </summary>
        /// <param name="psdApi">The imaging API.</param>
        public CropImage(PsdApi psdApi) : base(psdApi)
        {
            PrintHeader("Crop image example:");
        }

        /// <summary>
        ///     Gets the name of the example image file.
        /// </summary>
        ///     The name of the example image file.
        protected override string SampleImageFileName => "SampleImage.psd";

        /// <summary>
        ///     Crops the image from cloud storage.
        /// </summary>
        public void CropImageFromStorage()
        {
            Console.WriteLine("Crops the image from cloud storage");

            UploadSampleImageToCloud();

            // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Crop 
            // for possible output formats
            var format = "psd"; // Resulting image format.
            int? x = 10;
            int? y = 10;
            int? width = 100;
            int? height = 150;
            var folder = CloudPath; // Input file is saved at the Examples folder in the storage
            string storage = null; // We are using default Cloud Storage

            var request = new CropImageRequest(SampleImageFileName, x, y, width, height, format, folder, storage);

            Console.WriteLine($"Call CropImage with params:x:{x},y:{y}, width:{width}, height:{height}");

            using (var updatedImage = PsdApi.CropImage(request))
            {
                SaveUpdatedSampleImageToOutput(updatedImage, false, format);
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     Crop an existing image, and upload updated image to Cloud Storage.
        /// </summary>
        public void CropImageAndUploadToStorage()
        {
            Console.WriteLine("Crops the image and upload to cloud storage");

            UploadSampleImageToCloud();

            // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Crop 
            // for possible output formats
            var format = "psd"; // Resulting image format.
            int? x = 10;
            int? y = 10;
            int? width = 100;
            int? height = 150;
            var folder = CloudPath; // Input file is saved at the Examples folder in the storage
            string storage = null; // We are using default Cloud Storage

            var request = new CropImageRequest(SampleImageFileName, x, y, width, height, format, folder, storage);

            Console.WriteLine($"Call CropImage with params:x:{x},y:{y}, width:{width}, height:{height}");

            using (var updatedImage = PsdApi.CropImage(request))
            {
                UploadImageToCloud(GetModifiedSampleImageFileName(false, format), updatedImage);
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     Crop an image. Image data is passed in a request stream.
        /// </summary>
        public void CreateCroppedImageFromRequestBody()
        {
            Console.WriteLine("Crops the image from request body");

            using (var inputImageStream = File.OpenRead(Path.Combine(ExampleImagesFolder, SampleImageFileName)))
            {
                // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Crop 
                // for possible output formats
                var format = "psd"; // Resulting image format.
                int? x = 10;
                int? y = 10;
                int? width = 100;
                int? height = 150;
                string storage = null; // We are using default Cloud Storage
                string outPath = null; // Path to updated file (if this is empty, response contains streamed image)

                var request =
                    new CreateCroppedImageRequest(inputImageStream, x, y, width, height, format, outPath, storage);

                Console.WriteLine($"Call CreateCroppedImage with params:x:{x},y:{y}, width:{width}, height:{height}");

                using (var updatedImage = PsdApi.CreateCroppedImage(request))
                {
                    SaveUpdatedSampleImageToOutput(updatedImage, true, format);
                }
            }

            Console.WriteLine();
        }
    }
}