// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="FileApiTests.cs">
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
using Aspose.Psd.Cloud.Sdk.Model.Requests;
using NUnit.Framework;

namespace Aspose.Psd.Cloud.Sdk.Test.Api.Storage
{
    /// <summary>
    ///     Specific file API tests for Storage.
    /// </summary>
    /// <seealso cref="StorageApiTester" />
    [Category("File")]
    public class FileApiTests : StorageApiTester
    {
        [Test]
        public void CopyDownloadFileTest()
        {
            var folder = $"{TempFolder}/Storage";
            var file = "Storage.txt";
            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file}", $"{folder}/{file}", TestStorage, TestStorage));
                var existResponse = PsdApi.ObjectExists(
                    new ObjectExistsRequest($"{folder}/{file}", TestStorage));
                Assert.NotNull(existResponse);
                Assert.IsFalse(existResponse.IsFolder.Value);
                Assert.IsTrue(existResponse.Exists.Value);

                var originalFileInfo =
                    PsdApi.GetFilesList(new GetFilesListRequest(OriginalDataFolder, TestStorage)).Value
                        .Find(f => f.Name == file);
                var copiedFileInfo =
                    PsdApi.GetFilesList(new GetFilesListRequest(folder, TestStorage)).Value.Find(f => f.Name == file);
                Assert.AreEqual(originalFileInfo.Size, copiedFileInfo.Size);

