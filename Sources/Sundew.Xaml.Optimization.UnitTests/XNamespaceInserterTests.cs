// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XNamespaceInserterTests.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.UnitTests;

using System.Xml.Linq;
using AwesomeAssertions;
using Sundew.Xaml.Optimization.Xml;
using Xunit;

public class XNamespaceInserterTests
{
    private const string PoName = "po";

    private static readonly XNamespace PresentationOptionsNamespace =
        "http://schemas.microsoft.com/winfx/2006/xaml/presentation/options";

    private static readonly XName PresentationOptionsName = XNamespace.Xmlns + PoName;

    [Fact]
    public void EnsureXmlNamespaceAttribute_When_NamespaceAlreadyExists_Then_ResultShouldBeExistingAttribute()
    {
        var input = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:po=""http://schemas.microsoft.com/winfx/2006/xaml/presentation/options""
    xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
    mc:IgnorableText=""po"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" po:Freeze=""False"" Color=""#111111"" />
</ResourceDictionary>";
        var xDocument = XDocument.Parse(input);
        var expectedAttribute = new XAttribute(PresentationOptionsName, PresentationOptionsNamespace);

        var result = xDocument.Root!
            .EnsureXmlNamespaceAttribute(PresentationOptionsNamespace, PoName, 3, Constants.DefaultXamlNamespace);

        result.Should().Be(expectedAttribute);
        xDocument.ToString().Should().Be(XDocument.Parse(input).ToString());
    }

    [Fact]
    public void
        EnsureXmlNamespaceAttribute_When_NamespaceDoesNotExist_Then_ResultShouldBeNewAttributeAndNamespaceShouldBeAdded()
    {
        var input = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionary>";
        var expectedResult = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:po=""http://schemas.microsoft.com/winfx/2006/xaml/presentation/options""
    xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionary>";
        var xDocument = XDocument.Parse(input);
        var expectedAttribute = new XAttribute(PresentationOptionsName, PresentationOptionsNamespace);

        var result = xDocument.Root!
            .EnsureXmlNamespaceAttribute(PresentationOptionsNamespace, PoName, 3, Constants.DefaultXamlNamespace);

        result.Should().Be(expectedAttribute);
        xDocument.ToString().Should().Be(XDocument.Parse(expectedResult).ToString());
    }

    [Fact]
    public void
        EnsureXmlNamespaceAttribute_When_NamespaceDoesNotExistButPrefixDoes_Then_ResultShouldBeNewAttributeAndNamespaceShouldBeAddedWithIncrementedPrefix()
    {
        var input = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:po=""http://schemas.openxmlformats.org/markup-compatibility/2006"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionary>";
        var expectedResult = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:po1=""http://schemas.microsoft.com/winfx/2006/xaml/presentation/options""
    xmlns:po=""http://schemas.openxmlformats.org/markup-compatibility/2006"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionary>";
        var xDocument = XDocument.Parse(input);
        var expectedAttribute = new XAttribute(PresentationOptionsName + "1", PresentationOptionsNamespace);

        var result = xDocument.Root!
            .EnsureXmlNamespaceAttribute(PresentationOptionsNamespace, PoName, 3, Constants.DefaultXamlNamespace);

        result.Should().Be(expectedAttribute);
        xDocument.ToString().Should().Be(XDocument.Parse(expectedResult).ToString());
    }

    [Fact]
    public void
        EnsureXmlNamespaceAttribute_When_NamespaceDoesNotExistAndInsertAfterNamespaceOccursAfterMaxInsertIndex_Then_ResultShouldBeNewAttributeAndNamespaceShouldBeAddedAtMaxIndex()
    {
        var input = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionary>";
        var expectedResult = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:po=""http://schemas.microsoft.com/winfx/2006/xaml/presentation/options""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionary>";
        var xDocument = XDocument.Parse(input);
        var expectedAttribute = new XAttribute(PresentationOptionsName, PresentationOptionsNamespace);

        var result = xDocument.Root!
            .EnsureXmlNamespaceAttribute(
                PresentationOptionsNamespace,
                PoName,
                1,
                Constants.MarkupCompatibilityNamespace);

        result.Should().Be(expectedAttribute);
        xDocument.ToString().Should().Be(XDocument.Parse(expectedResult).ToString());
    }

