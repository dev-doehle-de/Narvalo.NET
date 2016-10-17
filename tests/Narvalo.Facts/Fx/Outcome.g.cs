﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 12.0
// </auto-generated>
//------------------------------------------------------------------------------


namespace Narvalo.Fx
{
    using System;

    using Xunit;

    public static partial class OutcomeFacts
    {
        #region Linq Operators

        [Fact]
        public static void Select_ThrowsArgumentNullException_ForNullSelector()
        {
            // Arrange
            var source = Outcome.Success(1);
            Func<int, int> selector = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => source.Select(selector));
        }


        [Fact]
        public static void SelectMany_ThrowsArgumentNullException_ForNullValueSelector()
        {
            // Arrange
            var source = Outcome.Success(1);
            Func<int, Outcome<int>> valueSelector = null;
            Func<int, int, int> resultSelector = (i, j) => i + j;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => source.SelectMany(valueSelector, resultSelector));
        }

        [Fact]
        public static void SelectMany_ThrowsArgumentNullException_ForNullResultSelector()
        {
            // Arrange
            var source = Outcome.Success(1);
            var middle = Outcome.Success(2);
            Func<int, Outcome<int>> valueSelector = _ => middle;
            Func<int, int, int> resultSelector = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => source.SelectMany(valueSelector, resultSelector));
        }

        #endregion

        #region Monad Laws


        [Fact]
        public static void Outcome_SatisfiesFirstMonadLaw()
        {
            // Arrange
            int value = 1;
            Func<int, Outcome<long>> kun = _ => Outcome.Success((long)2 * _);

            // Act
            var left = Outcome.Success(value).Bind(kun);
            var right = kun(value);

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact]
        public static void Outcome_SatisfiesSecondMonadLaw()
        {
            // Arrange
            Func<int, Outcome<int>> create = _ => Outcome.Success(_);
            var monad = Outcome.Success(1);

            // Act
            var left = monad.Bind(create);
            var right = monad;

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact]
        public static void Outcome_SatisfiesThirdMonadLaw()
        {
            // Arrange
            Outcome<short> m = Outcome.Success((short)1);
            Func<short, Outcome<int>> f = _ => Outcome.Success((int)3 * _);
            Func<int, Outcome<long>> g = _ => Outcome.Success((long)2 * _);

            // Act
            var left = m.Bind(f).Bind(g);
            var right = m.Bind(_ => f(_).Bind(g));

            // Assert
            Assert.True(left.Equals(right));
        }


        #endregion
    } // End of Outcome.
} // End of Narvalo.Fx.

