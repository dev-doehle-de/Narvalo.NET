﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Internal
{
#if !NO_INTERNALS_VISIBLE_TO

    using System;

    using Xunit;

    public static class AsciiFacts
    {
        #region IsDigit()

        [Fact]
        public static void IsDigit_Fails_ForNullString()
            => Assert.False(Ascii.IsDigit(null));

        [Fact]
        public static void IsDigit_Fails_ForEmptyString()
            => Assert.False(Ascii.IsDigit(String.Empty));

        [Theory]
        [InlineData("1")]
        [InlineData("10")]
        [InlineData("100")]
        [InlineData("1000")]
        [InlineData("10000")]
        [CLSCompliant(false)]
        public static void IsDigit_ReturnsTrue_ForValidInput(string value)
            => Assert.True(Ascii.IsDigit(value));

        [Theory]
        [InlineData(" ")]
        [InlineData("a")]
        [InlineData("A")]
        [InlineData("é")]
        [InlineData("'")]
        [InlineData("@")]
        [InlineData("ab")]
        [InlineData("AB")]
        [InlineData("1a2b3c")]
        [InlineData("1A2B3C")]
        [InlineData(" a")]
        [InlineData("a ")]
        [InlineData(" a ")]
        [InlineData(" 1a")]
        [InlineData("1a ")]
        [InlineData(" 1a ")]
        [CLSCompliant(false)]
        public static void IsDigit_ReturnsFalse_ForInvalidInput(string value)
            => Assert.False(Ascii.IsDigit(value));

        #endregion

        #region IsDigitOrUpperLetter()

        [Fact]
        public static void IsDigitOrUpperLetter_Fails_ForNullString()
            => Assert.False(Ascii.IsDigitOrUpperLetter(null));

        [Fact]
        public static void IsDigitOrUpperLetter_Fails_ForEmptyString()
            => Assert.False(Ascii.IsDigitOrUpperLetter(String.Empty));

        [Theory]
        [InlineData("1")]
        [InlineData("10")]
        [InlineData("A")]
        [InlineData("AB")]
        [InlineData("1A2B3C")]
        [CLSCompliant(false)]
        public static void IsDigitOrUpperLetter_ReturnsTrue_ForValidInput(string value)
            => Assert.True(Ascii.IsDigitOrUpperLetter(value));

        [Theory]
        [InlineData(" ")]
        [InlineData("a")]
        [InlineData("é")]
        [InlineData("'")]
        [InlineData("@")]
        [InlineData("ab")]
        [InlineData("1a2b3c")]
        [InlineData(" a")]
        [InlineData("a ")]
        [InlineData(" a ")]
        [InlineData(" 1a")]
        [InlineData("1a ")]
        [InlineData(" 1a ")]
        [CLSCompliant(false)]
        public static void IsDigitOrUpperLetter_ReturnsFalse_ForInvalidInput(string value)
            => Assert.False(Ascii.IsDigitOrUpperLetter(value));

        #endregion

        #region IsUpperLetter()

        [Fact]
        public static void IsUpperLetter_Fails_ForNullString()
            => Assert.False(Ascii.IsUpperLetter(null));

        [Fact]
        public static void IsUpperLetter_Fails_ForEmptyString()
            => Assert.False(Ascii.IsUpperLetter(String.Empty));

        [Theory]
        [InlineData("A")]
        [InlineData("AB")]
        [CLSCompliant(false)]
        public static void IsUpperLetter_ReturnsTrue_ForValidInput(string value)
            => Assert.True(Ascii.IsUpperLetter(value));

        [Theory]
        [InlineData(" ")]
        [InlineData("a")]
        [InlineData("é")]
        [InlineData("'")]
        [InlineData("@")]
        [InlineData("ab")]
        [InlineData("1")]
        [InlineData("10")]
        [InlineData("1a2b3c")]
        [InlineData("1A2B3C")]
        [InlineData(" a")]
        [InlineData("a ")]
        [InlineData(" a ")]
        [InlineData(" A")]
        [InlineData("A ")]
        [InlineData(" A ")]
        [InlineData(" 1a")]
        [InlineData("1a ")]
        [InlineData(" 1a ")]
        [CLSCompliant(false)]
        public static void IsUpperLetter_ReturnsFalse_ForInvalidInput(string value)
            => Assert.False(Ascii.IsUpperLetter(value));

        #endregion
    }

#endif
}
