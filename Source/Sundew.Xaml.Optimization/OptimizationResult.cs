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
    private static readonly AdditionalFile[] EmptyAdditionalFiles = new AdditionalFile[0];

    /// <summary>
    /// Initializes a new instance of the <see cref="OptimizationResult" /> class.
    /// </summary>
    /// <param name="xDocument">The x document.</param>
    /// <param name="additionalFiles">The additional files.</param>
    /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
    private OptimizationResult(XDocument? xDocument, IReadOnlyList<AdditionalFile> additionalFiles, bool isSuccess)
    {
        this.XDocument = xDocument;
        this.AdditionalFiles = additionalFiles ?? EmptyAdditionalFiles;
        this.IsSuccess = isSuccess;
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
    /// Performs an implicit conversion from <see cref="OptimizationResult"/> to <see cref="bool"/>.
    /// </summary>
    /// <param name="optimizationResult">The optimization result.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator bool(OptimizationResult optimizationResult)
    {
        return optimizationResult.IsSuccess;
    }

    /// <summary>
    /// Gets a successful result.
    /// </summary>
    /// <param name="xDocument">The x document.</param>
    /// <param name="additionalFiles">The additional files.</param>
    /// <returns>A new <see cref="OptimizationResult"/>.</returns>
    public static OptimizationResult Success(XDocument xDocument, IReadOnlyList<AdditionalFile>? additionalFiles = null)
    {
        return new OptimizationResult(xDocument, additionalFiles ?? [], true);
    }

    /// <summary>
    /// Gets and error result.
    /// </summary>
    /// <returns>A new <see cref="OptimizationResult"/>.</returns>
    public static OptimizationResult Error()
    {
        return new OptimizationResult(null, [], false);
    }

    /// <summary>
    /// Gets result from the specified parameters.
    /// </summary>
    /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
    /// <param name="xDocument">The x document.</param>
    /// <param name="additionalFiles">The additional files.</param>
    /// <returns>
    /// A new <see cref="OptimizationResult" />.
    /// </returns>
    public static OptimizationResult From(bool isSuccess, XDocument xDocument, IReadOnlyList<AdditionalFile>? additionalFiles = null)
    {
        return new OptimizationResult(xDocument, [], isSuccess);
    }
}