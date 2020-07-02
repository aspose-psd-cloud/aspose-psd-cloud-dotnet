// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ImagingResponse.cs">
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

namespace Aspose.Psd.Cloud.Sdk.Model 
{
  using System;  
  using System.Collections;
  using System.Collections.Generic;
  using System.Runtime.Serialization;
  using System.Text;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Converters;

  /// <summary>
  /// Represents information about image.
  /// </summary>  
  public class ImagingResponse 
  {                       
        /// <summary>
        /// Gets or sets the height of image.
        /// </summary>  
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the width of image.
        /// </summary>  
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the bits per pixel for image.
        /// </summary>  
        public int? BitsPerPixel { get; set; }

        /// <summary>
        /// Gets or sets the PSD properties.
        /// </summary>  
        public PsdProperties PsdProperties { get; set; }

        /// <summary>
        /// Gets or sets the horizontal resolution of an image.
        /// </summary>  
        public double? HorizontalResolution { get; set; }

        /// <summary>
        /// Gets or sets the vertical resolution of an image.
        /// </summary>  
        public double? VerticalResolution { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether image is cached.
        /// </summary>  
        public bool? IsCached { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class ImagingResponse {\n");
          sb.Append("  Height: ").Append(this.Height).Append("\n");
          sb.Append("  Width: ").Append(this.Width).Append("\n");
          sb.Append("  BitsPerPixel: ").Append(this.BitsPerPixel).Append("\n");
          sb.Append("  PsdProperties: ").Append(this.PsdProperties).Append("\n");
          sb.Append("  HorizontalResolution: ").Append(this.HorizontalResolution).Append("\n");
          sb.Append("  VerticalResolution: ").Append(this.VerticalResolution).Append("\n");
          sb.Append("  IsCached: ").Append(this.IsCached).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
