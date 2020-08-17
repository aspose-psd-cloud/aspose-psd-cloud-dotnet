// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="FolderApiTests.cs">
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

using Aspose.Psd.Cloud.Sdk.Model.Requests;
using NUnit.Framework;

namespace Aspose.Psd.Cloud.Sdk.Test.Api.Storage
{
    /// <summary>
    ///     Specific folder API tests for Storage.
    /// </summary>
    /// <seealso cref="StorageApiTester" />
    [Category("Folder")]
    public class FolderApiTests : StorageApiTester
    {
        [Test]
        public void CopyFolderTest()
        {
            var folder = $"{TempFolder}/Storage";
            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFolder(
                    new CopyFolderRequest(OriginalDataFolder, folder, TestStorage, TestStorage));
                Assert.IsTrue(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);
                var originalFiles = PsdApi.GetFilesList(
                    new GetFilesListRequest(OriginalDataFolder, TestStorage)).Value;
                var copiedFiles = PsdApi.GetFilesList(
                    new GetFilesListRequest(folder, TestStorage)).Value;
                Assert.Greater(originalFiles.Count, 0);
                Assert.Greater(copiedFiles.Count, 0);
                Assert.AreEqual(originalFiles.Count, copiedFiles.Count);
                var count = originalFiles.Count;
                for (var x = 0; x < count; x++)
                {
                    var curFile = originalFiles[x];
                    Assert.NotNull(copiedFiles.Find(f => f.IsFolder == curFile.IsFolder && f.Size == curFile.Size
                                                                                        && f.Name == curFile.Name));
                }
            }
            finally
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);
            }
        }

        [Test]
        public void CreateFolderTest()
        {
            var folder = $"{TempFolder}/DummyFolder";
            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CreateFolder(new CreateFolderRequest(folder, TestStorage));
                Assert.IsTrue(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);
            }
            finally
            {
                if (PsdApi.ObjectExists(new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);
            }
        }

        [Test]
        public void FilesListTest()
        {
            var files = PsdApi.GetFilesList(new GetFilesListRequest(OriginalDataFolder,
                TestStorage)).Value;
            Assert.AreEqual(3, files.Count);
            var folder1 = files.Find(f => f.Name == "Folder1");
            Assert.NotNull(folder1);
            Assert.IsTrue(folder1.IsFolder.Value);
            Assert.IsTrue(folder1.Path.Trim('/').EndsWith(folder1.Name));
            var folder2 = files.Find(f => f.Name == "Folder2");
            Assert.NotNull(folder2);
            Assert.IsTrue(folder2.IsFolder.Value);
            Assert.IsTrue(folder2.Path.Trim('/').EndsWith(folder2.Name));
            var storageFile = files.Find(f => f.Name == "Storage.txt");
            Assert.NotNull(storageFile);
            Assert.IsFalse(storageFile.IsFolder.Value);
            Assert.IsTrue(storageFile.Path.Trim('/').EndsWith(storageFile.Name));
            Assert.AreEqual(storageFile.Size, storageFile.Path.Trim('/').Length);

            files = PsdApi.GetFilesList(new GetFilesListRequest($"{OriginalDataFolder}/{folder1.Name}",
                TestStorage)).Value;
            Assert.AreEqual(1, files.Count);
            var folder1File = files.Find(f => f.Name == "Folder1.txt");
            Assert.NotNull(folder1File);
            Assert.IsFalse(folder1File.IsFolder.Value);
            Assert.IsTrue(folder1File.Path.Trim('/').EndsWith(folder1File.Name));
            Assert.AreEqual(folder1File.Size, folder1File.Path.Trim('/').Length);

            files = PsdApi.GetFilesList(new GetFilesListRequest($"{OriginalDataFolder}/{folder2.Name}",
                TestStorage)).Value;
            Assert.AreEqual(2, files.Count);
            var folder2File = files.Find(f => f.Name == "Folder2.txt");
            Assert.NotNull(folder2File);
            Assert.IsFalse(folder2File.IsFolder.Value);
            Assert.IsTrue(folder2File.Path.Trim('/').EndsWith(folder2File.Name));
            Assert.AreEqual(folder2File.Size, folder1File.Path.Trim('/').Length);
            var folder3 = files.Find(f => f.Name == "Folder3");
            Assert.NotNull(folder3);
            Assert.IsTrue(folder3.IsFolder.Value);
            Assert.IsTrue(folder3.Path.Trim('/').EndsWith(folder3.Name));

            files = PsdApi.GetFilesList(new GetFilesListRequest(
                $"{OriginalDataFolder}/{folder2.Name}/{folder3.Name}",
                TestStorage)).Value;
            Assert.AreEqual(1, files.Count);
            var folder3File = files.Find(f => f.Name == "Folder3.txt");
            Assert.NotNull(folder3File);
            Assert.IsFalse(folder3File.IsFolder.Value);
            Assert.IsTrue(folder3File.Path.Trim('/').EndsWith(folder3File.Name));
            Assert.AreEqual(folder3File.Size, folder3File.Path.Trim('/').Length);
        }

        [Test]
        public void MoveFolderTest()
        {
            var tmpFolder = $"{TempFolder}/Temp";
            var folder = $"{TempFolder}/Storage";
            try
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(tmpFolder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(tmpFolder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(tmpFolder, TestStorage)).Exists.Value);
                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                PsdApi.CopyFolder(
                    new CopyFolderRequest(OriginalDataFolder, tmpFolder, TestStorage, TestStorage));
                Assert.IsTrue(PsdApi.ObjectExists(
                    new ObjectExistsRequest(tmpFolder, TestStorage)).Exists.Value);

                PsdApi.MoveFolder(
                    new MoveFolderRequest(tmpFolder, folder, TestStorage, TestStorage));
                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(tmpFolder, TestStorage)).Exists.Value);
                Assert.IsTrue(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);

                var originalFiles = PsdApi.GetFilesList(
                    new GetFilesListRequest(OriginalDataFolder, TestStorage)).Value;
                var copiedFiles = PsdApi.GetFilesList(
                    new GetFilesListRequest(folder, TestStorage)).Value;
                Assert.Greater(originalFiles.Count, 0);
                Assert.Greater(copiedFiles.Count, 0);
                Assert.AreEqual(originalFiles.Count, copiedFiles.Count);
                var count = originalFiles.Count;
                for (var x = 0; x < count; x++)
                {
                    var curFile = originalFiles[x];
                    Assert.NotNull(copiedFiles.Find(f => f.IsFolder == curFile.IsFolder && f.Size == curFile.Size
                                                                                        && f.Name == curFile.Name));
                }
            }
            finally
            {
                if (PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value)
                    PsdApi.DeleteFolder(new DeleteFolderRequest(folder, TestStorage, true));

                Assert.IsFalse(PsdApi.ObjectExists(
                    new ObjectExistsRequest(folder, TestStorage)).Exists.Value);
            }
        }
    }
}