﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    using static System.Diagnostics.Contracts.Contract;

    public static class WarrantX
    {
        [DebuggerHidden]
        [ContractAbbreviator]
        [Conditional("CONTRACTS_FULL")]
        [ExcludeFromCodeCoverage(
            Justification = "OpenCover can't discover the tests because of the CONTRACTS_FULL conditional.")]
        public static void Length(int length)
        {
            Ensures(Result<string>() != null);
            Ensures(Result<string>().Length == length);
        }

        [DebuggerHidden]
        [ContractAbbreviator]
        [Conditional("CONTRACTS_FULL")]
        [ExcludeFromCodeCoverage(
            Justification = "OpenCover can't discover the tests because of the CONTRACTS_FULL conditional.")]
        public static void Lengths(int length1, int length2)
        {
            Ensures(Result<string>() != null);
            Ensures(Result<string>().Length == length1 || Result<string>().Length == length2);
        }

        [DebuggerHidden]
        [ContractAbbreviator]
        [Conditional("CONTRACTS_FULL")]
        [ExcludeFromCodeCoverage(
            Justification = "OpenCover can't discover the tests because of the CONTRACTS_FULL conditional.")]
        public static void LengthRange(int minLength, int maxLength)
        {
            Ensures(Result<string>() != null);
            Ensures(Result<string>().Length >= minLength || Result<string>().Length <= maxLength);
        }
    }
}