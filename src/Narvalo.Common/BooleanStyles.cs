﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;

    [Flags]
    public enum BooleanStyles
    {
        Literal = 1 << 0,

        ZeroOrOne = 1 << 1,

        EmptyOrWhiteSpaceIsFalse = 1 << 2,

        HtmlInput = 1 << 3,

        Default = Literal | ZeroOrOne,

        Any = Literal | ZeroOrOne | EmptyOrWhiteSpaceIsFalse | HtmlInput,
    }

    public static class BooleanStylesExtensions
    {
        public static bool Contains(this BooleanStyles @this, BooleanStyles styles) => (@this & styles) != 0;
    }
}
