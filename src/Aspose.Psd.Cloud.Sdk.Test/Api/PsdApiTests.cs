// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="PsdApiTests.cs">
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

using System.IO;
using Aspose.Psd.Cloud.Sdk.Model;
using Aspose.Psd.Cloud.Sdk.Model.Requests;
using NUnit.Framework;

namespace Aspose.Psd.Cloud.Sdk.Test.Api
{
    /// <summary>
    ///     Class for testing PsdApi
    /// </summary>
    [Category("v3.0")]
    [Category("Psd")]
    [TestFixture]
    public class PsdApiTests : PsdApiTester
    {
        /// <summary>
        ///     Test CreateModifiedPsd
        /// </summary>
        /// <param name="saveResultToStorage">If result should be saved to storage</param>
        [TestCase(true)]
        [TestCase(false)]
        public void CreateModifiedPsdTest(bool saveResultToStorage)
        {
            var name = "test.psd";
            var channelsCount = 3;
            var compressionMethod = "raw";
            bool? fromScratch = null;
            var outName = $"{name}_specific.psd";
            var folder = TempFolder;
            var storage = TestStorage;

            TestPostRequest(
                "CreateModifiedPsdTest",
                saveResultToStorage,
                $"Input image: {name}; Channel count: {channelsCount}; Compression method: {compressionMethod}",
                name,
                outName,
                delegate(Stream inputStream, string outPath)
                {
                    var request = new CreateModifiedPsdRequest(inputStream, channelsCount, compressionMethod,
                        fromScratch, outPath, storage);
                    return PsdApi.CreateModifiedPsd(request);
                },
                delegate(ImagingResponse originalProperties, ImagingResponse resultProperties, Stream resultStream)
                {
                    Assert.NotNull(resultProperties.PsdProperties);
                    Assert.AreEqual(compressionMethod, resultProperties.PsdProperties.Compression.ToLower());
                    Assert.AreEqual(channelsCount, resultProperties.PsdProperties.ChannelsCount);

                    Assert.NotNull(originalProperties.PsdProperties);
                    Assert.AreEqual(originalProperties.Width, resultProperties.Width);
                    Assert.AreEqual(originalProperties.Height, resultProperties.Height);
                    Assert.AreEqual(originalProperties.PsdProperties.BitsPerChannel,
                        resultProperties.PsdProperties.BitsPerChannel);
                },
                folder,
                storage);
        }

        /// <summary>
        ///     Test ModifyPsd
        /// </summary>
        [Test]
        public void ModifyPsdTest()
        {
            var name = "test.psd";
            var channelsCount = 3;
            var compressionMethod = "raw";
            bool? fromScratch = null;
            var folder = TempFolder;
            var storage = TestStorage;

            TestGetRequest(
                "ModifyPsdTest",
                $"Input image: {name}; Channel count: {channelsCount}; Compression method: {compressionMethod}",
                name,
                delegate
                {
                    var request = new ModifyPsdRequest(name, channelsCount, compressionMethod, fromScratch,
                        folder, storage);
                    return PsdApi.ModifyPsd(request);
                },
                delegate(ImagingResponse originalProperties, ImagingResponse resultProperties, Stream resultStream)
                {
                    Assert.NotNull(resultProperties.PsdProperties);
                    Assert.AreEqual(compressionMethod, resultProperties.PsdProperties.Compression.ToLower());
                    Assert.AreEqual(channelsCount, resultProperties.PsdProperties.ChannelsCount);

                    Assert.NotNull(originalProperties.PsdProperties);
                    Assert.AreEqual(originalProperties.Width, resultProperties.Width);
                    Assert.AreEqual(originalProperties.Height, resultProperties.Height);
                    Assert.AreEqual(originalProperties.PsdProperties.BitsPerChannel,
                        resultProperties.PsdProperties.BitsPerChannel);
                },
                folder,
                storage);
        }
    }
}