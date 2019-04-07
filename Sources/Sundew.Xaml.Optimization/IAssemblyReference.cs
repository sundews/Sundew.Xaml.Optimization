// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssemblyReference.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization
{
    /// <summary>Represents an assembly reference.</summary>
    public interface IAssemblyReference
    {
        /// <summary>Gets the name of the assembly.</summary>
        /// <value>The name of the assembly.</value>
        string Name { get; }

        /// <summary>Gets the assembly path.</summary>
        /// <value>The assembly path.</value>
        string Path { get; }

        /// <summary>Gets the aliases.</summary>
        /// <value>The aliases.</value>
        string[] Aliases { get; }
    }
}