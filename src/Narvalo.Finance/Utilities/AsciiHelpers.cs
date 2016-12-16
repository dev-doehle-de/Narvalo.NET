﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance.Utilities
{
    using System;
    using System.Diagnostics.Contracts;

    public static partial class AsciiHelpers
    {
        [Pure]
        public static bool IsDigitOrUpperLetter(string value)
        {
            if (value == null || value.Length == 0) { return false; }

            for (int i = 0; i < value.Length; i++)
            {
                if (!IsDigitOrUpperLetter(value[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsDigit(Char ch) => ch >= '0' && ch <= '9';

        private static bool IsDigitOrUpperLetter(Char ch) => IsDigit(ch) || IsUpperLetter(ch);
    }
}
