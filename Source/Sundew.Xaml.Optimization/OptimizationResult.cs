// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptimizationResult.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

/// <summary>The result of a xaml optimization.</summary>
public sealed class OptimizationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptimizationResult" /> class.
    /// </summary>
    /// <param name="xDocument">The x document.</param>
    /// <param name="additionalFiles">The additional files.</param>
    /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
    /// <param name="xamlDiagnostics">The xaml diagnostics.</param>
    private OptimizationResult(XDocument? xDocument, IReadOnlyList<AdditionalFile> additionalFiles, bool isSuccess, IReadOnlyList<XamlDiagnostic> xamlDiagnostics)
    {
        this.XDocument = xDocument;
        this.AdditionalFiles = additionalFiles;
        this.IsSuccess = isSuccess;
        this.XamlDiagnostics = xamlDiagnostics;
    }

    /// <summary>Gets the x document.</summary>
    /// <value>The x document.</value>
    public XDocument? XDocument { get; }

    /// <summary>Gets the additional files.</summary>
    /// <value>The additional files.</value>
    public IReadOnlyList<AdditionalFile> AdditionalFiles { get; }

    /// <summary>
    /// Gets a value indicating whether this instance is success.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
    /// </value>
    [MemberNotNullWhen(true, nameof(XDocument))]
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the xaml diagnostics.
    /// </summary>
    public IReadOnlyList<XamlDiagnostic> XamlDiagnostics { get; }

    /// <summary>
    /// Performs an implicit conversion from <see cref="OptimizationResult"/> to <see cref="bool"/>.
    /// </summary>
    /// <param name="optimizationResult">The optimization result.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    [MemberNotNullWhen(true, nameof(XDocument))]
    public static implicit operator bool(OptimizationResult optimizationResult)
    {
        return optimizationResult.IsSuccess;
    }

    /// <summary>
    /// Gets a successful result.
    /// </summary>
    /// <param name="xDocument">The x document.</param>
    /// <param name="additionalFiles">The additional files.</param>
    /// <param name="xamlDiagnostics">The xaml diagnostics.</param>
    /// <returns>A new <see cref="OptimizationResult"/>.</returns>
    public static OptimizationResult Success(XDocument xDocument, IReadOnlyList<AdditionalFile>? additionalFiles = null, params IReadOnlyList<XamlDiagnostic> xamlDiagnostics)
    {
        return new OptimizationResult(xDocument, additionalFiles ?? [], true, xamlDiagnostics);
    }

    /// <summary>
    /// Gets a result with no modifications.
    /// </summary>
    /// <param name="xamlDiagnostics">The xaml diagnostics.</param>
    /// <returns>A new <see cref="OptimizationResult"/>.</returns>
    public static OptimizationResult None(params IReadOnlyList<XamlDiagnostic> xamlDiagnostics)
    {
        return new OptimizationResult(null, [], false, xamlDiagnostics);
    }

    /// <summary>
    /// Gets result from the specified parameters.
    /// </summary>
    /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
    /// <param name="xDocument">The x document.</param>
    /// <param name="additionalFiles">The additional files.</param>
    /// <param name="xamlDiagnostics">The xaml diagnostics.</param>
    /// <returns>
    /// A new <see cref="OptimizationResult" />.
    /// </returns>
    public static OptimizationResult From(bool isSuccess, XDocument xDocument, IReadOnlyList<AdditionalFile>? additionalFiles = null, params IReadOnlyList<XamlDiagnostic> xamlDiagnostics)
    {
        return new OptimizationResult(xDocument, [], isSuccess, xamlDiagnostics);
    }
}