// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlPlatformInfo.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Xml
{
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Contains xaml platform information.
    /// </summary>
    public class XamlPlatformInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XamlPlatformInfo" /> class.
        /// </summary>
        /// <param name="xamlPlatform">The xaml platform.</param>
        /// <param name="presentationNamespace">The presentation namespace.</param>
        /// <param name="sundewXamlOptimizationsNamespace">The sundew xaml optimizations namespace.</param>
        public XamlPlatformInfo(
            XamlPlatform xamlPlatform,
            XNamespace presentationNamespace,
            XNamespace sundewXamlOptimizationsNamespace)
        {
            this.XamlPlatform = xamlPlatform;
            this.PresentationNamespace = presentationNamespace;
            this.SundewXamlOptimizationsNamespace = sundewXamlOptimizationsNamespace;
            this.XmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            this.XmlNamespaceManager.AddNamespace(Constants.System, presentationNamespace.NamespaceName);
        }

        /// <summary>
        /// Gets the XML namespace manager.
        /// </summary>
        /// <value>
        /// The XML namespace manager.
        /// </value>
        public XmlNamespaceManager XmlNamespaceManager { get; }

        /// <summary>Gets the xaml platform.</summary>
        /// <value>The xaml platform.</value>
        public XamlPlatform XamlPlatform { get; }

        /// <summary>Gets the presentation namespace.</summary>
        /// <value>The presentation namespace.</value>
        public XNamespace PresentationNamespace { get; }

        /// <summary>
        /// Gets the sundew xaml optimizations namespace.
        /// </summary>
        /// <value>
        /// The sundew xaml optimizations namespace.
        /// </value>
        public XNamespace SundewXamlOptimizationsNamespace { get; }
    }
}