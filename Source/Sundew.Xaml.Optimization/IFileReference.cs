// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileReference.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization
{
    using System.Collections.Generic;

    /// <summary>Interface for providing information about a xaml file.</summary>
    public interface IFileReference
    {
        /// <summary>Gets the identity.</summary>
        /// <value>The identity.</value>
        string Id { get; }

        /// <summary>Gets the build action.</summary>
        /// <value>The build action.</value>
        BuildAction BuildAction { get; }

        /// <summary>Gets the path.</summary>
        /// <value>The path.</value>
        string Path { get; }

        /// <summary>Gets the names.</summary>
        /// <value>The names.</value>
        IReadOnlyCollection<string> Names { get; }

        /// <summary>Gets the <see cref="string"/> with the specified name.</summary>
        /// <param name="name">The name.</param>
        /// <value>The <see cref="string"/>.</value>
        /// <returns>The value or null.</returns>
        string this[string name] { get; }
    }
}