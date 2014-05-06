﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Web
{
    using System;
    using System.Web.UI;

    internal static class TypeExtensions
    {
        public static bool IsAspNetDynamicType(this Type @this)
        {
            DebugCheck.NotNull(@this);

            // Use the base type for pages & user controls as that is the code-behind file.
            // TODO: Ensure using BaseType still works in WebSite projects with code-beside files
            // instead of code-behind files.
            return @this.Namespace == "ASP"
                && (typeof(Page).IsAssignableFrom(@this) || typeof(Control).IsAssignableFrom(@this));
        }
    }
}
