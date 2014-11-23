﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;
    using System.Diagnostics;
#if CONTRACTS_FULL
    using System.Diagnostics.Contracts;
#endif

    [DebuggerStepThrough]
    public static class DebugAssert
    {
#if CONTRACTS_FULL
        [ContractAbbreviator]
        public static void IsEnum(Type type)
        {
            Check.NotNull(type);
            Contract.Requires(type.IsEnum);
        }

        [ContractAbbreviator]
        public static void IsValueType(Type type)
        {
            Check.NotNull(type);
            Contract.Requires(type.IsValueType);
        }
#else
        [Conditional("DEBUG")]
        public static void IsEnum(Type type)
        {
            Check.NotNull(type);
            Debug.Assert(type.IsEnum, type.FullName, SR.DebugAssert_IsNotEnum);
        }

        [Conditional("DEBUG")]
        public static void IsValueType(Type type)
        {
            Check.NotNull(type);
            Debug.Assert(type.IsValueType, type.FullName, SR.DebugAssert_IsNotValueType);
        }
#endif
    }
}
