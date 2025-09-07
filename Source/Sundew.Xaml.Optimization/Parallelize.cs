// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parallelize.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Provides parallel processing extensions.
/// </summary>
public static class Parallelize
{
    /// <summary>
    /// Processes the source in parallel.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="func">The func.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public static Task ParallelForEachAsync<TItem>(
        this IEnumerable<TItem> source,
        Func<TItem, CancellationToken, Task> func)
    {
        return ParallelForEachAsync(source, new ParallelOptions(), func);
    }

    /// <summary>
    /// Processes the source in parallel.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="parallelOptions">The parallel options.</param>
    /// <param name="func">The func.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public static Task ParallelForEachAsync<TItem>(
        this IEnumerable<TItem> source,
        ParallelOptions parallelOptions,
        Func<TItem, CancellationToken, Task> func)
    {
        var maxDegreeOfParallelism = parallelOptions.MaxDegreeOfParallelism;
        if (maxDegreeOfParallelism < 0)
        {
            maxDegreeOfParallelism = Environment.ProcessorCount;
        }

        var cancellationToken = parallelOptions.CancellationToken;
        var scheduler = parallelOptions.TaskScheduler ?? TaskScheduler.Current;
        var enumerator = source.GetEnumerator();
        var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var semaphore = new SemaphoreSlim(1, 1);
        var workerTasks = new Task[maxDegreeOfParallelism];
        for (int i = 0; i < maxDegreeOfParallelism; i++)
        {
            workerTasks[i] = Task.Factory.StartNew(
                    async () =>
                    {
                        try
                        {
                            while (true)
                            {
                                if (cts.IsCancellationRequested)
                                {
                                    cancellationToken.ThrowIfCancellationRequested();
                                    break;
                                }

                                TItem item;
                                await semaphore.WaitAsync().ConfigureAwait(true);
                                try
                                {
                                    if (!enumerator.MoveNext())
                                    {
                                        break;
                                    }

                                    item = enumerator.Current;
                                }
                                finally
                                {
                                    semaphore.Release();
                                }

                                await func(item, cts.Token).ConfigureAwait(true);
                            }
                        }
                        catch
                        {
                            cts.Cancel();
                            throw;
                        }
                    },
                    CancellationToken.None,
                    TaskCreationOptions.DenyChildAttach,
                    scheduler)
                .Unwrap();
        }

        return Task.WhenAll(workerTasks).ContinueWith(
            t =>
        {
            using (enumerator)
            using (cts)
            using (semaphore)
            {
            }

            return t;
        },
            CancellationToken.None,
            TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default).Unwrap();
    }
}