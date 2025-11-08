// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXamlFileProvider.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Xml;

using System.Threading.Tasks;

/// <summary>
/// Interface for implementing a xaml document provider.
/// </summary>
public interface IXamlFileProvider
{
    /// <summary>Gets the file references.</summary>
    /// <value>The file references.</value>
    XamlFiles XamlFiles { get; }

    /// <summary>
    /// Load the xaml file.
    /// </summary>
    /// <param name="fileReference">The file reference.</param>
    /// <returns>An async task with the xaml file.</returns>
    Task<XamlFile> LoadAsync(IFileReference fileReference);
}