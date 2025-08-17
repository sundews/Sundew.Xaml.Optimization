// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildAction.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

/// <summary>Defines to possible build actions.</summary>
public enum BuildAction
{
    /// <summary>The assembly reference.</summary>
    AssemblyReference,

    /// <summary>The compile.</summary>
    Compile,

    /// <summary>The page.</summary>
    Page,

    /// <summary>The embedded resource.</summary>
    EmbeddedResource,

    /// <summary>The application definition.</summary>
    ApplicationDefinition,
}