// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlPlatformInfoProvider.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Xml;

using System;

/// <summary>Maps a <see cref="XamlPlatform"/> to a <see cref="XamlPlatformInfo"/>.</summary>
public static class XamlPlatformInfoProvider
{
    private static readonly XamlPlatformInfo WpfXamlPlatformInfo = new XamlPlatformInfo(
        XamlPlatform.WPF,
        Constants.WpfPresentationNamespace,
        Constants.DefaultXamlNamespace);

    private static readonly XamlPlatformInfo MauiXamlPlatformInfo = new XamlPlatformInfo(
        XamlPlatform.Maui,
        Constants.MauiPresentationNamespace,
        Constants.MauiXamlNamespace);

    private static readonly XamlPlatformInfo AvaloniaXamlPlatformInfo = new XamlPlatformInfo(
        XamlPlatform.Avalonia,
        Constants.AvaloniaNamespace,
        Constants.DefaultXamlNamespace);

    private static readonly XamlPlatformInfo WinUIXamlPlatformInfo = new XamlPlatformInfo(
        XamlPlatform.WinUI,
        Constants.WinUIPresentationNamespace,
        Constants.DefaultXamlNamespace);

    private static readonly XamlPlatformInfo UwpXamlPlatformInfo = new XamlPlatformInfo(
        XamlPlatform.UWP,
        Constants.UwpPresentationNamespace,
        Constants.DefaultXamlNamespace);

    private static readonly XamlPlatformInfo XfXamlPlatformInfo = new XamlPlatformInfo(
        XamlPlatform.XF,
        Constants.XfPresentationNamespace,
        Constants.DefaultXamlNamespace);

    /// <summary>Gets a <see cref="XamlPlatformInfo"/> based on the specified <see cref="XamlPlatform"/>.</summary>
    /// <param name="xamlPlatform">The xaml platform.</param>
    /// <returns>The xaml platform info.</returns>
    /// <exception cref="ArgumentOutOfRangeException">xamlPlatform - The specified value: {xamlPlatform}.</exception>
    public static XamlPlatformInfo GetXamlPlatformInfo(XamlPlatform xamlPlatform)
    {
        switch (xamlPlatform)
        {
            case XamlPlatform.WPF:
                return WpfXamlPlatformInfo;
            case XamlPlatform.Avalonia:
                return AvaloniaXamlPlatformInfo;
            case XamlPlatform.Maui:
                return MauiXamlPlatformInfo;
            case XamlPlatform.WinUI:
                return WinUIXamlPlatformInfo;
            case XamlPlatform.UWP:
                return UwpXamlPlatformInfo;
            case XamlPlatform.XF:
                return XfXamlPlatformInfo;

            default:
                throw new ArgumentOutOfRangeException(nameof(xamlPlatform), xamlPlatform, $"The specified value: {xamlPlatform} is not supported");
        }
    }
}