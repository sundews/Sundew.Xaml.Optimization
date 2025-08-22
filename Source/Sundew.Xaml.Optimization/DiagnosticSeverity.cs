// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticSeverity.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

/// <summary>
/// Represents the severity of a diagnostic message.
/// </summary>
public enum DiagnosticSeverity
{
    /// <summary>
    /// Indicates an error.
    /// </summary>
    Error,

    /// <summary>
    /// Indicates a warning.
    /// </summary>
    Warning,

    /// <summary>
    /// Indicates an informational message.
    /// </summary>
    Info,
}