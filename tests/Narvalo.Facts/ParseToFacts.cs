﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;

    using Xunit;

    public static partial class ParseToFacts
    {
        private enum EnumStub_
        {
            None = 0,
            ActualValue = 1,
            AliasValue = ActualValue,
        }

        private struct StructStub_ { }
    }

    public static partial class ParseToFacts
    {
        #region Boolean()

        [Fact]
        public static void Boolean_ReturnsNull_ForNullString()
        {
            // Act
            bool? result = ParseTo.Boolean(null, BooleanStyles.Default);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void Boolean_ReturnsNull_ForEmptyString()
        {
            // Act
            bool? result = ParseTo.Boolean(String.Empty, BooleanStyles.ZeroOrOne);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void Boolean_ReturnsTrue_ForEmptyStringAndEmptyIsFalse()
        {
            // Act
            bool? result = ParseTo.Boolean(String.Empty, BooleanStyles.EmptyIsFalse);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(false, result);
        }

        [Fact]
        public static void Boolean_ReturnsTrue_ForLiteralTrueAndLiteralStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("true", BooleanStyles.Literal);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(true, result);
        }

        [Fact]
        public static void Boolean_ReturnsTrue_ForLiteralMixedCaseTrueAndLiteralStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("TrUe", BooleanStyles.Literal);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(true, result);
        }

        [Fact]
        public static void Boolean_ReturnsTrue_ForLiteralFalseAndLiteralStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("false", BooleanStyles.Literal);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(false, result);
        }

        [Fact]
        public static void Boolean_ReturnsTrue_ForLiteralMixedCaseFalseAndLiteralStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("fAlSe", BooleanStyles.Literal);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(false, result);
        }

        [Fact]
        public static void Boolean_ReturnsTrue_ForLiteralTrueAndWhiteSpacesAndLiteralStyle()
        {
            // Act
            bool? result = ParseTo.Boolean(" true ", BooleanStyles.Literal);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(true, result);
        }

        [Fact]
        public static void Boolean_ReturnsNull_ForStrictlyPositiveInt32AndIntegerStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("10", BooleanStyles.ZeroOrOne);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void Boolean_ReturnsTrueAndPicksTrue_ForOneAndIntegerStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("1", BooleanStyles.ZeroOrOne);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(true, result);
        }

        [Fact]
        public static void Boolean_ReturnsTrueAndPicksFalse_ForZeroAndIntegerStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("0", BooleanStyles.ZeroOrOne);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(false, result);
        }

        [Fact]
        public static void Boolean_ReturnsNull_ForMinusOneAndIntegerStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("-1", BooleanStyles.ZeroOrOne);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void Boolean_ReturnsNull_ForNegativeInt32AndIntegerStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("-10", BooleanStyles.ZeroOrOne);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void Boolean_ReturnsNull_ForDecimalAndIntegerStyle()
        {
            // Act
            bool? result = ParseTo.Boolean("-10.1", BooleanStyles.ZeroOrOne);

            // Assert
            Assert.False(result.HasValue);
        }

        #endregion

        #region Enum()

        [Fact]
        public static void ParseTo_ThrowsArgumentException_ForInt32()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => ParseTo.Enum<int>("Whatever"));
        }

        [Fact]
        public static void ParseTo_ThrowsArgumentException_ForNonEnumerationStruct()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => ParseTo.Enum<StructStub_>("Whatever"));
        }

        [Fact]
        public static void ParseTo_ReturnsNull_ForActualValueAndBadCase()
        {
            // Act
            var result = ParseTo.Enum<EnumStub_>("actualvalue", ignoreCase: false);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void ParseTo_ReturnsNull_ForInvalidValue()
        {
            // Act
            var result = ParseTo.Enum<EnumStub_>("InvalidValue");

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void ParseTo_ReturnsNull_ForInvalidValueAndIgnoreCase()
        {
            // Act
            var result = ParseTo.Enum<EnumStub_>("invalidvalue", ignoreCase: true);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void ParseTo_ReturnsNull_ForInvalidValueAndBadCase()
        {
            // Act
            var result = ParseTo.Enum<EnumStub_>("invalidvalue", ignoreCase: false);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public static void ParseTo_ReturnsExpectedValue_ForActualValue()
        {
            // Act
            EnumStub_? result = ParseTo.Enum<EnumStub_>("ActualValue");

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(EnumStub_.ActualValue, result.Value);
        }

        [Fact]
        public static void ParseTo_ReturnsExpectedValue_ForActualValueAndIgnoreCase()
        {
            // Act
            EnumStub_? result = ParseTo.Enum<EnumStub_>("actualvalue", ignoreCase: true);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal(EnumStub_.ActualValue, result.Value);
        }

        #endregion
    }
}
