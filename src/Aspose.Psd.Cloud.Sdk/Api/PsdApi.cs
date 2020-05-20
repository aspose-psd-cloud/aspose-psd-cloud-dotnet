// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="PsdApi.cs">
//   Copyright (c) 2018-2020 Aspose Pty Ltd. All rights reserved.
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
using System.Text.RegularExpressions;
using Aspose.Psd.Cloud.Sdk.Client;
using Aspose.Psd.Cloud.Sdk.Client.Internal;
using Aspose.Psd.Cloud.Sdk.Client.Internal.RequestHandlers;
using Aspose.Psd.Cloud.Sdk.Model;
using Aspose.Psd.Cloud.Sdk.Model.Requests;

namespace Aspose.Psd.Cloud.Sdk.Api
{
    /// <summary>
    ///     Aspose.Psd Cloud API.
    /// </summary>
    public class PsdApi
    {
        /// <summary>
        ///     The API invoker
        /// </summary>
        private readonly ApiInvoker _apiInvoker;

        /// <summary>
        ///     The configuration
        /// </summary>
        public readonly Configuration Configuration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PsdApi" /> class for Aspose Cloud-hosted solution usage.
        /// </summary>
        /// <param name="appKey">
        ///     The app key.
        /// </param>
        /// <param name="appSid">
        ///     The app SID.
        /// </param>
        /// <param name="baseUrl">
        ///     The base URL. Use <see cref="Configuration.DefaultBaseUrl" /> to set the default base URL.
        /// </param>
        /// <param name="apiVersion">
        ///     The API version.
        /// </param>
        /// <param name="debug">
        ///     If debug mode is enabled.
        /// </param>
        public PsdApi(string appKey, string appSid, string baseUrl = Configuration.DefaultBaseUrl,
            string apiVersion = Configuration.DefaultApiVersion, bool debug = false)
            : this(new Configuration
            {
                AppKey = appKey,
                AppSid = appSid,
                ApiBaseUrl = baseUrl,
                ApiVersion = apiVersion,
                DebugMode = debug,
                OnPremise = false
            })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PsdApi" /> class for on-premise solution with metered license usage.
        /// </summary>
        /// <param name="baseUrl">
        ///     The base URL of your server.
        /// </param>
        /// <param name="apiVersion">
        ///     The API version.
        /// </param>
        /// <param name="debug">
        ///     If debug mode is enabled.
        /// </param>
        public PsdApi(string baseUrl, string apiVersion = Configuration.DefaultApiVersion, bool debug = false)
            : this(new Configuration
            {
                ApiBaseUrl = baseUrl,
                ApiVersion = apiVersion,
                DebugMode = debug,
                OnPremise = true
            })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PsdApi" /> class.
        /// </summary>
        /// <param name="configuration">Configuration settings</param>
        private PsdApi(Configuration configuration)
        {
            Configuration = configuration;
            var requestHandlers = new List<IRequestHandler>();
            if (!configuration.OnPremise) requestHandlers.Add(new AuthRequestHandler(Configuration));

            requestHandlers.Add(new DebugLogRequestHandler(Configuration));
            requestHandlers.Add(new ApiExceptionRequestHandler());
            _apiInvoker = new ApiInvoker(requestHandlers, Configuration);
        }

        /// <summary>
        ///     Copy file
        /// </summary>
        /// <param name="request">Specific request.<see cref="CopyFileRequest" /></param>
        public void CopyFile(CopyFileRequest request)
        {
            // verify the required parameter 'srcPath' is set
            if (request.SrcPath == null)
                throw new ApiException(400, "Missing required parameter 'srcPath' when calling CopyFile");

            // verify the required parameter 'destPath' is set
            if (request.DestPath == null)
                throw new ApiException(400, "Missing required parameter 'destPath' when calling CopyFile");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/file/copy/{srcPath}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "srcPath", request.SrcPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destPath", request.DestPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "srcStorageName", request.SrcStorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorageName", request.DestStorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.VersionId);

            _apiInvoker.InvokeApi(
                resourcePath,
                "PUT",
                null,
                null,
                formParams);
        }

