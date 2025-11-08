// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemException.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System;

/// <summary>
/// Outer exception when an exception is through during <see cref="Parallelize"/>.
/// </summary>
public class ItemException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ItemException" /> class.
    /// </summary>
    /// <param name="item">The item.</param>
    public ItemException(object? item)
     : base(GetMessage(item))
    {
        this.Item = item;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemException" /> class.
    /// </summary>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="item">The item.</param>
    public ItemException(Exception? innerException, object? item)
     : base(GetMessage(item), innerException)
    {
        this.Item = item;
    }

    /// <summary>
    /// Gets the item being processed when the exception occured.
    /// </summary>
    public object? Item { get; }

    private static string GetMessage(object? item)
    {
        return $"Exception while processing {item ?? "<null>"}";
    }
}