    [Fact]
    public void
        EnsureXmlNamespaceAttribute_When_NamespaceDoesNotExistAndMultipleInsertAfterNamespacesAreSpecified_Then_ResultShouldBeNewAttributeAndNamespaceShouldBeAddedAfterSpecifiedNamespaces()
    {
        var input = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
    xmlns:local=""clr-namespace:Sundew.Xaml.Sample"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionary>";
        var expectedResult = $@"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
    xmlns:po=""http://schemas.microsoft.com/winfx/2006/xaml/presentation/options""
    xmlns:local=""clr-namespace:Sundew.Xaml.Sample"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionary>";
        var xDocument = XDocument.Parse(input);
        var expectedAttribute = new XAttribute(PresentationOptionsName, PresentationOptionsNamespace);

        var result = xDocument.Root!
            .EnsureXmlNamespaceAttribute(
                PresentationOptionsNamespace,
                PoName,
                Constants.DefaultXamlNamespace,
                Constants.DesignerNamespace,
                Constants.MarkupCompatibilityNamespace);

        result.Should().Be(expectedAttribute);
        xDocument.ToString().Should().Be(XDocument.Parse(expectedResult).ToString());
    }

    [Fact]
    public void EnsureXmlNamespaceAttribute_When_NamespaceDoesNotExistAndSomeInsertAfterNamespacesExists_Then_ResultShouldBeNewAttributeAndNamespaceShouldBeAddedAfterSpecifiedNamespaces()
    {
        var input = $@"<ResourceDictionaryText
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:local=""clr-namespace:Sundew.Xaml.Sample"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionaryText>";
        var expectedResult = $@"<ResourceDictionaryText
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:po=""http://schemas.microsoft.com/winfx/2006/xaml/presentation/options""
    xmlns:local=""clr-namespace:Sundew.Xaml.Sample"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionaryText>";
        var xDocument = XDocument.Parse(input);
        var expectedAttribute = new XAttribute(PresentationOptionsName, PresentationOptionsNamespace);

        var result = xDocument.Root!
            .EnsureXmlNamespaceAttribute(
                PresentationOptionsNamespace,
                PoName,
                Constants.DefaultXamlNamespace,
                Constants.DesignerNamespace,
                Constants.MarkupCompatibilityNamespace);

        result.Should().Be(expectedAttribute);
        xDocument.ToString().Should().Be(XDocument.Parse(expectedResult).ToString());
    }

    [Fact]
    public void EnsureXmlNamespaceAttribute_When_NamespaceDoesNotExistAndInsertAfterNamespaceDoesNotExist_Then_ResultShouldBeNewAttributeAtTheEnd()
    {
        var input = $@"<ResourceDictionaryText
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:local=""clr-namespace:Sundew.Xaml.Sample"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionaryText>";
        var expectedResult = $@"<ResourceDictionaryText
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:local=""clr-namespace:Sundew.Xaml.Sample""
    xmlns:po=""http://schemas.microsoft.com/winfx/2006/xaml/presentation/options"">
    <SolidColorBrush x:Key=""AccentBrush"" Color=""#AAAAAA"" />
    <SolidColorBrush x:Key=""BackgroundBrush"" Color=""#111111"" />
</ResourceDictionaryText>";
        var xDocument = XDocument.Parse(input);
        var expectedAttribute = new XAttribute(PresentationOptionsName, PresentationOptionsNamespace);

        var result = xDocument.Root!
            .EnsureXmlNamespaceAttribute(
                PresentationOptionsNamespace,
                PoName,
                "NonExistingNamespace");

        result.Should().Be(expectedAttribute);
        xDocument.ToString().Should().Be(XDocument.Parse(expectedResult).ToString());
    }
}