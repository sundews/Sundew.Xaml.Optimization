// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XNamespaceInserter.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Xml;

using System;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Inserts an <see cref="XNamespace"/> into an <see cref="XElement"/>.
/// </summary>
public static class XNamespaceInserter
{
    /// <summary>Ensures that the specified namespace exists.</summary>
    /// <param name="xElement">The x element.</param>
    /// <param name="xNamespace">The x namespace.</param>
    /// <param name="prefix">The prefix in case the namespace does not exist.</param>
    /// <param name="maxInsertIndex">The maximum insert index to use if the insert after name does not exist.</param>
    /// <param name="insertAfterNamespaces">The namespaces to insert the namespace after.</param>
    /// <returns>
    ///   <c>true</c>, if the namespace was added, otherwise <c>false</c>.
    /// </returns>
    public static XAttribute EnsureXmlNamespaceAttribute(this XElement xElement, XNamespace xNamespace, string prefix, int maxInsertIndex, params XNamespace[] insertAfterNamespaces)
    {
        return PrivateEnsureXmlNamespaceAttribute(xElement, xNamespace, prefix, insertAfterNamespaces, maxInsertIndex);
    }

    /// <summary>Ensures the XML namespace attribute.</summary>
    /// <param name="xElement">The x element.</param>
    /// <param name="xNamespace">The x namespace.</param>
    /// <param name="prefix">The prefix.</param>
    /// <param name="insertAfterNamespaces">The namespaces to insert the namespace after.</param>
    /// <returns>
    ///   <c>true</c>, if the namespace was added, otherwise <c>false</c>.
    /// </returns>
    public static XAttribute EnsureXmlNamespaceAttribute(this XElement xElement, XNamespace xNamespace, string prefix, params XNamespace[] insertAfterNamespaces)
    {
        return PrivateEnsureXmlNamespaceAttribute(xElement, xNamespace, prefix, insertAfterNamespaces, null);
    }

    private static XAttribute PrivateEnsureXmlNamespaceAttribute(this XElement xElement, XNamespace xNamespace, string prefix, XNamespace[] insertAfterNamespaces, int? maxInsertIndex)
    {
        var xAttribute = FindNamespaceAttribute(xElement, xNamespace);
        if (xAttribute != null)
        {
            return xAttribute;
        }

        var namespaceNumber = 1;
        var attributeName = XNamespace.Xmlns + prefix;
        var bareAttributeName = attributeName;
        while (xElement.Attribute(attributeName) != null)
        {
            attributeName = bareAttributeName + namespaceNumber.ToString();
            namespaceNumber++;
        }

        var attributes = xElement.Attributes().ToList();
        var xAttributeIndex = insertAfterNamespaces.Select(insertAfterNamespace => attributes.FindIndex(x => x.Value == insertAfterNamespace)).Max();
        if (xAttributeIndex < 0)
        {
            xAttributeIndex = attributes.Count;
        }
        else
        {
            xAttributeIndex++;
        }

        if (maxInsertIndex.HasValue)
        {
            xAttributeIndex = Math.Min(xAttributeIndex, maxInsertIndex.Value);
        }

        var newXAttribute = new XAttribute(attributeName, xNamespace);
        var insertIndex = Math.Min(xAttributeIndex, attributes.Count);
        attributes.Insert(insertIndex, newXAttribute);
        xElement.ReplaceAttributes(attributes);

        return newXAttribute;
    }

    private static XAttribute? FindNamespaceAttribute(XElement xElement, XNamespace xNamespace)
    {
        foreach (var xAttribute in xElement.Attributes())
        {
            if (xAttribute.Value == xNamespace)
            {
                return xAttribute;
            }
        }

        return null;
    }
}