// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="GrayscaleApiTests.cs">
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
    [TestFixture]
    public class GrayscaleApiTests : PsdApiTester
    {
        /// <summary>
        ///     Create grayscale image test
        /// </summary>
        /// <param name="saveResultToStorage">Save results to storage</param>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CreateGrayscaledImageTest(bool saveResultToStorage,
            params string[] additionalExportFormats)
        {
            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestPostRequest(
                    "GrayscaleImageTest",
                    saveResultToStorage,
                    $"Input image: {inputFile.Name}; Output format: {format};",
                    inputFile.Name,
                    $"{inputFile.Name}_grayscale.{format}",
                    delegate(Stream inputStream, string outPath)
                    {
                        var request = new CreateGrayscaledImageRequest(inputStream, outPath, TestStorage);
                        return PsdApi.CreateGrayscaledImage(request);
                    },
                    delegate(PsdResponse originalProperties, PsdResponse resultProperties,
                        Stream resultStream)
                    {
                        if (!saveResultToStorage)
                        {
                            Assert.NotNull(resultStream);
                            Assert.IsTrue(resultStream.Length > 0);
                        }
                        else
                        {
                            Assert.IsTrue(originalProperties.BitsPerPixel == resultProperties.BitsPerPixel);
                        }
                    },
                    TempFolder,
                    TestStorage);
        }

        /// <summary>
        ///     Grayscale image test
        /// </summary>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(null)]
        public void GrayscaleImageTest(params string[] additionalExportFormats)
        {
            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestGetRequest(
                    "GrayscaleImageTest",
                    $"Input image: {inputFile.Name}; Output format: {format};",
                    inputFile.Name,
                    delegate
                    {
                        var request = new GrayscaleImageRequest(inputFile.Name, TempFolder, TestStorage);
                        return PsdApi.GrayscaleImage(request);
                    },
                    delegate(PsdResponse originalProperties, PsdResponse resultProperties, Stream resultStream)
                    {
                        Assert.NotNull(resultStream);
                        Assert.IsTrue(resultStream.Length > 0);
                    },
                    TempFolder,
                    TestStorage);
        }
    }
}