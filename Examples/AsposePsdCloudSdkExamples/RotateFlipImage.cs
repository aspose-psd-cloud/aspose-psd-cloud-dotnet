﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="RotateFlipAnImage.cs">
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
    ///     Rotate and/or flip an image example.
    /// </summary>
    /// <seealso cref="ImagingBase" />
    internal class RotateFlipImage : ImagingBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RotateFlipImage" /> class.
        /// </summary>
        /// <param name="psdApi">The imaging API.</param>
        public RotateFlipImage(PsdApi psdApi) : base(psdApi)
        {
            PrintHeader("Rotate/flip image example:");
        }

        /// <summary>
        ///     Gets the name of the example image file.
        /// </summary>
        protected override string SampleImageFileName => "SampleImage.psd";

        /// <summary>
        ///     Rotate and/or flip an image.
        /// </summary>
        public void RotateFlipImageFromStorage()
        {
            Console.WriteLine("Rotate and/or flip an image from cloud storage");

            UploadSampleImageToCloud();

            // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-RotateFlip 
            // for possible output formats
            var format = "psd";
            var method = "Rotate90FlipX"; // RotateFlip method
            var folder = CloudPath; // Input file is saved at the Examples folder in the storage
            string storage = null; // We are using default Cloud Storage

            var getImageRotateFlipRequest = new RotateFlipImageRequest(
                SampleImageFileName, method, format, folder, storage);

            Console.WriteLine($"Call RotateFlipImage with params: method:{method}, format:{format}");

            using (var updatedImage = PsdApi.RotateFlipImage(getImageRotateFlipRequest))
            {
                SaveUpdatedSampleImageToOutput(updatedImage, false, format);
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     Rotate and/or flip an image, and upload updated image to Cloud Storage
        /// </summary>
        public void RotateFlipImageAndUploadToStorage()
        {
            Console.WriteLine("Rotate/flip an image and upload to cloud storage");

            UploadSampleImageToCloud();

            // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-RotateFlip 
            // for possible output formats
            var format = "psd";
            var method = "Rotate90FlipX"; // RotateFlip method
            var folder = CloudPath; // Input file is saved at the Examples folder in the storage
            string storage = null; // We are using default Cloud Storage

            var getImageRotateFlipRequest = new RotateFlipImageRequest(
                SampleImageFileName, method, format, folder, storage);

            Console.WriteLine($"Call RotateFlipImage with params: method:{method}, format:{format}");

            using (var updatedImage = PsdApi.RotateFlipImage(getImageRotateFlipRequest))
            {
                UploadImageToCloud(GetModifiedSampleImageFileName(false, format), updatedImage);
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     Rotate and/or flip an image.
        ///     Image data is passed in a request stream.
        /// </summary>
        public void CreateRotateFlippedImageFromRequestBody()
        {
            Console.WriteLine("Rotate/flip an image from request body");

            using (var inputImageStream = File.OpenRead(Path.Combine(ExampleImagesFolder, SampleImageFileName)))
            {
                // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-RotateFlip 
                // for possible output formats
                var format = "psd";
                var method = "Rotate90FlipX"; // RotateFlip method
                string outPath = null; // Path to updated file (if this is empty, response contains streamed image).
                string storage = null; // We are using default Cloud Storage

                var createRotateFlippedImageRequest =
                    new CreateRotateFlippedImageRequest(inputImageStream, method, format, outPath, storage);

                Console.WriteLine($"Call CreateRotateFlippedImage with params: method:{method}, format:{format}");

                using (var updatedImage = PsdApi.CreateRotateFlippedImage(createRotateFlippedImageRequest))
                {
                    SaveUpdatedSampleImageToOutput(updatedImage, true, format);
                }

                Console.WriteLine();
            }
        }
    }
}