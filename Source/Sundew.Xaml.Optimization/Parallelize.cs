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
        var maxDegreeOfParallelism = Math.Min(Math.Max(1, parallelOptions.MaxDegreeOfParallelism), Environment.ProcessorCount);
        var cancellationToken = parallelOptions.CancellationToken;
        var taskScheduler = parallelOptions.TaskScheduler ?? TaskScheduler.Current;
        var enumerator = source.GetEnumerator();
        var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var semaphoreSlim = new SemaphoreSlim(1, 1);
        var tasks = new Task[maxDegreeOfParallelism];
        for (int i = 0; i < maxDegreeOfParallelism; i++)
        {
            tasks[i] = Task.Factory.StartNew(
                    async () =>
                    {
                        TItem? item = default;
                        try
                        {
                            while (ContinueOrThrowIfCancellationRequested(cancellationToken))
                            {
                                await semaphoreSlim.WaitAsync().ConfigureAwait(true);
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
                                    semaphoreSlim.Release();
                                }

                                await func(item, cancellationTokenSource.Token).ConfigureAwait(true);
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            cancellationTokenSource.Cancel();
                            throw;
                        }
                        catch (Exception exception)
                        {
                            cancellationTokenSource.Cancel();
                            throw new ItemException(exception, item);
                        }
                    },
                    CancellationToken.None,
                    TaskCreationOptions.DenyChildAttach,
                    taskScheduler)
                .Unwrap();
        }

        return Task.WhenAll(tasks).ContinueWith(
            task =>
            {
                using (enumerator)
                using (cancellationTokenSource)
                using (semaphoreSlim)
                {
                }

                return task;
            },
            CancellationToken.None,
            TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default).Unwrap();
    }

    private static bool ContinueOrThrowIfCancellationRequested(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return true;
    }
}