// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXamlOptimizer.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Collections.Generic;
using System.Xml.Linq;

/// <summary>Interface for implementing a xaml optimizer.</summary>
public interface IXamlOptimizer
{
    /// <summary>Gets the supported platforms.</summary>
    /// <value>The supported platforms.</value>
    IReadOnlyList<XamlPlatform> SupportedPlatforms { get; }

    /// <summary>Optimizes the specified xml document.</summary>
    /// <param name="xamlDocument">The xml document.</param>
    /// <param name="xamlFile">The xaml file reference.</param>
    /// <returns>The result of the xaml optimization.</returns>
    OptimizationResult Optimize(XDocument xamlDocument, IFileReference xamlFile);
}