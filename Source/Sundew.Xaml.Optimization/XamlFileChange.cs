// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlFileChange.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

/// <summary>
/// Represents a change to be made to a XAML file, including the file itself and the action to be performed.
/// </summary>
public sealed class XamlFileChange
{
    private XamlFileChange(XamlFile file, XamlFileAction action)
    {
        this.File = file;
        this.Action = action;
    }

    /// <summary>
    /// Gets the XAML file to be changed.
    /// </summary>
    public XamlFile File { get; }

    /// <summary>
    /// Gets the action to be performed on the XAML file.
    /// </summary>
    public XamlFileAction Action { get; }

    /// <summary>
    /// Creates a new instance of <see cref="XamlFileChange"/> with the specified XAML file and action set to Remove.
    /// </summary>
    /// <param name="xamlFile">The xaml file.</param>
    /// <returns>The change.</returns>
    public static XamlFileChange Remove(XamlFile xamlFile)
    {
        return new XamlFileChange(xamlFile, XamlFileAction.Remove);
    }

    /// <summary>
    /// Creates a new instance of <see cref="XamlFileChange"/> with the specified XAML file and action set to Update.
    /// </summary>
    /// <param name="xamlFile">The xaml file.</param>
    /// <returns>The change.</returns>
    public static XamlFileChange Update(XamlFile xamlFile)
    {
        return new XamlFileChange(xamlFile, XamlFileAction.Update);
    }
}