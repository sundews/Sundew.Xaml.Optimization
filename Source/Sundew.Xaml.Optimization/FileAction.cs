// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileAction.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

/// <summary>Defines how and additional file should be treated.</summary>
public enum FileAction
{
    /// <summary>The additional file will be compiled.</summary>
    Compile,

    /// <summary>The additional file will be included as a page.</summary>
    Page,

    /// <summary>The additional file will be embedded as a resource.</summary>
    EmbeddedResource,

    /// <summary>The additional file will be included as an additional file.</summary>
    AdditionalFile,

    /// <summary>The Maui Xaml.</summary>
    MauiXaml,

    /// <summary>The Avalonia Xaml.</summary>
    AvaloniaXaml,
}