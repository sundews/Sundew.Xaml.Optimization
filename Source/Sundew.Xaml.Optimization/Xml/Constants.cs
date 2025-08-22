// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Xml;

using System.Xml.Linq;

internal static class Constants
{
    public const string DefaultPrefix = "default";
    public const string XamlPrefix = "x";
    public const string MarkupCompatibilityPrefix = "mc";
    public const string DesignerPrefix = "d";
    public const string ResourceDictionaryText = "ResourceDictionary";
    public const string IgnorableText = "Ignorable";
    public static readonly XNamespace WpfPresentationNamespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
    public static readonly XNamespace WinUIPresentationNamespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
    public static readonly XNamespace MauiPresentationNamespace = "http://schemas.microsoft.com/dotnet/2021/maui";
    public static readonly XNamespace AvaloniaNamespace = "https://github.com/avaloniaui";
    public static readonly XNamespace UwpPresentationNamespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
    public static readonly XNamespace XfPresentationNamespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
    public static readonly XNamespace MauiXamlNamespace = "http://schemas.microsoft.com/winfx/2009/xaml";
    public static readonly XNamespace DefaultXamlNamespace = "http://schemas.microsoft.com/winfx/2006/xaml";
    public static readonly XNamespace DesignerNamespace = "http://schemas.microsoft.com/expression/blend/2008";
    public static readonly XNamespace SundewXamlNamespace = "http://sundew.dev/xaml";
    public static readonly XNamespace MarkupCompatibilityNamespace = "http://schemas.openxmlformats.org/markup-compatibility/2006";
    public static readonly XName IgnorableName = MarkupCompatibilityNamespace + IgnorableText;
}
