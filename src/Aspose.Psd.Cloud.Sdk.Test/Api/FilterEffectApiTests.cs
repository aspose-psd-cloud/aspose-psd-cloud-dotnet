// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="FilterEffectApiTests.cs">
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
using Aspose.Psd.Cloud.Sdk.Model;
using Aspose.Psd.Cloud.Sdk.Model.Requests;
using NUnit.Framework;

namespace Aspose.Psd.Cloud.Sdk.Test.Api
{
    /// <summary>
    ///     Class for testing FilterEffectApi
    /// </summary>
    [Category("v1.0")]
    [Category("FilterEffect")]
    [TestFixture]
    public class FilterEffectApiTests : PsdApiTester
    {
        /// <summary>
        ///     Wrapper for filter type and filter properties
        /// </summary>
        private class Filter
        {
            /// <summary>
            ///     Creates Filter instance
            /// </summary>
            /// <param name="filterType">The filter type.</param>
            /// <param name="filterProperties">The filter properties.</param>
            public Filter(string filterType, FilterPropertiesBase filterProperties)
            {
                FilterType = filterType;
                FilterProperties = filterProperties;
            }

            /// <summary>
            ///     The filter type
            /// </summary>
            public string FilterType { get; }

            /// <summary>
            ///     The filter properties
            /// </summary>
            public FilterPropertiesBase FilterProperties { get; }
        }

        /// <summary>
        ///     Filters to test
        /// </summary>
        private readonly IEnumerable<Filter> filters = new[]
        {
            new Filter("BigRectangular", new BigRectangularFilterProperties()),
            new Filter("SmallRectangular", new SmallRectangularFilterProperties()),
            new Filter("Median", new MedianFilterProperties
            {
                Size = 3
            }),
            new Filter("GaussWiener", new GaussWienerFilterProperties
            {
                Radius = 2,
                Smooth = 2
            }),
            new Filter("MotionWiener", new MotionWienerFilterProperties
            {
                Angle = 12,
                Length = 2,
                Smooth = 2
            }),
            new Filter("GaussianBlur", new GaussianBlurFilterProperties
            {
                Radius = 2,
                Sigma = 2
            }),
            new Filter("Sharpen", new SharpenFilterProperties
            {
                Sigma = 2,
                Size = 2
            }),
            new Filter("BilateralSmoothing", new BilateralSmoothingFilterProperties
            {
                Size = 2,
                ColorFactor = 2,
                ColorPower = 2,
                SpatialFactor = 2,
                SpatialPower = 2
            })
        };

        /// <summary>
        ///     Test FilterEffectImage
        /// </summary>
        /// <param name="additionalExportFormats">Additional formats to export to</param>
        [Test]
        [TestCase(null)]
        public void FilterEffectTest(params string[] additionalExportFormats)
        {
            var folder = TempFolder;
            var storage = TestStorage;

            var formatsToExport = new List<string>(BasicExportFormats);
            foreach (var additionalExportFormat in additionalExportFormats)
                if (!formatsToExport.Contains(additionalExportFormat))
                    formatsToExport.Add(additionalExportFormat);

            foreach (var inputFile in InputTestFiles)
            foreach (var filter in filters)
            foreach (var format in formatsToExport)
                TestGetRequest(
                    "FilterEffectTest",
                    $"Input image: {inputFile.Name}; Output format: {format ?? "null"}; Filter type: {filter.FilterType}",
                    inputFile.Name,
                    delegate
                    {
                        var request = new FilterEffectImageRequest(inputFile.Name, filter.FilterType,
                            filter.FilterProperties, format, folder, storage);
                        return PsdApi.FilterEffectImage(request);
                    },
                    null,
                    folder,
                    storage);
        }
    }
}