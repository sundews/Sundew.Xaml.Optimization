// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXDocumentProvider.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Xml
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Interface for implementing a xaml document provider.
    /// </summary>
    public interface IXDocumentProvider
    {
        /// <summary>Gets the file references.</summary>
        /// <value>The file references.</value>
        IReadOnlyList<IFileReference> FileReferences { get; }

        /// <summary>Gets the specified file reference.</summary>
        /// <param name="fileReference">The file reference.</param>
        /// <returns>The xDocument.</returns>
        XDocument Get(IFileReference fileReference);
    }
}