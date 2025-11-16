// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptimizerSettings.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Diagnostics;

/// <summary>
/// Represents configuration settings for controlling optimizer behavior, including debugging options.
/// </summary>
public class OptimizerSettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptimizerSettings" /> class.
    /// </summary>
    /// <param name="debug">Indicates whether debugging features should be enabled for the optimizer. Set to <see langword="true"/> to
    /// enable debugging; otherwise, <see langword="false"/>.</param>
    public OptimizerSettings(bool debug)
    {
        this.Debug = debug;
        if (debug)
        {
            Debugger.Launch();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the application is currently running in debugging mode.
    /// </summary>
    public bool Debug { get; }
}