// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlFilesTests.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Development.Tests;

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AwesomeAssertions;
using NSubstitute;
using TUnit.Core;

public class XamlFilesTests
{
    [Test]
    public async Task ForEachAsync_Then_AllFilesShouldBeProcessed()
    {
        string[] input = [GetXaml("Application"), GetXaml("UserControl"), GetXaml("Page"), GetXaml("Window")];
        var testee =
            new XamlFiles(
                input.Select(x => new XamlFile(XDocument.Parse(x), Substitute.For<IFileReference>(), "\r\n")).ToArray(),
                Environment.ProcessorCount);

        var concurrentBag = new ConcurrentBag<XamlFile>();
        await testee.ForEachAsync((xamlFile, cancellationToken) =>
        {
            concurrentBag.Add(xamlFile);
            return Task.CompletedTask;
        });

        concurrentBag.Count.Should().Be(input.Length);
    }

    private static string GetXaml(string rootType)
    {
        return $@"<{rootType} x:Class=""Sundew.Xaml.Optimization""
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" 
    xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
    xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
    xmlns:sx=""http://sundew.dev/xaml""
    mc:Ignorable=""d""
    StartupUri=""MainWindow.xaml"">
    <{rootType}.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source=""/Sundew.Xaml.Optimization.Wpf;component/Controls.xaml"" d:sx.ResourceDictionary.Category=""🎨"" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </{rootType}.Resources>
</{rootType}>";
    }
}