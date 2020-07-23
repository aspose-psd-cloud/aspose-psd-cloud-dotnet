// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiTester.cs">
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
using System.Reflection;
using Aspose.Psd.Cloud.Sdk.Api;
using Aspose.Psd.Cloud.Sdk.Model;
using Aspose.Psd.Cloud.Sdk.Model.Requests;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Aspose.Psd.Cloud.Sdk.Test.Base
{
    /// <summary>
    ///     Base class for API tester
    /// </summary>
    public abstract class ApiTester
    {
        /// <summary>
        ///     The server access file
        /// </summary>
        private const string ServerAccessFile = "serverAccess.json";

        /// <summary>
        ///     The API version
        /// </summary>
        private const string ApiVersion = "v1.0";

        /// <summary>
        ///     The base URL
        /// </summary>
        private const string BaseUrl = "http://api.aspose.cloud/";

        /// <summary>
        ///     The default storage
        /// </summary>
        protected const string DefaultStorage = "Local-CI-Linux";

        /// <summary>
        ///     If any test failed
        /// </summary>
        protected static bool FailedAnyTest;

        /// <summary>
        ///     The basic export formats
        /// </summary>
        protected readonly string[] BasicExportFormats =
        {
            "bmp",
            "gif",
            "jpg",
            "png",
            "psd",
            "tiff"
        };

        /// <summary>
        ///     The local test folder
        /// </summary>
        protected readonly string LocalTestFolder =
            Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))))),
                "TestData"));

        /// <summary>
        ///     The input test files
        /// </summary>
        protected List<StorageFile> InputTestFiles;

        /// <summary>
        ///     Aspose.Psd API
        /// </summary>
        protected PsdApi PsdApi;

        /// <summary>
        ///     The temporary folder
        /// </summary>
        protected string TempFolder;

        /// <summary>
        ///     The cloud test folder prefix
        /// </summary>
        protected virtual string CloudTestFolderPrefix => "PsdCloudTestDotNet";

        /// <summary>
        ///     Original test data folder
        /// </summary>
        protected virtual string OriginalDataFolder => "PsdIntegrationTestData";

        /// <summary>
        ///     The default storage
        /// </summary>
        protected string TestStorage { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether resulting images should be removed from cloud storage.
        /// </summary>
        /// <value>
        ///     <c>true</c> if resulting images should be removed from cloud storage; otherwise, <c>false</c>.
        /// </value>
        private bool RemoveResult { get; } = true;

        [OneTimeSetUp]
        public virtual void InitFixture()
        {
            TempFolder = $"{CloudTestFolderPrefix}_{GetEnvironmentVariable("BUILD_NUMBER") ?? Environment.UserName}";

            TestStorage = GetEnvironmentVariable("StorageName");

            if (string.IsNullOrEmpty(TestStorage))
            {
                WriteLineEverywhere("Storage name is not set by environment variable. Using the default one.");
                TestStorage = DefaultStorage;
            }

            CreateApiInstances();
            if (FailedAnyTest || !RemoveResult ||
                !PsdApi.ObjectExists(new ObjectExistsRequest(TempFolder, TestStorage)).Exists
                    .GetValueOrDefault(false)) return;

            PsdApi.DeleteFolder(new DeleteFolderRequest(TempFolder, TestStorage, true));
            PsdApi.CreateFolder(new CreateFolderRequest(TempFolder, TestStorage));
        }

        [OneTimeTearDown]
        public virtual void FinalizeFixture()
        {
            if (!FailedAnyTest && RemoveResult &&
                PsdApi.ObjectExists(new ObjectExistsRequest(TempFolder, TestStorage)).Exists.GetValueOrDefault(false))
                PsdApi.DeleteFolder(new DeleteFolderRequest(TempFolder, TestStorage, true));
        }

        /// <summary>
        ///     Creates the API instances using given access parameters.
        /// </summary>
        /// <exception cref="System.ArgumentException">Please, specify valid access data (AppKey, AppSid, Base URL)</exception>
        private void CreateApiInstances()
        {
            WriteLineEverywhere("Trying to obtain configuration from environment variables.");
            var onPremiseString = GetEnvironmentVariable("OnPremise");
            var onPremise = !string.IsNullOrEmpty(onPremiseString) &&
                            bool.Parse(GetEnvironmentVariable("OnPremise"));
            var appKey = onPremise ? string.Empty : GetEnvironmentVariable("AppKey");
            var appSid = onPremise ? string.Empty : GetEnvironmentVariable("AppSid");
            var baseUrl = GetEnvironmentVariable("ApiEndpoint");
            var apiVersion = GetEnvironmentVariable("ApiVersion");

            if (!onPremise && (string.IsNullOrEmpty(appKey) || string.IsNullOrEmpty(appSid))
                || string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(apiVersion))
                WriteLineEverywhere("Access data isn't set completely by environment variables. " +
                                    "Filling unset data with default values.");

            if (string.IsNullOrEmpty(apiVersion))
            {
                apiVersion = ApiVersion;
                WriteLineEverywhere("Set default API version");
            }

            var serverAccessPath = Path.Combine(LocalTestFolder, ServerAccessFile);
            var serverFileInfo = new FileInfo(serverAccessPath);

            if (serverFileInfo.Exists && serverFileInfo.Length > 0)
            {
                var accessData = JsonConvert.DeserializeObject<ServerAccessData>(File.ReadAllText(serverAccessPath));
                if (string.IsNullOrEmpty(appKey) && !onPremise)
                {
                    appKey = accessData.AppKey;
                    WriteLineEverywhere("Set default App key");
                }

                if (string.IsNullOrEmpty(appSid) && !onPremise)
                {
                    appSid = accessData.AppSid;
                    WriteLineEverywhere("Set default App SID");
                }

                if (string.IsNullOrEmpty(baseUrl))
                {
                    baseUrl = accessData.BaseURL;
                    WriteLineEverywhere("Set default base URL");
                }
            }
            else if (!onPremise)
            {
                throw new ArgumentException("Please, specify valid access data (AppKey, AppSid, Base URL)");
            }

            WriteLineEverywhere($"On-premise: {onPremise}");
            WriteLineEverywhere($"App key: {appKey}");
            WriteLineEverywhere($"App SID: {appSid}");
            WriteLineEverywhere($"Storage: {TestStorage}");
            WriteLineEverywhere($"Base URL: {baseUrl}");
            WriteLineEverywhere($"API version: {apiVersion}");
            PsdApi = onPremise
                ? new PsdApi(baseUrl, apiVersion, false)
                : new PsdApi(appKey, appSid, baseUrl, apiVersion);

            InputTestFiles = FetchInputTestFilesInfo();
        }

        /// <summary>
        ///     Tests the typical GET request.
        /// </summary>
        /// <param name="testMethodName">Name of the test method.</param>
        /// <param name="parametersLine">The parameters line.</param>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="requestInvoker">The request invoker.</param>
        /// <param name="propertiesTester">The properties tester.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="storage">The storage.</param>
        protected void TestGetRequest(string testMethodName, string parametersLine,
            string inputFileName,
#if NET20
            Newtonsoft.Json.Serialization.Func<Stream> requestInvoker,
#else
            Func<Stream> requestInvoker,
#endif
            PropertiesTesterDelegate propertiesTester, string folder, string storage = DefaultStorage)
        {
            TestRequest(testMethodName, false, parametersLine, inputFileName, null,
                () => ObtainGetResponse(requestInvoker),
                propertiesTester, folder, storage);
        }

        /// <summary>
        ///     Tests the typical PUT request.
        /// </summary>
        /// <param name="testMethodName">Name of the test method.</param>
        /// <param name="parametersLine">The parameters line.</param>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="requestInvoker">The request invoker.</param>
        /// <param name="propertiesTester">The properties tester.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="storage">The storage.</param>
        protected void TestPutRequest(string testMethodName, string parametersLine,
            string inputFileName,
#if NET20
            Newtonsoft.Json.Serialization.Func<Stream> requestInvoker,
#else
            Func<Stream> requestInvoker,
#endif
            PropertiesTesterDelegate propertiesTester, string folder, string storage = DefaultStorage)
        {
            TestRequest(testMethodName, false, parametersLine, inputFileName, null,
                () => ObtainPutResponse(requestInvoker),
                propertiesTester, folder, storage);
        }

        /// <summary>
        ///     Tests the typical POST request.
        /// </summary>
        /// <param name="testMethodName">Name of the test method.</param>
        /// <param name="saveResultToStorage">if set to <c>true</c> [save result to storage].</param>
        /// <param name="parametersLine">The parameters line.</param>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="resultFileName">Name of the result file.</param>
        /// <param name="requestInvoker">The request invoker.</param>
        /// <param name="propertiesTester">The properties tester.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="storage">The storage.</param>
        protected void TestPostRequest(string testMethodName, bool saveResultToStorage, string parametersLine,
            string inputFileName,
            string resultFileName, PostRequestInvokerDelegate requestInvoker, PropertiesTesterDelegate propertiesTester,
            string folder, string storage = DefaultStorage)
        {
            TestRequest(testMethodName, saveResultToStorage, parametersLine, inputFileName, resultFileName,
                () => ObtainPostResponse(folder + "/" + inputFileName,
                    saveResultToStorage ? $"{folder}/{resultFileName}" : null, storage, requestInvoker),
                propertiesTester, folder, storage);
        }

        /// <summary>
        ///     Checks if input file exists.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <returns></returns>
        private bool CheckInputFileExists(string inputFileName)
        {
            return InputTestFiles.Any(storageFileInfo => storageFileInfo.Name == inputFileName);
        }

        /// <summary>
        ///     Gets the storage file information.
        /// </summary>
        /// <param name="folder">The folder which contains a file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="storage">The storage.</param>
        /// <returns></returns>
        private StorageFile GetStorageFileInfo(string folder, string fileName,
            string storage)
        {
            var fileListResponse = PsdApi.GetFilesList(new GetFilesListRequest(folder, storage));

            return fileListResponse.Value.FirstOrDefault(storageFileInfo => storageFileInfo.Name == fileName);
        }

        /// <summary>
        ///     Fetches the input test files info.
        /// </summary>
        /// <returns></returns>
        private List<StorageFile> FetchInputTestFilesInfo()
        {
            var filesResponse = PsdApi.GetFilesList(
                new GetFilesListRequest(OriginalDataFolder, TestStorage));
            return filesResponse.Value.Where(p => !p.Name.StartsWith("multipage_") && p.Name.EndsWith("psd")).ToList();
        }

        /// <summary>
        ///     Obtains the typical GET request response.
        /// </summary>
        /// <param name="requestInvoker">The request invoker.</param>
        private Stream ObtainGetResponse(
#if NET20
            Newtonsoft.Json.Serialization.Func<Stream> requestInvoker
#else
            Func<Stream> requestInvoker
#endif
        )
        {
            var response = requestInvoker.Invoke();
            Assert.NotNull(response);
            Assert.Greater(response.Length, 0);
            return response;
        }

        /// <summary>
        ///     Obtains the typical PUT request response.
        /// </summary>
        /// <param name="requestInvoker">The request invoker.</param>
        private Stream ObtainPutResponse(
#if NET20
            Newtonsoft.Json.Serialization.Func<Stream> requestInvoker
#else
            Func<Stream> requestInvoker
#endif
        )
        {
            var response = requestInvoker.Invoke();
            Assert.NotNull(response);
            Assert.Greater(response.Length, 0);
            return response;
        }

        /// <summary>
        ///     Obtains the typical POST request response.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="requestInvoker">The request invoker.</param>
        /// <param name="outPath">The output path to save the result.</param>
        /// <param name="storage">The storage.</param>
        private Stream ObtainPostResponse(string inputPath, string outPath, string storage,
            PostRequestInvokerDelegate requestInvoker)
        {
            using (var iStream = PsdApi.DownloadFile(new DownloadFileRequest(inputPath, storage)))
            {
                var response = requestInvoker.Invoke(iStream, outPath);

                if (!string.IsNullOrEmpty(outPath)) return null;

                Assert.NotNull(response);
                Assert.Greater(response.Length, 0);
                return response;
            }
        }

        /// <summary>
        ///     Tests the typical request.
        /// </summary>
        /// <param name="testMethodName">Name of the test method.</param>
        /// <param name="saveResultToStorage">if set to <c>true</c> [save result to storage].</param>
        /// <param name="parametersLine">The parameters line.</param>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="resultFileName">Name of the result file.</param>
        /// <param name="invokeRequestAction">The invoke request action.</param>
        /// <param name="propertiesTester">The properties tester.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="storage">The storage.</param>
        private void TestRequest(string testMethodName, bool saveResultToStorage, string parametersLine,
            string inputFileName,
            string resultFileName,
#if NET20
            Newtonsoft.Json.Serialization.Func<Stream> invokeRequestAction,
#else
            Func<Stream> invokeRequestAction,
#endif
            PropertiesTesterDelegate propertiesTester, string folder, string storage = DefaultStorage)
        {
            WriteLineEverywhere(testMethodName);

            CopyInputFileToTestFolder(inputFileName, folder, storage);

            var passed = false;
            string outPath = null;

            try
            {
                WriteLineEverywhere(parametersLine);

                if (saveResultToStorage)
                {
                    outPath = folder + "/" + resultFileName;

                    // remove output file from the storage (if exists)
                    if (PsdApi.ObjectExists(new ObjectExistsRequest(outPath, storage)).Exists.GetValueOrDefault(false))
                        PsdApi.DeleteFile(new DeleteFileRequest(outPath, storage));
                }

                ImagingResponse resultProperties = null;

                using (var response = invokeRequestAction.Invoke())
                {
                    if (saveResultToStorage)
                    {
                        var resultInfo = GetStorageFileInfo(folder, resultFileName, storage);
                        if (resultInfo == null)
                            throw new ArgumentException(
                                $"Result file {resultFileName} doesn't exist in the specified storage folder: {folder}. " +
                                "Result isn't present in the storage by an unknown reason.");

                        if (!resultFileName.EndsWith(".pdf"))
                        {
                            resultProperties =
                                PsdApi.GetImageProperties(
                                    new GetImagePropertiesRequest(resultFileName, folder, storage));
                            Assert.NotNull(resultProperties);
                        }
                    }
                    else
                    {
                        if (!FileIsPdf(response))
                        {
                            resultProperties =
                                PsdApi.ExtractImageProperties(new ExtractImagePropertiesRequest(response));
                            Assert.NotNull(resultProperties);
                        }
                    }

                    var originalProperties =
                        PsdApi.GetImageProperties(new GetImagePropertiesRequest(inputFileName, folder, storage));
                    Assert.NotNull(originalProperties);

                    if (resultProperties != null)
                        propertiesTester?.Invoke(originalProperties, resultProperties, response);
                }

                passed = true;
            }
            catch (Exception ex)
            {
                FailedAnyTest = true;
                WriteLineEverywhere(ex.Message);
                throw;
            }
            finally
            {
                if (passed && saveResultToStorage && RemoveResult && PsdApi.ObjectExists(
                    new ObjectExistsRequest(outPath, storage)).Exists.GetValueOrDefault(false))
                    PsdApi.DeleteFile(new DeleteFileRequest(outPath, storage));

                WriteLineEverywhere($"Test passed: {passed}");
            }
        }

        /// <summary>
        ///     Copies original input file to test folder
        /// </summary>
        /// <param name="inputFileName">The original input file</param>
        /// <param name="folder">The folder</param>
        /// <param name="storage">The storage</param>
        private void CopyInputFileToTestFolder(string inputFileName, string folder, string storage)
        {
            if (!CheckInputFileExists(inputFileName))
                throw new ArgumentException(
                    $"Input file {inputFileName} doesn't exist in the specified storage folder: {folder}. Please, upload it first.");

            if (!PsdApi.ObjectExists(new ObjectExistsRequest(folder + "/" + inputFileName, storage)).Exists
                .GetValueOrDefault(false))
                PsdApi.CopyFile(
                    new CopyFileRequest(OriginalDataFolder + "/" + inputFileName, folder + "/" + inputFileName, storage,
                        storage));
        }

        /// <summary>
        ///     Writes the line everywhere to support different use-cases.
        /// </summary>
        /// <param name="line">The line.</param>
        private void WriteLineEverywhere(string line)
        {
            Console.WriteLine(line);
            TestContext.WriteLine(line);
            TestContext.Progress.WriteLine(line);
        }

        /// <summary>
        ///     Returns environment variable value
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns>Environment variable value</returns>
        private string GetEnvironmentVariable(string variableName)
        {
            return (Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.Process) ??
                    Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.User))
                   ?? Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.Machine);
        }

        /// <summary>
        ///     Checks that stream represents PDF file
        /// </summary>
        /// <param name="file">The file stream</param>
        /// <returns><c>true</c> - if file is a PDF, <c>false</c> otherwise</returns>
        /// <exception cref="ArgumentNullException"><paramref name="file" /> is null</exception>
        private bool FileIsPdf(Stream file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var buffer = new byte[5];
            var originalPosition = file.Position;

            file.Seek(0, SeekOrigin.Begin);
            file.Read(buffer, 0, 5);
            file.Seek(originalPosition, SeekOrigin.Begin);

            // That's the direct magic bytes check
            return buffer[0] == 0x25 && buffer[1] == 0x50 && buffer[2] == 0x44 && buffer[3] == 0x46 &&
                   buffer[4] == 0x2d;
        }

        /// <summary>
        ///     Delegate that tests properties.
        /// </summary>
        /// <param name="originalProperties">The original properties.</param>
        /// <param name="resultProperties">The result properties.</param>
        /// <param name="resultStream">The result stream.</param>
        protected delegate void PropertiesTesterDelegate(ImagingResponse originalProperties,
            ImagingResponse resultProperties, Stream resultStream);

        /// <summary>
        ///     Typical POST request delegate that accepts input image stream.
        /// </summary>
        /// <param name="inputStream">The input image stream.</param>
        /// <returns></returns>
        protected delegate Stream PostRequestInvokerDelegate(Stream inputStream, string outPath);
    }
}