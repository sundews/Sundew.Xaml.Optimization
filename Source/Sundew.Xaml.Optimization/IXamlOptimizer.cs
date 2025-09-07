// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXamlOptimizer.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>Interface for implementing a xaml optimizer.</summary>
public interface IXamlOptimizer
{
    /// <summary>Gets the supported platforms.</summary>
    /// <value>The supported platforms.</value>
    IReadOnlyList<XamlPlatform> SupportedPlatforms { get; }

    /// <summary>
    /// Optimizes the project.
    /// </summary>
    /// <returns>The result of the project optimization.</returns>
    ValueTask<OptimizationResult> OptimizeAsync(IReadOnlyList<XamlFile> xamlFiles);
}