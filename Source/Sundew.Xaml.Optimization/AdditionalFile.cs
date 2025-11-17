// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalFile.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.IO;

/// <summary>Provides additional file during xaml optimizations.</summary>
public record AdditionalFile
{
    /// <summary>Initializes a new instance of the <see cref="AdditionalFile"/> class.</summary>
    /// <param name="itemType">The file action.</param>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="link">The link.</param>
    /// <param name="content">The content.</param>
    public AdditionalFile(ItemType itemType, FileInfo fileInfo, string content, string? link)
    {
        this.ItemType = itemType;
        this.FileInfo = fileInfo;
        this.Link = link;
        this.Content = content;
    }

    /// <summary>Gets the file action.</summary>
    /// <value>The file action.</value>
    public ItemType ItemType { get; }

    /// <summary>Gets the file information.</summary>
    /// <value>The file information.</value>
    public FileInfo FileInfo { get; }

    /// <summary>
    /// Gets the link (relative path) to use in the project file.
    /// </summary>
    public string? Link { get; }

    /// <summary>
    /// Gets the content of the file.
    /// </summary>
    public string Content { get; }
}