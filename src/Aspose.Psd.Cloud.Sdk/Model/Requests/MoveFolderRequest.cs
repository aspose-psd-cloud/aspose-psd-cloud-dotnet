// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="MoveFolderRequest.cs">
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

namespace Aspose.Psd.Cloud.Sdk.Model.Requests
{
    /// <summary>
    ///     Request model for <see cref="Aspose.Psd.Cloud.Sdk.Api.PsdApi.MoveFolder" /> operation.
    /// </summary>
    public class MoveFolderRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MoveFolderRequest" /> class.
        /// </summary>
        public MoveFolderRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MoveFolderRequest" /> class.
        /// </summary>
        /// <param name="srcPath">Folder path to move e.g. &#39;/folder&#39;</param>
        /// <param name="destPath">Destination folder path to move to e.g &#39;/dst&#39;</param>
        /// <param name="srcStorageName">Source storage name</param>
        /// <param name="destStorageName">Destination storage name</param>
        public MoveFolderRequest(string srcPath, string destPath, string srcStorageName = null,
            string destStorageName = null)
        {
            SrcPath = srcPath;
            DestPath = destPath;
            SrcStorageName = srcStorageName;
            DestStorageName = destStorageName;
        }

        /// <summary>
        ///     Folder path to move e.g. '/folder'
        /// </summary>
        public string SrcPath { get; set; }

        /// <summary>
        ///     Destination folder path to move to e.g '/dst'
        /// </summary>
        public string DestPath { get; set; }

        /// <summary>
        ///     Source storage name
        /// </summary>
        public string SrcStorageName { get; set; }

        /// <summary>
        ///     Destination storage name
        /// </summary>
        public string DestStorageName { get; set; }
    }
}