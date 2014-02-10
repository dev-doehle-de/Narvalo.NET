﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;

    [Flags]
    [Serializable]
    public enum BooleanStyles
    {
        Literal = 1 << 0,
        OneOrZero = 1 << 1,
        EmptyIsFalse = 1 << 2,
        HtmlInput = 1 << 3,

        Default = Literal | OneOrZero,
        Any = Literal | OneOrZero | EmptyIsFalse | HtmlInput,
    }
}