// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXamlOptimizer.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    using Sundew.Base.Computation;

    /// <summary>Interface for implementing a xaml optimizer.</summary>
    public interface IXamlOptimizer
    {
        /// <summary>Gets the supported platforms.</summary>
        /// <value>The supported platforms.</value>
        IReadOnlyList<XamlPlatform> SupportedPlatforms { get; }

        /// <summary>Optimizes the specified xml document.</summary>
        /// <param name="fileInfo">The file info.</param>
        /// <param name="xDocument">The xml document.</param>
        /// <param name="intermediateDirectory">The intermediate directory.</param>
        /// <returns>The result of the xaml optimization.</returns>
        Result<XamlOptimization> Optimize(FileInfo fileInfo, XDocument xDocument, DirectoryInfo intermediateDirectory);
    }
}