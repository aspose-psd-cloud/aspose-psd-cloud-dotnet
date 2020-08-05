﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="DeskewImage.cs">
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
    /// Deskew image example.
    /// </summary>
    /// <seealso cref="ImagingBase" />
    class DeskewImage : ImagingBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeskewImage"/> class.
        /// </summary>
        /// <param name="psdApi">The imaging API.</param>
        public DeskewImage(PsdApi psdApi) : base(psdApi)
        {
            PrintHeader("Deskew image example:");
        }

        /// <summary>
        /// Gets the name of the example image file.
        /// </summary>
        protected override string SampleImageFileName => "SampleImage.psd";

        private const string SaveImageFormat = "tif";

        /// <summary>
        /// Deskews an image from a cloud storage.
        /// </summary>
        public void DeskewImageFromStorage()
        {
            Console.WriteLine("Deskew the image from cloud storage");

            UploadSampleImageToCloud();

            bool resizeProportionally = true;
            string bkColor = "white";
            string folder = CloudPath; // Input file is saved at the Examples folder in the storage
            string storage = null; // We are using default Cloud Storage

            var request = new DeskewImageRequest(SampleImageFileName, resizeProportionally, bkColor, folder, storage);

            Console.WriteLine($"Call DeskewImage with params: resizeProportionally:{resizeProportionally}, bkColor:{bkColor}");

            using (Stream updatedImage = this.PsdApi.DeskewImage(request))
            {
                SaveUpdatedSampleImageToOutput(updatedImage, false, SaveImageFormat);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Deskew an existing image, and upload updated image to a cloud storage.
        /// </summary>
        public void DeskewImageAndUploadToStorage()
        {
            Console.WriteLine("Deskews the image and upload to cloud storage");

            UploadSampleImageToCloud();

            bool resizeProportionally = true;
            string bkColor = null;
            string folder = CloudPath; // Input file is saved at the Examples folder in the storage
            string storage = null; // We are using default Cloud Storage

            var request = new DeskewImageRequest(SampleImageFileName, resizeProportionally, bkColor, folder, storage);

            Console.WriteLine($"Call DeskewImage with params: resizeProportionally:{resizeProportionally}, bkColor:{bkColor}");

            using (Stream updatedImage = this.PsdApi.DeskewImage(request))
            {
                UploadImageToCloud(GetModifiedSampleImageFileName(false, SaveImageFormat), updatedImage);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Deskews an image. Image data is passed in a request stream.
        /// </summary>
        public void CreateDeskewedImageFromRequestBody()
        {
            Console.WriteLine("Deskews the image from request body");

            using (FileStream inputImageStream = File.OpenRead(Path.Combine(ExampleImagesFolder, SampleImageFileName)))
            {
                bool resizeProportionally = true;
                string bkColor = "white";
                string storage = null; // We are using default Cloud Storage
                string outPath = null; // Path to updated file (if this is empty, response contains streamed image)

                var request = new CreateDeskewedImageRequest(inputImageStream, resizeProportionally, bkColor, outPath, storage);

                Console.WriteLine($"Call DeskewImage with params: resizeProportionally:{resizeProportionally}, bkColor:{bkColor}");

                using (Stream updatedImage = this.PsdApi.CreateDeskewedImage(request))
                {
                    SaveUpdatedSampleImageToOutput(updatedImage, true, SaveImageFormat);
                }
            }

            Console.WriteLine();
        }
    }
}