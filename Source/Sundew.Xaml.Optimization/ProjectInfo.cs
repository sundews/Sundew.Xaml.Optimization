// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectInfo.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization
{
    using System.Collections.Generic;
    using System.IO;
    using Sundew.Xaml.Optimization.Xml;

    /// <summary>Contains information about the project being built.</summary>
    public sealed class ProjectInfo
    {
        /// <summary>Initializes a new instance of the <see cref="ProjectInfo"/> class.</summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="rootNamespace">The root namespace.</param>
        /// <param name="intermediateDirectory">The intermediate directory.</param>
        /// <param name="assemblyReferences">The assembly references.</param>
        /// <param name="compiles">The compiles.</param>
        /// <param name="xDocumentProvider">The XDocument provider.</param>
        public ProjectInfo(
            string assemblyName,
            string rootNamespace,
            DirectoryInfo intermediateDirectory,
            IReadOnlyList<IAssemblyReference> assemblyReferences,
            IReadOnlyList<IFileReference> compiles,
            IXDocumentProvider xDocumentProvider)
        {
            this.AssemblyName = assemblyName;
            this.RootNamespace = rootNamespace ?? this.AssemblyName;
            this.IntermediateDirectory = intermediateDirectory;
            this.AssemblyReferences = assemblyReferences;
            this.Compiles = compiles;
            this.XDocumentProvider = xDocumentProvider;
        }

        /// <summary>Gets the name of the assembly.</summary>
        /// <value>The name of the assembly.</value>
        public string AssemblyName { get; }

        /// <summary>Gets the root namespace.</summary>
        /// <value>The root namespace.</value>
        public string RootNamespace { get; }

        /// <summary>Gets the intermediate directory.</summary>
        /// <value>The intermediate directory.</value>
        public DirectoryInfo IntermediateDirectory { get; }

        /// <summary>Gets the assembly references.</summary>
        /// <value>The assembly references.</value>
        public IReadOnlyList<IAssemblyReference> AssemblyReferences { get; }

        /// <summary>Gets the compiles.</summary>
        /// <value>The compiles.</value>
        public IReadOnlyList<IFileReference> Compiles { get; }

        /// <summary>Gets the x document provider.</summary>
        /// <value>The x document provider.</value>
        public IXDocumentProvider XDocumentProvider { get; }
    }
}