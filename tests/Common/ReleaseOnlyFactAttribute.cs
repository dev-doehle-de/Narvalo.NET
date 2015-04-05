﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.TestCommon
{
    using System;

    using Xunit;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ReleaseOnlyFactAttribute : FactAttribute
    {
        public ReleaseOnlyFactAttribute()
            : base()
        {
#if DEBUG // Release only test.
            Skip = "Release only test.";
#endif
        }
    }
}