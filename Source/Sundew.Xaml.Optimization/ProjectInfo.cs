// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectInfo.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Collections.Generic;
using System.IO;
using Sundew.Xaml.Optimization.Xml;

/// <summary>Contains information about the project being built.</summary>
public sealed class ProjectInfo
{
    /// <summary>Initializes a new instance of the <see cref="ProjectInfo"/> class.</summary>
    /// <param name="assemblyName">Name of the assembly.</param>
    /// <param name="rootNamespace">The root namespace.</param>
    /// <param name="projectDirectory">The project directory.</param>
    /// <param name="solutionDirectory">The solution directory.</param>
    /// <param name="intermediateDirectory">The intermediate directory.</param>
    /// <param name="assemblyReferences">The assembly references.</param>
    /// <param name="compiles">The compiles.</param>
    /// <param name="xamlFileProvider">The xaml file provider.</param>
    /// <param name="isDebugging"><c>true</c> if debugging was set, otherwise <c>false</c>.</param>
    public ProjectInfo(
        string assemblyName,
        string? rootNamespace,
        DirectoryInfo projectDirectory,
        DirectoryInfo solutionDirectory,
        DirectoryInfo intermediateDirectory,
        IReadOnlyList<IAssemblyReference> assemblyReferences,
        IReadOnlyList<IFileReference> compiles,
        IXamlFileProvider xamlFileProvider,
        bool isDebugging)
    {
        this.AssemblyName = assemblyName;
        this.ProjectDirectory = projectDirectory;
        this.SolutionDirectory = solutionDirectory;
        this.RootNamespace = rootNamespace ?? this.AssemblyName;
        this.IntermediateDirectory = intermediateDirectory;
        this.AssemblyReferences = assemblyReferences;
        this.Compiles = compiles;
        this.XamlFileProvider = xamlFileProvider;
        this.IsDebugging = isDebugging;
    }

    /// <summary>Gets the name of the assembly.</summary>
    /// <value>The name of the assembly.</value>
    public string AssemblyName { get; }

    /// <summary>
    /// Gets the project directory.
    /// </summary>
    public DirectoryInfo ProjectDirectory { get; }

    /// <summary>
    /// Gets the solution directory.
    /// </summary>
    public DirectoryInfo SolutionDirectory { get; }

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

    /// <summary>Gets the xaml file provider.</summary>
    /// <value>The xaml file provider.</value>
    public IXamlFileProvider XamlFileProvider { get; }

    /// <summary>
    /// Gets a value indicating whether debugging was set.
    /// </summary>
    public bool IsDebugging { get; }
}