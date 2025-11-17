// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlFile.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Xml.Linq;

/// <summary>
/// Represents a XAML file.
/// </summary>
/// <param name="Document">The document.</param>
/// <param name="Reference">The file.</param>
/// <param name="LineEndings">The line endings.</param>
public sealed record XamlFile(XDocument Document, IFileReference Reference, string LineEndings)
{
    /// <summary>
    /// Returns a <see cref="string" /> that represents this instance.
    /// </summary>
    /// <returns>The reference.</returns>
    public override string ToString()
    {
        return this.Reference.ToString();
    }
}
