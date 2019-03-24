// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XNamespaceInserter.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization.Xml
{
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Inserts an <see cref="XNamespace"/> into an <see cref="XElement"/>.
    /// </summary>
    public static class XNamespaceInserter
    {
        /// <summary>Tries the add XML namespace.</summary>
        /// <param name="xElement">The x element.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="xNamespace">The x namespace.</param>
        /// <param name="insertAfterName">Name of the insert after.</param>
        /// <param name="maxInsertPosition">The maximum insert position to use if the insert after name does not exist.</param>
        public static void TryAddXmlNamespace(this XElement xElement, XName attributeName, XNamespace xNamespace, XName insertAfterName, int maxInsertPosition)
        {
            var namespaceNumber = 1;
            XAttribute xAttribute;
            while ((xAttribute = xElement.Attribute(attributeName)) != null)
            {
                if (xAttribute.Value == xNamespace)
                {
                    return;
                }

                attributeName += namespaceNumber.ToString();
                namespaceNumber++;
            }

            var attributes = xElement.Attributes().ToList();
            foreach (var attribute in attributes)
            {
                attribute.Remove();
            }

            var xAttributeIndex = attributes.FindIndex(x => x.Name == insertAfterName);
            if (xAttributeIndex < 0)
            {
                xAttributeIndex = attributes.Count >= maxInsertPosition
                    ? maxInsertPosition
                    : attributes.Count;
            }
            else
            {
                xAttributeIndex++;
            }

            attributes.Insert(
                xAttributeIndex,
                new XAttribute(attributeName, xNamespace));
            xElement.Add(attributes);
        }
    }
}