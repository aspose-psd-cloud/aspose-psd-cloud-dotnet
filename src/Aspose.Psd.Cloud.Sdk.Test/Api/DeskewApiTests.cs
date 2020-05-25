// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="DeskewApiTests.cs">
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
    public class DeskewApiTests : PsdApiTester
    {
        /// <summary>
        ///     Create deskew image test
        /// </summary>
        /// <param name="saveResultToStorage">Save results to storage</param>
        /// <param name="resizeProportionally">Resize proportionally</param>
        /// <param name="bkColor">Background color</param>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true, "green")]
        public void CreateDeskewedImageTest(
            bool saveResultToStorage,
            bool resizeProportionally,
            string bkColor = null,
            params string[] additionalExportFormats)
        {
            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (!formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestPostRequest(
                    "DeskewImageTest",
                    saveResultToStorage,
                    $"Input image: {inputFile.Name}; Output format: {format}; Resize proportionally: {resizeProportionally}; Background color: {bkColor ?? "null"};",
                    inputFile.Name,
                    $"{inputFile.Name}_deskew.{format}",
                    delegate(Stream inputStream, string outPath)
                    {
                        var request = new CreateDeskewedImageRequest(inputStream, resizeProportionally, bkColor,
                            outPath, TestStorage);
                        return PsdApi.CreateDeskewedImage(request);
                    },
                    delegate(PsdResponse originalProperties, PsdResponse resultProperties,
                        Stream resultStream)
                    {
                        if (!saveResultToStorage)
                        {
                            Assert.NotNull(resultStream);
                            Assert.IsTrue(resultStream.Length > 0);
                            Assert.AreEqual(originalProperties.BitsPerPixel, resultProperties.BitsPerPixel);
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
        ///     Deskew image test
        /// </summary>
        /// <param name="resizeProportionally">Resize proportionally</param>
        /// <param name="bkColor">Background color</param>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(false, "green")]
        public void DeskewImageTest(bool resizeProportionally, string bkColor = null,
            params string[] additionalExportFormats)
        {
            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (!formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestGetRequest(
                    "DeskewImageTest",
                    $"Input image: {inputFile.Name}; Output format: {format}; Resize proportionally: {resizeProportionally}; Background color: {bkColor ?? "null"};",
                    inputFile.Name,
                    delegate
                    {
                        var request = new DeskewImageRequest(inputFile.Name, resizeProportionally, bkColor, TempFolder,
                            TestStorage);
                        return PsdApi.DeskewImage(request);
                    },
                    delegate(PsdResponse originalProperties, PsdResponse resultProperties, Stream resultStream)
                    {
                        Assert.NotNull(resultStream);
                        Assert.IsTrue(resultStream.Length > 0);
                        Assert.AreEqual(originalProperties.BitsPerPixel, resultProperties.BitsPerPixel);
                    },
                    TempFolder,
                    TestStorage);
        }
    }
}