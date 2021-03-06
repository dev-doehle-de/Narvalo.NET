﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web
{
    using System;

    [Flags]
    public enum HttpVersions
    {
        HttpV10 = 1 << 0,

        HttpV11 = 1 << 1,

        Any = HttpV10 | HttpV11
    }

    public static class HttpVersionsExtensions
    {
        public static bool Contains(this HttpVersions @this, HttpVersions versions) => (@this & versions) != 0;
    }
}
