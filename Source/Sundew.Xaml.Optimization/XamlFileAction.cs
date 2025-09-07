// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlFileAction.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

/// <summary>
/// Specifies the actions that can be performed on a XAML file.
/// </summary>
/// <remarks>This enumeration is used to indicate the type of operation to perform on a XAML file, such as
/// removing or updating it.</remarks>
public enum XamlFileAction
{
    /// <summary>
    /// No action specified.
    /// </summary>
    None,

    /// <summary>
    /// The XAML file will be removed.
    /// </summary>
    Remove,

    /// <summary>
    /// The XAML file will be updated.
    /// </summary>
    Update,
}