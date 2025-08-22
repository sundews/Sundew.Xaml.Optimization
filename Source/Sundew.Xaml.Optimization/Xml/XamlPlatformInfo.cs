// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlPlatformInfo.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Xml;

using System.Xml;
using System.Xml.Linq;

/// <summary>
/// Contains xaml platform information.
/// </summary>
public class XamlPlatformInfo
{
    /// <summary>Initializes a new instance of the <see cref="XamlPlatformInfo"/> class.</summary>
    /// <param name="xamlPlatform">The xaml platform.</param>
    /// <param name="presentationNamespace">The presentation namespace.</param>
    /// <param name="xamlNamespace">The xaml namespace.</param>
    public XamlPlatformInfo(
        XamlPlatform xamlPlatform,
        XNamespace presentationNamespace,
        XNamespace xamlNamespace)
    {
        this.XamlPlatform = xamlPlatform;
        this.PresentationNamespace = presentationNamespace;
        this.XamlNamespace = xamlNamespace;
        var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
        xmlNamespaceManager.AddNamespace(string.Empty, presentationNamespace.NamespaceName);
        xmlNamespaceManager.AddNamespace(Constants.DefaultPrefix, presentationNamespace.NamespaceName);
        xmlNamespaceManager.AddNamespace(Constants.XamlPrefix, xamlNamespace.NamespaceName);
        xmlNamespaceManager.AddNamespace(Constants.MarkupCompatibilityPrefix, Constants.MarkupCompatibilityNamespace.NamespaceName);
        xmlNamespaceManager.AddNamespace(Constants.DesignerPrefix, Constants.DesignerNamespace.NamespaceName);
        this.XmlNamespaceResolver = xmlNamespaceManager;
        this.SystemResourceDictionaryName = this.PresentationNamespace + Constants.ResourceDictionaryText;
        this.DefaultFileAction = xamlPlatform switch
        {
            XamlPlatform.WPF => FileAction.Page,
            XamlPlatform.Maui => FileAction.MauiXaml,
            XamlPlatform.WinUI => FileAction.Page,
            XamlPlatform.Avalonia => FileAction.AvaloniaXaml,
            XamlPlatform.UWP => FileAction.Page,
            XamlPlatform.XF => FileAction.Page,
            _ => FileAction.Page,
        };
    }

    /// <summary>
    /// Gets the XML namespace manager.
    /// </summary>
    /// <value>
    /// The XML namespace manager.
    /// </value>
    public IXmlNamespaceResolver XmlNamespaceResolver { get; }

    /// <summary>Gets the xaml platform.</summary>
    /// <value>The xaml platform.</value>
    public XamlPlatform XamlPlatform { get; }

    /// <summary>Gets the presentation namespace.</summary>
    /// <value>The presentation namespace.</value>
    public XNamespace PresentationNamespace { get; }

    /// <summary>Gets the system resource dictionary.</summary>
    /// <value>The system resource dictionary.</value>
    public XName SystemResourceDictionaryName { get; }

    /// <summary>Gets the xaml namespace.</summary>
    /// <value>The xaml namespace.</value>
    public XNamespace XamlNamespace { get; }

    /// <summary>Gets the designer namespace.</summary>
    /// <value>The designer namespace.</value>
    public XNamespace DesignerNamespace => Constants.DesignerNamespace;

    /// <summary>Gets the markup compatibility namespace.</summary>
    /// <value>The markup compatibility namespace.</value>
    public XNamespace MarkupCompatibilityNamespace => Constants.MarkupCompatibilityNamespace;

    /// <summary>Gets the name of the ignorable.</summary>
    /// <value>The name of the ignorable.</value>
    public XName IgnorableName => Constants.IgnorableName;

    /// <summary>Gets the xaml prefix.</summary>
    /// <value>The xaml prefix.</value>
    public string XPrefix => Constants.XamlPrefix;

    /// <summary>Gets the markup compatibility.</summary>
    /// <value>The markup compatibility.</value>
    public string MarkupCompatibilityPrefix => Constants.MarkupCompatibilityPrefix;

    /// <summary>Gets the designer.</summary>
    /// <value>The designer.</value>
    public string DesignerPrefix => Constants.DesignerPrefix;

    /// <summary>
    /// Gets the default file action.
    /// </summary>
    public FileAction DefaultFileAction { get; }

    /// <summary>Gets the default insert after namespaces.</summary>
    /// <value>The default insert after namespaces.</value>
    public XNamespace[] DefaultInsertAfterNamespaces { get; } = [Constants.DefaultXamlNamespace, Constants.DesignerNamespace, Constants.MarkupCompatibilityNamespace, Constants.SundewXamlNamespace];
}
