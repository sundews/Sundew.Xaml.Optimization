// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlOptimization.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Collections.Generic;
using System.Xml.Linq;

/// <summary>The result of a xaml optimization.</summary>
public sealed class XamlOptimization
{
    private static readonly AdditionalFile[] EmptyAdditionalFiles = [];

    /// <summary>Initializes a new instance of the <see cref="XamlOptimization"/> class.</summary>
    /// <param name="xDocument">The x document.</param>
    public XamlOptimization(XDocument xDocument)
        : this(xDocument, null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="XamlOptimization"/> class.</summary>
    /// <param name="xDocument">The x document.</param>
    /// <param name="additionalFiles">The additional files.</param>
    public XamlOptimization(XDocument xDocument, IReadOnlyList<AdditionalFile>? additionalFiles)
    {
        this.XDocument = xDocument;
        this.AdditionalFiles = additionalFiles ?? EmptyAdditionalFiles;
    }

    /// <summary>Gets the x document.</summary>
    /// <value>The x document.</value>
    public XDocument XDocument { get; }

    /// <summary>Gets the additional files.</summary>
    /// <value>The additional files.</value>
    public IReadOnlyList<AdditionalFile> AdditionalFiles { get; }
}