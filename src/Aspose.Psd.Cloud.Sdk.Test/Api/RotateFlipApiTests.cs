// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="RotateFlipApiTests.cs">
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
using Aspose.Psd.Cloud.Sdk.Model;
using Aspose.Psd.Cloud.Sdk.Model.Requests;
using NUnit.Framework;

namespace Aspose.Psd.Cloud.Sdk.Test.Api
{
    /// <summary>
    ///     Class for testing RotateFlipApi
    /// </summary>
    [Category("v1.0")]
    [Category("RotateFlip")]
    [TestFixture]
    public class RotateFlipApiTests : PsdApiTester
    {
        /// <summary>
        ///     Test CreateRotateFlippedImage
        /// </summary>
        /// <param name="saveResultToStorage">If result should be saved to storage</param>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [TestCase(true)]
        [TestCase(false)]
        public void CreateRotateFlippedImageTest(bool saveResultToStorage,
            params string[] additionalExportFormats)
        {
            var method = "Rotate90FlipX";
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestPostRequest(
                    "CreateRotateFlippedImageTest",
                    saveResultToStorage,
                    $"Input image: {inputFile.Name}; Output format: {format ?? "null"}; Method: {method}",
                    inputFile.Name,
                    $"{inputFile.Name}_rotateFlip.{format}",
                    delegate(Stream inputStream, string outPath)
                    {
                        var request =
                            new CreateRotateFlippedImageRequest(inputStream, method, format, outPath, storage);
                        return PsdApi.CreateRotateFlippedImage(request);
                    },
                    delegate(PsdResponse originalProperties, PsdResponse resultProperties, Stream resultStream)
                    {
                        try
                        {
                            Assert.AreEqual(originalProperties.Height, resultProperties.Width);
                        }
                        catch (Exception)
                        {
                            Assert.AreEqual(originalProperties.Height - 1, resultProperties.Width);
                        }

                        try
                        {
                            Assert.AreEqual(originalProperties.Width, resultProperties.Height);
                        }
                        catch (Exception)
                        {
                            Assert.AreEqual(originalProperties.Width - 1, resultProperties.Height);
                        }
                    },
                    folder,
                    storage);
        }

        /// <summary>
        ///     Test RotateFlipImage
        /// </summary>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(null)]
        public void RotateFlipImageTest(params string[] additionalExportFormats)
        {
            var method = "Rotate90FlipX";
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestGetRequest(
                    "RotateFlipImageTest",
                    $"Input image: {inputFile.Name}; Output format: {format ?? "null"}; Method: {method}",
                    inputFile.Name,
                    delegate
                    {
                        var request =
                            new RotateFlipImageRequest(inputFile.Name, method, format, folder, storage);
                        return PsdApi.RotateFlipImage(request);
                    },
                    delegate(PsdResponse originalProperties, PsdResponse resultProperties, Stream resultStream)
                    {
                        try
                        {
                            Assert.AreEqual(originalProperties.Height, resultProperties.Width);
                        }
                        catch (Exception)
                        {
                            Assert.AreEqual(originalProperties.Height - 1, resultProperties.Width);
                        }

                        try
                        {
                            Assert.AreEqual(originalProperties.Width, resultProperties.Height);
                        }
                        catch (Exception)
                        {
                            Assert.AreEqual(originalProperties.Width - 1, resultProperties.Height);
                        }
                    },
                    folder,
                    storage);
        }
    }
}