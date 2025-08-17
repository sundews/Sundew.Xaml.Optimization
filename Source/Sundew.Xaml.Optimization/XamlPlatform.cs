// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlPlatform.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

/// <summary>Defines the various Xaml platforms.</summary>
public enum XamlPlatform
{
    /// <summary>The WPF platform.</summary>
    WPF,

    /// <summary>The Maui platform.</summary>
    Maui,

    /// <summary>The WinUI platform.</summary>
    WinUI,

    /// <summary>The Avalonia platform.</summary>
    Avalonia,

    /// <summary>The UWP platform.</summary>
    UWP,

    /// <summary>The Xamarin Forms platform.</summary>
    XF,
}