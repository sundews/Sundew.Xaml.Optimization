// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalFile.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization
{
    using System.IO;

    /// <summary>Provides additional file during xaml optimizations.</summary>
    public class AdditionalFile
    {
        /// <summary>Initializes a new instance of the <see cref="AdditionalFile"/> class.</summary>
        /// <param name="fileAction">The file action.</param>
        /// <param name="fileInfo">The file information.</param>
        public AdditionalFile(FileAction fileAction, FileInfo fileInfo)
        {
            this.FileAction = fileAction;
            this.FileInfo = fileInfo;
        }

        /// <summary>Gets the file action.</summary>
        /// <value>The file action.</value>
        public FileAction FileAction { get; }

        /// <summary>Gets the file information.</summary>
        /// <value>The file information.</value>
        public FileInfo FileInfo { get; }
    }
}