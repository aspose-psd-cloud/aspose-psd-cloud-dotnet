// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="PsdProperties.cs">
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

using System.Text;

namespace Aspose.Psd.Cloud.Sdk.Model
{
    /// <summary>
    ///     Represents information about PSD image
    /// </summary>
    public class PsdProperties
    {
        /// <summary>
        ///     Gets or sets the bits per channel.
        /// </summary>
        public int? BitsPerChannel { get; set; }

        /// <summary>
        ///     Gets or sets the channels count.
        /// </summary>
        public int? ChannelsCount { get; set; }

        /// <summary>
        ///     Gets or sets the color mode.
        /// </summary>
        public string ColorMode { get; set; }

        /// <summary>
        ///     Gets or sets the compression.
        /// </summary>
        public string Compression { get; set; }

        /// <summary>
        ///     Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PsdProperties {\n");
            sb.Append("  BitsPerChannel: ").Append(BitsPerChannel).Append("\n");
            sb.Append("  ChannelsCount: ").Append(ChannelsCount).Append("\n");
            sb.Append("  ColorMode: ").Append(ColorMode).Append("\n");
            sb.Append("  Compression: ").Append(Compression).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}