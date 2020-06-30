// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="SaveAsApiTests.cs">
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
using Aspose.Psd.Cloud.Sdk.Model.Requests;
using NUnit.Framework;

namespace Aspose.Psd.Cloud.Sdk.Test.Api
{
    /// <summary>
    ///     Class for testing SaveAsApi
    /// </summary>
    [Category("v1.0")]
    [Category("SaveAs")]
    [TestFixture]
    public class SaveAsApiTests : PsdApiTester
    {
        /// <summary>
        ///     Performs SaveAs (export to another format) operation test with POST method, sending input data in request stream.
        /// </summary>
        /// <param name="saveResultToStorage">If resulting image should be saved to storage</param>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [TestCase(true)]
        [TestCase(false)]
        public void CreateSavedImageAsTest(bool saveResultToStorage,
            params string[] additionalExportFormats)
        {
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestPostRequest(
                    "CreateSavedImageAsTest",
                    saveResultToStorage,
                    $"Input image: {inputFile.Name}; Output format: {format}",
                    inputFile.Name,
                    $"{inputFile.Name}.{format}",
                    delegate(Stream inputStream, string outPath)
                    {
                        var request =
                            new CreateSavedImageAsRequest(inputStream, format, outPath, storage);
                        return PsdApi.CreateSavedImageAs(request);
                    },
                    null,
                    folder,
                    storage);
        }

        /// <summary>
        ///     Performs SaveAs (export to another format) operation test with GET method, taking input data from storage.
        /// </summary>
        /// <param name="formatExtension">Format extension to search for input images in the test folder</param>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(null)]
        public void SaveImageAsTest(string formatExtension, params string[] additionalExportFormats)
        {
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (additionalExportFormat != null && !formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var format in formatsToExport)
                TestGetRequest(
                    "SaveImageAsTest",
                    $"Input image: {inputFile.Name}; Output format: {format}",
                    inputFile.Name,
                    delegate
                    {
                        var request = new SaveImageAsRequest(inputFile.Name, format, folder, storage);
                        return PsdApi.SaveImageAs(request);
                    },
                    null,
                    folder,
                    storage);
        }
    }
}