// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXamlOptimizer.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Sundew.Base;

/// <summary>Interface for implementing a xaml optimizer.</summary>
public interface IXamlOptimizer
{
    /// <summary>Gets the supported platforms.</summary>
    /// <value>The supported platforms.</value>
    IReadOnlyList<XamlPlatform> SupportedPlatforms { get; }

    /// <summary>Optimizes the specified xml document.</summary>
    /// <param name="xDocument">The xml document.</param>
    /// <param name="fileInfo">The file info.</param>
    /// <param name="intermediateDirectory">The intermediate directory.</param>
    /// <param name="assemblyReferences">The assembly references.</param>
    /// <returns>The result of the xaml optimization.</returns>
    R<XamlOptimization> Optimize(XDocument xDocument, FileInfo fileInfo, DirectoryInfo intermediateDirectory, IReadOnlyList<IAssemblyReference> assemblyReferences);
}