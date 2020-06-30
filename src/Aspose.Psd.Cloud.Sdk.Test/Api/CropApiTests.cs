// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="CropApiTests.cs">
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

using System.Collections.Generic;
using System.IO;
using Aspose.Psd.Cloud.Sdk.Model;
using Aspose.Psd.Cloud.Sdk.Model.Requests;
using NUnit.Framework;

namespace Aspose.Psd.Cloud.Sdk.Test.Api
{
    /// <summary>
    ///     Class for testing CropApi
    /// </summary>
    [Category("v1.0")]
    [Category("Crop")]
    [TestFixture]
    public class CropApiTests : PsdApiTester
    {
        /// <summary>
        ///     Test CreateCroppedImage
        /// </summary>
        /// <param name="saveResultToStorage">If result should be saved to storage</param>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CreateCroppedImageTest(bool saveResultToStorage,
            params string[] additionalExportFormats)
        {
            int? x = 10;
            int? y = 10;
            int? width = 100;
            int? height = 150;
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestPostRequest(
                    "CropImageTest",
                    saveResultToStorage,
                    $"Input image: {inputFile.Name}; Output format: {format}; Width: {width}; Height: {height}; X: {x}; Y: {y}",
                    inputFile.Name,
                    $"{inputFile.Name}_crop.{format}",
                    delegate(Stream inputStream, string outPath)
                    {
                        var request = new CreateCroppedImageRequest(inputStream, x, y, width, height, format,
                            outPath, storage);
                        return PsdApi.CreateCroppedImage(request);
                    },
                    delegate(PsdResponse originalProperties, PsdResponse resultProperties, Stream resultStream)
                    {
                        Assert.AreEqual(width, resultProperties.Width);
                        Assert.AreEqual(height, resultProperties.Height);
                    },
                    folder,
                    storage);
        }

        /// <summary>
        ///     Test CropImage
        /// </summary>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(null)]
        public void CropImageTest(params string[] additionalExportFormats)
        {
            int? x = 10;
            int? y = 10;
            int? width = 100;
            int? height = 150;
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);

            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestGetRequest(
                    "CropImageTest",
                    $"Input image: {inputFile.Name}; Output format: {format ?? "null"}; Width: {width}; Height: {height}; X: {x}; Y: {y}",
                    inputFile.Name,
                    delegate
                    {
                        var request = new CropImageRequest(inputFile.Name, x, y, width, height, format, folder,
                            storage);
                        return PsdApi.CropImage(request);
                    },
                    delegate(PsdResponse originalProperties, PsdResponse resultProperties, Stream resultStream)
                    {
                        Assert.AreEqual(width, resultProperties.Width);
                        Assert.AreEqual(height, resultProperties.Height);
                    },
                    folder,
                    storage);
        }
    }
}