                using (var originalFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{OriginalDataFolder}/{file}", TestStorage)))
                using (var copiedFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{folder}/{file}", TestStorage)))
                {
                    Assert.AreEqual(originalFile.Length, copiedFile.Length);
                    Assert.AreEqual(originalFile.Length, originalFileInfo.Size);
                    using (var originalReader = new StreamReader(originalFile))
                    using (var copiedReader = new StreamReader(copiedFile))
                    {
                        var originalString = originalReader.ReadToEnd();
                        var copiedString = copiedReader.ReadToEnd();
                        Assert.AreEqual(originalString, copiedString);
                        Assert.AreEqual(originalString, originalFileInfo.Path.Trim('/'));
                        Assert.AreEqual(originalString.Replace(OriginalDataFolder, folder),
                            copiedFileInfo.Path.Trim('/'));
                    }
                }
            }
            finally
            {
                PsdApi.DeleteFile(new DeleteFileRequest($"{folder}/{file}", TestStorage));
                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest($"{folder}/{file}", TestStorage)).Exists.Value);

                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);
            }
        }

        [Test]
        public void FileVersionsCopyTest()
        {
            if (PsdApi.Configuration.OnPremise) return;

            var folder = $"{TempFolder}/Storage";
            var file1 = "Storage.txt";
            var file2 = "Folder1/Folder1.txt";

            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file1}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file2}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                var versions =
                    PsdApi.GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}", TestStorage))
                        .Value;
                var recentVersion = versions.Find(v => v.IsLatest.Value);
                var oldVersion = versions.Find(v => !v.IsLatest.Value);

                PsdApi.CopyFile(new CopyFileRequest($"{folder}/{file1}", $"{folder}/{file1}.recent",
                    TestStorage, TestStorage, recentVersion.VersionId));
                var copiedVersions =
                    PsdApi
                        .GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}.recent", TestStorage))
                        .Value;
                Assert.AreEqual(1, copiedVersions.Count);
                Assert.IsTrue(copiedVersions[0].IsLatest.Value);
                Assert.AreEqual(recentVersion.Size, copiedVersions[0].Size);

                PsdApi.CopyFile(new CopyFileRequest($"{folder}/{file1}", $"{folder}/{file1}.old",
                    TestStorage, TestStorage, oldVersion.VersionId));
                copiedVersions =
                    PsdApi
                        .GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}.old", TestStorage))
                        .Value;
                Assert.AreEqual(1, copiedVersions.Count);
                Assert.IsTrue(copiedVersions[0].IsLatest.Value);
                Assert.AreEqual(oldVersion.Size, copiedVersions[0].Size);
            }
            finally
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));
            }
        }

        [Test]
        public void FileVersionsCreateTest()
        {
            if (PsdApi.Configuration.OnPremise) return;

            var folder = $"{TempFolder}/Storage";
            var file1 = "Storage.txt";
            var file2 = "Folder1/Folder1.txt";

            var file1Size = PsdApi.GetFilesList(new GetFilesListRequest($"{OriginalDataFolder}", TestStorage))
                .Value.Find(f => f.Name == file1).Size;
            var file2Size = PsdApi.GetFilesList(new GetFilesListRequest($"{OriginalDataFolder}/Folder1", TestStorage))
                .Value.Find(f => f.Name == "Folder1.txt").Size;

            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file1}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file2}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                var versions =
                    PsdApi.GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}", TestStorage))
                        .Value;
                Assert.AreEqual(2, versions.Count);
                var recentVersion = versions.Find(v => v.IsLatest.Value);
                var oldVersion = versions.Find(v => !v.IsLatest.Value);
                var recentVersionSize = recentVersion.Size;
                var oldVersionSize = oldVersion.Size;
                Assert.AreNotEqual(recentVersionSize, oldVersionSize);
                Assert.AreEqual(oldVersionSize, file1Size);
                Assert.AreEqual(recentVersionSize, file2Size);
            }
            finally
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));
            }
        }

        [Test]
        public void FileVersionsDeleteTest()
        {
            if (PsdApi.Configuration.OnPremise) return;

            var folder = $"{TempFolder}/Storage";
            var file1 = "Storage.txt";
            var file2 = "Folder1/Folder1.txt";

            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file1}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file2}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                var versions =
                    PsdApi.GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}", TestStorage))
                        .Value;
                var recentVersion = versions.Find(v => v.IsLatest.Value);
                var oldVersion = versions.Find(v => !v.IsLatest.Value);
                Assert.IsTrue(PsdApi
                    .ObjectExists(new ObjectExistsRequest($"{folder}/{file1}", TestStorage,
                        recentVersion.VersionId)).Exists.Value);
                Assert.IsTrue(PsdApi
                    .ObjectExists(new ObjectExistsRequest($"{folder}/{file1}", TestStorage,
                        oldVersion.VersionId)).Exists.Value);

                PsdApi.DeleteFile(new DeleteFileRequest($"{folder}/{file1}", TestStorage,
                    recentVersion.VersionId));
                versions =
                    PsdApi.GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}", TestStorage))
                        .Value;
                Assert.IsFalse(PsdApi
                    .ObjectExists(new ObjectExistsRequest($"{folder}/{file1}", TestStorage,
                        recentVersion.VersionId)).Exists.Value);
                Assert.IsTrue(PsdApi
                    .ObjectExists(new ObjectExistsRequest($"{folder}/{file1}", TestStorage,
                        oldVersion.VersionId)).Exists.Value);
                Assert.AreEqual(1, versions.Count);
                Assert.AreEqual(oldVersion.Size, versions[0].Size);

                PsdApi.DeleteFile(new DeleteFileRequest($"{folder}/{file1}", TestStorage,
                    oldVersion.VersionId));
                Assert.IsFalse(PsdApi
                    .ObjectExists(new ObjectExistsRequest($"{folder}/{file1}", TestStorage)).Exists.Value);
            }
            finally
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));
            }
        }

        [Test]
        public void FileVersionsDownloadTest()
        {
            if (PsdApi.Configuration.OnPremise) return;

            var folder = $"{TempFolder}/Storage";
            var file1 = "Storage.txt";
            var file2 = "Folder1/Folder1.txt";

            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file1}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file2}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                var versions =
                    PsdApi.GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}", TestStorage))
                        .Value;
                var recentVersion = versions.Find(v => v.IsLatest.Value);
                var oldVersion = versions.Find(v => !v.IsLatest.Value);
                var recentVersionSize = recentVersion.Size;
                var oldVersionSize = oldVersion.Size;

                using (var oldFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{folder}/{file1}", TestStorage,
                        oldVersion.VersionId)))
                {
                    Assert.AreEqual(oldVersionSize, oldFile.Length);
                }

                using (var recentFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{folder}/{file1}", TestStorage,
                        recentVersion.VersionId)))
                {
                    Assert.AreEqual(recentVersionSize, recentFile.Length);
                }
            }
            finally
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));
            }
        }

        [Test]
        public void FileVersionsMoveTest()
        {
            if (PsdApi.Configuration.OnPremise) return;

            var folder = $"{TempFolder}/Storage";
            var file1 = "Storage.txt";
            var file2 = "Folder1/Folder1.txt";

            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file1}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file2}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                var versions =
                    PsdApi.GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}", TestStorage))
                        .Value;
                var recentVersion = versions.Find(v => v.IsLatest.Value);

                PsdApi.MoveFile(new MoveFileRequest($"{folder}/{file1}", $"{folder}/{file1}.recent",
                    TestStorage, TestStorage, recentVersion.VersionId));
                var copiedVersions =
                    PsdApi
                        .GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}.recent", TestStorage))
                        .Value;
                Assert.AreEqual(1, copiedVersions.Count);
                Assert.IsTrue(copiedVersions[0].IsLatest.Value);
                Assert.AreEqual(recentVersion.Size, copiedVersions[0].Size);

                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file1}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file2}", $"{folder}/{file1}", TestStorage,
                        TestStorage));
                versions =
                    PsdApi.GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}", TestStorage))
                        .Value;
                var oldVersion = versions.Find(v => !v.IsLatest.Value);
                PsdApi.MoveFile(new MoveFileRequest($"{folder}/{file1}", $"{folder}/{file1}.old",
                    TestStorage, TestStorage, oldVersion.VersionId));
                copiedVersions =
                    PsdApi
                        .GetFileVersions(new GetFileVersionsRequest($"{folder}/{file1}.old", TestStorage))
                        .Value;
                Assert.AreEqual(1, copiedVersions.Count);
                Assert.IsTrue(copiedVersions[0].IsLatest.Value);
                Assert.AreEqual(oldVersion.Size, copiedVersions[0].Size);
            }
            finally
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));
            }
        }

        [Test]
        public void MoveFileTest()
        {
            var folder = $"{TempFolder}/Storage";
            var file = "Storage.txt";
            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFile(
                    new CopyFileRequest($"{OriginalDataFolder}/{file}", $"{folder}/{file}.copied", TestStorage,
                        TestStorage));
                var existResponse = PsdApi.ObjectExists(
                    new ObjectExistsRequest($"{folder}/{file}.copied", TestStorage));
                Assert.NotNull(existResponse);
                Assert.IsFalse(existResponse.IsFolder.Value);
                Assert.IsTrue(existResponse.Exists.Value);

                PsdApi.MoveFile(
                    new MoveFileRequest($"{folder}/{file}.copied", $"{folder}/{file}", TestStorage, TestStorage));
                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest($"{folder}/{file}.copied", TestStorage)).Exists.Value);
                existResponse = PsdApi.ObjectExists(
                    new ObjectExistsRequest($"{folder}/{file}", TestStorage));
                Assert.NotNull(existResponse);
                Assert.IsFalse(existResponse.IsFolder.Value);
                Assert.IsTrue(existResponse.Exists.Value);

                var originalFileInfo =
                    PsdApi.GetFilesList(new GetFilesListRequest(OriginalDataFolder, TestStorage)).Value
                        .Find(f => f.Name == file);
                var movedFileInfo =
                    PsdApi.GetFilesList(new GetFilesListRequest(folder, TestStorage)).Value.Find(f => f.Name == file);
                Assert.AreEqual(originalFileInfo.Size, movedFileInfo.Size);

                using (var originalFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{OriginalDataFolder}/{file}", TestStorage)))
                using (var movedFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{folder}/{file}", TestStorage)))
                {
                    Assert.AreEqual(originalFile.Length, movedFile.Length);
                    Assert.AreEqual(originalFile.Length, originalFileInfo.Size);
                    using (var originalReader = new StreamReader(originalFile))
                    using (var movedReader = new StreamReader(movedFile))
                    {
                        var originalString = originalReader.ReadToEnd();
                        var movedString = movedReader.ReadToEnd();
                        Assert.AreEqual(originalString, movedString);
                        Assert.AreEqual(originalString, originalFileInfo.Path.Trim('/'));
                        Assert.AreEqual(originalString.Replace(OriginalDataFolder, folder),
                            movedFileInfo.Path.Trim('/'));
                    }
                }
            }
            finally
            {
                PsdApi.DeleteFile(new DeleteFileRequest($"{folder}/{file}", TestStorage));
                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest($"{folder}/{file}", TestStorage)).Exists.Value);

                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);
            }
        }

        [Test]
        public void UploadFileTest()
        {
            var folder = $"{TempFolder}/Storage";
            var file = "Storage.txt";
            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                using (var originalFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{OriginalDataFolder}/{file}",
                        TestStorage)))
                {
                    var result =
                        PsdApi.UploadFile(new UploadFileRequest($"{folder}/{file}", originalFile,
                            TestStorage));
                    Assert.NotNull(result);
                    Assert.IsTrue(result.Errors == null || result.Errors.Count == 0);
                    Assert.NotNull(result.Uploaded);
                    Assert.AreEqual(1, result.Uploaded.Count);
                    Assert.AreEqual(file, result.Uploaded[0]);
                }

                var existResponse = PsdApi.ObjectExists(
                    new ObjectExistsRequest($"{folder}/{file}", TestStorage));
                Assert.NotNull(existResponse);
                Assert.IsFalse(existResponse.IsFolder.Value);
                Assert.IsTrue(existResponse.Exists.Value);

                var originalFileInfo =
                    PsdApi.GetFilesList(new GetFilesListRequest(OriginalDataFolder, TestStorage)).Value
                        .Find(f => f.Name == file);
                var uploadedFileInfo =
                    PsdApi.GetFilesList(new GetFilesListRequest(folder, TestStorage)).Value.Find(f => f.Name == file);
                Assert.AreEqual(originalFileInfo.Size, uploadedFileInfo.Size);

                using (var originalFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{OriginalDataFolder}/{file}", TestStorage)))
                using (var uploadedFile =
                    PsdApi.DownloadFile(new DownloadFileRequest($"{folder}/{file}", TestStorage)))
                {
                    Assert.AreEqual(originalFile.Length, uploadedFile.Length);
                    Assert.AreEqual(originalFile.Length, originalFileInfo.Size);
                    using (var originalReader = new StreamReader(originalFile))
                    using (var uploadedReader = new StreamReader(uploadedFile))
                    {
                        var originalString = originalReader.ReadToEnd();
                        var uploadedString = uploadedReader.ReadToEnd();
                        Assert.AreEqual(originalString, uploadedString);
                        Assert.AreEqual(originalString, originalFileInfo.Path.Trim('/'));
                        Assert.AreEqual(originalString.Replace(OriginalDataFolder, folder),
                            uploadedFileInfo.Path.Trim('/'));
                    }
                }
            }
            finally
            {
                PsdApi.DeleteFile(new DeleteFileRequest($"{folder}/{file}", TestStorage));
                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest($"{folder}/{file}", TestStorage)).Exists.Value);

                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);
            }
        }
    }
}