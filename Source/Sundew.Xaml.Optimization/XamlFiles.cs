// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlFiles.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Represents the xaml files for the project.
/// </summary>
public sealed class XamlFiles : IReadOnlyList<XamlFile>
{
    private readonly IReadOnlyList<XamlFile> xamlFiles;
    private readonly int maxParallelization;

    /// <summary>
    /// Initializes a new instance of the <see cref="XamlFiles"/> class.
    /// </summary>
    /// <param name="xamlFiles">The xaml files.</param>
    public XamlFiles(params IReadOnlyList<XamlFile> xamlFiles)
    {
        this.xamlFiles = xamlFiles;
        this.maxParallelization = 1;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XamlFiles"/> class.
    /// </summary>
    /// <param name="xamlFiles">The xaml files.</param>
    /// <param name="maxParallelization">The max parallelization.</param>
    public XamlFiles(IReadOnlyList<XamlFile> xamlFiles, int maxParallelization)
    {
        this.xamlFiles = xamlFiles;
        this.maxParallelization = maxParallelization;
    }

    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count => this.xamlFiles.Count;

    /// <summary>
    /// Gets the item at the index.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns>The item.</returns>
    public XamlFile this[int index]
    {
        get => this.xamlFiles[index];
    }

    /// <summary>
    /// Gets the enumerator.
    /// </summary>
    /// <returns>The enumerator.</returns>
    public IEnumerator<XamlFile> GetEnumerator()
    {
        return this.xamlFiles.GetEnumerator();
    }

    /// <summary>
    /// Gets the enumerator.
    /// </summary>
    /// <returns>The enumerator.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Processes the source in parallel.
    /// </summary>
    /// <param name="func">The func.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public Task ForEachAsync(Func<XamlFile, CancellationToken, Task> func)
    {
        return this.ForEachAsync(new ParallelOptions { MaxDegreeOfParallelism = Math.Min(Math.Max(1, this.maxParallelization), Environment.ProcessorCount) }, func);
    }

    /// <summary>
    /// Processes the source in parallel.
    /// </summary>
    /// <param name="parallelOptions">The parallel options.</param>
    /// <param name="func">The func.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public Task ForEachAsync(
        ParallelOptions parallelOptions,
        Func<XamlFile, CancellationToken, Task> func)
    {
        return this.xamlFiles.ParallelForEachAsync(parallelOptions, func);
    }
}