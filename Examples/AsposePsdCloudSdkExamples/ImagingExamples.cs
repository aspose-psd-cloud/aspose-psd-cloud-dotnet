// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ImagingExamples.cs">
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
using System.Linq;
using Aspose.Imaging.Cloud.Sdk.Api;

namespace AsposePsdCloudSdkExamples
{
    /// <summary>
    ///     Launcher for examples.
    /// </summary>
    internal static class ImagingExamples
    {
        /// <summary>
        ///     Main function.
        /// </summary>
        /// <param name="args"><c>--appKey</c> and <c>--appSid</c> are required arguments, <c>--baseUrl</c> is optional.</param>
        private static void Main(string[] args)
        {
            string appKey, appSid, baseUrl;
            // ProcessArguments(args, out appKey, out appSid, out baseUrl);

            try
            {
                // var api = new ImagingApi(appKey, appSid, baseUrl);
                var api = new ImagingApi("http://localhost:57972/", "v1.0", false);

                PrepareOutput();

                Console.WriteLine("Running Imaging Cloud examples:");
                Console.WriteLine();

                // Crop an existing image
                var cropImage = new CropImage(api);
                cropImage.CropImageFromStorage();
                cropImage.CropImageAndUploadToStorage();
                cropImage.CreateCroppedImageFromRequestBody();
                
                // Deskew an existing image
                var deskewImage = new DeskewImage(api);
                deskewImage.DeskewImageFromStorage();
                deskewImage.DeskewImageAndUploadToStorage();
                deskewImage.CreateDeskewedImageFromRequestBody();
                
                // grayscale an existing image
                var grayscaleImage = new GrayscaleImage(api);
                grayscaleImage.GrayscaleImageFromStorage();
                grayscaleImage.GrayscaleImageAndUploadToStorage();
                grayscaleImage.CreateGrayscaledImageFromRequestBody();
                
                // Export existing image to another format
                var exportImage = new ExportImage(api);
                exportImage.SaveImageAsFromStorage();
                exportImage.SaveImageAsAndUploadToStorage();
                exportImage.CreateSavedImageAsFromRequestBody();
                
                // Apply a filtering effect to an image
                var filterImage = new FilterImage(api);
                filterImage.FilterImageFromStorage();
                filterImage.FilterImageAndUploadToStorage();
                
                // Get properties of an image
                var imageProperties = new ImageProperties(api);
                imageProperties.GetImagePropertiesFromStorage();
                imageProperties.ExtractImagePropertiesFromRequestBody();
                
                // Resize an existing image
                var resizeImage = new ResizeImage(api);
                resizeImage.ResizeImageFromStorage();
                resizeImage.ResizeImageAndUploadToStorage();
                resizeImage.CreateResizedImageFromRequestBody();
                
                // Rotate and/or flip an existing image
                var rotateFlipImage = new RotateFlipImage(api);
                rotateFlipImage.RotateFlipImageFromStorage();
                rotateFlipImage.RotateFlipImageAndUploadToStorage();
                rotateFlipImage.CreateRotateFlippedImageFromRequestBody();

                // Update parameters of existing PSD image
                var updatePsdImage = new UpdatePsdImage(api);
                updatePsdImage.ModifyPsdFromStorage();
                updatePsdImage.ModifyPsdAndUploadToStorage();
                updatePsdImage.CreateModifiedPsdFromRequestBody();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something goes wrong: {ex}");
                Environment.Exit(1);
            }

            Environment.Exit(0);
        }

        /// <summary>
        ///     Prepare output folder.
        /// </summary>
        private static void PrepareOutput()
        {
            if (Directory.Exists(ImagingBase.OutputFolder)) Directory.Delete(ImagingBase.OutputFolder, true);

            Directory.CreateDirectory(ImagingBase.OutputFolder);
        }

        /// <summary>
        ///     Process CLI arguments, exit on invalid input.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        /// <param name="appKey">The app key.</param>
        /// <param name="appSid">The app SID.</param>
        /// <param name="baseUrl">The base URL.</param>
        private static void ProcessArguments(string[] args, out string appKey, out string appSid,
            out string baseUrl)
        {
            var errors = new List<string>(2);

            appKey = ProcessArgument(args, "--appKey", "app key", errors);
            appSid = ProcessArgument(args, "--appSid", "app sid", errors);
            baseUrl = ProcessArgument(args, "--baseUrl", "Base url", errors, "https://api.aspose.cloud/");

            if (!errors.Any()) return;

            Console.WriteLine("Failed to launch examples:" + Environment.NewLine +
                              string.Join(Environment.NewLine, errors));
            Environment.Exit(1);
        }

        /// <summary>
        ///     Retrieves argument value or writes error message.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        /// <param name="key">Argument key.</param>
        /// <param name="description">Argument description (for error message).</param>
        /// <param name="errors">Errors to append to.</param>
        /// <param name="defaultValue">Default value for optional parameter.</param>
        /// <returns>Argument value, if found.</returns>
        private static string ProcessArgument(string[] args, string key, string description, ICollection<string> errors,
            string defaultValue = null)
        {
            var argumentValue = args.FirstOrDefault(p => p.StartsWith(key + "="))?.Split('=').Last();
            if (argumentValue == null)
            {
                var argumentKeyIndex = Array.IndexOf(args, key);
                if (argumentKeyIndex != -1)
                    argumentValue = args.ElementAtOrDefault(argumentKeyIndex + 1);
            }

            if (!string.IsNullOrEmpty(argumentValue)) return argumentValue;

            if (defaultValue == null)
                errors.Add($"Please, provide {description}: \'{key} <value>\' or \'{key}=<value>\'");
            else
                argumentValue = defaultValue;

            return argumentValue;
        }
    }
}