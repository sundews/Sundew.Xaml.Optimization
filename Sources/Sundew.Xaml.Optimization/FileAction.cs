// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileAction.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization
{
    /// <summary>Defines how and additional file should be treated.</summary>
    public enum FileAction
    {
        /// <summary>The additional file will be compiled.</summary>
        Compile,

        /// <summary>The additional file will be included as a page.</summary>
        Page,

        /// <summary>The additional file will be embedded as a resource.</summary>
        EmbeddedResource,
    }
}