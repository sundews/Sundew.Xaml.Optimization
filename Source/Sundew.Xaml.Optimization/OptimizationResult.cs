// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptimizationResult.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>The result of a xaml optimization.</summary>
public sealed class OptimizationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptimizationResult" /> class.
    /// </summary>
    /// <param name="additionalFiles">The additional files.</param>
    /// <param name="xamlFileChanges">The optimized files.</param>
    /// <param name="xamlDiagnostics">The xaml diagnostics.</param>
    private OptimizationResult(IReadOnlyCollection<XamlFileChange> xamlFileChanges, IReadOnlyCollection<AdditionalFile> additionalFiles, IReadOnlyCollection<XamlDiagnostic> xamlDiagnostics)
    {
        this.XamlFileChanges = xamlFileChanges;
        this.AdditionalFiles = additionalFiles;
        this.XamlDiagnostics = xamlDiagnostics;
    }

    /// <summary>
    /// Gets a value indicating whether this instance is success.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
    /// </value>
    public bool IsSuccess => this.AdditionalFiles.Count > 0 || this.XamlFileChanges.Count > 0;

    /// <summary>
    /// Gets the xaml files changes.
    /// </summary>
    public IReadOnlyCollection<XamlFileChange> XamlFileChanges { get; }

    /// <summary>Gets the additional files.</summary>
    /// <value>The additional files.</value>
    public IReadOnlyCollection<AdditionalFile> AdditionalFiles { get; }

    /// <summary>
    /// Gets the xaml diagnostics.
    /// </summary>
    public IReadOnlyCollection<XamlDiagnostic> XamlDiagnostics { get; }

    /// <summary>
    /// Converts to a ValueTask of <see cref="OptimizationResult"/>.
    /// </summary>
    /// <param name="optimizationResult">The project optimization result.</param>
    public static implicit operator ValueTask<OptimizationResult>(OptimizationResult optimizationResult)
    {
        return new ValueTask<OptimizationResult>(optimizationResult);
    }

    /// <summary>
    /// Gets a successful result.
    /// </summary>
    /// <param name="xamlFileChanges">The files to be removed.</param>
    /// <param name="additionalFiles">The additional files.</param>
    /// <param name="xamlDiagnostics">The xaml diagnostics.</param>
    /// <returns>A new <see cref="OptimizationResult"/>.</returns>
    public static OptimizationResult From(IReadOnlyCollection<XamlFileChange>? xamlFileChanges = null, IReadOnlyCollection<AdditionalFile>? additionalFiles = null, params IReadOnlyCollection<XamlDiagnostic> xamlDiagnostics)
    {
        return new OptimizationResult(xamlFileChanges ?? [], additionalFiles ?? [], xamlDiagnostics);
    }

    /// <summary>
    /// Gets a result with no modifications.
    /// </summary>
    /// <returns>A new <see cref="OptimizationResult"/>.</returns>
    public static OptimizationResult None()
    {
        return new OptimizationResult([], [], []);
    }

    /// <summary>
    /// Gets a result with no modifications.
    /// </summary>
    /// <param name="xamlDiagnostics">The xaml diagnostics.</param>
    /// <returns>A new <see cref="OptimizationResult"/>.</returns>
    public static OptimizationResult Report(params IReadOnlyCollection<XamlDiagnostic> xamlDiagnostics)
    {
        return new OptimizationResult([], [], xamlDiagnostics);
    }
}