        /// <summary>
        ///     Copy folder
        /// </summary>
        /// <param name="request">Specific request.<see cref="CopyFolderRequest" /></param>
        public void CopyFolder(CopyFolderRequest request)
        {
            // verify the required parameter 'srcPath' is set
            if (request.SrcPath == null)
                throw new ApiException(400, "Missing required parameter 'srcPath' when calling CopyFolder");

            // verify the required parameter 'destPath' is set
            if (request.DestPath == null)
                throw new ApiException(400, "Missing required parameter 'destPath' when calling CopyFolder");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/folder/copy/{srcPath}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "srcPath", request.SrcPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destPath", request.DestPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "srcStorageName", request.SrcStorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorageName", request.DestStorageName);

            _apiInvoker.InvokeApi(
                resourcePath,
                "PUT",
                null,
                null,
                formParams);
        }

        /// <summary>
        ///     Crop an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateCroppedImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CreateCroppedImage(CreateCroppedImageRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400, "Missing required parameter 'imageData' when calling CreateCroppedImage");

            // verify the required parameter 'x' is set
            if (request.X == null)
                throw new ApiException(400, "Missing required parameter 'x' when calling CreateCroppedImage");

            // verify the required parameter 'y' is set
            if (request.Y == null)
                throw new ApiException(400, "Missing required parameter 'y' when calling CreateCroppedImage");

            // verify the required parameter 'width' is set
            if (request.Width == null)
                throw new ApiException(400, "Missing required parameter 'width' when calling CreateCroppedImage");

            // verify the required parameter 'height' is set
            if (request.Height == null)
                throw new ApiException(400, "Missing required parameter 'height' when calling CreateCroppedImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/crop";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "x", request.X);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "y", request.Y);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "width", request.Width);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "height", request.Height);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "outPath", request.OutPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Deskew an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateDeskewedImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CreateDeskewedImage(CreateDeskewedImageRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400, "Missing required parameter 'imageData' when calling CreateDeskewedImage");

            // verify the required parameter 'resizeProportionally' is set
            if (request.ResizeProportionally == null)
                throw new ApiException(400,
                    "Missing required parameter 'resizeProportionally' when calling CreateDeskewedImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/deskew";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath =
                UrlHelper.AddQueryParameterToUrl(resourcePath, "resizeProportionally", request.ResizeProportionally);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "bkColor", request.BkColor);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "outPath", request.OutPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Create the folder
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateFolderRequest" /></param>
        public void CreateFolder(CreateFolderRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling CreateFolder");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/folder/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);

            _apiInvoker.InvokeApi(
                resourcePath,
                "PUT",
                null,
                null,
                formParams);
        }

        /// <summary>
        ///     Grayscales an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateGrayscaledImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CreateGrayscaledImage(CreateGrayscaledImageRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400,
                    "Missing required parameter 'imageData' when calling CreateGrayscaledImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/grayscale";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "outPath", request.OutPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Update parameters of PSD image. Image data is passed as zero-indexed multipart/form-data content or as raw body
        ///     stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateModifiedPsdRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CreateModifiedPsd(CreateModifiedPsdRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400, "Missing required parameter 'imageData' when calling CreateModifiedPsd");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/psd";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "channelsCount", request.ChannelsCount);
            resourcePath =
                UrlHelper.AddQueryParameterToUrl(resourcePath, "compressionMethod", request.CompressionMethod);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "fromScratch", request.FromScratch);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "outPath", request.OutPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Resize an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateResizedImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CreateResizedImage(CreateResizedImageRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400, "Missing required parameter 'imageData' when calling CreateResizedImage");

            // verify the required parameter 'newWidth' is set
            if (request.NewWidth == null)
                throw new ApiException(400, "Missing required parameter 'newWidth' when calling CreateResizedImage");

            // verify the required parameter 'newHeight' is set
            if (request.NewHeight == null)
                throw new ApiException(400, "Missing required parameter 'newHeight' when calling CreateResizedImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/resize";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newWidth", request.NewWidth);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newHeight", request.NewHeight);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "outPath", request.OutPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Rotate and/or flip an image. Image data is passed as zero-indexed multipart/form-data content or as raw body
        ///     stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateRotateFlippedImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CreateRotateFlippedImage(CreateRotateFlippedImageRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400,
                    "Missing required parameter 'imageData' when calling CreateRotateFlippedImage");

            // verify the required parameter 'method' is set
            if (request.Method == null)
                throw new ApiException(400,
                    "Missing required parameter 'method' when calling CreateRotateFlippedImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/rotateflip";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "method", request.Method);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "outPath", request.OutPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Export existing image to another format. Image data is passed as zero-indexed multipart/form-data content or as raw
        ///     body stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateSavedImageAsRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CreateSavedImageAs(CreateSavedImageAsRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400, "Missing required parameter 'imageData' when calling CreateSavedImageAs");

            // verify the required parameter 'format' is set
            if (request.Format == null)
                throw new ApiException(400, "Missing required parameter 'format' when calling CreateSavedImageAs");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/saveAs";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "outPath", request.OutPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Perform scaling, cropping and flipping of an image in a single request. Image data is passed as zero-indexed
        ///     multipart/form-data content or as raw body stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CreateUpdatedImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CreateUpdatedImage(CreateUpdatedImageRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400, "Missing required parameter 'imageData' when calling CreateUpdatedImage");

            // verify the required parameter 'newWidth' is set
            if (request.NewWidth == null)
                throw new ApiException(400, "Missing required parameter 'newWidth' when calling CreateUpdatedImage");

            // verify the required parameter 'newHeight' is set
            if (request.NewHeight == null)
                throw new ApiException(400, "Missing required parameter 'newHeight' when calling CreateUpdatedImage");

            // verify the required parameter 'x' is set
            if (request.X == null)
                throw new ApiException(400, "Missing required parameter 'x' when calling CreateUpdatedImage");

            // verify the required parameter 'y' is set
            if (request.Y == null)
                throw new ApiException(400, "Missing required parameter 'y' when calling CreateUpdatedImage");

            // verify the required parameter 'rectWidth' is set
            if (request.RectWidth == null)
                throw new ApiException(400, "Missing required parameter 'rectWidth' when calling CreateUpdatedImage");

            // verify the required parameter 'rectHeight' is set
            if (request.RectHeight == null)
                throw new ApiException(400, "Missing required parameter 'rectHeight' when calling CreateUpdatedImage");

            // verify the required parameter 'rotateFlipMethod' is set
            if (request.RotateFlipMethod == null)
                throw new ApiException(400,
                    "Missing required parameter 'rotateFlipMethod' when calling CreateUpdatedImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/updateImage";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newWidth", request.NewWidth);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newHeight", request.NewHeight);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "x", request.X);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "y", request.Y);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "rectWidth", request.RectWidth);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "rectHeight", request.RectHeight);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "rotateFlipMethod", request.RotateFlipMethod);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "outPath", request.OutPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Crop an existing image.
        /// </summary>
        /// <param name="request">Specific request.<see cref="CropImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream CropImage(CropImageRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling CropImage");

            // verify the required parameter 'x' is set
            if (request.X == null) throw new ApiException(400, "Missing required parameter 'x' when calling CropImage");

            // verify the required parameter 'y' is set
            if (request.Y == null) throw new ApiException(400, "Missing required parameter 'y' when calling CropImage");

            // verify the required parameter 'width' is set
            if (request.Width == null)
                throw new ApiException(400, "Missing required parameter 'width' when calling CropImage");

            // verify the required parameter 'height' is set
            if (request.Height == null)
                throw new ApiException(400, "Missing required parameter 'height' when calling CropImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/crop";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "x", request.X);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "y", request.Y);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "width", request.Width);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "height", request.Height);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Delete file
        /// </summary>
        /// <param name="request">Specific request.<see cref="DeleteFileRequest" /></param>
        public void DeleteFile(DeleteFileRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling DeleteFile");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/file/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.VersionId);

            _apiInvoker.InvokeApi(
                resourcePath,
                "DELETE",
                null,
                null,
                formParams);
        }

        /// <summary>
        ///     Delete folder
        /// </summary>
        /// <param name="request">Specific request.<see cref="DeleteFolderRequest" /></param>
        public void DeleteFolder(DeleteFolderRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling DeleteFolder");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/folder/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "recursive", request.Recursive);

            _apiInvoker.InvokeApi(
                resourcePath,
                "DELETE",
                null,
                null,
                formParams);
        }

        /// <summary>
        ///     Deskew an existing image.
        /// </summary>
        /// <param name="request">Specific request.<see cref="DeskewImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream DeskewImage(DeskewImageRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling DeskewImage");

            // verify the required parameter 'resizeProportionally' is set
            if (request.ResizeProportionally == null)
                throw new ApiException(400,
                    "Missing required parameter 'resizeProportionally' when calling DeskewImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/deskew";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath =
                UrlHelper.AddQueryParameterToUrl(resourcePath, "resizeProportionally", request.ResizeProportionally);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "bkColor", request.BkColor);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Download file
        /// </summary>
        /// <param name="request">Specific request.<see cref="DownloadFileRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream DownloadFile(DownloadFileRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling DownloadFile");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/file/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.VersionId);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Get properties of an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
        /// </summary>
        /// <param name="request">Specific request.<see cref="ExtractImagePropertiesRequest" /></param>
        /// <returns>
        ///     <see cref="PsdResponse" />
        /// </returns>
        public PsdResponse ExtractImageProperties(ExtractImagePropertiesRequest request)
        {
            // verify the required parameter 'imageData' is set
            if (request.ImageData == null)
                throw new ApiException(400,
                    "Missing required parameter 'imageData' when calling ExtractImageProperties");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/properties";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();

            if (request.ImageData != null)
                formParams.Add("imageData", _apiInvoker.ToFileInfo(request.ImageData, "imageData"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "POST",
                null,
                null,
                formParams);

            if (response == null) return null;

            return (PsdResponse) SerializationHelper.Deserialize<PsdResponse>(StreamHelper.ToString(response));
        }

        /// <summary>
        ///     Apply filtering effects to an existing image.
        /// </summary>
        /// <param name="request">Specific request.<see cref="FilterEffectImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream FilterEffectImage(FilterEffectImageRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling FilterEffectImage");

            // verify the required parameter 'filterType' is set
            if (request.FilterType == null)
                throw new ApiException(400, "Missing required parameter 'filterType' when calling FilterEffectImage");

            // verify the required parameter 'filterProperties' is set
            if (request.FilterProperties == null)
                throw new ApiException(400,
                    "Missing required parameter 'filterProperties' when calling FilterEffectImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/filterEffect";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "filterType", request.FilterType);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);
            var postBody = SerializationHelper.Serialize(request.FilterProperties);
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "PUT",
                postBody,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Get disc usage
        /// </summary>
        /// <param name="request">Specific request.<see cref="GetDiscUsageRequest" /></param>
        /// <returns>
        ///     <see cref="DiscUsage" />
        /// </returns>
        public DiscUsage GetDiscUsage(GetDiscUsageRequest request)
        {
            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/disc";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);

            if (response == null) return null;

            return (DiscUsage) SerializationHelper.Deserialize<DiscUsage>(StreamHelper.ToString(response));
        }

        /// <summary>
        ///     Get file versions
        /// </summary>
        /// <param name="request">Specific request.<see cref="GetFileVersionsRequest" /></param>
        /// <returns>
        ///     <see cref="FileVersions" />
        /// </returns>
        public FileVersions GetFileVersions(GetFileVersionsRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling GetFileVersions");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/version/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);

            if (response == null) return null;

            return (FileVersions) SerializationHelper.Deserialize<FileVersions>(StreamHelper.ToString(response));
        }

        /// <summary>
        ///     Get all files and folders within a folder
        /// </summary>
        /// <param name="request">Specific request.<see cref="GetFilesListRequest" /></param>
        /// <returns>
        ///     <see cref="FilesList" />
        /// </returns>
        public FilesList GetFilesList(GetFilesListRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling GetFilesList");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/folder/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);

            if (response == null) return null;

            return (FilesList) SerializationHelper.Deserialize<FilesList>(StreamHelper.ToString(response));
        }

        /// <summary>
        ///     Get properties of an image.
        /// </summary>
        /// <param name="request">Specific request.<see cref="GetImagePropertiesRequest" /></param>
        /// <returns>
        ///     <see cref="PsdResponse" />
        /// </returns>
        public PsdResponse GetImageProperties(GetImagePropertiesRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling GetImageProperties");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/properties";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);

            if (response == null) return null;

            return (PsdResponse) SerializationHelper.Deserialize<PsdResponse>(StreamHelper.ToString(response));
        }

        /// <summary>
        ///     Grayscale an existing image.
        /// </summary>
        /// <param name="request">Specific request.<see cref="GrayscaleImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream GrayscaleImage(GrayscaleImageRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling GrayscaleImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/grayscale";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Update parameters of existing PSD image.
        /// </summary>
        /// <param name="request">Specific request.<see cref="ModifyPsdRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream ModifyPsd(ModifyPsdRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling ModifyPsd");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/psd";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "channelsCount", request.ChannelsCount);
            resourcePath =
                UrlHelper.AddQueryParameterToUrl(resourcePath, "compressionMethod", request.CompressionMethod);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "fromScratch", request.FromScratch);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Move file
        /// </summary>
        /// <param name="request">Specific request.<see cref="MoveFileRequest" /></param>
        public void MoveFile(MoveFileRequest request)
        {
            // verify the required parameter 'srcPath' is set
            if (request.SrcPath == null)
                throw new ApiException(400, "Missing required parameter 'srcPath' when calling MoveFile");

            // verify the required parameter 'destPath' is set
            if (request.DestPath == null)
                throw new ApiException(400, "Missing required parameter 'destPath' when calling MoveFile");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/file/move/{srcPath}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "srcPath", request.SrcPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destPath", request.DestPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "srcStorageName", request.SrcStorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorageName", request.DestStorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.VersionId);

            _apiInvoker.InvokeApi(
                resourcePath,
                "PUT",
                null,
                null,
                formParams);
        }

        /// <summary>
        ///     Move folder
        /// </summary>
        /// <param name="request">Specific request.<see cref="MoveFolderRequest" /></param>
        public void MoveFolder(MoveFolderRequest request)
        {
            // verify the required parameter 'srcPath' is set
            if (request.SrcPath == null)
                throw new ApiException(400, "Missing required parameter 'srcPath' when calling MoveFolder");

            // verify the required parameter 'destPath' is set
            if (request.DestPath == null)
                throw new ApiException(400, "Missing required parameter 'destPath' when calling MoveFolder");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/folder/move/{srcPath}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "srcPath", request.SrcPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destPath", request.DestPath);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "srcStorageName", request.SrcStorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorageName", request.DestStorageName);

            _apiInvoker.InvokeApi(
                resourcePath,
                "PUT",
                null,
                null,
                formParams);
        }

        /// <summary>
        ///     Check if file or folder exists
        /// </summary>
        /// <param name="request">Specific request.<see cref="ObjectExistsRequest" /></param>
        /// <returns>
        ///     <see cref="ObjectExist" />
        /// </returns>
        public ObjectExist ObjectExists(ObjectExistsRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling ObjectExists");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/exist/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.VersionId);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);

            if (response == null) return null;

            return (ObjectExist) SerializationHelper.Deserialize<ObjectExist>(StreamHelper.ToString(response));
        }

        /// <summary>
        ///     Resize an existing image.
        /// </summary>
        /// <param name="request">Specific request.<see cref="ResizeImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream ResizeImage(ResizeImageRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling ResizeImage");

            // verify the required parameter 'newWidth' is set
            if (request.NewWidth == null)
                throw new ApiException(400, "Missing required parameter 'newWidth' when calling ResizeImage");

            // verify the required parameter 'newHeight' is set
            if (request.NewHeight == null)
                throw new ApiException(400, "Missing required parameter 'newHeight' when calling ResizeImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/resize";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newWidth", request.NewWidth);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newHeight", request.NewHeight);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Rotate and/or flip an existing image.
        /// </summary>
        /// <param name="request">Specific request.<see cref="RotateFlipImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream RotateFlipImage(RotateFlipImageRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling RotateFlipImage");

            // verify the required parameter 'method' is set
            if (request.Method == null)
                throw new ApiException(400, "Missing required parameter 'method' when calling RotateFlipImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/rotateflip";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "method", request.Method);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Export existing image to another format.
        /// </summary>
        /// <param name="request">Specific request.<see cref="SaveImageAsRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream SaveImageAs(SaveImageAsRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling SaveImageAs");

            // verify the required parameter 'format' is set
            if (request.Format == null)
                throw new ApiException(400, "Missing required parameter 'format' when calling SaveImageAs");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/saveAs";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Check if storage exists
        /// </summary>
        /// <param name="request">Specific request.<see cref="StorageExistsRequest" /></param>
        /// <returns>
        ///     <see cref="StorageExist" />
        /// </returns>
        public StorageExist StorageExists(StorageExistsRequest request)
        {
            // verify the required parameter 'storageName' is set
            if (request.StorageName == null)
                throw new ApiException(400, "Missing required parameter 'storageName' when calling StorageExists");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/{storageName}/exist";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "storageName", request.StorageName);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);

            if (response == null) return null;

            return (StorageExist) SerializationHelper.Deserialize<StorageExist>(StreamHelper.ToString(response));
        }

        /// <summary>
        ///     Perform scaling, cropping and flipping of an existing image in a single request.
        /// </summary>
        /// <param name="request">Specific request.<see cref="UpdateImageRequest" /></param>
        /// <returns>
        ///     <see cref="System.IO.Stream" />
        /// </returns>
        public Stream UpdateImage(UpdateImageRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.Name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling UpdateImage");

            // verify the required parameter 'newWidth' is set
            if (request.NewWidth == null)
                throw new ApiException(400, "Missing required parameter 'newWidth' when calling UpdateImage");

            // verify the required parameter 'newHeight' is set
            if (request.NewHeight == null)
                throw new ApiException(400, "Missing required parameter 'newHeight' when calling UpdateImage");

            // verify the required parameter 'x' is set
            if (request.X == null)
                throw new ApiException(400, "Missing required parameter 'x' when calling UpdateImage");

            // verify the required parameter 'y' is set
            if (request.Y == null)
                throw new ApiException(400, "Missing required parameter 'y' when calling UpdateImage");

            // verify the required parameter 'rectWidth' is set
            if (request.RectWidth == null)
                throw new ApiException(400, "Missing required parameter 'rectWidth' when calling UpdateImage");

            // verify the required parameter 'rectHeight' is set
            if (request.RectHeight == null)
                throw new ApiException(400, "Missing required parameter 'rectHeight' when calling UpdateImage");

            // verify the required parameter 'rotateFlipMethod' is set
            if (request.RotateFlipMethod == null)
                throw new ApiException(400, "Missing required parameter 'rotateFlipMethod' when calling UpdateImage");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/{name}/updateImage";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.Name);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newWidth", request.NewWidth);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newHeight", request.NewHeight);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "x", request.X);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "y", request.Y);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "rectWidth", request.RectWidth);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "rectHeight", request.RectHeight);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "rotateFlipMethod", request.RotateFlipMethod);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "format", request.Format);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "folder", request.Folder);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.Storage);

            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "GET",
                null,
                null,
                formParams);
            return response;
        }

        /// <summary>
        ///     Upload file
        /// </summary>
        /// <param name="request">Specific request.<see cref="UploadFileRequest" /></param>
        /// <returns>
        ///     <see cref="FilesUploadResult" />
        /// </returns>
        public FilesUploadResult UploadFile(UploadFileRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
                throw new ApiException(400, "Missing required parameter 'path' when calling UploadFile");

            // verify the required parameter 'file' is set
            if (request.File == null)
                throw new ApiException(400, "Missing required parameter 'file' when calling UploadFile");

            // create path and map variables
            var resourcePath = Configuration.GetApiRootUrl() + "/psd/storage/file/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);

            if (request.File != null) formParams.Add("file", _apiInvoker.ToFileInfo(request.File, "File"));
            var response = _apiInvoker.InvokeApi(
                resourcePath,
                "PUT",
                null,
                null,
                formParams);

            if (response == null) return null;

            return (FilesUploadResult) SerializationHelper.Deserialize<FilesUploadResult>(
                StreamHelper.ToString(response));
        }
    }
}