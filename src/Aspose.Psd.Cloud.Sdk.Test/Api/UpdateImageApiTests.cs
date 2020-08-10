// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="WebPApiTests.cs">
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
    ///     Class for testing UpdateImageApi
    /// </summary>
    [TestFixture]
    [Category("v3.0")]
    [Category("Update")]
    public class UpdateImageApiTests : PsdApiTester
    {
        /// <summary>
        ///     Test CreateUpdatedImage
        /// </summary>
        /// <param name="saveResultToStorage">If result should be saved to storage</param>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [TestCase(true, null)]
        [TestCase(false, null)]
        public void CreateUpdatedImageTest(bool saveResultToStorage,
            params string[] additionalExportFormats)
        {
            int? newWidth = 300;
            int? newHeight = 450;
            int? x = 10;
            int? y = 10;
            int? rectWidth = 200;
            int? rectHeight = 300;
            var rotateFlipMethod = "Rotate90FlipX";
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestPostRequest(
                    "CreateUpdatedImageTest",
                    saveResultToStorage,
                    $"Input image: {inputFile.Name}; Output format: {format ?? "null"}; New width: {newWidth}; New height: {newHeight}; Rotate/flip method: {rotateFlipMethod}; " +
                    $"X: {x}; Y: {y}; Rect width: {rectWidth}; Rect height: {rectHeight}",
                    inputFile.Name,
                    $"{inputFile.Name}_update.{format}",
                    delegate(Stream inputStream, string outPath)
                    {
                        var request = new CreateUpdatedImageRequest(inputStream, newWidth, newHeight, x, y,
                            rectWidth, rectHeight, rotateFlipMethod, format, outPath, storage);
                        return PsdApi.CreateUpdatedImage(request);
                    },
                    delegate(ImagingResponse originalProperties, ImagingResponse resultProperties, Stream resultStream)
                    {
                        Assert.AreEqual(rectHeight, resultProperties.Width);
                        Assert.AreEqual(rectWidth, resultProperties.Height);
                    },
                    folder,
                    storage);
        }

        /// <summary>
        ///     Test UpdateImage
        /// </summary>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(null)]
        public void UpdateImageTest(params string[] additionalExportFormats)
        {
            int? newWidth = 300;
            int? newHeight = 450;
            int? x = 10;
            int? y = 10;
            int? rectWidth = 200;
            int? rectHeight = 300;
            var rotateFlipMethod = "Rotate90FlipX";
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestGetRequest(
                    "UpdateImageTest",
                    $"Input image: {inputFile.Name}; Output format: {format ?? "null"}; New width: {newWidth}; New height: {newHeight}; Rotate/flip method: {rotateFlipMethod}; " +
                    $"X: {x}; Y: {y}; Rect width: {rectWidth}; Rect height: {rectHeight}",
                    inputFile.Name,
                    delegate
                    {
                        var request = new UpdateImageRequest(inputFile.Name, newWidth, newHeight, x, y, rectWidth,
                            rectHeight, rotateFlipMethod, format, folder, storage);
                        return PsdApi.UpdateImage(request);
                    },
                    delegate(ImagingResponse originalProperties, ImagingResponse resultProperties, Stream resultStream)
                    {
                        Assert.AreEqual(rectHeight, resultProperties.Width);
                        Assert.AreEqual(rectWidth, resultProperties.Height);
                    },
                    folder,
                    storage);
        }
    }
}